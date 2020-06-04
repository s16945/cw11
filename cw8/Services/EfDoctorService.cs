using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cw8.Models;

namespace cw8.DAL
{
    public class MssqlDoctorService : IDoctorService
    {
        private s16945Context _dbContext;

        public MssqlDoctorService(s16945Context dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            return _dbContext.Doctor.ToList();
        }

        public async Task<Doctor> AddDoctor(Doctor doctor)
        {
            _dbContext.Add(doctor);
            await _dbContext.SaveChangesAsync();
            return doctor;
        }

        public async Task<Doctor> UpdateDoctor(int idDoctor, Doctor doctor)
        {
            var existingDoctor = _dbContext.Doctor.SingleOrDefault(s => s.IdDoctor == idDoctor);
            if (existingDoctor == null)
            {
                return null;
            }

            _dbContext.Attach(existingDoctor);
            existingDoctor.FirstName = doctor.FirstName;
            existingDoctor.LastName = doctor.LastName;
            existingDoctor.Email = doctor.Email;
            existingDoctor.Prescriptions = doctor.Prescriptions;
            await _dbContext.SaveChangesAsync();
            return existingDoctor;
        }

        public async Task<Doctor> DeleteDoctor(int idDoctor)
        {
            var doctor = _dbContext.Doctor.SingleOrDefault(s => s.IdDoctor == idDoctor);
            if (doctor == null)
            {
                return null;
            }

            _dbContext.Remove(doctor);
            await _dbContext.SaveChangesAsync();
            return doctor;
        }
    }
}