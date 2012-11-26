using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;

namespace FoodAppService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "GetFood" in code, svc and config file together.
    public class GetFood : IGetFood
    {
        public List<Food> GetAllFoodMethod()
        {
            List<Food> mylist = new List<Food>();

            using (SqlConnection conn = new SqlConnection("server=(local);database=FoodApp;Integrated Security=SSPI;"))
            {
                conn.Open();

                string cmdStr = String.Format("Select RID, FID, food, spicy_rating, Notes from Restuarant_food");
                SqlCommand cmd = new SqlCommand(cmdStr, conn);
                SqlDataReader rd = cmd.ExecuteReader();

                    if (rd.HasRows)
                    {
                        while (rd.Read())
                            mylist.Add(new Food(rd.GetDecimal(0), rd.GetDecimal(1), rd.GetString(2), rd.GetDouble(3)));
                    }
                conn.Close();
            }

            return mylist;
        }
    }
    [DataContract]
    public class Food
    {
        [DataMember]
        public decimal RID { get; set; }
        [DataMember]
        public decimal FID { get; set; }
        [DataMember]
        public string food { get; set; }
        [DataMember]
        public double spicy_rating { get; set; }
        
        public Food(decimal r_id, decimal f_id, string f_food, double s_rating)
        {
            RID = r_id;
            FID = f_id;
            food = f_food;
            spicy_rating = s_rating;
        }
    }
}
