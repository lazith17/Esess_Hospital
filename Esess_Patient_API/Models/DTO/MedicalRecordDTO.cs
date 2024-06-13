namespace Esess.PatientAPI.Models.DTO
{
    public class MedicalRecordDTO
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        //public Patient Patient { get; set; }
        public string RecordDetails { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
