using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using LibraryAutomationSystem.Models;

namespace LibraryAutomationSystem.Controllers
{
    public class BooksController : Controller
    {
      
        public ActionResult Liste(DynamicParameters param=null)
        {

            return View(Dap.Listeleme<BooksSet>("BooksBringAll",param));
        }

        [HttpGet]
        public ActionResult BookAU(int id=0)
        {
            if (id == 0)
            {
                return View();


            }
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@BookId",id);
                return View(Dap.Listeleme<BooksSet>("BooksBringId",param).FirstOrDefault<BooksSet>());

                
            }

        }


        [HttpPost]
        public ActionResult BookAU(BooksSet books)
        {

            DynamicParameters param = new DynamicParameters();
            param.Add("@BookId",books.BookId);
            param.Add("@BookName",books.BookName);
            param.Add("@BookAuthor",books.BookAuthor);
            param.Add("@Publisher",books.Publisher);
            param.Add("@Translator",books.Translator);
            param.Add("@PageCount",books.PageCount);
            param.Add("@ReleaseDate",books.ReleaseDate);
            param.Add("@ReaderId",books.ReaderId);
            param.Add("@LibrarianId",books.LibrarianId);


            Dap.ExecuteReturn("BooksAU",param);

            return RedirectToAction("Liste");


        }


        public ActionResult Sil(int id=0)
        {

            DynamicParameters param = new DynamicParameters();
            param.Add("BookId",id);

            Dap.ExecuteReturn("BooksDelete",param);
            return RedirectToAction("Liste");



        }



    }
}