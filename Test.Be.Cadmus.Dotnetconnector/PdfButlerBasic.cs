using System;
using System.Collections.Generic;
using Be.Cadmus.Dotnetconnector;
using Be.Cadmus.Dotnetconnector.Model;
using Be.Cadmus.Dotnetconnector.Generic;

namespace Test.Be.Cadmus.Dotnetconnector
{
    class PdfButlerBasic
    {
        public static void CreatePdf()
        {
            Console.WriteLine("Hello PDF Butler user! " + DateTime.Now.ToString());

            Metadata metadata = new Metadata();
            metadata.organizationId = "CloudCrossing.Sales";
            metadata.stage = Constants.Stage.TEST;
            metadata.targetName = "[[!AccountName!]]_[[!StageName!]]";
            metadata.userId = "istuyver";
            metadata.targetType = Constants.ConvertFileType.PDF;

            Datasources datasources = new Datasources();
            dynamic account = datasources.GetSingle("<YOUR ACCOUNT DS ID>").GetDictionary();
            account.OppOwner = "Igor Stuyver";
            account.AccountName = "CloudCrossing";
            account.StageName = "Closed Won";

            DatasourceList products = datasources.GetList("<YOUR PRODUCTS DS ID>");
            dynamic products_1 = products.GetDictionary();
            products_1.ProdName = "Gizmo 1";
            products_1.ProdPrice = "1000";
            products_1.ProdQuantity = "3";
            dynamic products_2 = products.GetDictionary();
            products_2.ProdName = "Gizmo 2";
            products_2.ProdPrice = "500";
            products_2.ProdQuantity = "12";
            dynamic products_3 = products.GetDictionary();
            products_3.ProdName = "Gizmo 3";
            products_3.ProdPrice = "10";
            products_3.ProdQuantity = "50";
            
            Convertor.Username = "<YOUR USERNAME>";
            Convertor.Password = "<YOUR PASSWORD>";
            
            ConvertResponse resp = Convertor.DoConvert(metadata, datasources, "<YOUR DOC CONFIG ID>");
            Console.WriteLine("FileName: " + resp.metadata.targetName);
            resp.SaveToFile(@"C:\Users\istuyver\Documents\Igor\Cadmus\DotNetConnectorSolution\");
            Console.WriteLine("--------------------------------------------------------------");
            //Console.WriteLine("Done, file saved under name: " + resp.metadata.targetName);
        }
    }
}
