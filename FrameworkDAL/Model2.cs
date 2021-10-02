using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FrameworkDAL
{
    public partial class Model2 : DbContext
    {
        public Model2()
            : base("name=Model2")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Trade> Trades { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trade>()
                .Property(e => e.Result)
                .IsUnicode(false);

            modelBuilder.Entity<Trade>()
                .Property(e => e.Category)
                .IsUnicode(false);
        }
    }
}
