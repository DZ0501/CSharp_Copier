using System;

namespace Zadanie3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("                              #====================#");
            Console.WriteLine("                              #     Copier test    #");
            Console.WriteLine("                              #====================#");

            Copier xerox = new Copier();

            Console.WriteLine($"\ncopier counter: {xerox.Counter}");
            Console.WriteLine($"print counter: {xerox.PrintCounter}");

            Console.WriteLine(xerox.GetState());

            xerox.PowerOn();

            Console.WriteLine(xerox.GetState());
            Console.WriteLine("printing doc1.pdf");

            IDocument doc1 = new PDFDocument("doc1.pdf");

            xerox.Print(doc1);

            Console.WriteLine("scanning doc.txt");
            xerox.Scan(IDocument.FormatType.TXT);
            Console.WriteLine("scanning doc.jpg");
            xerox.Scan(IDocument.FormatType.JPG);

            Console.WriteLine($"copier counter: {xerox.Counter}");
            Console.WriteLine($"print counter: {xerox.PrintCounter}");
            Console.WriteLine($"scan counter: {xerox.ScanCounter}");

            Console.WriteLine("scanning and printing doc.pdf");
            xerox.ScanAndPrint(IDocument.FormatType.PDF);
            Console.WriteLine($"print counter: {xerox.PrintCounter}");
            Console.WriteLine($"scan counter: {xerox.ScanCounter}\n");


            Console.WriteLine("                              #======================================#");
            Console.WriteLine("                              #     Multidimensional device test     #");
            Console.WriteLine("                              #======================================#");


            MultidimensionalDevice multi = new MultidimensionalDevice();

            Console.WriteLine(multi.GetState());

            multi.PowerOn();

            Console.WriteLine(multi.GetState());
            Console.WriteLine($"multi print counter: {multi.PrintCounter}");
            Console.WriteLine($"multi scan counter: {multi.ScanCounter}");

            multi.Print(doc1);
            Console.WriteLine("scanning doc.txt");
            multi.Scan(IDocument.FormatType.TXT);
            Console.WriteLine("scanning doc.jpg");
            multi.Scan(IDocument.FormatType.JPG);

            Console.WriteLine($"multi print counter: {multi.PrintCounter}");
            Console.WriteLine($"multi scan counter: {multi.ScanCounter}");
            Console.WriteLine("faxing .txt document to testRecievier");

            multi.FaxDocument("testReciever", IDocument.FormatType.TXT);
            Console.WriteLine("faxing .pdf document to testRecievier2");
            multi.FaxDocument("testReciever2", IDocument.FormatType.PDF);
            Console.WriteLine("faxing .pdf document to testRecievier2");
            multi.FaxDocument("testReciever2", IDocument.FormatType.JPG);
            Console.WriteLine($"multi counter: {multi.Counter}");

            Console.WriteLine($"multi print counter: {multi.PrintCounter}");
            Console.WriteLine($"multi scan counter: {multi.ScanCounter}");
            Console.WriteLine($"multi fax counter: {multi.FaxCounter}");
        }
    }
}
