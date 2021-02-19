using Hospital.DAL;
using Hospital.WindowsForm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hospital.WindowsForm
{
    public partial class UserProfileForm : Form
    {
        public UserProfileForm()
        {
            InitializeComponent();
        }

        private void UserProfileForm_Load(object sender, EventArgs e)
        {
            using (MyContext context = new MyContext())
            {
                var doctor = context.Doctors.SingleOrDefault(x => x.Id == DoctorLogin.Id);
                lblName.Text = $"{doctor.LastName} {doctor.FirstName}";
                pbAvatar.Image = Image.FromFile($"images/{doctor.Image}");
            }
        }

        private void pbAvatar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if(dlg.ShowDialog()==DialogResult.OK)
            {
                var extension = Path.GetExtension(dlg.FileName);
                var imageName = Path.GetRandomFileName()+extension;
                var dir =Directory.GetCurrentDirectory();
                var fileSave = Path.Combine(dir, "images", imageName);
                File.Copy(dlg.FileName, fileSave);
                pbAvatar.Image = Image.FromFile($"images/{imageName}");
                using (MyContext context = new MyContext())
                {
                    var doctor = context.Doctors.SingleOrDefault(x => x.Id == DoctorLogin.Id);
                    doctor.Image = imageName;
                    context.SaveChanges();
                }
            }
        }
    }
}
