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
    public class GroupController
    {
        private GroupRepository _groupRepository;

        public GroupController()
        {
            _groupRepository = new GroupRepository();
        }
        #region CreateGroup
        public void CreateGroup()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter group name:");
            string name = Console.ReadLine();

        MaxSize: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter group max size:");
            string size = Console.ReadLine();
            int maxSize;
            bool result = int.TryParse(size, out maxSize);
            if (result)
            {
                Group group = new Group
                {
                    Name = name,
                    MaxSize = maxSize
                };
                var createdGroup = _groupRepository.Create(group);
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{createdGroup.Name} is successfully created with max size:");
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct group max size:");
                goto MaxSize;
            }
        }
        #endregion

        #region update
        public void UpdateGroup()
        {
            var groups = _groupRepository.GetAll();
            if (groups.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "All groups");

                foreach (var dbGroup in groups)
                {
                    Console.WriteLine($"Id-{dbGroup.Id}, name-{dbGroup.Name}");
                }
            ID: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Enter group id:");
                int chosenId;
                string id = Console.ReadLine();
                var result = int.TryParse(id, out chosenId);

                if (result)
                {
                    var group = _groupRepository.Get(g => g.Id == chosenId);
                    if (group != null)
                    {
                        int oldSize = group.MaxSize;
                        string oldName = group.Name;
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Enter new group name:");
                        string newName = Console.ReadLine();

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Enter new group max size:");
                        string size = Console.ReadLine();

                        int maxSize;
                        result = int.TryParse(size, out maxSize);

                        if (result)
                        {
                            var newGroup = new Group
                            {
                                Id = group.Id,
                                Name = newName,
                                MaxSize = maxSize
                            };
                            _groupRepository.Update(newGroup);
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, $"Name:{oldName} Max size:, {oldSize} is updated to name:");
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, $"Please enter correct group max size:");
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, $"Please enter correct group name:");
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, $"Please enter correct id:");
                    goto ID;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, $"There are no any groups:");
            }
        }
        #endregion

        #region GetGroupByName

        public void GetGroupByName()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.White, "Enter group name:");
            string name = Console.ReadLine();

            var group = _groupRepository.Get(g => g.Name.ToLower() == name.ToLower());
            if (group != null)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Name:{group.Name}, Max size:{group.MaxSize}");
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "this group doesn't exist");
            }

        }
        #endregion

        #region AllGroups

        public void AllGroups()
        {
            var groups = _groupRepository.GetAll();
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "All groups");
            foreach (var group in groups)
            {
                Console.WriteLine($"Name:{group.Name}, Max size:{group.MaxSize}");
            }

        }

        #endregion

        #region DeleteGroup

        public void DeleteGroup()
        {
            var groups = _groupRepository.GetAll();
            if (groups.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "All groups");

                foreach (var dbGroup in groups)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, $"Id - {dbGroup.Id}, Name -{dbGroup.Name}");
                }
            Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter group id:");
                int chosenId;
                string id = Console.ReadLine();
                var result = int.TryParse(id, out chosenId);
                if (result)
                {
                    var group = _groupRepository.Get(g => g.Id == chosenId);
                    if (group != null)
                    {
                        string name = group.Name;
                        _groupRepository.Delete(group);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{name} is deleted");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This group doesn't exist");

                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct Id");
                    goto Id;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There are no any groups");
            }
        }
        #endregion

        #region Exit

        public void Exit()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "Thanks for using our application");

        }

        #endregion
    }
}
