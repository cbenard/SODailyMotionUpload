using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SO_Dailymotion_Upload
{
    public class UploadResponse
    {
        public string format { get; set; }
        public string acodec { get; set; }
        public string vcodec { get; set; }
        public int duration { get; set; }
        public int bitrate { get; set; }
        public string dimension { get; set; }
        public string name { get; set; }
        public int size { get; set; }
        public string url { get; set; }
        public string hash { get; set; }
        public string seal { get; set; }

        public override string ToString()
        {
            var flags = System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.FlattenHierarchy;
            System.Reflection.PropertyInfo[] infos = this.GetType().GetProperties(flags);

            StringBuilder sb = new StringBuilder();

            string typeName = this.GetType().Name;
            sb.AppendLine(typeName);
            sb.AppendLine(string.Empty.PadRight(typeName.Length + 5, '='));

            foreach (var info in infos)
            {
                object value = info.GetValue(this, null);
                sb.AppendFormat("{0}: {1}{2}", info.Name, value != null ? value : "null", Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}
