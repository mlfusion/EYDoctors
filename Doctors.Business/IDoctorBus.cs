using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Doctors.Models;

namespace Doctors.Business
{
    public interface IDoctorBus
    {
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<Doctor> GetDoctor(int id);
        Task<Doctor> AddDoctor(Doctor doctor);

    }
}
