using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCA.Data.Models
{
    public class AttendanceModel
    {
        public int AttendanceId { get; set; }
        public int StudentId { get; set; }

        public bool Status { get; set; }

        public DateTime Date { get; set; }

    }
}
