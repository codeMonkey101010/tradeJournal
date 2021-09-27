using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FrameworkDAL
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("Data Source = sowmya.cgievgljj5qy.us-east-2.rds.amazonaws.com,1433;Initial Catalog = sowmya; User ID = Trader; Password=Trader10;")
        {
        }

        public virtual DbSet<Trade> Trades { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
