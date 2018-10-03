namespace Lib.Models
{
    public class Server
    {
        public int Id { get; set; }

        public string Domen { get; set; }

        public string Name { get; set; }

        public ServerType Type { get; set; }
    }

    public enum ServerType
    {
        Web = 1,
        Gaming,
        Media,
        Email,
        Users,
    }
}
