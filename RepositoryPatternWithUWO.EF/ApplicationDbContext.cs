using System;
using Microsoft.EntityFrameworkCore;
using RepositoryPatternWithUWO.Core.Models;

namespace RepositoryPatternWithUWO.EF
{
	public class ApplicationDbContext:DbContext
	{

       public DbSet<Author> Authors { set; get; }

       public DbSet<Book> Books { set; get; }

       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
		{
		}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Author>().HasMany(a => a.Books).WithOne(b => b.Author).HasForeignKey(b => b.AuthorId).HasPrincipalKey(a=>a.Id);


        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    optionsBuilder.UseSqlServer("server=localhost;database=EFFCore;user=SA;password=MyStrongPass123 ;TrustServerCertificate=true");
        //    base.OnConfiguring(optionsBuilder);
        //}

    }
}


