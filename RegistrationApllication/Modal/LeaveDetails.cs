using System;
using System.ComponentModel.DataAnnotations;

namespace RegistrationApllication.Modal
{
    public class LeaveDetails
    {
        [Key]
        public int LeaveId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public DateTime DateTime { get; set; }

    }
}
