using Rate.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rate.Services.Abstract
{
    public interface IFlickAPI
    {
        FlickDTO FetchFlickByTitle(string title);
        Collection<FlickDTO> FetchFlicksByTitle(string title);
    }
}
