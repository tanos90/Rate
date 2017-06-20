using Rate.Models;
using Rate.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Rate.Controllers
{
    [Route("api/[controller]")]
    public class ReviewController : ApiController
    {
        private readonly IReviewService _reviewService;
        private readonly IFlickService _flickService;

        public ReviewController()
        {

        }
        public ReviewController(IReviewService reviewService, IFlickService flickService)
        {
            _reviewService = reviewService;
            _flickService = flickService;

        }
        [HttpGet]
        [Route("api/reviews")]
        public ICollection<ReviewDTO> GetReviews()
        {

            ICollection<ReviewDTO> reviews = _reviewService.FetchAll();
            return reviews;
        }

        [HttpPost]
        [Route("api/review")]
        public IHttpActionResult Post(ReviewDTO review)
        {
            if (review != null)
            {
                review.Flick = _flickService.FindBy(flck => flck.Id == review.Flick_Id).FirstOrDefault();
                if (review.Flick != null)
                {
                    review.Flick.ImdbId = review.Flick_Id;
                    _reviewService.Add(review);
                    return Ok();
                }
            }
            return BadRequest();

        }
    }

}