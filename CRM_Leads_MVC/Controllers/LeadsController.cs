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
            // To show all the Leads we need a list of obj
            List<LeadsEntity> leads = new List<LeadsEntity>();

            LeadRepository leadRepository = new LeadRepository();

            leads = leadRepository.GetAllLeads();

            return View(leads);
        }

        public IActionResult EditLead(int Id)
        {
            // Now we will edit single record at a time, so now we need single object not a list of obj
            LeadsEntity leads = new LeadsEntity();

            LeadRepository leadRepository = new LeadRepository();

            leads = leadRepository.GetLeadById(Id);

            return View(leads);

        }

        // Edit controller is similar & logic copied from Add controller
        public IActionResult EditLeadDetails(int Id, LeadsEntity leadDetails)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (leadDetails.NextFollowUpDate < leadDetails.LeadDate)
                    {
                        ViewBag.Message = "Next Follow-up date can't be less than Lead date !";
                        return View("AddLead");
                    }

                    LeadRepository leadRepository = new LeadRepository();
                    if (leadRepository.EditLeadDetails(Id, leadDetails) == true)
                    {
                        TempData["InsertMsg"] = "<script>alert('Lead updated successfully')</script>";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["InsertErrorMsg"] = "<script>alert('Lead not updated !')</script>";
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
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
                    if(leadDetails.NextFollowUpDate < leadDetails.LeadDate)
                    {
                        ViewBag.Message = "Next Follow-up date can't be less than Lead date !";
                        return View("AddLead");
                    }

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

        
        public ActionResult DeleteLead(int id)
        {
            LeadRepository leadRepository = new LeadRepository();
            int idValue = leadRepository.DeleteLead(id);
            if (idValue > 0)
            {
                TempData["DeleteMsg"] = "<script>alert('Lead deleted successfully')</script>";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["DeleteErrorMsg"] = "<script>alert('Lead not deleted !')</script>";
            }
            return View();
        }

    }
}
