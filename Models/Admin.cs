using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectCore.Models
{
	public class Admin
	{
        [Key]
        public int AdminID { get; set; }
        [Column(TypeName ="Varchar(20)")]

        public string User { get; set; }
		[Column(TypeName = "Varchar(10)")]

		public string Password { get; set; }
    }
}
