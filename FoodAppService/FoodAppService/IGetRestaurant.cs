using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using foodApp;
using foodApp.Controllers;
using foodApp.Models;
using FoodAppService;
using System.Data.Entity;
using System.Data.EntityClient;
using System.Data.EntityModel;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Security.Principal;
using System.Diagnostics.CodeAnalysis;
namespace FoodAppService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IGetRestaurant" in both code and config file together.
    [ServiceContract]
    public interface IGetRestaurant
    {
        [OperationContract]

        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "json/Restaurants")]
        //method
        List<FoodAppService.GetRestaurant.Restaurant> getRestaurant();
       
    }
}
