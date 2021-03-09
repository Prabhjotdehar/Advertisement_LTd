using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advertisement_LTd.Models

{
    //This class display the job details under which it has job id, job role, job type, job salary, job description, employer id
    public class Job_Detail
    {
        public int Id { get; set; }
        public string Job_role { get; set; }
        public string Job_type { get; set; }
        public decimal Job_salary { get; set; }
        public string Job_description { get; set; }
        public int EmployerId { get; set; }
        public Employer Employer { get; set; }
    }
}
