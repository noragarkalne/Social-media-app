using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SocialApp.Core.Models;

namespace Social_app.Models
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public bool FriendRequest { get; set; } = false;
        public bool Online { get; set; } = false;
    }
}