using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace OtakuClub.WebService
{
    /// <summary>
    /// Summary description for DisplayAllMembersWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class DisplayAllMembersWS : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public DataTable getAllMembers()
        {
            return runQuery("SELECT * FROM dbo.AspNetUsers ", "dbo.AspNetUsers");
        }

        private DataTable runQuery(String query, String tableName)
        {
            string constr = "Server = tcp:otakusocietydb.database.windows.net,1433; Data Source = otakusocietydb.database.windows.net; Initial Catalog = viaotakusociety_db; Persist Security Info = False; User ID = peterkudryskAdmin; Password = IamJustTestingThisShit1; Pooling = False; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            dt.TableName = tableName;
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }
    }
}
