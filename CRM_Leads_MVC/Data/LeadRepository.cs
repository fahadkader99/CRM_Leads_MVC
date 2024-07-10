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
         * - all the procedure related function to perform the CRUD operation
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

            // Passing store proc name 'GetAllLeads' & the connection
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

        /*
        * This function is adding records to DB
        */
        public bool AddLead(LeadsEntity lead)
        {
            // Passing store proc name 'AddLead' & the connection
            SqlCommand cmd = new SqlCommand("AddLead", _connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@LeadDate", lead.LeadDate);
            cmd.Parameters.AddWithValue("@Name", lead.Name);
            cmd.Parameters.AddWithValue("@EmailAddress", lead.EmailAddress);
            cmd.Parameters.AddWithValue("@Mobile", lead.Mobile);
            cmd.Parameters.AddWithValue("@LeadSource", lead.LeadSource);
            cmd.Parameters.AddWithValue("@LeadStatus", lead.LeadStatus);
            cmd.Parameters.AddWithValue("@NextFollowUpDate", lead.NextFollowUpDate);

            _connection.Open();

            int count = cmd.ExecuteNonQuery();
            _connection.Close();

            if(count >= 1)
            {
                // Count will increment if query is executed
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
