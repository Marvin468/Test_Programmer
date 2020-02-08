using System;
using System.Collections.Generic;

namespace Test_WebAPI.Models
{
    public partial class Profiles
    {
        public Profiles()
        {
            Employees = new HashSet<Employees>();
        }

        public int ProfileId { get; set; }
        public string ProfileName { get; set; }

        public virtual ICollection<Employees> Employees { get; set; }
    }
}
