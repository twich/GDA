﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime.Serialization.Json;
using System.Net;
using System.Runtime.Serialization;
using WebApplication1.Models;



namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
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

        public ActionResult SearchCompanies(string searchState, string searchIndustry)
        {
            try
            {
                string searchRequest = CreateRequest(searchState, searchIndustry);
                GdJsonResponse searchResults = MakeRequest(searchRequest);
                return View(searchResults);
            }

            // TODO: Add the catch block handling and make sure it reaches a view
            catch (Exception)
            {

                return View();
            }
        }

        public static string CreateRequest(string queryState, string queryIndustry)
        {
            // TODO: Incorporate the query criteria
            string UrlRequest = "http://api.glassdoor.com/api/api.htm?t.p=26578&t.k=jX8BMvJLWAE&userip=0.0.0.0&useragent=SO/1.0&format=json&v=1&action=employers";
            return (UrlRequest);
        }

        public static GdJsonResponse MakeRequest(string requestUrl)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    // TODO: Make sure this error makes it back to a view
                    if (response.StatusCode != HttpStatusCode.OK)
                        throw new Exception(String.Format(
                        "Server error (HTTP {0}: {1}).",
                        response.StatusCode,
                        response.StatusDescription));
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(GdJsonResponse));
                    object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                    GdJsonResponse jsonResponse = objResponse as GdJsonResponse;
                    return jsonResponse;
                }
            }

            // TODO: Build out this catch block so that the output makes its way to a view
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        
    }
}