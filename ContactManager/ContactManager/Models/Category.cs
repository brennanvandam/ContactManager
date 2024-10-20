using System.ComponentModel.DataAnnotations;

namespace ContactManager.Models
{
    public class Category
    {
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Please enter a category name.")]
        public string CategoryName { get; set; } = string.Empty;
    }
}
