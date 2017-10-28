using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IPLookup
{
    public class IPIPdotNET
    {
        public bool EnableFileWatch = false;

        private int offset;
        private readonly uint[] index = new uint[256];
        private byte[] dataBuffer;
        private byte[] indexBuffer;
        private long lastModifyTime;
        private string ipFile;
        private readonly object @lock = new object();
        private string _filename;

        public void Load(string filename)
        {
            _filename = filename;
            ipFile = new FileInfo(filename).FullName;
            Load();
            if (EnableFileWatch)
            {
                Watch();
            }
        }

        public string[] GetLocation(string ip)
        {
            lock (@lock)
            {
                try
                {
                    var ips = ip.Split('.');
                    var ip_prefix_value = int.Parse(ips[0]);
                    long ip2long_value = BytesToLong(byte.Parse(ips[0]), byte.Parse(ips[1]), byte.Parse(ips[2]),
                        byte.Parse(ips[3]));
                    var start = index[ip_prefix_value];
                    var max_comp_len = offset - 1028;
                    long index_offset = -1;
                    var index_length = -1;
                    byte b = 0;
                    for (start = start * 8 + 1024; start < max_comp_len; start += 8)
                    {
                        if (BytesToLong(indexBuffer[start + 0], indexBuffer[start + 1], indexBuffer[start + 2],
                                indexBuffer[start + 3])
                            < ip2long_value)
                            continue;
                        index_offset = BytesToLong(b, indexBuffer[start + 6], indexBuffer[start + 5],
                            indexBuffer[start + 4]);
                        index_length = 0xFF & indexBuffer[start + 7];
                        break;
                    }
                    var areaBytes = new byte[index_length];
                    Array.Copy(dataBuffer, offset + (int) index_offset - 1024, areaBytes, 0, index_length);

                    return RemoveEmptyString(Encoding.UTF8.GetString(areaBytes).Split('\t'));  
                }
                catch
                {
                    return new[]{@"IP 查询错误！"};
                }
            }
        }

        private void Watch()
        {
            var file = new FileInfo(ipFile);
            if (file.DirectoryName == null) return;
            var watcher = new FileSystemWatcher(file.DirectoryName, file.Name) { NotifyFilter = NotifyFilters.LastWrite };
            watcher.Changed += (s, e) =>
            {
                var time = File.GetLastWriteTime(ipFile).Ticks;
                if (time > lastModifyTime)
                {
                    Load();
                }
            };
            watcher.EnableRaisingEvents = true;
        }

        private void Load()
        {
            lock (@lock)
            {
                var file = new FileInfo(ipFile);
                lastModifyTime = file.LastWriteTime.Ticks;
                try
                {
                    dataBuffer = new byte[file.Length];
                    using (var fin = new FileStream(file.FullName, FileMode.Open, FileAccess.Read))
                    {
                        fin.Read(dataBuffer, 0, dataBuffer.Length);
                    }

                    var indexLength = BytesToLong(dataBuffer[0], dataBuffer[1], dataBuffer[2], dataBuffer[3]);
                    indexBuffer = new byte[indexLength];
                    Array.Copy(dataBuffer, 4, indexBuffer, 0, indexLength);
                    offset = (int)indexLength;

                    for (var loop = 0; loop < 256; loop++)
                    {
                        index[loop] = BytesToLong(indexBuffer[loop * 4 + 3], indexBuffer[loop * 4 + 2],
                            indexBuffer[loop * 4 + 1],
                            indexBuffer[loop * 4]);
                    }
                }
                catch (Exception)
                {
                    LoadError();
                }
            }
        }

        private static uint BytesToLong(byte a, byte b, byte c, byte d)
        {
            return ((uint)a << 24) | ((uint)b << 16) | ((uint)c << 8) | d;
        }

        private void LoadError()
        {
            MessageBox.Show(@"载入 "+ _filename+ @" 出错", @"出错啦", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            Environment.Exit(0);
        }

        private static string[] RemoveEmptyString(string[] raw)
        {
            return raw.Where(s => !string.IsNullOrEmpty(s)).ToArray();
        }
    }

    public class CZIP
    {
        FileStream ipFile;
        long ip;
        private string ipfilePath;

        public struct location
        {
            public string country, area;
        }

        public void Load(string PATH)
        {
            ipfilePath = PATH;
        }

        public location GetLocation(string strIP)
        {
            ip = IPToLong(strIP);
            ipFile = new FileStream(ipfilePath, FileMode.Open, FileAccess.Read);
            long[] ipArray = BlockToArray(ReadIPBlock());
            long offset = SearchIP(ipArray, 0, ipArray.Length - 1) * 7 + 4;
            ipFile.Position += offset;//跳过起始IP
            ipFile.Position = ReadLongX(3) + 4;//跳过结束IP

            location loc = new location();
            int flag = ipFile.ReadByte();//读取标志
            if (flag == 1)//表示国家和地区被转向
            {
                ipFile.Position = ReadLongX(3);
                flag = ipFile.ReadByte();//再读标志
            }
            long countryOffset = ipFile.Position;
            loc.country = ReadString(flag);

            if (flag == 2)
            {
                ipFile.Position = countryOffset + 3;
            }
            flag = ipFile.ReadByte();
            loc.area = ReadString(flag);

            ipFile.Close();
            ipFile = null;
            return loc;
        }

        private static long IPToLong(string strIP)
        {
            byte[] ip_bytes = new byte[8];
            string[] strArr = strIP.Split('.');
            for (int i = 0; i < 4; ++i)
            {
                ip_bytes[i] = byte.Parse(strArr[3 - i]);
            }
            return BitConverter.ToInt64(ip_bytes, 0);
        }

        long[] BlockToArray(byte[] ipBlock)
        {
            long[] ipArray = new long[ipBlock.Length / 7];
            int ipIndex = 0;
            byte[] temp = new byte[8];
            for (int i = 0; i < ipBlock.Length; i += 7)
            {
                Array.Copy(ipBlock, i, temp, 0, 4);
                ipArray[ipIndex] = BitConverter.ToInt64(temp, 0);
                ipIndex++;
            }
            return ipArray;
        }

        int SearchIP(long[] ipArray, int start, int end)
        {
            while (start <= end)
            {
                int middle = start + ((end - start) >> 1);
                if (ipArray[middle] > ip)
                {
                    end = middle - 1;
                }
                else if (ipArray[middle] < ip)
                {
                    start = middle + 1;
                }
                else
                {
                    return middle;
                }
            }
            return end;
        }

        byte[] ReadIPBlock()
        {
            long startPosition = ReadLongX(4);
            long endPosition = ReadLongX(4);
            long count = (endPosition - startPosition) / 7 + 1;//总记录数
            ipFile.Position = startPosition;
            byte[] ipBlock = new byte[count * 7];
            ipFile.Read(ipBlock, 0, ipBlock.Length);
            ipFile.Position = startPosition;
            return ipBlock;
        }

        long ReadLongX(int bytesCount)
        {
            byte[] _bytes = new byte[8];
            ipFile.Read(_bytes, 0, bytesCount);
            return BitConverter.ToInt64(_bytes, 0);
        }

        string ReadString(int flag)
        {
            if (flag == 1 || flag == 2)//转向标志
                ipFile.Position = ReadLongX(3);
            else
                ipFile.Position -= 1;

            List<byte> list = new List<byte>();
            byte b = (byte)ipFile.ReadByte();
            while (b > 0)
            {
                list.Add(b);
                b = (byte)ipFile.ReadByte();
            }
            return Encoding.GetEncoding(936).GetString(list.ToArray());
        }
    }
}