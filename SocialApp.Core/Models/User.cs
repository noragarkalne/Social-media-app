using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApp.Core.Models
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; } = null;
        public DateTime BirthDate { get; set; } 
        public string Email { get; set; }
        public string Password { get; set; }
        public string Interests { get; set; }
        public string Image { get; set; }
        public bool FriendRequest { get; set; } = false;
        public bool Online { get; set; } = false;
        public virtual Post Post { get; set; }
    }
}
