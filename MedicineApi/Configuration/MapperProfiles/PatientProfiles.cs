using AutoMapper;
using MedicineApi.Models;
using MedicineApi.ViewModels.Hospital;

namespace MedicineApi.Configuration.MapperProfiles
{
    /// <summary>
    /// Маппинги для объектов докторов.
    /// </summary>
    public class PatientProfiles : Profile
    {
        public PatientProfiles()
        {
            CreateMap<Patient, PatientViewModel>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Surname, opt => opt.MapFrom(src => src.Surname))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dst => dst.Patronymic, opt => opt.MapFrom(src => src.Patronymic))
                .ForMember(dst => dst.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dst => dst.BDay, opt => opt.MapFrom(src => src.BDay))
                .ForMember(dst => dst.Sex, opt => opt.MapFrom(src => src.Sex))
                .ForMember(dst => dst.DistrictId, opt => opt.MapFrom(src => src.DistrictId));

            CreateMap<Patient, PatientListViewModel>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Surname, opt => opt.MapFrom(src => src.Surname))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dst => dst.Patronymic, opt => opt.MapFrom(src => src.Patronymic))
                .ForMember(dst => dst.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dst => dst.BDay, opt => opt.MapFrom(src => src.BDay))
                .ForMember(dst => dst.Sex, opt => opt.MapFrom(src => src.Sex))
                .ForMember(dst => dst.District, opt => opt.MapFrom(src => src.District.Number));

            CreateMap<PatientRequestViewModel, Patient>()
                .ForMember(dst => dst.Id, opt => opt.Ignore())
                .ForMember(dst => dst.Surname, opt => opt.MapFrom(src => src.Surname))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dst => dst.Patronymic, opt => opt.MapFrom(src => src.Patronymic))
                .ForMember(dst => dst.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dst => dst.BDay, opt => opt.MapFrom(src => src.BDay))
                .ForMember(dst => dst.Sex, opt => opt.MapFrom(src => src.Sex))
                .ForMember(dst => dst.District, opt => opt.Ignore());
        }
    }
}
