using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectCore.Models
{
	public class Unit
	{
        [Key]
        public int UnitID { get; set; }
        public string UnitName { get; set; }
        public IList<Staff> Staffs { get; set; }
    }
}