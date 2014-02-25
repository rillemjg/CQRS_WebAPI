using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dtos.Additional;

namespace MvcLearning_WebAPI.ViewModels
{
    public class ShoppingCartWithGuidViewModel
    {
        public List<ShoppingCartNamedElement> ShoppingCartElements { get; set; }
        public string Guid { get; set; }
    }
}