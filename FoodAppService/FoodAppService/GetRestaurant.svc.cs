using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;
using System.Data.SqlClient;
using System.ComponentModel;
using foodApp.Models;
using foodApp;
using foodApp.Controllers;
using System.Data.Common;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityModel;
using System.Data.EntityClient;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Services;
namespace FoodAppService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "GetRestaurant" in code, svc and config file together.
    public class GetRestaurant : IGetRestaurant
    {
        //public int p;
        public List<Restaurant> getRestaurant()
        {
           
            foodApp.Models.foodAppEntities context = new foodApp.Models.foodAppEntities();
            List<RestaurantEntity> restaurantEntity = context.RestaurantEntities.Select(n => n).ToList<RestaurantEntity>();/*(from p in context.RestaurantEntities
                                    select p).ToList();*/
            Restaurant temp;
            List<Restaurant> rest = new List<Restaurant>();
            foreach(var p in restaurantEntity)
            {
                temp = new Restaurant(p.RID, p.Restaurant_name, p.address, p.average_rating, p.Notes, p.City, p.State);
                rest.Add(temp);
            }
            context.Dispose();
            if (rest/*restaurantEntity*/ != null)
                return rest;//TranslateRestaurantEntityToRestaurant(restaurantEntity);
            else
                throw new Exception("Invalid Product Id");
        }
        /*private List<Restaurant> TranslateRestaurantEntityToRestaurant(List<foodApp.Models.RestaurantEntity> restaurantEntity)
        {
            List<Restaurant> rest = new List<Restaurant>();
            Restaurant temp;
            foreach (RestaurantEntity p in restaurantEntity)
            {
                temp = new Restaurant(p.RID, p.Resturant_name, p.address, p.average_rating, p.Notes, p.City, p.State);
                rest.Add(temp);
            }
            return rest;
        }*/
        /* public List<Restaurant> GetAllRestaurantMethod()
         {
             List<Restaurant> mylist = new List<Restaurant>();

             using (SqlConnection conn = new SqlConnection("server=(local);database=FoodApp;Integrated Security=SSPI;"))
             {
                 conn.Open();

                 string cmdStr = String.Format("Select RID, Resturant_name, address, average_rating, Notes, City, State from Restaurant");
                 SqlCommand cmd = new SqlCommand(cmdStr, conn);
                 SqlDataReader rd = cmd.ExecuteReader();

                     if (rd.HasRows)
                     {
                         while (rd.Read())
                             mylist.Add(new Restaurant(rd.GetGuid(0), rd.GetString(1), rd.GetString(2), rd.GetDouble(3), rd.GetString(4), rd.GetString(5), rd.GetString(6)));
                     }
                 conn.Close();
             }

             return mylist;
         }
     }*/
        [DataContract]
        public class Restaurant
        {
            [DataMember]
            public Guid RID { get; set; }
            [DataMember]
            public string Resturant_name { get; set; }
            [DataMember]
            public string address { get; set; }
            [DataMember]
            public double? average_rating { get; set; }
            [DataMember]
            public string Notes { get; set; }
            [DataMember]
            public string City { get; set; }
            [DataMember]
            public string State { get; set; }
            public Restaurant(Guid id, string rest_name, string add, double? avg_rating, string note, string rcity, string rstate)
            {
                RID = id;
                Resturant_name = rest_name;
                address = add;
                average_rating = avg_rating;
                Notes = note;
                City = rcity;
                State = rstate;
            }
        }
    }
}
