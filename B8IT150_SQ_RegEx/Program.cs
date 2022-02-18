using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace B8IT150_SQ_RegEx
{
    class Program
    {
        static void Main(string[] args)
        {
            bool cont = true;

            Console.Write("File Path: ");
            string file = Console.ReadLine();

            if (file == "")
            {
                Environment.Exit(0);
            }

            do
            {
                Console.Write("Regular Expression: ");
                string regEx = Console.ReadLine();

                if (regEx == "")
                {
                    Environment.Exit(0);
                }

                Regex engine = new Regex(regEx);

                try
                {
                    using (StreamReader rdr = new StreamReader(file))
                    {
                        string line;

                        while ((line = rdr.ReadLine()) != null)
                        {
                            Match match = engine.Match(line);

                            if (match.Success)
                            {
                                Console.WriteLine($"Match at {match.Index}");
                                Console.WriteLine($"Line: {line}");
                            }
                            else
                            {
                                Console.WriteLine("No match found.");
                            }
                        }
                    }
                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine("The file does not exist at the path provided.");
                }
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine("The application is unable to read the file at this path.");
                }

                Console.WriteLine("Press any key followed by 'Enter' to continue or 'N' to exit.");
                string input = Console.ReadLine();

                if (input == "N")
                {
                    cont = false;
                }
            }
            while (cont == true);
        }
    }
}
