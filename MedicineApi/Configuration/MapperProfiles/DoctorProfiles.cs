using AutoMapper;
using MedicineApi.Models;
using MedicineApi.ViewModels.Doctor;

namespace MedicineApi.Configuration.MapperProfiles
{
    /// <summary>
    /// Маппинги для объектов докторов.
    /// </summary>
    public class DoctorProfiles : Profile
    {
        public DoctorProfiles()
        {
            CreateMap<Doctor, DoctorViewModel>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dst => dst.CabinetId, opt => opt.MapFrom(src => src.CabinetId))
                .ForMember(dst => dst.SpecializationId, opt => opt.MapFrom(src => src.SpecializationId))
                .ForMember(dst => dst.DistrictId, opt => opt.MapFrom(src =>
                    src.District == null
                        ? (long?)null
                        : src.District!.Id));

            CreateMap<Doctor, DoctorListViewModel>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dst => dst.Cabinet, opt => opt.MapFrom(src => src.Cabinet!.Number))
                .ForMember(dst => dst.Specialization, opt => opt.MapFrom(src => src.Specialization!.Name))
                .ForMember(dst => dst.District, opt =>
                {
                    opt.PreCondition(src => src.District is not null);
                    opt.MapFrom(src => src.District!.Id);
                });

            CreateMap<DoctorRequestViewModel, Doctor>()
                .ForMember(dst => dst.Id, opt => opt.Ignore())
                .ForMember(dst => dst.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dst => dst.Cabinet, opt => opt.Ignore())
                .ForMember(dst => dst.Specialization, opt => opt.Ignore())
                .ForMember(dst => dst.District, opt => opt.Ignore());
        }
    }
}
