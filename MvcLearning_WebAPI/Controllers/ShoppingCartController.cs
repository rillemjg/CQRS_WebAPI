using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dtos;
using Queries;

namespace MvcLearning_WebAPI.Controllers
{
    public class ShoppingCartController : ApiController
    {
        // GET api/shoppingcart
        public IEnumerable<string> Get()
        {
            return new ShoppingCartQuery().GetAllShoppingCartElements();
        }

        //// GET api/shoppingcart/5
        //public ShoppingCartElement Get(int id)
        //{
        //    // TODO: przerobić na użycie query
        //    return ShoppingCartRepository.Get(id);
        //}

        //// POST api/shoppingcart
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/shoppingcart/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/shoppingcart/5
        //public void Delete(int id)
        //{
        //}
    }
}
