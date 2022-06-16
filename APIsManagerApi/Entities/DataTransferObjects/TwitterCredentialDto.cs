using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class TwitterCredentialDto
    {
        public int IdUser { get; set; }
        public string CONSUMER_KEY { get; set; }
        public string CONSUMER_SECRET { get; set; }
        public string ACCESS_TOKEN { get; set; }
        public string ACCESS_TOKEN_SECRET { get; set; }
    }
}
