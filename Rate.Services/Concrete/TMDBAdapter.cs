using Rate.Models;
using Rate.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.TMDb;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TMDbLib.Client;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Search;

namespace Rate.Services.Concrete
{
    public class TMDBAdapter : IFlickAPI
    {
        public TMDbClient tmdbClient { get; set; }
        public TMDBAdapter()
        {
            tmdbClient = new TMDbClient("9a74fbba6582772f94124b4536a02bc3");
        }
        
        public FlickDTO FetchFlickByTitle(string title)
        {
            SearchContainer<SearchMovie> results = tmdbClient.SearchMovieAsync(title).Result;
            SearchMovie firstMovie = results.Results.FirstOrDefault();
            if (firstMovie != null)
            {
                return MapSearchResultToDTO(firstMovie);
            }
            return null;
        }

        public Collection<FlickDTO> FetchFlicksByTitle (string title)
        {
            SearchContainer<SearchMovie> results = tmdbClient.SearchMovieAsync(title).Result;
            Collection<FlickDTO> flicks = new Collection<FlickDTO>();
            results.Results.ForEach(result => flicks.Add(MapSearchResultToDTO(result)));
            return flicks;

        }

        private FlickDTO MapSearchResultToDTO (SearchMovie result)
        {
            FlickDTO flick = new FlickDTO
            {
                Title = result.Title,
                Poster = "http://image.tmdb.org/t/p/w342" + result.PosterPath,
                Year = result.ReleaseDate.Value.Year.ToString(),
                Id = result.Id.ToString()
            };
            return flick;
        } 

     
    }
}
