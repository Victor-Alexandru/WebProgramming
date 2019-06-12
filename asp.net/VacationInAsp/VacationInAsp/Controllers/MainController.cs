using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VacationInAsp.Models;
using VacationInAsp.DataAbstractionLayer;
using System.Web.Script.Serialization;

namespace VacationInAsp.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {
            return View("IndexView");
        }
      


        public string GetStudentsFromGroup()
        {
            int group_id = int.Parse(Request.Params["group_id"]);
            DAL dal = new DAL();
            List<Student> slist = dal.GetStudentsFromGroup(group_id);
            ViewData["studentList"] = slist;


            string result = "<table><thead><th>Id</th><th>Nume</th><th>Password</th><th>Group_Id</th></thead>";


            foreach (Student stud in slist)
            {
                result += "<tr><td>" + stud.Id + "</td><td>" + stud.Nume + "</td><td>" + stud.Password + "</td><td>" + stud.Group_id + "</td><td></tr>";
            }

            result += "</table>";

            result += slist.Count();

            return result;
        }



        public string ValidateData()
        {
            string username = Request.Params["username"];
            string password = Request.Params["password"];
            DAL dal = new DAL();
            String result = dal.ValidateData(username ,password);

            return result;

        }




        public string GetDestinationsFrom()
        {
            int start = int.Parse(Request.Params["start"]);
            int end = int.Parse(Request.Params["end"]);
            DAL dal = new DAL();
            List<Destination> dlist = dal.GetDestinationsFrom(start,end);

            var jsonSerialiser = new JavaScriptSerializer();
            var json = jsonSerialiser.Serialize(dlist);

            return json;

        }

        public string GetCustomFrom()
        {
            int start = int.Parse(Request.Params["start"]);
            int end = int.Parse(Request.Params["end"]);
            string countryName = Request.Params["countryName"];
            DAL dal = new DAL();
            List<Destination> dlist = dal.GetCustomFrom(start, end,countryName);

           
            var jsonSerialiser = new JavaScriptSerializer();
            var json = jsonSerialiser.Serialize(dlist);

            return json;

        }

        public ActionResult DestinationManager()
        {
            return View("DestinationManager");

        }

        public ActionResult LoginManager()
        {
            return View("Login");
        }
        public ActionResult TargetManager()
        {
            return View("TargetManager");

        }

        public ActionResult CustomSearch()
        {
            return View("CustomSearch");

        }

        public string AddTarget()
        {
            long target_id = long.Parse(Request.Params["targetId"]);
            long destination_id = long.Parse(Request.Params["destinationId"]);
            string target_name = (string)(Request.Params["targetName"]);



            DAL dal = new DAL();

            return dal.AddTarget(target_id,destination_id,target_name);


        }


        public string DeleteTarget()
        {
            long id = long.Parse(Request.Params["targetId"]);

            DAL dal = new DAL();
            return dal.DeleteTarget(id);


        }


        public string AddDestination()
        {
            long id = long.Parse(Request.Params["id"]);
            string locationName = (string)(Request.Params["locationName"]);
            string countryName = (string)(Request.Params["countryName"]);
            string description = (string)(Request.Params["description"]);
            long costPerDay = long.Parse(Request.Params["costPerDay"]);

            DAL dal = new DAL();
            return  dal.AddDestination(new Destination(id,locationName,countryName,description,costPerDay));


        }

        public string DeleteDestination()
        {
            long id = long.Parse(Request.Params["id"]);

            DAL dal = new DAL();
            return dal.DeleteDestination(id);


        }

        public ActionResult Destinations()
        {
            return View("Destinations");
        }

    }
}