using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please insert a name for the category")]
        public string Name { get; set; }
    }
}
