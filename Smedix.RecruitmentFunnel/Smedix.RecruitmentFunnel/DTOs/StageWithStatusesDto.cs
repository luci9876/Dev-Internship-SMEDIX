namespace Smedix.RecruitmentFunnel.DTOs
{
    public class StageWithStatusesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<StatusDto> Statuses { get; set; }
    }
}
