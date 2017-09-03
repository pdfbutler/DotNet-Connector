using System;
using System.Collections.Generic;
using Be.Cadmus.Dotnetconnector.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Be.Cadmus.Dotnetconnector.Model {

    public class Datasources {

        private List<AbstractDatasource> datasources = new List<AbstractDatasource>();
        
        public DatasourceSingle GetSingle(string name) {
            DatasourceSingle temp = new DatasourceSingle();
            temp.setName(name);
            this.datasources.Add(temp);
            
            return temp;
        }

        public DatasourceList GetList(string name) {
            DatasourceList temp = new DatasourceList();
            temp.setName(name);
            this.datasources.Add(temp);
            
            return temp;
        }

        public DatasourcePicture GetPicture(string name) {
            DatasourcePicture temp = new DatasourcePicture();
            temp.setName(name);
            this.datasources.Add(temp);
            
            return temp;
        }

        public List<AbstractDatasource> GetDatasources() {
            return datasources;
        }
        
        public string GetAsString() {
            
            dynamic retObject = new JObject();
            
            foreach(AbstractDatasource ad in datasources) {
                dynamic dsItem = new JObject();
                dsItem.type = ad.getType().ToString();
                retObject[ad.getName()] = dsItem;
                
                if(ad is DatasourceSingle) {
                    DatasourceSingle ds = (DatasourceSingle)ad;

                    dynamic data = new JObject();
                    dsItem.data = data;
                    
                    foreach(KeyValuePair<string, string> entry in ds.getData()) {
                        data[entry.Key] = entry.Value;
                    }
                } else if(ad is DatasourceList) {
                    DatasourceList ds = (DatasourceList)ad;

                    JArray data = new JArray();
                    foreach(Dictionary<string, string> item in ds.GetData()) {
                        dynamic itemEntry = new JObject();
                        foreach(KeyValuePair<string, string> entry in item) {
                            itemEntry[entry.Key] = entry.Value;
                        }
                        data.Add(itemEntry);
                    }
                    dsItem.data = data;
                } else if(ad is DatasourcePicture) {
                    DatasourcePicture ds = (DatasourcePicture)ad;

                    JArray data = new JArray();
                    foreach(DatasourcePicture.Picture item in ds.GetData()) {
                        dynamic itemEntry = new JObject();
                        itemEntry["base64"] = item.base64;
                        itemEntry["name"] = item.name;
                        itemEntry["parentId"] = item.parentId;

                        data.Add(itemEntry);
                    }
                    dsItem.data = data;
                } else {
                    throw new Exception("This datasource type is not supported: " + ad.getType().ToString());
                }
            }
            string ret = retObject.ToString();
            //Console.WriteLine("datasources json:" + ret);
            return ret;
            //return JSONObject.valueToString(this.datasources);
        }
    }
}