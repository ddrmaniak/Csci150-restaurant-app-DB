using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;

namespace FoodAppService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "GetRestuarant" in code, svc and config file together.
    public class GetRestuarant : IGetRestuarant
    {
        public List<Restuarant> GetAllRestuarantMethod()
        {
            List<Restuarant> mylist = new List<Restuarant>();

            using (SqlConnection conn = new SqlConnection("server=(local);database=FoodApp;Integrated Security=SSPI;"))
            {
                conn.Open();

                string cmdStr = String.Format("Select RID, Resturant_name, address, average_rating, Notes, City, State from Restuarant");
                SqlCommand cmd = new SqlCommand(cmdStr, conn);
                SqlDataReader rd = cmd.ExecuteReader();

                    if (rd.HasRows)
                    {
                        while (rd.Read())
                            mylist.Add(new Restuarant(rd.GetDecimal(0), rd.GetString(1), rd.GetString(2), rd.GetDouble(3), rd.GetString(4), rd.GetString(5), rd.GetString(6)));
                    }
                conn.Close();
            }

            return mylist;
        }
    }
    [DataContract]
    public class Restuarant
    {
        [DataMember]
        public decimal RID { get; set; }
        [DataMember]
        public string Resturant_name { get; set; }
        [DataMember]
        public string address { get; set; }
        [DataMember]
        public double average_rating { get; set; }
        [DataMember]
        public string Notes { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string State { get; set; }
        public Restuarant(decimal id, string rest_name, string add, double avg_rating, string note, string rcity, string rstate)
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
