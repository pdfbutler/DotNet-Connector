using System;
using System.Collections.Generic;
using Be.Cadmus.Dotnetconnector.Generic;

namespace Be.Cadmus.Dotnetconnector.Model {

    public class DatasourceList : AbstractDatasource {
        
        internal DatasourceList() {
            this.setType(Constants.DataSourceType.LIST);
        }

        private List<Dictionary<string, string>> data = new List<Dictionary<string, string>>();
        
        public List<Dictionary<string, string>> GetData() {
            return data;
        }
        public void AddData(Dictionary<string, string> item) {
            this.data.Add(item);
        }

        public dynamic GetDictionary() {
            dynamic dic = new DynamicDictionary();
            this.data.Add(dic.dictionary);

            return dic;
        }
    }
}