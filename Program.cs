using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace RequestManagerApplication
{
    class Exec
    {
        void Writer()
        {

            Console.WriteLine("Enter Request Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Assigned to:");
            string user = Console.ReadLine();
            Console.WriteLine("Status:");
            string status = Console.ReadLine();
            Console.WriteLine(name);
            Console.WriteLine(user);
            Console.WriteLine(status);
            Console.ReadLine();
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            XmlWriter writer = XmlWriter.Create("RequestManagerApplication.xml", settings);
            writer.WriteStartDocument();
            writer.WriteStartElement("Request");
            writer.WriteElementString("Name", name);

            writer.WriteStartElement("User");
            writer.WriteString(user);
            writer.WriteEndElement();


            writer.WriteStartElement("Status");
            writer.WriteElementString("CurrentStatus", status);
            writer.WriteEndElement();
            writer.WriteElementString("style", "urn:samples", "hardcover");

            writer.WriteEndElement();
            writer.WriteEndDocument();

            writer.Flush();
            writer.Close();
            checkPause();
        }

        void Reader()
        {
            XmlTextReader reader = new XmlTextReader("RequestManagerApplication.xml");

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        Console.Write("<{0}>", reader.Name);
                        break;
                    case XmlNodeType.Text:
                        Console.Write(reader.Value);
                        break;
                    case XmlNodeType.CDATA:
                        Console.Write("<![CDATA[{0}]]>", reader.Value);
                        break;
                    case XmlNodeType.ProcessingInstruction:
                        Console.Write("<?{0} {1}?>", reader.Name, reader.Value);
                        break;
                    case XmlNodeType.Comment:
                        Console.Write("<!--{0}-->", reader.Value);
                        break;
                    case XmlNodeType.XmlDeclaration:
                        Console.Write("<?xml version='1.0'?>");
                        break;
                    case XmlNodeType.Document:
                        break;
                    case XmlNodeType.DocumentType:
                        Console.Write("<!DOCTYPE {0} [{1}]", reader.Name, reader.Value);
                        break;
                    case XmlNodeType.EntityReference:
                        Console.Write(reader.Name);
                        break;
                    case XmlNodeType.EndElement:
                        Console.Write("</{0}>", reader.Name);
                        break;
                }
                Console.ReadLine();
                
            }
            checkPause();
        }
        public bool pause { get; set; }

        public void checkPause()
        {
            if (pause)
            {
                Console.Write("\n  Press any key to move to next demonstraton:");
                Console.ReadKey();
                Console.WriteLine();
            }
        }
        List<int> tests = new List<int>();

        void processCommandLine(string[] args)
        {
            if (args.Length > 0)
            {
                if (args[0] == "pause")
                    pause = true;
            }
            foreach (string arg in args)
            {
                try
                {
                    int testNum = Int32.Parse(arg);
                    tests.Add(testNum);
                }
                catch
                {
                    continue;
                }
            }
            if (tests.Count() == 0)
            {
                for (int i = 2; i <= 3; ++i)
                    tests.Add(i);
            }
        }
        void dispatchTests()
        {
            foreach (int test in tests)
            {
                switch (test)
                {
                    case 2:
                        Writer(); break;
                    case 3:
                        Reader(); break;

                }
            }
        }


        static void Main(string[] args)
        {


            Exec exec = new Exec();
            try
            {
                exec.processCommandLine(args);
                exec.dispatchTests();
            }


            catch (Exception ex)
            {
                Console.Write("\n  --- {0} ---", ex.Message);
            }
            Console.Write("\n\n");



            //XmlWriterSettings settings = new XmlWriterSettings();
            //settings.Indent = true;

            //XmlWriter writer = XmlWriter.Create("Products.xml", settings);
            //writer.WriteStartDocument();
            //writer.WriteComment("This file is generated by the program.");
            //writer.WriteStartElement("Product");
            //writer.WriteAttributeString("ID", "002");
            //writer.WriteAttributeString("Name", "Soap");
            //writer.WriteElementString("Price", "10.00");
            //writer.WriteStartElement("OtherDetails");
            //writer.WriteElementString("BrandName", "X Soap");
            //writer.WriteElementString("Manufacturer", "X Company");
            //writer.WriteEndElement();
            //writer.WriteEndDocument();

            //writer.Flush();
            //writer.Close();


            //string startupPath = Environment.CurrentDirectory;
            //Console.WriteLine(startupPath);
            //Console.ReadLine();


        }
    }
}

