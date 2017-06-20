using System.Data.Entity;
using DAL.Models;


namespace Rate
{
    public class RateflixContext : DbContext
    {
        public RateflixContext() : base("RateConnection")
        {

        }
        public DbSet<Flick> Flicks { get; set; }
        public DbSet<Review> Reviews { get; set; }

    }
}
