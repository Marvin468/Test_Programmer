using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_WebAPI.Models;

namespace Test_WebAPI.DTOs
{
    public class ProfileDTO
    {
        public int ProfileId { get; set; }
        public string ProfileName { get; set; }

        public virtual IList<Employees> Employees { get; set; }
    }
}
