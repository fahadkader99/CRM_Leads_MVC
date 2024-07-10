using CRM_Leads_MVC.Data;
using CRM_Leads_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Leads_MVC.Controllers
{
    /*
    * Controller hold all the action methods
    */
    public class LeadsController : Controller
    {
        public IActionResult Index()
        {
            List<LeadsEntity> leads = new List<LeadsEntity>();

            LeadRepository leadRepository = new LeadRepository();

            leads = leadRepository.GetAllLeads();

            return View(leads);
        }

        public IActionResult AddLead()
        {
            /* 
             * when user click to Add New Lead from UI  [Index.cshtml (add lead btn)]
             * Then this method will be called & then this current method will re-call
             * the bellow method (AddNewLead).
             * 
             * In short AddLead is calling AddNewLead
             */
            return View();
          
        }

        public IActionResult AddNewLead(LeadsEntity leadDetails)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LeadRepository leadRepository = new LeadRepository();
                    if (leadRepository.AddLead(leadDetails) == true)
                    {
                        TempData["InsertMsg"] = "<script>alert('Lead saved successfully')</script>";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["InsertErrorMsg"] = "<script>alert('Lead not saved !')</script>";
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }

        }

    }
}
