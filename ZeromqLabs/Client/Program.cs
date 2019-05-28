using System;
using ZeroMQ;

namespace Client
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var endpoint = "tcp://191.232.181.23:5560";
            
            using (var context = new ZContext())
            using (var socket = new ZSocket(context, ZSocketType.REQ))
            {
                Console.WriteLine($"Conectando-se ao endpoint {endpoint}");
                
                socket.Connect(endpoint);
                var count = 1;
                
                while (count < 10001)
                {
                    var frame = new ZFrame(count.ToString());
                    socket.Send(frame);
                    
                    var reply = socket.ReceiveFrame();
                    Console.WriteLine($"Resposta {reply.ToString()} recebida");
                    
                    count++;
                }

                Console.ReadLine();
            }
        }
    }
}