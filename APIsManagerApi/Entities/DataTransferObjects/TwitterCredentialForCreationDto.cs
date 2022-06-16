using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{

    public class TwitterCredentialForCreationDto
    {
        [Key]
        public int IdUser { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string CONSUMER_KEY { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string CONSUMER_SECRET { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string ACCESS_TOKEN { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string ACCESS_TOKEN_SECRET { get; set; }
    }
}
