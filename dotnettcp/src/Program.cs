// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class TcpTimeServer
{
    
    public static int Main(String[] args)
    {
        bool done = false;
        
        var listener = new TcpListener(IPAddress.Parse(args[0]), int.Parse(args[1]));
        listener.Start();
        while (!done)
        {
            Console.Write("Waiting for connection...");
            TcpClient client = listener.AcceptTcpClient();

            Console.WriteLine("Connection accepted.");
            NetworkStream ns = client.GetStream();

            byte[] byteTime = Encoding.ASCII.GetBytes(DateTime.Now.ToString());

            try
            {
                // Buffer to store the response bytes.
                Byte[] data = new Byte[256];
                Int32 bytes = ns.Read(data, 0, data.Length);
                string responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                Console.WriteLine("Received: {0}", responseData);

                ns.Write(byteTime, 0, byteTime.Length);
                ns.Close();
                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        listener.Stop();
        return 0;
    }
}