using System.ComponentModel.DataAnnotations;

namespace YumBlazor.DTO
{
    public class CategoryInsertDTO
    {
        [Required(ErrorMessage = "Please enter a category")]
        public string Name { get; set; }
    }
}
