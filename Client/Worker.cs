using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MiniChatClient
{
    public class Worker
    {
        public void Start()
        {
            Console.WriteLine("Client");
            
                using (TcpClient clientSocket = new TcpClient("localhost", 7070))
                using (StreamReader reader = new StreamReader(clientSocket.GetStream()))
                using (StreamWriter writer = new StreamWriter(clientSocket.GetStream()))
                {
                    while (true)
                    {

                        string line = Console.ReadLine();
                        writer.WriteLine(line);

                        writer.Flush();

                        string myLine = reader.ReadLine();
                        Console.WriteLine(myLine);

                        if (line == "STOP" || myLine == "STOP")
                        {
                            clientSocket.Close();
                        }
                }
                }
                    

                    
                
                    
            

            




        }
    }
}
