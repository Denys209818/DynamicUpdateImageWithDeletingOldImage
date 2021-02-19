using Hospital.DAL;
using Hospital.DAL.Helpers;
using Hospital.WindowsForm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hospital.WindowsForm
{
    public partial class LoginForm : Form
    {
        private readonly MyContext context;

        public LoginForm()
        {
            context = new MyContext();
            InitializeComponent();

            DbSeeder.SeedAll(context);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text;
            string password = txtPassword.Text;
            var doctor = context.Doctors.FirstOrDefault(x=>x.Login==login);
            if(doctor!=null)
            {
                var passwordHash = doctor.Password;
                if (PasswordManager.Verify(password, passwordHash))
                {
                    DoctorLogin.Id = doctor.Id;
                    DoctorLogin.Image = doctor.Image;
                    //DoctorAuth = doctor;
                    this.DialogResult = DialogResult.OK;
                }
                else
                    MessageBox.Show("Думайте...");
            }
            else
                MessageBox.Show("Думайте...");

        }
    }
}
