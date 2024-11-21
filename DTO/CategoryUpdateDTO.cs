using System.ComponentModel.DataAnnotations;

namespace YumBlazor.DTO
{
    public class CategoryUpdateDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a category")]
        public string Name { get; set; }
    }
}
