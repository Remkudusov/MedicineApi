using AutoMapper;
using MedicineApi.Configuration;
using MedicineApi.Extensions;
using MedicineApi.Models;
using MedicineApi.ViewModels;
using MedicineApi.ViewModels.Doctor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace MedicineApi.Controllers
{
    [Route("api/doctors/")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly MedicineContext _context;

        public DoctorsController(MedicineContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        /// <summary>
        /// Получить список докторов.
        /// </summary>
        /// <param name="paging">Модель постраничной навигации и фильтрации.</param>
        /// <returns>Список докторов.</returns>
        [HttpGet]
        public async Task<IEnumerable<DoctorListViewModel>> Get(
            [FromQuery] PagingModel paging)
        {
            var doctors = await _context.Doctors
                .Include(d => d.Cabinet)
                .Include(d => d.Specialization)
                .Include(d => d.District)
                .ToListAsync();
            var paginatedDoctors = doctors.Paginate(paging).ToList();
            var result = _mapper.Map<IEnumerable<DoctorListViewModel>>(paginatedDoctors);

            return _mapper.Map<IEnumerable<DoctorListViewModel>>(result);
        }

        /// <summary>
        /// Получить доктора по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор доктора.</param>
        /// <returns>Модель доктора.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorViewModel>> Get(
            [Range(1, long.MaxValue, ErrorMessage = "Неверное значение идентификатора.")] long id)
        {
            var doctor = await _context.Doctors.FirstOrDefaultAsync(d => d.Id == id);
            if (doctor is null)
                return NotFound("Доктора с таким идентификатором не существует.");

            return _mapper.Map<DoctorViewModel>(doctor);
        }

        /// <summary>
        /// Добавить доктора.
        /// </summary>
        /// <param name="value">Модель доктора.</param>
        /// <returns>Добавленная модель доктора.</returns>
        [HttpPost]
        public async Task<ActionResult<DoctorViewModel>> Post([FromBody] DoctorRequestViewModel value)
        {
            var doctor = _mapper.Map<Doctor>(value);

            if (await CheckDoctorRequestModel(value) is ErrorResponseViewModel postModelCheckResult)
                return BadRequest(postModelCheckResult);

            doctor.Cabinet = await _context.Cabinets.FirstOrDefaultAsync(c => c.Id == value.CabinetId);
            doctor.Specialization = await _context.Specializations.FirstOrDefaultAsync(s => s.Id == value.SpecializationId);
            doctor.District = value.DistrictId is not null ? await _context.Districts.FirstOrDefaultAsync(d => d.Id == value.DistrictId) : null;

            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();

            return _mapper.Map<DoctorViewModel>(doctor);
        }

        /// <summary>
        /// Редактировать доктора.
        /// </summary>
        /// <param name="id">Идентификатор доктора.</param>
        /// <param name="value">Отредактированная модель доктора.</param>
        /// <returns>Отредактированная модель доктора.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<DoctorViewModel>> Put(
            [Range(1, long.MaxValue, ErrorMessage = "Неверное значение идентификатора.")] long id,
            [FromBody] DoctorRequestViewModel value)
        {
            var doctor = await _context.Doctors
                .Include(d => d.Cabinet)
                .Include(d => d.Specialization)
                .Include(d => d.District)
                .FirstOrDefaultAsync(d => d.Id == id);
            if (doctor is null)
                return NotFound("Доктора с таким идентификатором не существует.");

            if (await CheckDoctorRequestModel(value) is ErrorResponseViewModel putModelCheckResult)
                return BadRequest(putModelCheckResult);

            _mapper.Map(value, doctor);

            if (doctor.Cabinet.Id != value.CabinetId)
                doctor.Cabinet = await _context.Cabinets.FirstAsync(c => c.Id == value.CabinetId);
            
            if (doctor.Specialization.Id != value.CabinetId)
                doctor.Specialization = await _context.Specializations.FirstAsync(s => s.Id == value.SpecializationId);
            
            if ((value.DistrictId is not null && doctor.District is not null) &&
                ((value.DistrictId is null && doctor.District is not null) ||
                (value.DistrictId is not null && doctor.District is null) ||
                doctor.District!.Id != value.DistrictId))
                doctor.District = value.DistrictId is not null ? await _context.Districts.FirstOrDefaultAsync(d => d.Id == value.DistrictId) : null;

            await _context.SaveChangesAsync();
            return _mapper.Map<DoctorViewModel>(doctor);
        }

        /// <summary>
        /// Удалить доктора.
        /// </summary>
        /// <param name="id">Идентификатор доктора.</param>
        /// <returns>Код успешного удаления записи.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(
            [Range(1, long.MaxValue, ErrorMessage = "Неверное значение идентификатора.")] long id)
        {
            var doctor = await _context.Doctors.FirstOrDefaultAsync(d => d.Id == id);
            if (doctor is null)
                return NotFound("Доктора с таким идентификатором не существует.");

            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        async Task<ErrorResponseViewModel?> CheckDoctorRequestModel(DoctorRequestViewModel model)
        {
            var cabinet = await _context.Cabinets.FirstOrDefaultAsync(c => c.Id == model.CabinetId);
            if (cabinet is null)
                return new ErrorResponseViewModel("Кабинет с указанным идентификатором не найден.");

            var specialization = await _context.Specializations.FirstOrDefaultAsync(c => c.Id == model.SpecializationId);
            if (specialization is null)
                return new ErrorResponseViewModel("Специализация с указанным идентификатором не найдена.");

            if (model.DistrictId is not null)
            {
                var district = await _context.Districts.FirstOrDefaultAsync(c => c.Id == model.DistrictId);
                if (district is null)
                    return new ErrorResponseViewModel("Участок с указанным идентификатором не найден.");
            }

            return null;
        }
    }
}
