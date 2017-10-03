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
        private IFlickAPI _flickAPI;
        public FlickService(RateflixContext context, Action<IMapperConfigurationExpression> mapper,IFlickAPI flickAPI)
            : base(context, mapper)
        {
            _flickAPI = flickAPI;
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
                flick = _flickAPI.FetchFlickByTitle(title);
                Add(flick);
                return flick;
            }

        }


    }
}
