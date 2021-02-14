using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApp.Service.Exceptions
{
    public class EmptySurNameException : Exception
    {
        public EmptySurNameException() : base("Surname can't be empty, please fill it!")
        {

        }
    }
}
