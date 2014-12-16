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
             List<SelectListItem>stateList = new List<SelectListItem>();
             stateList.Add(new SelectListItem() { Text = "AL", Value = "Alabama" });
             stateList.Add(new SelectListItem() { Text = "AK", Value = "Alaska" });
             stateList.Add(new SelectListItem() { Text = "AZ", Value = "Arizona" });
             stateList.Add(new SelectListItem() { Text = "AR", Value = "Arkansas" });
             stateList.Add(new SelectListItem() { Text = "CA", Value = "California" });
             stateList.Add(new SelectListItem() { Text = "CO", Value = "Colorado" });
             stateList.Add(new SelectListItem() { Text = "CT", Value = "Connecticut" });
             stateList.Add(new SelectListItem() { Text = "DC", Value = "District of Columbia" });
             stateList.Add(new SelectListItem() { Text = "DE", Value = "Delaware" });
             stateList.Add(new SelectListItem() { Text = "FL", Value = "Florida" });
             stateList.Add(new SelectListItem() { Text = "GA", Value = "Georgia" });
             stateList.Add(new SelectListItem() { Text = "HI", Value = "Hawaii" });
             stateList.Add(new SelectListItem() { Text = "ID", Value = "Idaho" });
             stateList.Add(new SelectListItem() { Text = "IL", Value = "Illinois" });
             stateList.Add(new SelectListItem() { Text = "IN", Value = "Indiana" });
             stateList.Add(new SelectListItem() { Text = "IA", Value = "Iowa" });
             stateList.Add(new SelectListItem() { Text = "KS", Value = "Kansas" });
             stateList.Add(new SelectListItem() { Text = "KY", Value = "Kentucky" });
             stateList.Add(new SelectListItem() { Text = "LA", Value = "Louisiana" });
             stateList.Add(new SelectListItem() { Text = "ME", Value = "Maine" });
             stateList.Add(new SelectListItem() { Text = "MD", Value = "Maryland" });
             stateList.Add(new SelectListItem() { Text = "MA", Value = "Massachusetts" });
             stateList.Add(new SelectListItem() { Text = "MI", Value = "Michigan" });
             stateList.Add(new SelectListItem() { Text = "MN", Value = "Minnesota" });
             stateList.Add(new SelectListItem() { Text = "MS", Value = "Mississippi" });
             stateList.Add(new SelectListItem() { Text = "MO", Value = "Missouri" });
             stateList.Add(new SelectListItem() { Text = "MT", Value = "Montana" });
             stateList.Add(new SelectListItem() { Text = "NE", Value = "Nebraska" });
             stateList.Add(new SelectListItem() { Text = "NV", Value = "Nevada" });
             stateList.Add(new SelectListItem() { Text = "NH", Value = "New Hampshire" });
             stateList.Add(new SelectListItem() { Text = "NJ", Value = "New Jersey" });
             stateList.Add(new SelectListItem() { Text = "NM", Value = "New Mexico" });
             stateList.Add(new SelectListItem() { Text = "NY", Value = "New York" });
             stateList.Add(new SelectListItem() { Text = "NC", Value = "North Carolina" });
             stateList.Add(new SelectListItem() { Text = "ND", Value = "North Dakota" });
             stateList.Add(new SelectListItem() { Text = "OH", Value = "Ohio" });
             stateList.Add(new SelectListItem() { Text = "OK", Value = "Oklahoma" });
             stateList.Add(new SelectListItem() { Text = "OR", Value = "Oregon" });
             stateList.Add(new SelectListItem() { Text = "PA", Value = "Pennsylvania" });
             stateList.Add(new SelectListItem() { Text = "RI", Value = "Rhode Island" });
             stateList.Add(new SelectListItem() { Text = "SC", Value = "South Carolina" });
             stateList.Add(new SelectListItem() { Text = "SD", Value = "South Dakota" });
             stateList.Add(new SelectListItem() { Text = "TN", Value = "Tennessee" });
             stateList.Add(new SelectListItem() { Text = "TX", Value = "Texas" });
             stateList.Add(new SelectListItem() { Text = "UT", Value = "Utah" });
             stateList.Add(new SelectListItem() { Text = "VT", Value = "Vermont" });
             stateList.Add(new SelectListItem() { Text = "VA", Value = "Virginia" });
             stateList.Add(new SelectListItem() { Text = "WA", Value = "Washington" });
             stateList.Add(new SelectListItem() { Text = "WV", Value = "West Virginia" });
             stateList.Add(new SelectListItem() { Text = "WI", Value = "Wisconsin" });
             stateList.Add(new SelectListItem() { Text = "WY", Value = "Wyoming" });
            return View(stateList);
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
        public ActionResult SearchCompanies(string state, int currentPage = 1)
        {
            //string queryState, string queryindustry, int currentPageNumber
            try
            {
                string searchRequest = CreateRequest(state);
                Rootobject searchResults = MakeRequest(searchRequest);

                //Assemble company list
                var companyList = new List<CompanyHeader>();
                companyList = makeCompanyList(searchResults);
                ViewBag.Companies = companyList;
                ViewBag.CurrentPage 
                return View();
            }

            // TODO: Add the catch block handling and make sure it reaches a view
            catch (Exception)
            {

                return View("Error");
            }
        }
        // TODO: Add accomodation for form parameters
        public static string CreateRequest(string state)
        {
            // TODO: Incorporate the query criteria
            string UrlRequest = "http://api.glassdoor.com/api/api.htm?t.p=26578&t.k=jX8BMvJLWAE&userip=0.0.0.0&useragent=SO/1.0&format=json&v=1&action=employers&state="+state;
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