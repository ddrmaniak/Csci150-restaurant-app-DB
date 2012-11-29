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
        List<GetRestaurant.Restaurant> getRestaurant();
       
    }
}
