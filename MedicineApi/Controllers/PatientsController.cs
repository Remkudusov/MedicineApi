using AutoMapper;
using MedicineApi.Configuration;
using MedicineApi.ViewModels.Doctor;
using MedicineApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedicineApi.ViewModels.Hospital;
using MedicineApi.Extensions;
using System.ComponentModel.DataAnnotations;
using MedicineApi.Models;

namespace MedicineApi.Controllers
{
    [Route("api/patients/")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly MedicineContext _context;

        public PatientsController(IMapper mapper, MedicineContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        /// <summary>
        /// Получить список пациентов.
        /// </summary>
        /// <param name="paging">Модель постраничной навигации и фильтрации.</param>
        /// <returns>Список пациентов.</returns>
        [HttpGet]
        public async Task<IEnumerable<PatientListViewModel>> Get(
            [FromQuery] PagingModel paging)
        {
            var patients = await _context.Patients
                .Include(d => d.District)
                .ToListAsync();
            var result = patients.Paginate(paging).ToList();
            return _mapper.Map<IEnumerable<PatientListViewModel>>(result);
        }

        /// <summary>
        /// Получить пациента по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор пациента.</param>
        /// <returns>Модель пациента.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientViewModel>> Get(
            [Range(1, long.MaxValue, ErrorMessage = "Неверное значение идентификатора.")] long id)
        {
            var patient = await _context.Patients.FirstOrDefaultAsync(d => d.Id == id);
            if (patient is null)
                return NotFound("Пациента с таким идентификатором не существует.");

            return _mapper.Map<PatientViewModel>(patient);
        }

        /// <summary>
        /// Добавить пациента.
        /// </summary>
        /// <param name="value">Модель пациента.</param>
        /// <returns>Добавленная модель пациента.</returns>
        [HttpPost]
        public async Task<ActionResult<PatientViewModel>> Post([FromBody] PatientRequestViewModel value)
        {
            var patient = _mapper.Map<Patient>(value);

            if (await CheckPatientRequestModel(value) is ErrorResponseViewModel postModelCheckResult)
                return BadRequest(postModelCheckResult);

            patient.District = await _context.Districts.FirstOrDefaultAsync(c => c.Id == value.DistrictId);

            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            return _mapper.Map<PatientViewModel>(patient);
        }

        /// <summary>
        /// Редактировать пациента.
        /// </summary>
        /// <param name="id">Идентификатор пациента.</param>
        /// <param name="value">Отредактированная модель пациента.</param>
        /// <returns>Отредактированная модель пациента.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<PatientViewModel>> Put(
            [Range(1, long.MaxValue, ErrorMessage = "Неверное значение идентификатора.")] long id,
            [FromBody] PatientRequestViewModel value)
        {
            var patient = await _context.Patients
                .Include(d => d.District)
                .FirstOrDefaultAsync(d => d.Id == id);
            if (patient is null)
                return NotFound("Пациента с таким идентификатором не существует.");

            if (await CheckPatientRequestModel(value) is ErrorResponseViewModel putModelCheckResult)
                return BadRequest(putModelCheckResult);

            _mapper.Map(value, patient);

            if (patient.District.Id != value.DistrictId)
                patient.District = await _context.Districts.FirstAsync(c => c.Id == value.DistrictId);

            await _context.SaveChangesAsync();
            return _mapper.Map<PatientViewModel>(patient);
        }

        /// <summary>
        /// Удалить пациента.
        /// </summary>
        /// <param name="id">Идентификатор пациента.</param>
        /// <returns>Код успешного удаления записи.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(
            [Range(1, long.MaxValue, ErrorMessage = "Неверное значение идентификатора.")] long id)
        {
            var patient = await _context.Patients.FirstOrDefaultAsync(d => d.Id == id);
            if (patient is null)
                return NotFound("Пациента с таким идентификатором не существует.");

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        async Task<ErrorResponseViewModel?> CheckPatientRequestModel(PatientRequestViewModel model)
        {
            var district = await _context.Districts.FirstOrDefaultAsync(c => c.Id == model.DistrictId);
            if (district is null)
                return new ErrorResponseViewModel("Участок с указанным идентификатором не найден.");

            return null;
        }
    }
}
