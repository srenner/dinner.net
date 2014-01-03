using dinner.net.DAL;
using dinner.net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace dinner.net.WebAPI
{
    public class RecentMealsController : ApiController
    {
        // GET api/<controller>
        public List<Meal> Get()
        {
            List<Meal> recentMeals;
            using(var context = new DinnerContext())
            {
                context.Configuration.LazyLoadingEnabled = false;
                recentMeals = context.Meals.OrderByDescending(x => x.LastAte).Take(5).ToList();
            }

            return recentMeals;
            //List<Meal> recentMeals;

            //using (var context = new DinnerContext())
            //{
            //    recentMeals = context.Meals.OrderByDescending(x => x.LastAte).Take(5).ToList();
            //}
            //return recentMeals;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}