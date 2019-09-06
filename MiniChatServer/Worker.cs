using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MiniChatServer
{
    public class Worker
    {

        public void Start()
        {
            IPAddress IP = IPAddress.Loopback;
            int port = 7070;

            TcpListener listner = new TcpListener(IP, port);


            try
            {

                Console.WriteLine("SERVER");

                listner.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           


            while (true)
            {

                TcpClient socket = listner.AcceptTcpClient();
                //Starter ny tråd
                Task.Run(() =>
                { //indsætter en metode (delegate)
                    TcpClient tempSocket = socket;
                    DoClient(tempSocket);

                });

            }



        }

        public void DoClient(TcpClient tempsocket)
        {

            
                using (StreamReader reader = new StreamReader(tempsocket.GetStream()))
                using (StreamWriter writer = new StreamWriter(tempsocket.GetStream()))
                {


                    while (true)
                    {
                        string line = reader.ReadLine();
                        writer.WriteLine(line);
                        Console.WriteLine(line);
                        string myLine = Console.ReadLine();
                        writer.WriteLine(myLine);
                        Console.WriteLine(myLine);
                        writer.Flush();

                        if (myLine == "STOP" || line == "STOP")
                        {
                            tempsocket?.Close();

                        }
                    }
                   


                }
            
                
            
            
        }
    }
}
