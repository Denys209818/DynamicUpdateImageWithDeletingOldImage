using Hospital.DAL;
using Hospital.WindowsForm.Models;
using Hospital.WindowsForm.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital.WindowsForm
{
    public partial class MainForm : Form
    {
        bool isAuth = false;
        private readonly MyContext _context;
        //номер сторінки
        private int _page = 1;
        public MainForm()
        {

            //LoginForm login_dlg = new LoginForm();
            //if (login_dlg.ShowDialog() == DialogResult.OK)
            //{
                isAuth = true;
                _context = new MyContext();
            DbSeeder.SeedAll(_context);

            var info = _context.Sessions
                .Where(x => x.UserId == 1)
                .Select(x => new
                {
                    Name= x.User.LastName+" "+x.User.FirstName,
                    Begin=x.Begin,
                    End=x.End,
                    Mark=x.Marks,
                    Quesions = x.Results.Select(y=> new
                    {
                        Text= y.Answer.Question.Text,
                        isTrue=y.Answer.IsTrue
                        
                    })
                }).ToList();
            //}
            InitializeComponent();
        }

        
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!isAuth)
            {
                Application.Exit();
            }
            else
            {
                SearchDoctor();


                foreach (var department in _context.Departments)
                {
                    CustomComboBoxItem item = new CustomComboBoxItem
                    {
                        Id = department.Id,
                        Name = department.Name
                    };
                    cbDepatments.Items.Add(item);
                }

                cbCountShowOnePage.Items.AddRange(
                    new List<CustomComboBoxItem> {
                            new CustomComboBoxItem { Id=1, Name="10" },
                            new CustomComboBoxItem { Id=2, Name="20" },
                            new CustomComboBoxItem { Id=3, Name="30" },
                            new CustomComboBoxItem { Id=4, Name="50" }
                       }.ToArray()
                    );
                cbCountShowOnePage.SelectedIndex = 0;
            }
        }

        private void btnPage_Click(object sender, EventArgs e)
        {
            string s = (sender as Button).Text;
            _page = int.Parse(s);
            SearchDoctor(GetSearchInputValue());
        }
        private void btnShowProfile_Click(object sender, EventArgs e)
        {
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void profileStripMenuItem_Click(object sender, EventArgs e)
        {
            UserProfileForm dlg = new UserProfileForm();
            dlg.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Якщо робимо пошук переходимо на початок
            _page = 1;
            SearchDoctor(GetSearchInputValue());
        }

        private SearchDoctor GetSearchInputValue()
        {
            SearchDoctor search = new SearchDoctor();
            var item = cbDepatments.SelectedItem;
            if (item != null)
            {
                var dep = cbDepatments.SelectedItem as CustomComboBoxItem;
                search.DepartmentId = dep.Id;
            }
            search.FirstName = txtName.Text;
            search.LastName = txtLastName.Text;
            var countSelect = cbCountShowOnePage.SelectedItem as CustomComboBoxItem;
            search.CountShowOnePage = int.Parse(countSelect.Name);
            return search;
        }

        private void SearchDoctor(SearchDoctor search = null)
        {
            dataGridView1.Rows.Clear();
            //if (search == null) 
            //    search = new SearchDoctor();
            search ??= new SearchDoctor();
            search.Page = _page;
            var result = DoctorService.Search(_context, search);
            foreach (var item in result.Doctors)
            {
                object[] row = {
                        item.Id,
                        item.Name,
                        item.Stage,
                        item.Department
                    };
                dataGridView1.Rows.Add(row);
            }
            int begin = (_page - 1) * search.CountShowOnePage + 1;
            int end = begin + (search.CountShowOnePage - 1);
            lblRange.Text = $"Показ: {begin} - {end}";
            lblCount.Text = "Всього записів: "+ result.CountRows.ToString();

            int totalPage = (int)Math.Ceiling((double)result.CountRows / search.CountShowOnePage);

            //Малюю кнопки 1, 2, ...
            int positionX = 10;
            int dx = 50;
            gbBoxButtons.Controls.Clear();
            for (int i = 1; i <= totalPage; i++)
            {
                Button btn = new Button();
                btn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                btn.Location = new System.Drawing.Point(positionX, 10);
                btn.Name = $"btnPage{i}";
                btn.Size = new System.Drawing.Size(45, 45);
                btn.Text = $"{i}";
                btn.UseVisualStyleBackColor = true;

                btn.Click += new System.EventHandler(this.btnPage_Click);
                gbBoxButtons.Controls.Add(btn);
                positionX += dx;
            }

        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (_page > 1)
            {
                _page -= 1;
                SearchDoctor(GetSearchInputValue());
            }
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            _page += 1;
            SearchDoctor(GetSearchInputValue());
        }

        private void startQuestionStrictMenuItem_Click(object sender, EventArgs e)
        {
            QuestionForm dlg = new QuestionForm(_context);
            dlg.ShowDialog();
        }
    }
}
