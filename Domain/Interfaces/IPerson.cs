using Domain.Entities;
using Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPerson
    {
        int Id { get; set; }
        string Name { get; set; }
        string Password { get; set; }
        string Document {  get; set; }
        int Type { get; set; }
        PersonRoles Roles { get; set; }


    }
}
