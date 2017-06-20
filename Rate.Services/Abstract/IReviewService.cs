using DAL.Models;
using Rate.Models;
using Rate.Repository.Abstract;

namespace Rate.Services.Abstract
{
    public interface IReviewService : IModelRepository<Review, ReviewDTO>
    {
    }
}
