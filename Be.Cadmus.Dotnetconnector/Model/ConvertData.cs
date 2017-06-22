using System;
using Be.Cadmus.Dotnetconnector.Generic;

namespace Be.Cadmus.Dotnetconnector.Model {
    public class ConvertData {
        public Metadata metadata { get; set; }
        public string customerDocumentConfigId { get; set; }
        public string dataSources { get; set; }
    }
}