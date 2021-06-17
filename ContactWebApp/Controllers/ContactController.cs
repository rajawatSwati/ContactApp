using ContactWebApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Web.Mvc;

namespace ContactWebApp.Controllers
{
    public class ContactController : Controller
    {
        private HttpClient Client { get; set; }

        public ContactController()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ServiceUrl"].ToString());
        }

        // GET: Contact
        public ActionResult Index()
        {
            try
            {
                var url = "api/Contact";
                HttpResponseMessage response = Client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
                List<ContactModel> contacts = response.Content.ReadAsAsync<List<ContactModel>>().Result;
                ViewBag.Title = "All Contacts";
                return View(contacts);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // GET: Contact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contact/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var url = "api/Contact";
                var model = new ContactModel()
                {
                    FirstName = collection["FirstName"],
                    LastName = collection["LastName"],
                    Email = collection["Email"],
                    PhoneNumber = collection["PhoneNumber"],
                    Active = Convert.ToBoolean(collection["Active"].Split(',')[0])
                };
                HttpResponseMessage response = Client.PostAsJsonAsync(url, model).Result;
                response.EnsureSuccessStatusCode();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(int id)
        {
            var url = "api/Contact?id=" + id.ToString();
            HttpResponseMessage response = Client.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            ContactModel contact = response.Content.ReadAsAsync<ContactModel>().Result;
            ViewBag.Title = "Edit Contact";
            return View(contact);
        }

        // POST: Contact/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var url = "api/Contact?id=" + id.ToString();
                var model = new ContactModel()
                {
                    FirstName = collection["FirstName"],
                    LastName = collection["LastName"],
                    Email = collection["Email"],
                    PhoneNumber = collection["PhoneNumber"],
                    Active = Convert.ToBoolean(collection["Active"].Split(',')[0])
                };
                HttpResponseMessage response = Client.PutAsJsonAsync(url, model).Result;
                response.EnsureSuccessStatusCode();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contact/Delete/5
        public ActionResult Delete(int id)
        {
            var url = "api/Contact?id=" + id.ToString();
            HttpResponseMessage response = Client.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            ContactModel contact = response.Content.ReadAsAsync<ContactModel>().Result;
            ViewBag.Title = "Delete Contact";
            return View(contact);
        }

        // POST: Contact/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var url = "api/Contact?id=" + id.ToString();
                HttpResponseMessage response = Client.DeleteAsync(url).Result;
                response.EnsureSuccessStatusCode();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult IsAlreadySigned(string email, string initialEmail)
        {
            return Json(CheckEmail(email, initialEmail));
        }

        [NonAction]
        public bool CheckEmail(string email, string initialEmail)
        {
            bool status;

            // To handle email validation in edit mode when email is not modified
            if (email == initialEmail)
            {
                return true;
            }
            var url = "api/Contact";
            HttpResponseMessage response = Client.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            List<ContactModel> contacts = response.Content.ReadAsAsync<List<ContactModel>>().Result;

            var emailExist = contacts.Exists(c => c.Email == email);

            if (emailExist)
            {
                status = false;
            }
            else
            {
                status = true;
            }

            return status;
        }
    }
}
