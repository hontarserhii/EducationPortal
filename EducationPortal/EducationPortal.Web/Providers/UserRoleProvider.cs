using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using EducationPortal.Core.Entities;
using EducationPortal.Core;

namespace EducationPortal.Web.Providers
{
    public class UserRoleProvider : RoleProvider
    {
        private IUser userService;

        public UserRoleProvider(IUser userService)
        {
            this.userService = userService;
        }

        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string userId, string roleId)
        {
            User user = userService.GetUserInfo(Int32.Parse(userId));
            bool result = false;
            if (user != null)
            {
                if (user.Role.Id == Int32.Parse(roleId))
                    result = true;
                else
                    result = false;
            }
            return result;
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}