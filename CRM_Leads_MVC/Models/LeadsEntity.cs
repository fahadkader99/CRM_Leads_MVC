using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRM_Leads_MVC.Models
{
    /*
     * Holds all the data properties/entities
     */

    public class LeadsEntity
    {
        [Key]
        [DisplayName("Lead Id")]
        public int Id { get; set; }

        [DisplayName("Date")]
        [DataType(DataType.Date)]
        public DateTime LeadDate { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }

        [DisplayName("Mobile")]
        public string Mobile { get; set; }

        [DisplayName("Lead Source")]
        public string LeadSource { get; set; }

        [DisplayName("Lead Status")]
        public string LeadStatus { get; set; }

        [DisplayName("Next Follow up Date")]
        [DataType(DataType.Date)]
        public DateTime NextFollowUpDate { get; set; }
    }
}
