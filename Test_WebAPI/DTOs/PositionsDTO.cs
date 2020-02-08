using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_WebAPI.Models;

namespace Test_WebAPI.DTOs
{
    public class PositionsDTO
    {
        public int PositionId { get; set; }
        public string PositionName { get; set; }

        public virtual IList<Employees> Employees { get; set; }
    }
}
