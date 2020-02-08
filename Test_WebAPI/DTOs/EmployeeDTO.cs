using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_WebAPI.Models;

namespace Test_WebAPI.DTOs
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int? PositionId { get; set; }
        public int? ProfileId { get; set; }

        public Positions Position { get; set; }
        public Profiles Profile { get; set; }
    }
}
