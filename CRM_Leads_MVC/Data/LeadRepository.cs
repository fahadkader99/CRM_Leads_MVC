using CRM_Leads_MVC.Models;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.CodeAnalysis.Elfie.Serialization;
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
                // Looping through DataTable row & adding each element/value to the Lead Entity list

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

        /*
         * This method is fetching records from DB by ID, so that it can edit any record by their ID
         */
        public LeadsEntity GetLeadById(int Id)
        {
            // working with single record to edit by ID, so 1 obj is needed not List
            LeadsEntity leadEntity = new LeadsEntity();

            // Passing store proc name 'GetLeadDetailsById' & the connection
            SqlCommand cmd = new SqlCommand("GetLeadDetailsById", _connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter;
            cmd.Parameters.Add(new SqlParameter("@Id", Id));

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            foreach (DataRow dr in dataTable.Rows)
            {
                // Looping through DataTable row & adding  element/value to the LeadEntity obj

                leadEntity = new LeadsEntity
                {
                    Id = Convert.ToInt32(dr["id"]),
                    LeadDate = Convert.ToDateTime(dr["LeadDate"]),
                    Name = dr["name"].ToString(),
                    EmailAddress = dr["EmailAddress"].ToString(),
                    Mobile = dr["Mobile"].ToString(),
                    LeadSource = dr["LeadSource"].ToString(),
                    LeadStatus = dr["LeadStatus"].ToString(),
                    NextFollowUpDate = Convert.ToDateTime(dr["NextFollowUpDate"]),

                };
            }

            return leadEntity;

        }

        /*
         * EditLead method is similer & logic copied from AddLead method
         */
        public bool EditLeadDetails(int Id, LeadsEntity lead)
        {
            // Passing store proc name 'EditLeadById' & the connection
            SqlCommand cmd = new SqlCommand("EditLeadById", _connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("id", Id);
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

            if (count >= 1)
            {
                // Count will increment if query is executed
                return true;
            }
            else
            {
                return false;
            }
        }

        public int DeleteLead(int Id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("DeleteLeadDetails", _connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                // Pass the ID that will be deleted
                cmd.Parameters.AddWithValue("Id", Id);

                _connection.Open();
                int val = cmd.ExecuteNonQuery();
                _connection.Close();

                return val;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
