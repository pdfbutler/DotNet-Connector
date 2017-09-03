using System;
using System.Collections.Generic;
using Be.Cadmus.Dotnetconnector;
using Be.Cadmus.Dotnetconnector.Model;
using Be.Cadmus.Dotnetconnector.Generic;

namespace Test.Be.Cadmus.Dotnetconnector
{
    class PdfButlerAdvanced
    {
        public static void CreatePdf()
        {
            Console.WriteLine("Hello PDF Butler user! " + DateTime.Now.ToString());

            Metadata metadata = new Metadata();
            metadata.organizationId = "CloudCrossing.Sales";
            metadata.stage = Constants.Stage.TEST;
            metadata.targetName = "PdbButlerAdvanced";
            metadata.userId = "istuyver";
            metadata.targetType = Constants.ConvertFileType.PDF;

            Datasources datasources = new Datasources();
            
            dynamic account = datasources.GetSingle("<YOUR ACCOUNT DS ID>").GetDictionary();
            account.Id = "Acc1";
            account.Name = "CloudCrossing";
            account.Phone = "555/12345678";
            account.Fax = "555/87654321";

            
            DatasourceList opportunities = datasources.GetList("<YOUR OPPORTUNITIES DS ID>");
            dynamic opp1 = opportunities.GetDictionary();
            opp1.Id = "Opp1";
            opp1.OppName = "500.000 widgets";
            opp1.StageName = "Ready to sign";
            opp1.AccountId = "Acc1";
            dynamic opp2 = opportunities.GetDictionary();
            opp2.Id = "Opp2";
            opp2.OppName = "200.000 widgets";
            opp2.StageName = "Closed Won";
            opp2.AccountId = "Acc1";
            dynamic opp3 = opportunities.GetDictionary();
            opp3.Id = "Opp3";
            opp3.OppName = "5.000 widgets";
            opp3.StageName = "Closed Lost";
            opp3.AccountId = "Acc1";

            DatasourceList opportunityProducts = datasources.GetList("<YOUR OPPORTUNITY PRODUCTS DATASOURCE ID>");
            dynamic oppProd1 = opportunityProducts.GetDictionary();
            oppProd1.ProductName = "Widget 1";
            oppProd1.Quantity = "200.000";
            oppProd1.OpportunityId = "Opp1";
            oppProd1.UnitPrice = "50";
            oppProd1.ProductCode = "100";
            oppProd1.TemplateId = "fc669f06-9f5e-4595-be09-a2235d6f94fe";
            dynamic oppProd2 = opportunityProducts.GetDictionary();
            oppProd2.ProductName = "Widget 2";
            oppProd2.Quantity = "300.000";
            oppProd2.OpportunityId = "Opp1";
            oppProd2.UnitPrice = "70";
            oppProd2.ProductCode = "200";
            oppProd2.TemplateId = "16f468ff-8f92-4762-8fdd-b6a09a1f6b08";
            dynamic oppProd3 = opportunityProducts.GetDictionary();
            oppProd3.ProductName = "Widget 2";
            oppProd3.Quantity = "200.000";
            oppProd3.OpportunityId = "Opp2";
            oppProd3.UnitPrice = "70";
            oppProd3.ProductCode = "200";
            oppProd3.TemplateId = "fc669f06-9f5e-4595-be09-a2235d6f94fe";
            dynamic oppProd4 = opportunityProducts.GetDictionary();
            oppProd4.ProductName = "Widget 3";
            oppProd4.Quantity = "5.000";
            oppProd4.OpportunityId = "Opp3";
            oppProd4.UnitPrice = "1000";
            oppProd4.ProductCode = "300";
            oppProd4.TemplateId = "16f468ff-8f92-4762-8fdd-b6a09a1f6b08";


            
            DatasourcePicture.Picture logo = datasources.GetPicture("<YOUR LOGO DS ID>").AddPicture();
            logo.file = "C:/Users/istuyver/Pictures/pdfbutlerlogo.png";
            logo.name = "Pdf Butler Logo";
            logo.parentId = "";
            
            DatasourcePicture.Picture accountLogo = datasources.GetPicture("<YOUR ACCOUNT LOGO DS ID>").AddPicture();
            accountLogo.file = "C:/Users/istuyver/Pictures/cadmus_arch.png";
            accountLogo.name = "Pdf Butler Architecture";
            accountLogo.parentId = "Acc1";
            
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
