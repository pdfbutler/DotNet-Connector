using System;
using System.Collections.Generic;
using Be.Cadmus.Dotnetconnector;
using Be.Cadmus.Dotnetconnector.Model;
using Be.Cadmus.Dotnetconnector.Generic;

namespace Test.Be.Cadmus.Dotnetconnector
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello PDF Butler user! " + DateTime.Now.ToString());

            Metadata metadata = new Metadata();
            metadata.organizationId = "CloudCrossing.Sales";
            metadata.stage = Constants.Stage.TEST;
            metadata.targetName = "[[!AccountName!]]_[[!StageName!]].pdf";
            metadata.userId = "istuyver";

            Datasources datasources = new Datasources();
            DatasourceSingle s1 = datasources.GetSingle("18393bdc-1445-4cf0-8e05-79fdb9e0d7ec");
            dynamic s1_1 = s1.GetDictionary();
            s1_1.OppOwner = "Igor Stuyver";
            s1_1.AccountName = "CloudCrossing";
            s1_1.StageName = "Closed Won";

            /*
            s1.addData("OppOwner", "Igor Stuyver");
            s1.addData("AccountName", "CloudCrossing");
            s1.addData("StageName", "Closed Won");
            */

            DatasourceList l1 = datasources.GetList("62dbb7d8-6c49-4f40-8d4b-8a60e1a00f23");
            dynamic l1_1 = l1.GetDictionary();
            l1_1.ProdName = "Prod 1";
            l1_1.ProdPrice = "1000";
            l1_1.ProdQuantity = "2";
            dynamic l1_2 = l1.GetDictionary();
            l1_2.ProdName = "Prod 2";
            l1_2.ProdPrice = "500";
            l1_2.ProdQuantity = "12";
            /*Dictionary<string, string> l1_1 = new Dictionary<string, string>();
            l1_1.Add("ProdName", "Prod 1");
            l1_1.Add("ProdPrice", "1000");
            l1_1.Add("ProdQuantity", "2");
            l1.AddData(l1_1);
            Dictionary<string, string> l1_2 = new Dictionary<string, string>();
            l1_2.Add("ProdName", "Prod 2");
            l1_2.Add("ProdPrice", "50");
            l1_2.Add("ProdQuantity", "12");
            l1.AddData(l1_2);
            */
            
            Convertor.Username = "<YOUR USERNAME>";
            Convertor.Password = "<YOUR PASSWORD>";
            for(int i = 0; i < 10; i++) {
                Console.WriteLine("Starting at: " + DateTime.Now.ToString());
                ConvertResponse resp = Convertor.DoConvert(metadata, datasources, "<YOUR DOC CONFIG ID>");
                Console.WriteLine(resp.result.ToString() + " - request " + i);
                Console.WriteLine("Finished at: " + DateTime.Now.ToString());
                resp.SaveToFile(@"C:\Users\istuyver\Documents\Igor\Cadmus\DotNetConnectorSolution\");
                Console.WriteLine("--------------------------------------------------------------");
                //Console.WriteLine("Done, file saved under name: " + resp.metadata.targetName);
            }
        }
    }
}
