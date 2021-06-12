using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApp.Service.Exceptions
{
    public class FutureDateBirthdayException : Exception
    {
        public FutureDateBirthdayException
            () : base("Birthday date can't be in future, please correct it!")
        {

        }
    }
}
