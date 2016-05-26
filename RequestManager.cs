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
            //checkPause();
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
                        Console.ReadLine();
                        break;
                    case XmlNodeType.Text:
                        Console.Write(reader.Value);
                        Console.ReadLine();
                        break;
                    case XmlNodeType.CDATA:
                        Console.Write("<![CDATA[{0}]]>", reader.Value);
                        Console.ReadLine();
                        break;
                    case XmlNodeType.ProcessingInstruction:
                        Console.Write("<?{0} {1}?>", reader.Name, reader.Value);
                        Console.ReadLine();
                        break;
                    case XmlNodeType.Comment:
                        Console.Write("<!--{0}-->", reader.Value);
                        Console.ReadLine();
                        break;
                    case XmlNodeType.XmlDeclaration:
                        Console.Write("<?xml version='1.0'?>");
                        Console.ReadLine();
                        break;
                    case XmlNodeType.Document:
                        break;
                    case XmlNodeType.DocumentType:
                        Console.Write("<!DOCTYPE {0} [{1}]", reader.Name, reader.Value);
                        Console.ReadLine();
                        break;
                    case XmlNodeType.EntityReference:
                        Console.Write(reader.Name);
                        Console.ReadLine();
                        break;
                    case XmlNodeType.EndElement:
                        Console.Write("</{0}>", reader.Name);
                        Console.ReadLine();
                        break;
                }
                
                
            }
            //checkPause();
        }
        //public bool pause { get; set; }

        //public void checkPause()
        //{
        //    if (pause)
        //    {
        //        Console.Write("\n  Press any key to move to next demonstraton:");
        //        Console.ReadKey();
        //        Console.WriteLine();
        //    }
        //}
        List<int> tests = new List<int>();

        public void processCommandLine(string[] args)
        {
            //if (args.Length > 0)
            //{
            //    if (args[0] == "pause")
            //        pause = true;
            //}
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
        public void dispatchTests()
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


    }
}

