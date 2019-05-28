using System;
using ZeroMQ;

namespace Server
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var endpoint = "tcp://192.168.60.87:5560";
            
            using (var context = new ZContext())
            using (var socket = new ZSocket(context, ZSocketType.REP))
            {
                Console.WriteLine($"Criando endpoint {endpoint}");
                socket.Connect(endpoint);
                Console.WriteLine("Aguardando mensagens");
                
                while (true)
                {
                    var message = socket.ReceiveFrame();
                    Console.WriteLine("Processando mensagem: " + message.ToString());
                    var reply = new ZFrame("resposta:" + message.ToString());
                    
                    socket.Send(reply);
                }
                
                Console.ReadLine();
            }
        }
    }
}