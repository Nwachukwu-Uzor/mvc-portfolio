using System.ComponentModel.DataAnnotations;

namespace Portfolio.MVC.Models
{
    public class EmailViewModel
    {
        [Required]
        public string Subject { get; set; }
        public string Phone { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
