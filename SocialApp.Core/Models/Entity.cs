using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialApp.Core.Interfaces;

namespace SocialApp.Core.Models
{
    public class Entity: IEntity
    {
        public int Id { get; set; }
    }
}
