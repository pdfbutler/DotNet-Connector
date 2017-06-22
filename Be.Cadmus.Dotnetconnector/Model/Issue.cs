using System;
using Be.Cadmus.Dotnetconnector.Generic;

namespace Be.Cadmus.Dotnetconnector.Model {
        
    public class Issue {

        private string description;
        private Constants.IssueLevel level;
        public string getDescription() {
            return description;
        }
        public void setDescription(string description) {
            this.description = description;
        }
        public Constants.IssueLevel getLevel() {
            return level;
        }
        public void setLevel(Constants.IssueLevel level) {
            this.level = level;
        }
    }
}