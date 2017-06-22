using System;
using System.Collections.Generic;
using Be.Cadmus.Dotnetconnector.Generic;

namespace Be.Cadmus.Dotnetconnector.Model {

    public class DatasourceSingle : AbstractDatasource {

        private Dictionary<string, string> data = new Dictionary<string, string>();
        
        internal DatasourceSingle() {
            this.setType(Constants.DataSourceType.SINGLE);
        }
        public Dictionary<string, string> getData() {
            return data;
        }
        public void addData(string key, string value) {
            this.data.Add(key, value);
        }

        public dynamic GetDictionary() {
            dynamic dic = new DynamicDictionary();
            data = dic.dictionary;

            return dic;
        }
    }
}