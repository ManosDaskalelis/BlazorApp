using System.ComponentModel.DataAnnotations;

namespace Project.DTO
{
    public class CategoryUpdateDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a category")]
        public string Name { get; set; }
    }
}
