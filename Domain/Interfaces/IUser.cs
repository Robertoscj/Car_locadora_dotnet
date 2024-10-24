using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUser
    {
        string CPF {get;}
        DateTime? Birthday { get; set;} 
        int ?AddressId { get; set;}
    }
}
