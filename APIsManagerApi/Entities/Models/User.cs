using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities.Models
{
    
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Password { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string FullName { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Description { get; set; }
    }
}
