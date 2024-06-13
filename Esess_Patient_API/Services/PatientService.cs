using AutoMapper;
using Esess.PatientAPI.Data;
using Esess.PatientAPI.Models.DTO;
using Esess.PatientAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Esess.PatientAPI.Services;

public class PatientService : IPatientService
{
    private readonly PatientDbContext _context;
    private ResponseDTO _responseDTO;
    private readonly IMapper _mapper;

    public PatientService(PatientDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
        _responseDTO = new ResponseDTO();
    }

    public async Task<ResponseDTO> GetAllPatientsAsync()
    {
        try
        {
            IEnumerable<Patient> objList = await _context.Patients.Include(p => p.MedicalRecords).ToListAsync();
            _responseDTO.Result = _mapper.Map<IEnumerable<PatientDTO>>(objList);
        }
        catch (Exception ex)
        {
            _responseDTO.IsSuccess = false;
            _responseDTO.Result = ex.Message;
        }
        return _responseDTO;
    }

    //public async Task<IEnumerable<PatientDTO>> GetAllPatientsAsync()
    //{
    //    var patients = await _context.Patients.Include(p => p.MedicalRecords).ToListAsync();
    //    return patients.Select(p => new PatientDTO
    //    {
    //        Id = p.Id,
    //        FirstName = p.FirstName,
    //        LastName = p.LastName,
    //        DateOfBirth = p.DateOfBirth,
    //        Email = p.Email,
    //        PhoneNumber = p.PhoneNumber,
    //        Address = p.Address,
    //        MedicalRecords = p.MedicalRecords.Select(m => new MedicalRecordDTO
    //        {
    //            Id = m.Id,
    //            PatientId = m.PatientId,
    //            RecordDetails = m.RecordDetails,
    //            CreatedDate = m.CreatedDate
    //        }).ToList()
    //    }).ToList();
    //}


    public async Task<ResponseDTO> GetPatientByIdAsync(int id)
    {
        //return await _context.Patients.Include(p => p.MedicalRecords).FirstOrDefaultAsync(p => p.Id == id);

        try
        {
            Patient patient = await _context.Patients.Include(p => p.MedicalRecords).FirstOrDefaultAsync(p => p.Id == id);
            _responseDTO.Result = _mapper.Map<PatientDTO>(patient);
            //Product obj = _dbcontext.Products.FirstOrDefault(u => u.ProductId == id);
            //_responseDTO.Result = _mapper.Map<ProductDTO>(obj);

        }
        catch (Exception ex)
        {
            _responseDTO.IsSuccess = false;
            _responseDTO.Result = "No Result for id : " + id;
        }
        return _responseDTO;
    }

    public async Task<Patient> RegisterPatientAsync(Patient patient)
    {
        _context.Patients.Add(patient);
        await _context.SaveChangesAsync();
        return patient;
        //try
        //{
        //    Patient patient = _mapper.Map<Patient>(patientDTO);
        //    _context.Patients.Add(patient);
        //    _context.SaveChanges();

        //    _context.Patients.Update(patient);
        //    _context.SaveChanges();
        //    _responseDTO.Result = _mapper.Map<PatientDTO>(patient);

        //}
        //catch (Exception ex)
        //{
        //    _responseDTO.IsSuccess = false;
        //    _responseDTO.Result = ex.Message;
        //}
        //return _responseDTO;
    }

    public async Task<bool> UpdatePatientAsync(Patient patient)
    {
        _context.Patients.Update(patient);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeletePatientAsync(int id)
    {
        var patient = await _context.Patients.FindAsync(id);
        if (patient == null) return false;
        _context.Patients.Remove(patient);
        return await _context.SaveChangesAsync() > 0;
    }
}