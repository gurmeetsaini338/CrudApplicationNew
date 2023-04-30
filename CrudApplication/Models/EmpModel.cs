using System.ComponentModel.DataAnnotations;

namespace CrudApplication.Models
{
    public class EmpModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="* Name can't be blank")]  
        public string Name { get; set; }
        [Required(ErrorMessage = "* City can't be blank")]
        public string City { get; set; }
        [Required(ErrorMessage = "* State can't be blank")]
        public string State { get; set; }
        [Required]
        public string Salary { get; set; }   

    }
}
