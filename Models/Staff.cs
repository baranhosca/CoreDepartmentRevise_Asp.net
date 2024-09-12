using System.ComponentModel.DataAnnotations;

namespace ProjectCore.Models
{
	public class Staff 
	{
        [Key]
        public int StaffID { get; set; }
        public string StaffName { get; set; }
        public string StaffSurname { get; set; }
        public string StaffCity { get; set; }


        public int UnitID { get; set; }
        public Unit Unit { get; set; }
    }
}