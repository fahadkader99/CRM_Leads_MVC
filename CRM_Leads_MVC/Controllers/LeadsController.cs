using CRM_Leads_MVC.Data;
using CRM_Leads_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Leads_MVC.Controllers
{
    public class LeadsController : Controller
    {
        /*
         * Controller hold all the action methods
         */
        public IActionResult Index()
        {
            List<LeadsEntity> leads = new List<LeadsEntity>();

            LeadRepository leadRepository = new LeadRepository();

            leads = leadRepository.GetAllLeads();

            return View(leads);
        }
    }
}
