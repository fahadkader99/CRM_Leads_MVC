using CRM_Leads_MVC.Models;
using System.Data;
using System.Data.SqlClient;
namespace CRM_Leads_MVC.Data
{
    public class LeadRepository
    {
        /*
         * This data layer class hold :
         * - the DB connection string 
         * - all the function to perform the CRUD operation
         *  System.Data.SqlClient - nuGet package needs to be downloaded
         */

        private SqlConnection _connection;

        public LeadRepository()
        {
            // Update connection string based on your local SSMS config 
            string connStr = "server=FAHAD_KADER;database=CRMLeads;Integrated Security=true;TrustServerCertificate=true;";

            _connection = new SqlConnection(connStr);
        }

        /*
         * This function is fetching all the records from DB to FrontEnd
         */
        public List<LeadsEntity> GetAllLeads()
        {
            // Empty list of Lead Entity
            List<LeadsEntity> leadListEntity = new List<LeadsEntity>();

            // Calling the 'GetAllLeads' store proc
            SqlCommand cmd = new SqlCommand("GetAllLeads", _connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            foreach(DataRow dr in dataTable.Rows)
            {
                // Looping tjrough DataTable row & adding each element/value to the Lead Entity list

                leadListEntity.Add(new LeadsEntity
                {
                    Id = Convert.ToInt32(dr["id"]),
                    LeadDate = Convert.ToDateTime(dr["LeadDate"]),
                    Name = dr["name"].ToString(),
                    EmailAddress = dr["EmailAddress"].ToString(),
                    Mobile = dr["Mobile"].ToString(),
                    LeadSource = dr["LeadSource"].ToString(),
                    LeadStatus = dr["LeadStatus"].ToString(),
                    NextFollowUpDate = Convert.ToDateTime(dr["NextFollowUpDate"]),

                });
            }

            return leadListEntity;

        }


    }
}
