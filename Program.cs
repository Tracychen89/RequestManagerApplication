using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace RequestManagerApplication
{
    class Program
    {
     


        static void Main(string[] args)
        {

            Application.Exec exec = new Application.Exec();
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

        }
    }
}

