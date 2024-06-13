using Esess.PatientAPI.Models;
using Esess.PatientAPI.Models.DTO;

namespace Esess.PatientAPI.Services;

public interface IPatientService
{
    Task<ResponseDTO> GetAllPatientsAsync();
    //Task<Patient> GetPatientByIdAsync(int id);
    Task<ResponseDTO> GetPatientByIdAsync(int id);
    Task<Patient> RegisterPatientAsync(Patient patient);
    Task<bool> UpdatePatientAsync(Patient patient);
    Task<bool> DeletePatientAsync(int id);
}