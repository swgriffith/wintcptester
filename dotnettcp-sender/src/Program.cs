using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class TcpSender
{
    private const int portNum = 13;
    public static int Main(String[] args)
    {
        try
        {
        
        bool done = false;

        while (!done)
        {
        var client = new TcpClient(args[0], int.Parse(args[1]));
        string message = "Gimme the time!";

        // Translate the test message into ASCII and store it as a Byte array.
        Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

        NetworkStream stream = client.GetStream();

        // Send the message to the connected TcpServer.
        stream.Write(data, 0, data.Length);

        Console.WriteLine("Sent: {0}", message);

        // Receive the TcpServer.response.

        // Buffer to store the response bytes.
        data = new Byte[256];

        // String to store the response ASCII representation.
        String responseData = String.Empty;

        // Read the first batch of the TcpServer response bytes.
        Int32 bytes = stream.Read(data, 0, data.Length);
        responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
        Console.WriteLine("Received: {0}", responseData);

        // Close everything.
        stream.Close();
        client.Close();
        System.Threading.Thread.Sleep(1000);
        }

        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine("ArgumentNullException: {0}", e);
        }
        catch (SocketException e)
        {
            Console.WriteLine("SocketException: {0}", e);
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: {0}", e);
        }

        return 0;
    }
}