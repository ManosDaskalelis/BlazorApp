using System.ComponentModel.DataAnnotations;

namespace Project.Data
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a category name")]
        public string Name { get; set; }
    }
}
