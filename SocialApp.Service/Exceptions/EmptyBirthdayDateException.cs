using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApp.Service.Exceptions
{
    public class EmptyBirthdayDateException : Exception
    {
        public EmptyBirthdayDateException() : base("Birthday is obligatory field, please fill it!")
        {

        }
    }
}
