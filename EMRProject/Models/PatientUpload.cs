using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMRProject.Models
{
    public class PatientUpload
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public PatientUpload()
        {

        }
    }
}
