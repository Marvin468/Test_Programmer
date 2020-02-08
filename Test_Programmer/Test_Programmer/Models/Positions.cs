using System;
using System.Collections.Generic;

namespace Test_WebAPI.Models
{
    public partial class Positions
    {
        public Positions()
        {
            Employees = new HashSet<Employees>();
        }

        public int PositionId { get; set; }
        public string PositionName { get; set; }

        public virtual ICollection<Employees> Employees { get; set; }
    }
}
