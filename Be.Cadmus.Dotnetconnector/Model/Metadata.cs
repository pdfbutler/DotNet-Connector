using System;
using Be.Cadmus.Dotnetconnector.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Be.Cadmus.Dotnetconnector.Model {

    public class Metadata {

        public string userId { get; set; }
        public string organizationId { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Constants.Stage stage { get; set; }
        public string targetName { get; set; }
        public string version { get{ return Constants.CURRENT_VERSION;} }
    }
}