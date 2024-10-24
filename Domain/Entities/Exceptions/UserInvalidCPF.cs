using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Exceptions
{
    [Serializable]
    public class UserInvalidCPF : Exception
    {
        public UserInvalidCPF(string message) : base(message) { }

    }
}
