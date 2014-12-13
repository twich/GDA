using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    /// <summary>
    /// Used to create the list of companies on the search results page
    /// </summary>
    public class CompanyHeader
    {
        public CompanyHeader()
        {
        }
        public string CompanyName { get; set; }
        public float AverageRating { get; set; }
        public string LogoURL { get; set; }
    }

    /*
     * The following classes are associated with the JSON Response and
     * used to create objects realated to the returned data
     */

    public class Rootobject
    {
        public bool success { get; set; }
        public string status { get; set; }
        public string jsessionid { get; set; }
        public Response response { get; set; }
    }

    public class Response
    {
        public int currentPageNumber { get; set; }
        public int totalNumberOfPages { get; set; }
        public int totalRecordCount { get; set; }
        public Employer[] employers { get; set; }
    }

    public class Employer
    {
        public int id { get; set; }
        public string name { get; set; }
        public string website { get; set; }
        public bool isEEP { get; set; }
        public bool exactMatch { get; set; }
        public string industry { get; set; }
        public int numberOfRatings { get; set; }
        public string squareLogo { get; set; }
        public float overallRating { get; set; }
        public string ratingDescription { get; set; }
        public string cultureAndValuesRating { get; set; }
        public string seniorLeadershipRating { get; set; }
        public string compensationAndBenefitsRating { get; set; }
        public string careerOpportunitiesRating { get; set; }
        public string workLifeBalanceRating { get; set; }
        public string recommendToFriendRating { get; set; }
        public Featuredreview featuredReview { get; set; }
        public Ceo ceo { get; set; }
    }

    public class Featuredreview
    {
        public int id { get; set; }
        public bool currentJob { get; set; }
        public string reviewDateTime { get; set; }
        public string jobTitle { get; set; }
        public string location { get; set; }
        public string headline { get; set; }
        public string pros { get; set; }
        public string cons { get; set; }
        public int overall { get; set; }
        public int overallNumeric { get; set; }
    }

    public class Ceo
    {
        public string name { get; set; }
        public string title { get; set; }
        public Image image { get; set; }
        public int numberOfRatings { get; set; }
        public int pctApprove { get; set; }
        public int pctDisapprove { get; set; }
    }

    public class Image
    {
        public string src { get; set; }
        public int height { get; set; }
        public int width { get; set; }
    }

}
