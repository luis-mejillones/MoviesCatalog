using System.ComponentModel.DataAnnotations;

namespace MoviesCatalog.Domain
{
    public class Miniature
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
