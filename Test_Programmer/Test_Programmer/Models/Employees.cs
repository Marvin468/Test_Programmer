using System;
using System.Collections.Generic;

namespace Test_WebAPI.Models
{
    public partial class Employees
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int? PositionId { get; set; }
        public int? ProfileId { get; set; }

        public virtual Positions Position { get; set; }
        public virtual Profiles Profile { get; set; }
    }
}
