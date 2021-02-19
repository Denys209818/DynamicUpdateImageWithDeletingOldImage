using Hospital.DAL;
using Hospital.WindowsForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital.WindowsForm.Services
{
    public class DoctorService
    {
        public static DoctorViewGrid Search(MyContext context, SearchDoctor search)
        {
            DoctorViewGrid model = new DoctorViewGrid();
            //отримуємо усі записи в оперативку
            //var query = context.Doctors.AsEnumerable();//.AsQueryable();
            //ми формуємо sql запит до БД - нічого з БД не отримуємо в цьому рядку
            var query = context.Doctors.AsQueryable();
            //Якщо DepartmentId !=null
            if (search.DepartmentId.HasValue)
            {
                query = query.Where(x => x.DepartmentId == search.DepartmentId.Value);
            }
            //Якщо у search.Name != null
            if (!string.IsNullOrEmpty(search.FirstName))
            {
                query = query.Where(x => x.FirstName.Contains(search.FirstName));
            }

            if (!string.IsNullOrEmpty(search.LastName))
            {
                query = query.Where(x => x.LastName.Contains(search.LastName));
            }
            int page = search.Page - 1;
            int showItems = search.CountShowOnePage;
            model.CountRows = query.Count();
            model.Doctors = query
                .OrderBy(x=>x.Id)
                .Skip(page*showItems)
                .Take(showItems)
                .Select(x=>new DoctorItemView {
                    Id=x.Id,
                    Name = x.LastName+" "+x.FirstName,
                    Stage=x.Stage,
                    Department=x.Department.Name
                }).ToList();

            return model;
        }
    }
}
