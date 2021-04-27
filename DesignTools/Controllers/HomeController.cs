using DesignTools.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace DesignTools.Controllers
{
    public class HomeController : Controller
    {

        DBMS db = new DBMS();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult ListOfDesigns()
        {
            
            List<Design> designs = new List<Design>();
            DataTable table = db.ExecuteSelectQuery("SELECT page_name , html_design FROM pages; ");
            if(table.Rows.Count > -1)
            {
                foreach (DataRow row in table.Rows)
                {
                    Design design = new Design();
                    design.page_name = row["page_name"].ToString();
                    design.html_design = row["html_design"].ToString();
                    designs.Add(design);
                }
            }
            return View(designs);
        }


        [HttpGet]
        public ActionResult AddDesigns()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AddDesigns(Design design)
        {
            bool ok = db.ExecuteInsertQuery(" insert into pages (page_name,html_design) values ('" + design.page_name + "','" + design.html_design + "')");
            return RedirectToAction("ListOfDesigns");
        }

    }
}