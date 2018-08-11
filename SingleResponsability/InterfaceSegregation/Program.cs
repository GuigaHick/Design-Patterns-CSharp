using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregation
{
    class Program
    {

        public class Document
        {

        }
        //BAD CHOICE 

        public interface IMachine
        {
            void Print(Document D);
            void Scan(Document D);
            void Fax(Document D);
        }

        public class MultiFunctionPrinter : IMachine
        {
            public void Fax(Document D)
            {
                //
            }

            public void Print(Document D)
            {
                //
            }

            public void Scan(Document D)
            {
                //
            }
        }
        //but for a simple printer we would have methods "remaining"..
        public class OldFashionedPrinter : IMachine
        {
            public void Print(Document d)
            {
                // yep
            }

            public void Fax(Document d)
            {
                throw new System.NotImplementedException();
            }

            public void Scan(Document d)
            {
                throw new System.NotImplementedException();
            }
        }
        //GOOD CHOICE
        public interface IPrinter
        {
            void Print(Document D);
        }

        public interface IScanner
        {
            void Scanner(Document D);
        }

        public interface IMultiFunctionDevice : IPrinter, IScanner
        {

        }

        public class MultiFunctionMachine : IMultiFunctionDevice
        {
            private IPrinter printer;
            private IScanner scanner;

            public MultiFunctionMachine( IPrinter printer, IScanner scanner)
            {
                if(printer == null)
                {
                    throw new ArgumentNullException();
                }
                if(scanner == null)
                {
                    throw new ArgumentNullException();
                }
                this.printer = printer;
                this.scanner = scanner;
            }


            public void Print(Document D)
            {
                printer.Print(D);
            }

            public void Scanner(Document D)
            {
                scanner.Scanner(D);
            }
        }
        static void Main(string[] args)
        {
        }
    }
}
