using DAL.Models;
using Rate.Models;
using Rate.Repository.Abstract;
using Rate.Repository.Base;
using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rate.Services.Abstract
{
    public class ReviewService : ModelServiceBase<RateflixContext, Review, ReviewDTO>, IReviewService
    {
        private readonly IFlickService _flickService;
        public ReviewService(RateflixContext context, Action<IMapperConfigurationExpression> mapper)
            : base(context, mapper)
        {
        }

    }
}
