using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
//using System.Net.Sockets.TcpClient;

namespace NetAppClient
{
    public class Program
    {



        //static void Connect(String server, String message)
        //{
        //    try
        //    {
        //        // Create a TcpClient.
        //        // Note, for this client to work you need to have a TcpServer 
        //        // connected to the same address as specified by the server, port
        //        // combination.
        //        Int32 port = 50001;
        //        TcpClient client = new TcpClient(server, port);

        //        // Translate the passed message into ASCII and store it as a Byte array.
        //        Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

        //        // Get a client stream for reading and writing.
        //        //  Stream stream = client.GetStream();

        //        NetworkStream stream = client.GetStream();

        //        // Send the message to the connected TcpServer. 
        //        stream.Write(data, 0, data.Length);

        //        Console.WriteLine("Sent: {0}", message);

        //        // Receive the TcpServer.response.

        //        // Buffer to store the response bytes.
        //        data = new Byte[1024];

        //        // String to store the response ASCII representation.
        //        String responseData = String.Empty;

        //        // Read the first batch of the TcpServer response bytes.
        //        Int32 bytes = stream.Read(data, 0, data.Length);
        //        responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
        //        Console.WriteLine("Received: {0}", responseData);

        //        // Close everything.
        //        client.Close();
        //    }
        //    catch (ArgumentNullException e)
        //    {
        //        Console.WriteLine("ArgumentNullException: {0}", e);
        //    }
        //    catch (SocketException e)
        //    {
        //        Console.WriteLine("SocketException: {0}", e);
        //    }

        //    Console.WriteLine("\n Press Enter to continue...");
        //    Console.Read();
        //}




        static void Main(string[] args)
        {




      //byte[] data = new byte[1024];
      //string input, stringData;
      //TcpClient server;
 
      //try
      //{
      //   server = new TcpClient("127.0.0.1", 50001);
      //} catch (SocketException)
      //{
      //   Console.WriteLine("Unable to connect to server");
      //   return;
      //}
      //NetworkStream ns = server.GetStream();

      //int recv = ns.Read(data, 0, data.Length);
      //stringData = Encoding.ASCII.GetString(data, 0, recv);
      //Console.WriteLine(stringData);

      //while(true)
      //{
      //   input = Console.ReadLine();
      //   if (input == "exit")
      //   {
      //       break;
      //   }
      //   ns.Write(Encoding.ASCII.GetBytes(input), 0, input.Length);
      //   ns.Flush();

      //   data = new byte[1024];
      //   recv = ns.Read(data, 0, data.Length);
      //   stringData = Encoding.ASCII.GetString(data, 0, recv);
      //   Console.WriteLine(stringData);
      //}
      //Console.WriteLine("Disconnecting from server...");
      //ns.Close();
      //server.Close();
   


 
        }
    }
}


/*
 * 
   
       //this works in main but needs a loop
            try {
            TcpClient tcpclnt = new TcpClient();
            Console.WriteLine("Connecting.....");
            
            tcpclnt.Connect("127.0.0.1",50001);
            // use the ipaddress as in the server program
            
            Console.WriteLine("Connected");
            Console.Write("Enter the string to be transmitted : ");
            
            String str=Console.ReadLine();
            NetworkStream stm = tcpclnt.GetStream();
                        
            ASCIIEncoding asen= new ASCIIEncoding();
            byte[] ba=asen.GetBytes(str);
            Console.WriteLine("Transmitting.....");
            
            stm.Write(ba,0,ba.Length);
            
            byte[] bb=new byte[1024];
            int k=stm.Read(bb,0,100);
            
            for (int i=0;i<k;i++)
                Console.Write(Convert.ToChar(bb[i]));
            
            tcpclnt.Close();
        }
        
        catch (Exception e) {
            Console.WriteLine("Error..... " + e.StackTrace);
        }
    
 * */



//int a, b;
//System.Console.Title = "Muganda's Console Input Program";
//String input;

//while (true)
//{
//    System.Console.Write("Enter a number: ");
//    input = System.Console.ReadLine();
//    if (input == "bye") break;
//    a = int.Parse(input.Trim());
//    System.Console.Write("Enter another number: ");
//    input = System.Console.ReadLine();
//    b = int.Parse(input.Trim());
//    System.Console.WriteLine("The sum of {0} and {1} is {2}",
//    a, b, a + b);
//}