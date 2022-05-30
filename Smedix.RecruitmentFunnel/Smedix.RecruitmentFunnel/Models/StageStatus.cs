namespace Smedix.RecruitmentFunnel.Models
{
    public class StageStatus
    {
        public int Id { get; set; }
        
        public Stage? Stage { get; set; }
        public int StageId { get; set; }
        public Status? Status { get; set; }
        public int StatusId { get; set; }
    }
}
