using AIPFramework.Entities;
using AYweb.Domain.Models.User.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Domain.Models.Role.Entities
{
    public class Role_Users : Entity
    {
        #region Properties
        public int RoleId { get; set; }
        public int UserId { get; set; }

        public Role Role { get; set; }
        public User.Entities.User User { get; set; }
        public bool IsDelete { get; set; }
        #endregion

        #region Constructor And Factories
        private Role_Users() { }
        public Role_Users(int roleId, int userId)
        {
            RoleId = roleId;
            UserId = userId;
            CreateAt = DateTime.Now;
        }
        public static Role_Users Create(int roleId, int userId)
        {
            return new Role_Users(roleId, userId);
        } 
        #endregion

        #region Common

        private void Modified()
        {
            ModifiedAt = DateTime.Now;
        }

        public void Delete()
        {
            IsDelete = true;
            Modified();
        }

        #endregion
    }
}
