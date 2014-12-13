using System;
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

        // TODO: Add accomodation for form parameters
        public ActionResult SearchCompanies()
        {
            try
            {
                string searchRequest = CreateRequest();
                Rootobject searchResults = MakeRequest(searchRequest);

                //Assemble company list
                var companyList = new List<CompanyHeader>();
                companyList = makeCompanyList(searchResults);
                ViewBag.Companies = companyList;
                return View();
            }

            // TODO: Add the catch block handling and make sure it reaches a view
            catch (Exception)
            {

                return View("Error");
            }
        }
        // TODO: Add accomodation for form parameters
        public static string CreateRequest()
        {
            // TODO: Incorporate the query criteria
            string UrlRequest = "http://api.glassdoor.com/api/api.htm?t.p=26578&t.k=jX8BMvJLWAE&userip=0.0.0.0&useragent=SO/1.0&format=json&v=1&action=employers";
            return (UrlRequest);
        }

        public static Rootobject MakeRequest(string requestUrl)
        {
           // I think that we can let any exceptions that fall to the calling method's catch block and return the 
           // Error view
           // try
           // {
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    // TODO: Make sure this error makes it back to a view
                    if (response.StatusCode != HttpStatusCode.OK)
                        throw new Exception(String.Format(
                        "Server error (HTTP {0}: {1}).",
                        response.StatusCode,
                        response.StatusDescription));
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Rootobject));
                    object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                    Rootobject jsonResponse = objResponse as Rootobject;
                    return jsonResponse;
                }
            //}

            /* TODO: Build out this catch block so that the output makes its way to a view
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
             */
        }

        public List<CompanyHeader> makeCompanyList(Rootobject searchResults)
        {
            var companyList = new List<CompanyHeader>();
            int numberOfCompanies = searchResults.response.employers.Length;
            for (int i = 0; i < numberOfCompanies; i++)
            {
                companyList.Add(new CompanyHeader {
                    CompanyName = searchResults.response.employers[i].name,
                    AverageRating = searchResults.response.employers[i].overallRating,
                    LogoURL= searchResults.response.employers[i].squareLogo
                });
            }
            return companyList;
        }
    }
}