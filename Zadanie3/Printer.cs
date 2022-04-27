using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie3
{
    public class Printer : IPrinter
    {
        public IDevice.State State 
        { 
            get;
            private set;
        } = IDevice.State.off;

        public int Counter 
        {
            get;
            private set;
        }
        public int PrintCounter 
        {
            get;
            private set;
        }

        public IDevice.State GetState() => State;

        public void PowerOff()
        {
            if (State == IDevice.State.on)
            {
                State = IDevice.State.off;
                Console.WriteLine("Printing functionality is down.");
            }
        }

        public void PowerOn()
        {
            if (State == IDevice.State.off)
            {
                State = IDevice.State.on;
                Counter++;
                Console.WriteLine("Printing functionality is up.");
            }
        }

        public void Print(in IDocument document)
        {
            if (State == IDevice.State.on)
            {      
                Console.WriteLine($"{DateTime.Now} Print: {document.GetFileName()}");
                PrintCounter++;
            }
        }
    }
}
