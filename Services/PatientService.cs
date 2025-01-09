
using EmotionCareServer.Models;
using Microsoft.EntityFrameworkCore;

namespace EmotionCareServer.Services
{
    public class PatientService : IPatientService
    {
        private readonly AppDbContext _context;

        public PatientService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Patient>> GetAllAsync()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task<Patient?> GetByIdAsync(int id)
        {
            return await _context.Patients.FindAsync(id);
        }

        public async Task<Patient> CreateAsync(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
            return patient;
        }

        public async Task<Patient?> UpdateAsync(int id, Patient patient)
        {
            var existingPatient = await _context.Patients.FindAsync(id);
            if (existingPatient == null) return null;

            existingPatient.Password = patient.Password;
            existingPatient.Name = patient.Name;
            existingPatient.Email = patient.Email;
            existingPatient.Age = patient.Age;
            existingPatient.ProfilePicture = patient.ProfilePicture;
            existingPatient.PsychologistId = patient.PsychologistId;
            existingPatient.OrganizationListId = patient.OrganizationListId;

            await _context.SaveChangesAsync();
            return existingPatient;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null) return false;

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
