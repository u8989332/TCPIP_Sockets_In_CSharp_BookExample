﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2
{
    class TcpEchoClient
    {
        public void BuildClient(string[] args)
        {
            if(args.Length < 2 || args.Length > 3)
            {
                throw new ArgumentException("Parameter: <Server> <Word> [<Port>]");
            }

            string server = args[0];

            byte[] byteBuffer = Encoding.ASCII.GetBytes(args[1]);

            int servPort = (args.Length == 3) ? Int32.Parse(args[2]) : 7;

            TcpClient client = null;
            NetworkStream netStream = null;

            try
            {
                client = new TcpClient(server, servPort);

                Console.WriteLine("Connected to server... sending echo string");

                netStream = client.GetStream();

                netStream.Write(byteBuffer, 0, byteBuffer.Length);

                Console.WriteLine("Sent {0} bytes to server...", byteBuffer.Length);

                int totalBytesRcvd = 0;
                int bytesRcvd = 0;

                while(totalBytesRcvd < byteBuffer.Length)
                {
                    if((bytesRcvd = netStream.Read(byteBuffer, totalBytesRcvd, byteBuffer.Length - totalBytesRcvd)) == 0)
                    {
                        Console.WriteLine("Connection closed prematurely.");
                        break;
                    }
                    totalBytesRcvd += bytesRcvd;
                }

                Console.WriteLine("Received {0} bytes from server: {1}", 
                    totalBytesRcvd, Encoding.ASCII.GetString(byteBuffer, 0, totalBytesRcvd));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                netStream.Close();
                client.Close();
            }

        }
    }
}
