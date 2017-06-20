using DAL.Models;

namespace Rate.Repository.Concrete
{
    public class FlickRepository : GenericRepository<RateflixContext, Flick>
    {
        public FlickRepository() : base(new RateflixContext())
        {

        }

    }
}
