using System.ComponentModel.DataAnnotations;

namespace Lib.Models
{
    public class Server
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Incorrect domen lenght", MinimumLength = 2)]
        [Url(ErrorMessage = "Not URL")]
        public string Domen { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Incorrect name lenght", MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Incorrect server type lenght", MinimumLength = 2)]
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
