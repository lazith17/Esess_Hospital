using AutoMapper;
using Esess.PatientAPI.Models;
using Esess.PatientAPI.Models.DTO;

namespace Esess.PatientAPI;

public class MappingConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        var mappingConfig = new MapperConfiguration(config =>
        {
            config.CreateMap<PatientDTO, Patient>();
            config.CreateMap<Patient, PatientDTO>();

            config.CreateMap<MedicalRecordDTO, MedicalRecord>();
            config.CreateMap<MedicalRecord, MedicalRecordDTO>();
        });
        return mappingConfig;
    }
}
