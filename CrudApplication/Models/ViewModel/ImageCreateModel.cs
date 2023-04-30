using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace CrudApplication.Models.ViewModel
{
    public class ImageCreateModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name ="Choose Image")]
        public IFormFile ImagePath { get; set; }
    }
}
