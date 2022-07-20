using System;
using Core.Constans;
using Core.Helpers;

namespace AcademyApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Salam");
            Console.WriteLine("----");

            while (true)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "1 - Create Group");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "2 - Update Group");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "3 - Delete Group");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "4 - Get Group ");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "5 - GetAll Group");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "0 - Exit");
                Console.WriteLine("----");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Select option");
                string number = Console.ReadLine();

                int selectedNumber;
                bool result = int.TryParse(number, out selectedNumber);
                if (result)
                {
                    if (selectedNumber >= 0 && selectedNumber <=5)
                    {
                        switch (selectedNumber)
                        {
                            case (int)Options.GreateGroup:
                                break;
                            case (int)Options.UpdateGroup:
                                break;
                            case (int)Options.DeleteGroup:
                                break;
                            case (int)Options:AllGroups:                       
                                break;
                            case (int)Options:GetGroupByName:
                                break;
                            case (int)Options:Exit:
                                break;
                               
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "mumkunse duzgun reqemi daxil edin");
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "mumkunse duzgun reqemi daxil edin");
                }

             }

            

           



        }
    }
}
