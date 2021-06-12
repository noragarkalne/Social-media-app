using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApp.Service.Exceptions
{
    public class EmptyPasswordException : Exception
    {
        public EmptyPasswordException() : base("Please fill in password!")
        {
            
        }
    }
}
