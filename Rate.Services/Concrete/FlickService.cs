using AutoMapper;
using DAL.Models;
using Newtonsoft.Json;
using Rate.Models;
using Rate.Repository.Base;
using Rate.Services.Abstract;
using Rate.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Rate.Services.Concrete
{
    public class FlickService : ModelServiceBase<RateflixContext, Flick, FlickDTO>, IFlickService
    {
        public FlickService(RateflixContext context, Action<IMapperConfigurationExpression> mapper)
            : base(context, mapper)
        {

        }

        public FlickDTO FetchByTitle(string title)
        {

            title = title.ToLower().Trim();
            FlickDTO flick = FindBy(flickEntity => flickEntity.Title == title).FirstOrDefault();
            if (flick != null)
            {
                return flick;
            }
            else
            {
                flick = FetchFromAPI(title);
                Add(flick);
                return flick;
            }

        }

        private FlickDTO FetchFromAPI(string title)
        {
            string OMDBApiUrl = $"https://www.omdbapi.com/?t={title}&plot=short&r=json";
            using (HttpClient httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(OMDBApiUrl).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    string flickResponse = response.Content.ReadAsStringAsync().Result;
                    if (!string.IsNullOrEmpty(flickResponse))
                    {
                        return JsonConvert.DeserializeObject<FlickDTO>(flickResponse);
                    }
                }
                return null;
            }
        }


    }
}
