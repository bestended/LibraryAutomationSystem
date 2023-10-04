using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using LibraryAutomationSystem.Models;
namespace LibraryAutomationSystem.Controllers
{
    public class ReadersController : Controller
    {
        // GET: Readers
        public ActionResult Liste(DynamicParameters param=null)
        {

            
            return View(Dap.Listeleme<ReadersSet>("ReadersBringAll", param));
        }

        [HttpGet]
        public ActionResult ReadersAU(int id=0)
        {

            if (id == 0)
            {
                return View();
            }
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("ReaderId",id);

                return View(Dap.Listeleme<ReadersSet>("ReadersBringId",param).FirstOrDefault<ReadersSet>());


            }
        }

        [HttpPost]
        public ActionResult ReadersAU(ReadersSet reader)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ReaderId", reader.ReaderId);
            param.Add("@ReaderName", reader.ReaderName);
            param.Add("@ReaderLastname", reader.ReaderLastname);
            param.Add("@ReaderPhone", reader.ReaderPhone);
            param.Add("@ReaderGender", reader.ReaderGender);
            param.Add("@TakingDate", reader.TakingDate);
            param.Add("@GivingDate", reader.GivingDate);

            Dap.ExecuteReturn("ReadersAU",param);
            return RedirectToAction("Liste");

        }

        public ActionResult Sil(int id=0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ReaderId", id);


            Dap.ExecuteReturn("ReadersDelete",param);
            return RedirectToAction("Liste");




        }




    }
}