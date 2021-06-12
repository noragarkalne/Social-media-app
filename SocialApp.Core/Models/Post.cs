using System;

namespace SocialApp.Core.Models
{
    public class Post: Entity
    {
        public int UserId { get; set; }
        public string DateCreated { get; set; }
        public string Picture { get; set; }
        public string Text { get; set; }
        public int Like { get; set; } = 0;
        public int Dislike { get; set; } = 0;
    }
}