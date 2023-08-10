using System;
using System.Collections.Generic;
using System.Text;

namespace VisionCar.Application.InputModels
{
    public class CreateUserInputModel
    {
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
