using System;
using System.IO;
using System.Collections.Generic;
using Be.Cadmus.Dotnetconnector.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Be.Cadmus.Dotnetconnector.Model {

    public class ConvertResponse {

        public Metadata metadata { get; set; }
        public string base64 { get; set; }
        public List<Issue> issues { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Constants.ConfigDataResult result { get; set; }
        
        //return file with filename of the metadata
        public void SaveToFile(string path) {
            byte[] decodedBytes = Convert.FromBase64String(base64);

            File.WriteAllBytes(path + this.metadata.targetName, decodedBytes);
        }
    }
}