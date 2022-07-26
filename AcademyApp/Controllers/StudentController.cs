using Core.Entities;
using Core.Helpers;
using DataAccess.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Controllers
{
    public class StudentController
    {
        private StudentRepository _studentRepository;
        private GroupRepository _groupRepository;

        public StudentController()
        {
            _studentRepository = new StudentRepository();
            _groupRepository = new GroupRepository();
        }

        public void CreateStudent()
        {
            var groups = _groupRepository.GetAll();
            if (groups.Count != 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter stduent name:");
                string name = Console.ReadLine();

                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter student surname:");
                string surname = Console.ReadLine();

                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter student age:");
                string age = Console.ReadLine();
                byte studentAge;
                bool result = byte.TryParse(age, out studentAge);

            AllGroupsList: ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "All groups");

                foreach (var group in groups)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, group.Name);
                }

                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter group name:");
                string groupName = Console.ReadLine();

                var dbGroup = _groupRepository.Get(g => g.Name.ToLower() == groupName.ToLower());
                if (dbGroup != null)
                {
                    if (dbGroup.MaxSize > dbGroup.CurrentSize)
                    {
                        var student = new Student
                        {
                            Name = name,
                            Surname = surname,
                            Age = studentAge,
                            Group = dbGroup
                        };

                        dbGroup.CurrentSize++;

                        _studentRepository.Create(student);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Name: {student.Name}, Surname: {student.Surname}, Age:{student.Age}, Group: {student.Group.Name}");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, $"Group is full, max size of group {dbGroup.MaxSize}");
                    }
                }

                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Including group doesn't exist");
                    goto AllGroupsList;
                }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "you must create group before creating of student");


            }
        }

        public void DeleteStudent()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter student name");
            string name = Console.ReadLine();
            var student = _studentRepository.Get(g => g.Name.ToLower() == name.ToLower());
            if (student != null)
            {
                _studentRepository.Delete(student);
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, $"{name} is deleted");

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This student doesn't exist");
            }

        }

        public void GetAllStudentByGroup()
        {
            var groups = _groupRepository.GetAll();
        GroupAllList: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "All groups");

            foreach (var group in groups)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, group.Name);
            }
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter group name:");
            string groupName = Console.ReadLine();

            var dbGroup = _groupRepository.Get(g => g.Name.ToLower() == groupName.ToLower());
            if (dbGroup != null)
            {
                var groupStudents = _studentRepository.GetAll(s => s.Group.Id == dbGroup.Id);

                if (groupStudents.Count != 0)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "All students of the group:");
                    foreach (var groupStudent in groupStudents)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{groupStudent.Name}, {groupStudent.Surname}, {groupStudent.Age}, {groupStudent.Id}");
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"There is no student in this group {dbGroup.Name}");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Including group doesnt exist");
            }


        }

        public void GetStudentByGroup()
        {  
            
            

        }


        public void UpdateStudent()
        {
            GetAllStudentByGroup();
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter student id");
            string id = Console.ReadLine();
            int studentid;
            bool result = int.TryParse(id, out studentid);
            var studentId = _studentRepository.Get(s => s.Id == studentid);
            if (studentId != null)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "please enter new student name:");
                string newName = Console.ReadLine();
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "please enter new student surname:");
                string newSurname = Console.ReadLine();
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "please enter new student age");
                string Age = Console.ReadLine();
                byte newAge;
                result = byte.TryParse(Age, out newAge);
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "enter New group name");
            Groupname: string newGroupName = Console.ReadLine();

                if (studentId.Group.Name.ToLower() == newGroupName)
                {
                    studentId.Surname = newSurname;
                    studentId.Age = newAge;
                    studentId.Name = newName;
                    _studentRepository.Update(studentId);
                }
                else
                {
                    studentId.Surname = newSurname;
                    studentId.Age = newAge;
                    studentId.Name = newName;
                    var group = _groupRepository.Get(g => g.Name.ToLower() == newGroupName.ToLower());
                    if (group != null)
                    {
                        studentId.Group.CurrentSize--;
                        studentId.Group = _groupRepository.Get(g => g.Name.ToLower() == newGroupName.ToLower());
                        studentId.Group.CurrentSize++;
                        _studentRepository.Update(studentId);
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Please enter correct group name");
                        goto Groupname;
                    }



                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please correct student ID");
            }




            
        }



    }
}







