using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using StudentProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentProject.Models.SeedRoles
{
    public class SeedRoles
    {
        private ApplicationDbContext _schAppContext;
        private readonly UserManager<SchoolsApplicationUser> _schAppUserManager;
        private readonly RoleManager<IdentityRole> _schAppRoleTab;
        public SeedRoles(ApplicationDbContext schAppContext, RoleManager<IdentityRole> schAppRoleTab,
            UserManager<SchoolsApplicationUser> schAppUserManager)
        {
            _schAppContext = schAppContext;
            _schAppUserManager = schAppUserManager;
            _schAppRoleTab = schAppRoleTab;
        }
        public async Task SeedRole()
        {
            var roleStore = new RoleStore<IdentityRole>(_schAppContext);
            #region Admin Role
            if (!_schAppContext.Roles.Any(r => r.Name == ConstantRoles.Admin))
            {
                var role = new IdentityRole()
                {
                    Id = "Admin001",
                    Name = ConstantRoles.Admin.ToString().Trim()
                };

                await _schAppRoleTab.CreateAsync(role);
            }
            #endregion
            #region School Admin Role
            if (!_schAppContext.Roles.Any(r => r.Name == ConstantRoles.SchoolAdmin))
            {
                var role = new IdentityRole()
                {
                    Id = "SchoolAdmin001",
                    Name = ConstantRoles.SchoolAdmin.ToString().Trim()
                };

                await _schAppRoleTab.CreateAsync(role);
            }
            #endregion

            #region Schools
            if (!_schAppContext.Roles.Any(r => r.Name == ConstantRoles.School))
            {
                var role = new IdentityRole()
                {
                    Id = "School001",
                    Name = ConstantRoles.School.ToString().Trim(),

                };

                await _schAppRoleTab.CreateAsync(role);
            }
            #endregion
            #region Spellers
            if (!_schAppContext.Roles.Any(r => r.Name == ConstantRoles.Spellers))
            {
                var role = new IdentityRole()
                {
                    Id = "Spellers01",
                    Name = ConstantRoles.Spellers.ToString().Trim()
                };
                await _schAppRoleTab.CreateAsync(role);
            }
            #endregion
            #region Parent Role
            if (!_schAppContext.Roles.Any(r => r.Name == ConstantRoles.Parent))
            {
                var role = new IdentityRole()
                {

                    Id = "Parent001",
                    Name = ConstantRoles.Parent.ToString().Trim()
                };
                await _schAppRoleTab.CreateAsync(role);
            }
            #endregion
            #region Student Role

            #endregion

            var getAdmin = await _schAppUserManager.FindByEmailAsync("michealmadu73@gmail.com");
            if (getAdmin == null)
            {
                var userd = new SchoolsApplicationUser
                {
                    Id = "SystemAdmin101",
                    Email = "michealmadu73@gmail.com",
                    UserName = "Admin",
                    FullName = "System Administrator",
                    AccountRole = "Admin",
                    CreatedBy = "Automatic",
                    DateCreated = DateTime.Now.ToString(),
                    EmailConfirmed = true
                };
                await _schAppUserManager.CreateAsync(userd, "Oj5!%hs17");
                await _schAppUserManager.AddToRoleAsync(userd, ConstantRoles.Admin);
            }
        }
    }
}
