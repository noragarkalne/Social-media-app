using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApp.Service.Exceptions
{
    public class EmptyEmailException : Exception
    {
        public EmptyEmailException() : base("Email can't be empty, please fill it!")
        {

        }
    }
}
