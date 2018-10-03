using System.ComponentModel.DataAnnotations;

namespace Lib.Models
{
    public class Server
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле 'Домен' - обязательное!")]
        [StringLength(100, ErrorMessage = "Недопустимая длинна домена!", MinimumLength = 2)]
        [Url]
        public string Domen { get; set; }

        [Required(ErrorMessage = "Поле 'Имя' - обязательное!")]
        [StringLength(100, ErrorMessage = "Недопустимая длинна имени!", MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
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
