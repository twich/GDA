using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime.Serialization.Json;
using System.Net;
using System.Runtime.Serialization;



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
        
        public static string CreateRequest(string queryState, string queryIndustry)
        {
            string UrlRequest = "http://api.glassdoor.com/api/api.htm?t.p=5317&t.k=n07aR34Lk3Y&userip=" + IPAddress.Loopback +
            return (UrlRequest);
        }
        public static GdJsonResponse MakeRequest(string requestUrl)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
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
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        [DataContract]
        public class GdJsonResponse
        {

            [DataMember(Name = "success")]
            public bool Success { get; set; }

            [DataMember(Name = "status")]
            public string Status { get; set; }

            [DataMember(Name = "response")]
            public Responses[] Responses { get; set; }
        } 

        [DataContract]
        public class Responses
        {
            [DataMember(Name = "currentPageNumber")]
            public int CurrentPageNumber { get; set; }

            [DataMember(Name = "totalNumberOfPages")]
            public int TotalNumberOfPages { get; set; }

            [DataMember(Name = "totalRecordCount")]
            public int TotalRecordCount { get; set; }

            [DataMember(Name = "employers")]
            public Employers[] Employers { get; set; }
        }

        [DataContract]
        public class Employers
        {
            [DataMember(Name = "id")]
            public int Id { get; set; }

            [DataMember(Name = "name")]
            public string Name { get; set; }

            [DataMember(Name = "website")]
            public string Website { get; set; }

            [DataMember(Name = "isEEP")]
            public bool IsEEP { get; set; }

            [DataMember(Name = "exactMatch")]
            public bool ExactMatch { get; set; }

            [DataMember(Name = "industry")]
            public string Industry { get; set; }

            [DataMember(Name = "numberOfRatings")]
            public int NumberOfRatings { get; set; }

            [DataMember(Name = "squareLogo")]
            public string SquareLogo { get; set; }

            [DataMember(Name = "overallRating")]
            public decimal OverallRating { get; set; }

            [DataMember(Name = "ratingDescription")]
            public string RatingDescription { get; set; }

            [DataMember(Name = "cultureAndValuesRating")]
            public string CultureAndValuesRating { get; set; }

            [DataMember(Name = "seniorLeadershipRating")]
            public string SeniorLeadershipRating { get; set; }

            [DataMember(Name = "compensationAndBenefitsRating")]
            public string CompensationAndBenefitsRating { get; set; }

            [DataMember(Name = "careerOpportunitiesRating")]
            public string CareerOpportunitiesRating { get; set; }

            [DataMember(Name = "workLifeBalanceRating")]
            public string WorkLifeBalanceRating { get; set; }

            [DataMember(Name = "featuredReview")]
            public FeaturedReview[] FeaturedReviews { get; set; }

            [DataMember(Name = "ceo")]
            public Ceo[] Ceo { get; set; }
        }

        public class FeaturedReview
        {
            [DataMember(Name = "id")]
            public int Id { get; set; }

            [DataMember(Name = "currentJob")]
            public bool CurrentJob { get; set; }

            [DataMember(Name = "reviewDateTime")]
            public DateTime ReviewDateTime { get; set; }

            [DataMember(Name = "jobTitle")]
            public string JobTitle { get; set; }

            [DataMember(Name = "location")]
            public string Location { get; set; }

            [DataMember(Name = "headline")]
            public string Headline { get; set; }

            [DataMember(Name = "pros")]
            public string Pros { get; set; }

            [DataMember(Name = "cons")]
            public string Cons { get; set; }
        }

        public class Ceo
        {
            [DataMember(Name = "name")]
            public string Name { get; set; }

            [DataMember(Name = "title")]
            public string Title { get; set; }

            [DataMember(Name = "image")]
            public CeoImage[] Image { get; set; }

            [DataMember(Name = "numberOfRatings")]
            public int NumberOfRatings { get; set; }

            [DataMember(Name = "pctApprove")]
            public decimal PctApprove { get; set; }

            [DataMember(Name = "pctDisapprove")]
            public decimal PctDisapprove { get; set; }
        }

        public class CeoImage
        {
            [DataMember(Name = "src")]
            public string Src { get; set; }

            [DataMember(Name = "height")]
            public int Height { get; set; }

            [DataMember(Name = "width")]
            public int Width { get; set; }
        }
    }
}