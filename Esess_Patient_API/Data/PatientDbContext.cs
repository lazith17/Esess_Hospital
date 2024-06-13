using Microsoft.EntityFrameworkCore;
using Esess.PatientAPI.Models;

namespace Esess.PatientAPI.Data;

public class PatientDbContext : DbContext
{
    public PatientDbContext(DbContextOptions<PatientDbContext> options) : base(options)
    {

    }

    public DbSet<Patient> Patients { get; set; }
    public DbSet<MedicalRecord> MedicalRecords { get; set; }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    base.OnModelCreating(modelBuilder);

    //    modelBuilder.Entity<Patient>().HasData(new Patient
    //    {
    //        Id = 1,
    //        FirstName = "Lasith",
    //        LastName = "Herath",
    //        Address = "Makola",
    //        DateOfBirth = DateTime.UtcNow,
    //        Email = "lazith15@gmail.com",
    //        PhoneNumber = "714755866",
    //        //MedicalRecords
    //    });

    //}

}
