using AutoMapper;
using Smedix.RecruitmentFunnel.DTOs;
using Smedix.RecruitmentFunnel.Models;

namespace Smedix.RecruitmentFunnel.Helpers
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Candidate, CandidateDto>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
                .ForMember(dest => dest.LastStatus, opt => opt.MapFrom(src => src.CandidateStatus))
                .ForMember(dest => dest.Technology, opt => opt.MapFrom(src => src.CandidateTechnologies.FirstOrDefault().Technology));

            CreateMap<Status, StatusDto>().ReverseMap();
                
        }
    }
}
