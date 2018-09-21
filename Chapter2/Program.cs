using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Core;
namespace Chapter2
{
    class Program
    {

        static void Main(string[] args)
        {
            string command = args[0];
            string[] commandArgs = Utils.SubArray<string>(args, 1, args.Length - 1);

            switch(command)
            {
                case "IPAddressExample":
                    IPAddressExampleImpl(commandArgs);
                    break;
                default:
                    break;
            }
        }

        static void IPAddressExampleImpl(string[] args)
        {
            // Get and print local host info
            try
            {
                Console.WriteLine("Local Host:");
                string localHostName = Dns.GetHostName();
                Console.WriteLine("\tHost Name: " + localHostName);
                IPAddressExample.PrintHostInfo(localHostName);
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to resolve local host\n");
            }

            // Get and print info for hosts given on command line
            foreach (string arg in args)
            {
                Console.WriteLine(arg + ":");
                IPAddressExample.PrintHostInfo(arg);
            }
        }
    }
}
