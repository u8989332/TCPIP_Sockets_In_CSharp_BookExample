using System;
using System.Collections.Generic;
using System.Net;

namespace Chapter2
{
    class IPAddressExample
    {
        public static void PrintHostInfo(string host)
        {
            try
            {
                IPHostEntry hostInfo;

                hostInfo = Dns.GetHostEntry(host);

                Console.WriteLine("\tCanonical Name: " + hostInfo.HostName);

                Console.Write("\tIP Addresses: ");
                foreach (IPAddress ipaddr in hostInfo.AddressList)
                {
                    Console.Write(ipaddr.ToString() + " ");
                }
                Console.WriteLine();

                Console.Write("\tAliases:      ");
                foreach (string alias in hostInfo.Aliases)
                {
                    Console.WriteLine(alias + " ");
                }
                Console.WriteLine("\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\tUnable to resolve host: " + host + "\n");
            }
        }

    }
}
