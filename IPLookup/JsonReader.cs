using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace IPLookup
{
    public struct HostList
    {
        public string host;
        public string ip;
    }

    internal static class JsonReader
    {
        public static List<HostList> ReadList(string filename)
        {
            using (var sr = new StreamReader(filename,Encoding.UTF8))
            {
                try
                {
                    var result = sr.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<HostList>>(result);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString(),@"出错啦",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            return null;
        }

        public static void WriteList(string filename, List<HostList> list)
        {
            var json = JsonConvert.SerializeObject(list);
            using (var fs = new FileStream(filename, FileMode.Create, FileAccess.Write))
            {
                var sw = new StreamWriter(fs);
                sw.Write(json);
                sw.Flush();
                sw.Close();
            }
        }
    }
}
