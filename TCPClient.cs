using System;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;

namespace tcp_com
{
    public class TCPClient
    {
        TcpClient client;
        string IP;
        int Port;
        string Username;

        public TCPClient(string ip, int port, string username)
        {
            try
            {
                client = new TcpClient();
                this.IP = ip;
                this.Port = port;
                this.Username = username;
            }
            catch (System.Exception)
            {
                
            }
        }

        public void Chat()
        {
            client.Connect(IP, Port);   
            Console.WriteLine("Conectado");

            while(true)
            {
                try
                {
                    string msg = Console.ReadLine();
                    DateTime horaCompuesta = DateTime.Now;
                    int hora = horaCompuesta.Hour;
                    int minuto = horaCompuesta.Minute;
                    string horareal = hora.ToString() + ":" + minuto.ToString();
                    Message newMessage = new Message(msg, Username,horareal);
                    string jsonMessage = JsonConvert.SerializeObject(newMessage);

                    // Envío de datos
                    var stream = client.GetStream();
                    byte[] data = Encoding.UTF8.GetBytes(jsonMessage);
                    Console.WriteLine("Enviando datos...");
                    stream.Write(data, 0, data.Length);

                    // Recepción de mensajes
                    byte[] package = new byte[1024];
                    stream.Read(package);
                    string serverMessage = Encoding.UTF8.GetString(package);
                    Console.WriteLine(serverMessage);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error {0}", ex.Message);
                }
            }
        }
    }
}