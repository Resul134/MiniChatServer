using System;
using MiniChatClient;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Worker work = new Worker();
            work.Start();
        }
    }
}
