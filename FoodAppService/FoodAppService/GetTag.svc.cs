using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;

namespace FoodAppService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "GetTag" in code, svc and config file together.
    public class GetTag : IGetTag
    {
        public List<Tag> GetAllFoodMethod()
        {
            List<Tag> mylist = new List<Tag>();

            using (SqlConnection conn = new SqlConnection("server=(local);database=FoodApp;Integrated Security=SSPI;"))
            {
                conn.Open();

                string cmdStr = String.Format("Select RID, tag from restuarant_tag");
                SqlCommand cmd = new SqlCommand(cmdStr, conn);
                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.HasRows)
                {
                    while (rd.Read())
                        mylist.Add(new Tag(rd.GetDecimal(0), rd.GetString(1)));
                }
                conn.Close();
            }

            return mylist;
        }
    }
    [DataContract]
    public class Tag
    {
        [DataMember]
        public decimal RID { get; set; }
        [DataMember]
        public string tag { get; set; }

        public Tag(decimal r_id,string r_tag)
        {
            RID = r_id;
            tag = r_tag;
            
        }
    }
}
