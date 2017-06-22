using System;
using Be.Cadmus.Dotnetconnector.Generic;

namespace Be.Cadmus.Dotnetconnector.Model {

    public abstract class AbstractDatasource {

        private string name;
        private Constants.DataSourceType type;
        
        public string getName() {
            return name;
        }
        public void setName(string name) {
            this.name = name;
        }
        public Constants.DataSourceType getType() {
            return type;
        }
        protected void setType(Constants.DataSourceType type) {
            this.type = type;
        }
    }
}