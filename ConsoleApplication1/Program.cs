using System;
using System.Net.NetworkInformation;
using System.Net;
using System.Diagnostics;

namespace NetScan
{
    class Program
    {
        static void Main(string[] args)
        {
            Ping sender = new Ping();
            Stopwatch s = new Stopwatch();
            string ipBase = "";

            if (args.Length == 0)
            {
                ipBase = "192.168.1.";
            }

            s.Start();
            for(int i = 1; i < 256; i++)
            {
                try
                {
                    PingReply reply = sender.Send(ipBase + i.ToString(), 5);
                    if (reply.Status == IPStatus.Success)
                    {
                        Console.WriteLine("Address: {0}", reply.Address);
                        Console.WriteLine("Hostname: {0}", Dns.GetHostEntry(reply.Address).HostName);
                        Console.WriteLine();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Couldn't resolve host.");
                    Console.WriteLine();
                }
                
            }
            s.Stop();
            Console.WriteLine("Finished in {0}.", s.Elapsed);
            Console.ReadKey();
        }
    }
}
