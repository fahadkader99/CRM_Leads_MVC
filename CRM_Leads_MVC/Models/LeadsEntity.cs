using System.ComponentModel.DataAnnotations;

namespace CRM_Leads_MVC.Models
{
    /*
     * Holds all the data properties
     */
    public class LeadsEntity
    {
        [Required]
        public int Id { get; set; }
        public DateTime LeadDate { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string Mobile { get; set; }
        public string LeadSource { get; set; }
        public string LeadStatus { get; set; }
        public DateTime NextFollowUpDate { get; set; }
    }
}
