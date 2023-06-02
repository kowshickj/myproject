using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Web.WebPages.Html;
using WebApplication13.Models;
using WebApplication13.Repository;

namespace WebApplication13.Controllers
{
    public class SignupController : Controller
    {
        UserDBcontext dbcontext = new UserDBcontext();

        //Dashboard

        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult Index()
        {
            var ns = dbcontext.GetallUser();
            if (ns.Count == 0)
            {
                TempData["InfoMessage"] = "Currently name is not Available in Database...";
            }
            return View(ns);

        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Signup signup)
        {
            bool IsInserted = false;
            try
            {
                if (ModelState.IsValid)
                {
                    IsInserted = dbcontext.AddUser(signup);
                    if (IsInserted)
                    {
                        TempData["SuccessMessage"] = "Inserted successfully...";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Name is Already Exit";
                    }

                }
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                TempData["Errormessage"] = ex.Message;
                return View();
            }
        }

        public ActionResult Edit(int id)
        {

            var signup = dbcontext.GetaUserById(id).FirstOrDefault();
            if (signup == null)
            {
                TempData["InfoMessage"] = "Name not available either Id" + id.ToString();
                return RedirectToAction("Index");
            }
            return View(signup);
        }


        [HttpPost, ActionName("Edit")]
        public ActionResult Update(Signup sign)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool IsUpdated = dbcontext.UpdateUser(sign);
                    if (IsUpdated)
                    {
                        TempData["SuccessMessage"] = "Details Updated Successfully";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Name is already available/Unable to update";
                    }
                    return RedirectToAction("Index");
                }

                return View();
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                var signup = dbcontext.GetaUserById(id).FirstOrDefault();
                if (signup == null)
                {
                    TempData["InfoMessage"] = "Name not available with Id" + id.ToString();
                    return RedirectToAction("Index");
                }
                return View(signup);
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmation(int id)
        {
            try
            {
                string result = dbcontext.DeleteUser(id);
                if (result.Contains("deleted"))
                {
                    TempData["SuccessMessage"] = "Details Deleted Successfully";
                }
                else
                {
                    TempData["ErrorMessage"] = "Details not availabel";
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                return View();
            }

        }

        public ActionResult Details(int id)
        {
            try
            {
                var signup = dbcontext.GetaUserById(id).FirstOrDefault();
                if (signup == null)
                {
                    TempData["InfoMessage"] = "Name not available with Id" + id.ToString();
                    return RedirectToAction("Index");
                }
                return View(signup);
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

        [HttpGet]

        public ActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signin(string username, string password)
        {
            Signup sign = dbcontext.Signin(username, password);
            if (sign != null)
            {
                return RedirectToAction("Create", "Signup");
            }

            else
            {
                ModelState.AddModelError("", "Invalid username or password.");
            }

            return View();
        }


    }
}
