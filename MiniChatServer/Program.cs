using System;

namespace MiniChatServer
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
