using System.Collections.Generic;
using System.Threading.Tasks;
using cw8.Models;

namespace cw8.DAL
{
    public interface IDoctorService
    {
        public IEnumerable<Doctor> GetDoctors();
        public Task<Doctor> AddDoctor(Doctor doctor);
        public Task<Doctor> UpdateDoctor(int idDoctor, Doctor doctor);
        public Task<Doctor> DeleteDoctor(int idDoctor);
    }
}