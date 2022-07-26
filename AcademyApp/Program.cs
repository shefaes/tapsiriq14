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
            //AdminRepository _adminRepository = new AdminRepository();
            //GroupRepository _groupRepository = new GroupRepository();
            //StudentRepository _studentRepository = new StudentRepository();

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
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "4 - All Groups ");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "5 - Get Group By Name ");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "6 - Create Student ");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "7-  Update Student ");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "8 - Delete Student ");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "9 - Get Student by Group ");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "10 - Get All Student by Group");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "0 - Exit");
                    Console.WriteLine("----");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Select option");
                    string number = Console.ReadLine();

                    int selectedNumber;
                    bool result = int.TryParse(number, out selectedNumber);
                    if (result)
                    {
                        if (selectedNumber >= 0 && selectedNumber <= 10)
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
                                case (int)Options.GetAllStudentByGroup:
                                    _studentController.GetAllStudentByGroup();
                                    break;
                                case (int)Options.GetStudentByGroup:
                                    _studentController.GetAllStudentByGroup();
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
