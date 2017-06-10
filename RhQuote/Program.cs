// The MIT License (MIT)
// 
// Copyright (c) 2015 Filip Frącz
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text;

namespace BasicallyMe.RobinhoodNet.RhQuote
{
    class MainClass
    {
        public static void Main (string [] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Usage:");
                Console.WriteLine("RhQuote SYMBOL1 [SYMBOL2 SYMBOL3 SYMBOL_N]");
                Environment.Exit(1);
            }

            var rh = new RobinhoodClient();

            if (!authenticate(rh))
            {
                Console.WriteLine("Unable to authenticate user");
                Environment.Exit(1);
            }

            try
            {
                var quotes = rh.DownloadQuote(args).Result;
                var history = rh.DownloadHistory (args, "5minute", "week").Result;
                Console.WriteLine(DateTime.Now);
                foreach (var q in quotes)
                {
                    if (q == null)
                    {
                        continue;
                    }

                    Console.WriteLine("{0}\tCh: {1}%\tLTP: {2}\tBID: {3}\tASK: {4}",
                                      q.Symbol,
                                      q.ChangePercentage,
                                      q.LastTradePrice,
                                      q.BidPrice,
                                      q.AskPrice);
                }
                foreach (var h in history) {
                    if (h == null) {
                        continue;
                    }

                    Console.WriteLine ("{0}\tInterval: {1}\tSpan: {2}\tBound: {3}",
                                      h.Symbol,
                                      h.Interval,
                                      h.Span,
                                      h.Bounds);
                    foreach (var p in h.HistoricalInfo) {
                        Console.WriteLine ("{0}\tOpen: {1}\tClose: {2}\tHigh: {3}\tLow: {3}",
                                          p.BeginsAt,
                                           p.OpenPrice,
                                           p.ClosePrice,
                                           p.HighPrice,
                                           p.LowPrice);
                    }
                }
            }
            catch
            {
                Console.WriteLine("None of the quotes entered were found.");
            }

        }




        static readonly string __tokenFile = System.IO.Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "RobinhoodNet",
            "token");

        static string getConsolePassword ()
        {
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }

                if (cki.Key == ConsoleKey.Backspace)
                {
                    if (sb.Length > 0)
                    {
                        Console.Write("\b\0\b");
                        sb.Length--;
                    }

                    continue;
                }

                Console.Write('*');
                sb.Append(cki.KeyChar);
            }

            return sb.ToString();
        }

        static bool authenticate (RobinhoodClient client)
        {
            if (System.IO.File.Exists(__tokenFile))
            {
                var token = System.IO.File.ReadAllText(__tokenFile);
                if (!client.Authenticate(token))
                {
                    if (System.IO.File.Exists(__tokenFile))
                    {
                        System.IO.File.Delete(__tokenFile);
                    }
                    return false;
                }
                return true;
            }
            else
            {
                Console.Write("username: ");
                string userName = Console.ReadLine();

                Console.Write("password: ");
                string password = getConsolePassword();

                if (!client.Authenticate(userName, password))
                {
                    return false;
                }

                System.IO.Directory.CreateDirectory(
                    System.IO.Path.GetDirectoryName(__tokenFile));

                System.IO.File.WriteAllText(__tokenFile, client.AuthToken);
                return true;
            }
        }
        
    }
}
