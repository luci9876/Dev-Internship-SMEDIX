using Smedix.RecruitmentFunnel.Helpers;

namespace Smedix.RecruitmentFunnel.Helpers
{
    public class CandidateParams : QueryStringParameters
    {
        public CandidateParams()
        {
            OrderBy = "name";
        }
        public int PageSize { get; set; } = 20;
        public int PageNumber { get; set; } = 1;
        public string? SearchName { get; set; }


    }
}
