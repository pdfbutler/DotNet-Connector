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
            PdfButlerBasic.CreatePdf();
            PdfButlerAdvanced.CreatePdf();
        }
    }
}
