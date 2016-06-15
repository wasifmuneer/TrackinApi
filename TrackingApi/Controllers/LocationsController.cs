using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrackingApi.Models;
using TrackingApi.Repositories;

namespace TrackingApi.Controllers
{
    [RoutePrefix("api/Locations")]
    [Authorize]
    public class LocationsController : ApiController
    {
        private readonly IFrequentLocationsRepository _locations=null;

        public LocationsController()
        {
            _locations = new FrequentLocationsRepository();

        }

        //POST api/Locations/Post
        [Route("Post")]
        public void Post(FrequentLocationsModel model)
        {
            if(!ModelState.IsValid)
            {
                return;
            }
            _locations.Insert(model);
        }
    }
}
