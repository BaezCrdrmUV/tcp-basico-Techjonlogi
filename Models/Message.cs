namespace tcp_com
{
    public class Message
    {
        public string MessageString { get; set; }
        public string User { get; set; }
        public string Hora { get; set; }

        public Message()
        {
            MessageString = "";
            User = "Default";
            Hora = "";
        }

        public Message(string messageString, string user,string hora)
        {
            this.MessageString = messageString;
            this.User = user;
            this.Hora = hora;
        }
    }
}