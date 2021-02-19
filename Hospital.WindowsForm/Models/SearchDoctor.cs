using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.WindowsForm.Models
{
    public class SearchDoctor
    {
        public int ? DepartmentId { get; set; }
        public string LastName { get; set; }
        /// <summary>
        /// Ім'я лікаря
        /// </summary>
        public string FirstName { get; set; }
        public int Page { get; set; }
        /// <summary>
        /// Кількість записів на сторінці
        /// </summary>
        public int CountShowOnePage { get; set; } = 10;
    }
}
