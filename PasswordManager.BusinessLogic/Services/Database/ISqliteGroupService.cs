using PasswordManager.BusinessLogic.Models;

namespace PasswordManager.BusinessLogic.Services.Database
{
    public interface ISqliteGroupService
    {
        void AddGroup(Group group);
        void CreateIfNotExists();
        void DeleteGroup(int id);
        List<Group> LoadGroups();
        void UpdateGroup(Group group);
    }
}