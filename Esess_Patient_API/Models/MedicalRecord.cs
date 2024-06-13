using System.Text.Json.Serialization;

namespace Esess.PatientAPI.Models
{
    public class MedicalRecord
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        //[JsonIgnore]
        //public Patient Patient { get; set; }
        public string RecordDetails { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
