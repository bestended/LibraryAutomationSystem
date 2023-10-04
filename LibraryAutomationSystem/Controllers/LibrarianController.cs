using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using LibraryAutomationSystem.Models;

namespace LibraryAutomationSystem.Controllers
{
    public class LibrarianController : Controller
    {
        // GET: Librarian
        public ActionResult Liste(DynamicParameters param=null)
        {
            return View(Dap.Listeleme<LibrariansSet>("LibrarianBringAll",param));
        }

        [HttpGet]
        public ActionResult LibrarianAU(int id=0)
        {

            if (id == 0)
            {
                return View();
            }
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("LibrarianId",id);

                return View(Dap.Listeleme<LibrariansSet>("LibrarianBringId", param).FirstOrDefault<LibrariansSet>());




            }


        }


        [HttpPost]
        public ActionResult LibrarianAU(LibrariansSet librarian)
        {

            DynamicParameters param = new DynamicParameters();

            param.Add("@LibrarianId",librarian.LibrarianId);
            param.Add("@LibrarianName",librarian.LibrarianName);
            param.Add("@LibrarianPhone",librarian.LibrarianPhone);
            param.Add("@LibrarianAge", librarian.LibrarianAge);
            param.Add("@LibrarianCountry", librarian.LibrarianCountry);
            param.Add("@BranchId", librarian.BranchId);

            Dap.ExecuteReturn("LibrarianAU",param);
            return RedirectToAction("Liste");
        }

        public ActionResult Sil(int id=0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@LibrarianId", id);
            Dap.ExecuteReturn("LibrarianDelete",param);
            return RedirectToAction("Liste");
        }





    }
}