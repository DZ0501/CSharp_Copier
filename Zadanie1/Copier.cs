using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie1
{
    public class Copier : BaseDevice, IPrinter, IScanner
    {
        public int PrintCounter
        { 
            get;
            private set;
        }

        public int ScanCounter
        {
            get;
            private set;
        }

        public new int Counter
        {
            get;
            private set;
        }

        public new void PowerOn()
        {
            if (state == IDevice.State.off)
            {
                base.PowerOn();
                Counter++;
            }
        }

        public new void PowerOff()
        {
            if (state == IDevice.State.on)
            {
                base.PowerOff();
            }
        }

        public void Print(in IDocument document)
        {
            if (state == IDevice.State.on)
            {
                Console.WriteLine($"{DateTime.Now} Print: {document.GetFileName()}");
                PrintCounter++;
            }
        }

        public void Scan(out IDocument document, IDocument.FormatType formatType = IDocument.FormatType.JPG)
        {
            document = null;
            if (state == IDevice.State.on)
            {
                string scanType = "";

                switch (formatType)
                {
                    case IDocument.FormatType.JPG:
                        scanType = $"ImageScan{ScanCounter}.jpg";
                        document = new ImageDocument(scanType);
                        break;
                    case IDocument.FormatType.PDF:
                        scanType = $"PDFScan{ScanCounter}.pdf";
                        document = new PDFDocument(scanType);
                        break;
                    case IDocument.FormatType.TXT:
                        scanType = $"TextScan{ScanCounter}.txt";
                        document = new TextDocument(scanType);
                        break;
                }

                ScanCounter++;
                Console.WriteLine($"{DateTime.Now} Scan: {scanType}");
            }
        }
        public void ScanAndPrint()
        {
            if (state == IDevice.State.on)
            {
                Scan(out IDocument document);
                Print(in document);
            }
        }
    }
}
