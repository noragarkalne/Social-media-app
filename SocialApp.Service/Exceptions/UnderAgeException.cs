using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApp.Service.Exceptions
{
    public class UnderAgeException :Exception
    {
        public UnderAgeException() : base("To register on this site, you should be at least 13 years old, so go to your parents and ask for permision!!!")
        {

        }
    }
}
