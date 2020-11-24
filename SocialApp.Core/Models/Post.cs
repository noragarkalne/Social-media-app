using System;

namespace SocialApp.Core.Models
{
    public class Post: Entity
    {
        public int UserId { get; set; }
        public DateTime DateCreated { get; set; }
        public string Picture { get; set; }
        public string Text { get; set; }
        public bool Like { get; set; } = false;
        public bool Dislike { get; set; } = false;
    }
}