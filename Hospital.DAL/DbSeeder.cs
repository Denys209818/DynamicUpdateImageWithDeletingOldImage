using Hospital.DAL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital.DAL
{
    public static class DbSeeder
    {
        public static void SeedAll(MyContext context)
        {
            SeedDepatrment(context);
            SeedDoctor(context);
            SeedQuestion(context);
            SeedUser(context);
            SeedSession(context);
            SeedResult(context);
        }


        private static void SeedQuestion(MyContext context)
        {
            if (context.Questions.Count()==0)
            {
                var question = new Question
                {
                    Text = "Скільки планет в Сонячній системі?",
                };
                context.Questions.Add(question);
                context.SaveChanges();
                
                var answers = new List<Answer>
                {
                    new Answer { Text="8", IsTrue=true, QuestionId=question.Id },
                    new Answer { Text="9", IsTrue=false, QuestionId=question.Id },
                    new Answer { Text="10", IsTrue=false, QuestionId=question.Id }
                };
                context.Answers.AddRange(answers);
                context.SaveChanges();
                
                question = new Question
                {
                    Text = "Яке небесне тіло було раніше планетою?",
                };
                context.Questions.Add(question);
                context.SaveChanges();
                
                answers = new List<Answer>
                {
                    new Answer { Text="Місяць", IsTrue=false, QuestionId=question.Id },
                    new Answer { Text="Плутон", IsTrue=true, QuestionId=question.Id },
                    new Answer { Text="Харон", IsTrue=false, QuestionId=question.Id },
                    new Answer { Text="Церера", IsTrue=false, QuestionId=question.Id }
                };
                context.Answers.AddRange(answers);
                context.SaveChanges();

                question = new Question
                {
                    Text = "Що знаходиться між орбітами Марса та Юпітера?",
                };
                context.Questions.Add(question);
                context.SaveChanges();
                
                answers = new List<Answer>
                {
                    new Answer { Text="Пояс Койпера", IsTrue=false, QuestionId=question.Id },
                    new Answer { Text="Пояс астероїдів", IsTrue=true, QuestionId=question.Id },
                    new Answer { Text="Кільця Сатурна", IsTrue=false, QuestionId=question.Id }
                };
                context.Answers.AddRange(answers);
                context.SaveChanges();

                question = new Question
                {
                    Text = "Скільки супутників у Юпітера?",
                };
                context.Questions.Add(question);
                context.SaveChanges();

                answers = new List<Answer>
                {
                    new Answer { Text="13", IsTrue=false, QuestionId=question.Id },
                    new Answer { Text="47", IsTrue=false, QuestionId=question.Id },
                    new Answer { Text="79", IsTrue=true, QuestionId=question.Id },
                    new Answer { Text="97", IsTrue=false, QuestionId=question.Id }
                };
                context.Answers.AddRange(answers);
                context.SaveChanges();

                question = new Question
                {
                    Text = "Яка ще гіпотетична планета обертається навколо Сонця?",
                };
                context.Questions.Add(question);
                context.SaveChanges();

                answers = new List<Answer>
                {
                    new Answer { Text="Тіамат", IsTrue=false, QuestionId=question.Id },
                    new Answer { Text="Фаетон", IsTrue=false, QuestionId=question.Id },
                    new Answer { Text="Нібіру", IsTrue=true, QuestionId=question.Id }
                };
                context.Answers.AddRange(answers);
                context.SaveChanges();
            }

        }


        private static void SeedDepatrment(MyContext context)
        {
            if(context.Departments.Count()==0)
            {
                context.Departments
                    .Add(
                    new Department
                    {
                        Name="Хіругрія",
                        NumberCabinet=243
                    });

                context.Departments
                    .Add(
                    new Department
                    {
                        Name = "Інфекційне",
                        NumberCabinet = 12
                    });
                context.SaveChanges();
            }
        }

        private static void SeedDoctor(MyContext context)
        {
            if (context.Doctors.Count() == 0)
            {
                context.Doctors
                    .Add(
                    new Doctor
                    {
                        FirstName="Влад",
                        LastName="Яма-Подвал",
                        Login="vladik",
                        Password= PasswordManager.HashPassword("123456"),
                        Stage=15,
                        Image="1.jpg",
                        Department= context.Departments
                        .FirstOrDefault(x=>x.Name== "Хіругрія")
                    });

                context.Doctors
                    .Add(
                    new Doctor
                    {
                        FirstName = "Опенько",
                        LastName = "Лісовик",
                        Login = "beaver",
                        Password = PasswordManager.HashPassword("xvost"),
                        Image="3.jpg",
                        Stage = 25,
                        Department = context.Departments
                        .FirstOrDefault(x => x.Name == "Інфекційне")
                    });


                context.SaveChanges();
            }
        }

        private static void SeedUser(MyContext context)
        {
            if (context.Users.Count() == 0)
            {
                context.Users
                    .Add(
                    new User
                    {
                        FirstName = "Оксана",
                        LastName = "Мельник",
                        Login = "gena",
                        Password = PasswordManager.HashPassword("123456"),
                    });

                context.SaveChanges();
            }
        }

        private static void SeedSession(MyContext context)
        {
            if (context.Sessions.Count() == 0)
            {
                context.Sessions
                    .Add(
                    new Session
                    {
                        Begin=DateTime.Now,
                        End=DateTime.Now.AddMinutes(26),
                        Marks=75.4M,
                        UserId=1
                    });

                context.SaveChanges();
            }
        }

        private static void SeedResult(MyContext context)
        {
            if (context.Results.Count() == 0)
            {
                context.Results
                    .Add(
                    new Result
                    {
                        SessionId= 1,
                        AnswerId = 2
                    });
                context.Results
                    .Add(
                    new Result
                    {
                        SessionId = 1,
                        AnswerId = 5
                    });
                context.Results
                   .Add(
                   new Result
                   {
                       SessionId = 1,
                       AnswerId = 9
                   });
                context.Results
                   .Add(
                   new Result
                   {
                       SessionId = 1,
                       AnswerId = 13
                   });

                context.Results
                   .Add(
                   new Result
                   {
                       SessionId = 1,
                       AnswerId = 16
                   });

                context.SaveChanges();
            }
        }

    }
}
