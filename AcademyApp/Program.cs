using System;
using Core.Constans;
using Core.Entities;
using Core.Helpers;
using DataAccess.Repositories.Implementations;
using Manage.Controllers;

namespace AcademyApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            GroupController _groupController = new GroupController();
            StudentController _studentController = new StudentController();
            AdminController _adminController = new AdminController();
            TeacherController _teacherController = new TeacherController();
           

            Authentication:  var admin = _adminController.Authenticate();


            if (admin != null)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Hello,{admin.Username}");
                Console.WriteLine("----");

                while (true)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "1 - Create Group");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "2 - Update Group");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "3 - Delete Group");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "4 - All Groups");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "5 - Get Group By Name");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "6 - Create Student");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "7-  Update Student");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "8 - Delete Student");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "9 - Get Student by Group");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "10 - All Students by Group");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "11 - Create Teacher");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "12-  Update Teacher");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "13 - Delete  Teacher");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "14- Get All");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "15- Get All teachers by group");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "16 - Add group to teacher");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "0 - Exit");
                    Console.WriteLine("----");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Select option");
                    string number = Console.ReadLine();

                    int selectedNumber;
                    bool result = int.TryParse(number, out selectedNumber);
                    if (result)
                    {
                        if (selectedNumber >= 0 && selectedNumber <= 16)
                        {
                            switch (selectedNumber)
                            {
                                case (int)Options.CreateGroup:
                                CreateGroup: _groupController.CreateGroup();
                                    break;
                                case (int)Options.UpdateGroup:
                                    _groupController.UpdateGroup();
                                    break;
                                case (int)Options.DeleteGroup:
                                    _groupController.DeleteGroup();
                                    break;
                                case (int)Options.AllGroups:
                                    _groupController.AllGroups();
                                    break;
                                case (int)Options.GetGroupByName:
                                    _groupController.GetGroupByName();
                                    break;
                                case (int)Options.CreateStudent:
                                    _studentController.CreateStudent();
                                    break;
                                case (int)Options.UpdateStudent:
                                    _studentController.UpdateStudent();
                                    break;
                                case (int)Options.DeleteStudent:
                                    _studentController.DeleteStudent();
                                    break;
                                case (int)Options.AllStudentsByGroup:
                                    _studentController.AllStudenstByGroup();
                                    break;
                                case (int)Options.GetStudentByGroup:
                                    _studentController.GetStudentByGroup();
                                    break;
                                case (int)Options.CreateTeacher:
                                    _teacherController.CreateTeacher();
                                    break;
                                case (int)Options.UpdateTeacher:
                                    _teacherController.UpdateTeacher();
                                    break;
                                case (int)Options.DeleteTeacher:
                                    _teacherController.DeleteTeacher();
                                    break;
                                case (int)Options.GetAll:
                                    _teacherController.GetAll();
                                    break;
                                case (int)Options.AddGroupToTeacher:
                                    _teacherController.AddGroupToTeacher();
                                    break;
                                case (int)Options.GetAllGroupsByTeacher:
                                    _teacherController.GetAllGroupsByTeacher();
                                    break;
                                case (int)Options.Exit:
                                    _groupController.Exit();
                                    return;

                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct number");
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct number");
                    }
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Admin username or password is incorrect");
                goto Authentication;
            }
        }
    }
}
