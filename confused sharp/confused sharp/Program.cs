using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Z.Expressions;
using System.IO;
using System.Net;
using System.Threading;
using System.Reflection;
using System.Runtime.InteropServices;
using Z.Expressions.Compiler.Shared;
using System.Diagnostics;

namespace confused_sharp
{
    class program
    {
        static string[] commands = { "cls, ", "clear, ", "example " };
        static string tmp1;
        static int tmp = 0;
        static string tmpstr = $"";
        static void Main(string[] args)
        {

            Console.WriteLine("commands : "  +"cls, clear, example");
            Console.WriteLine("Example: \n++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++;\n+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++;\n++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++;\n++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++;\n+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++;");
            Console.WriteLine("Enter your confused sharp code:");
            while (true)
            {
                byte[] inputbuffer = new byte[1000000000];
                Stream inputstream = Console.OpenStandardInput(inputbuffer.Length);
                Console.SetIn(new StreamReader(inputstream, Console.InputEncoding, false, inputbuffer.Length));
                string input = Console.ReadLine();
                if (input.ToLower() == "cls" | input.ToLower() == "clear")
                {
                    Console.Clear();
                } else if (input.ToLower() == "example")
                {
                    Console.WriteLine("commands : "); foreach (string a in commands) { Console.Write(a); } Console.WriteLine();
                    Console.WriteLine("Example: \n++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++;\n+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++;\n++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++;\n++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++;\n+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++;");
                    Console.WriteLine("Enter your confused sharp code:");
                }
                foreach (string group in input.Split(';'))
                {
                    tmp = 0;
                    foreach (char c in group)
                    {
                        if (c == '+')
                        {
                            tmp++;
                        }
                        else if (c == '-')
                        {
                            tmp--;
                        }
                    }
                    tmpstr = tmpstr + (char)tmp;
                }
                if (input.StartsWith("_"))
                {
                    try
                    {
                        input = input.Replace("_", "");
                        EvalContext context = new EvalContext();
                        object result;

                        try
                        {
                            result = context.Execute<object>(input);
                        }
                        catch (EvalException evalException)
                        {
                            Console.WriteLine("An error occurred while evaluating the expression: " + evalException.Message);
                            continue;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("An error occurred: " + ex.Message);
                            continue;
                        }

                        Console.WriteLine(result);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
                else if (!input.StartsWith("_"))
                {
                    if (tmpstr.EndsWith(";"))
                    {
                        int a = input.Length - 1;
                        foreach (char c in tmpstr)
                        {
                            tmp1 = tmp1 + c;
                            if (tmp1.Length == a)
                            {
                                input = tmp1;
                                tmp1 = "";
                            }
                        }
                    }
                    if (tmpstr != "")
                        foreach (string a in commands)
                        {
                            string tmp = input;
                            if (tmpstr != a)
                            {
                                Console.WriteLine(tmpstr);
                                tmpstr = "";
                            }
                         }

                }
                tmpstr = "";
                tmp = 0;
                input = "";
            }
        }
    }
}
