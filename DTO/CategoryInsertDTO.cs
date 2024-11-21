using System.ComponentModel.DataAnnotations;

namespace Project.DTO
{
    public class CategoryInsertDTO
    {
        [Required(ErrorMessage = "Please enter a category")]
        public string Name { get; set; }
    }
}
