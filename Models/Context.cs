using Microsoft.EntityFrameworkCore;

namespace ProjectCore.Models
{
	public class Context : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=BARANPC\\SQLEXPRESS; database=UnitDB; integrated security=true; TrustServerCertificate=true");
		}
        public DbSet<Unit> Units { get; set; }
        public DbSet<Staff> Staffs { get; set; }
		public DbSet<Admin> Admins { get; set; }
    }
}