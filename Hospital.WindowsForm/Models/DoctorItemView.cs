using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.WindowsForm.Models
{
    public class DoctorViewGrid
    {
        /// <summary>
        /// Записи, які ми відображаємо по пошуку
        /// </summary>
        public List<DoctorItemView> Doctors { get; set; }
        /// <summary>
        /// Загальна кількість записів, які ми знайшли
        /// </summary>
        public int CountRows { get; set; }
    }

    public class DoctorItemView
    {
        public int Id { get; set; }
        /// <summary>
        /// Повне ім'я (прізвище + ім'я) хворого
        /// </summary>
        public string Name { get; set; }
        public int Stage { get; set; }
        public string Department { get; set; }
    }
}
