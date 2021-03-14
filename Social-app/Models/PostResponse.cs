using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Social_app.Models
{
    public class PostResponse
    { 
        public int UserId { get; set; }
        public string DateCreated { get; set; }
        public string Picture { get; set; }
        public string Text { get; set; }
        public int Like { get; set; } = 0;
        public int Dislike { get; set; } = 0;
    }
}