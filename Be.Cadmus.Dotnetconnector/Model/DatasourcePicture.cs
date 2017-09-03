using System;
using System.IO;
using System.Collections.Generic;
using Be.Cadmus.Dotnetconnector.Generic;

namespace Be.Cadmus.Dotnetconnector.Model {

    public class DatasourcePicture : AbstractDatasource {
        
        internal DatasourcePicture() {
            this.setType(Constants.DataSourceType.LIST);
        }

        private List<Picture> data = new List<Picture>();
        
        public List<Picture> GetData() {
            return data;
        }
	
        public Picture AddPicture() {
            Picture picture = new Picture();
            this.data.Add(picture);
            
            return picture;
        }
	
        public class Picture {
            public string base64 { get; set; }
            public string name { get; set; }
            public string parentId { get; set; }

            public string file { 
                set {
                    Byte[] bytes = File.ReadAllBytes(value);
                    this.base64 = Convert.ToBase64String(bytes);
                } 
            }
        }
    }
}