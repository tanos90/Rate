using DAL.Models;
using Rate.Models;
using Rate.Repository.Abstract;

namespace Rate.Services.Abstract
{
    public interface IFlickService : IModelRepository<Flick, FlickDTO>
    {
        FlickDTO FetchByTitle(string title);
    }
}
