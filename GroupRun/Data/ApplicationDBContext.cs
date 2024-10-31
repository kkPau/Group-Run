using System;
using GroupRun.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GroupRun.Data
{
	public class ApplicationDBContext : IdentityDbContext<AppUser>
	{
		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
		{

		}

		public DbSet<Race> Races { get; set; }

		public DbSet<Club> Clubs { get; set; }

		public DbSet<Address> Addresses { get; set; }
	}
}

