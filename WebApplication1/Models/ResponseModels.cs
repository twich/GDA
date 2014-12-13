using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    [DataContract]
    public class GdJsonResponse
    {

        [DataMember(Name = "success")]
        public bool Success { get; set; }

        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "response")]
        public Responses[] Response { get; set; }
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
