using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryAutomationSystem.Models;

namespace LibraryAutomationSystem.Controllers
{
    public class BranchesController : Controller
    {
        // GET: Branches

     


        public ActionResult Liste(DynamicParameters param=null)
        {

          
            return View(Dap.Listeleme<BranchesSet>("BranchesBringAll", param));
        }

        [HttpGet]
        public ActionResult BranchAU(int id=0)
        {
            if (id == 0)
            {
                return View();
            }
            else
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@BranchId",id);
                return View(Dap.Listeleme<BranchesSet>("BranchesBringId", param).FirstOrDefault<BranchesSet>());


            }

        }

        [HttpPost]
        public ActionResult BranchAU(BranchesSet branch)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@BranchId",branch.BranchId);
            param.Add("@BranchName",branch.BranchName);
            param.Add("@BranchPhone",branch.BranchPhone);
            param.Add("@BranchCity",branch.BranchCity);

            Dap.ExecuteReturn("BranchesAU", param);

            return RedirectToAction("Liste");

        }



        public ActionResult Sil(int id=0)
        {

            DynamicParameters param = new DynamicParameters();
            param.Add("@BranchId",id);

            Dap.ExecuteReturn("BranchesDelete",param);
            return RedirectToAction("Liste");
        }




    }
}