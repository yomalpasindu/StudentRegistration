﻿using StudentRegistration.Modles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Services
{
    public interface IStudentRepository
    {
        public List<Students> GetStudents();
    }
}
