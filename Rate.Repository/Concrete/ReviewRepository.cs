using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rate.Repository.Concrete
{
    public class ReviewRepository : GenericRepository<RateflixContext,Review>
    {

        public ReviewRepository() : base(new RateflixContext())
        {

        }

    }
}
