using System;

namespace Be.Cadmus.Dotnetconnector.Generic {

    public class Constants {

        public const string MERGE_FIELD_PREFIX = "[[!";
        public const string MERGE_FIELD_SUFFIX = "!]]";
        public const string WORD_EXTENSION = ".docx";
        public const string PDF_EXTENSION = ".pdf";
        public const string ROLE_SEPERATOR = "-";
        public const string CURRENT_VERSION = "v1.0";
        
        public enum Stage {
            PROD,
            TEST
        }

        public enum EnvironmentType {
            DEV,
            PROD, 
        }

        public enum IssueLevel {
            INFO,
            WARNING, 
            ERROR 
        }

        public enum ConfigDataResult {
            SUCCESS,
            SUCCESS_WITH_WARNINGS, 
            FAILED 
        }

        public enum DataSourceType {
            SINGLE,
            LIST
        }

        public enum UserRole {
            ADMIN,
            USER
        }

        public enum ConvertFileType {
            PDF,
            DOCX
        }
    }
}