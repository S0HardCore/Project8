using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.IO;

namespace WpfApplication2
{
    public class JsonFileService
    {
        public void Save(string fileName, List<dynamic> source)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<dynamic>));
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                jsonFormatter.WriteObject(fs, source);
            }
        }
    }
}
