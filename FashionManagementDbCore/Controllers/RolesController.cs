using FashionManagementDbCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FashionManagementDbCore.Controllers
{
    public class RolesController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public RolesController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {

            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View(roleManager.Roles);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoleName")] Role role)
        {

            if (ModelState.IsValid)
            {


                IdentityResult result = await roleManager.CreateAsync(new IdentityRole(role.RoleName));

                if (result.Succeeded)
                {

                    return RedirectToAction("Index");
                }

                string errors = "";

                foreach (IdentityError error in result.Errors)
                {
                    errors += error.Description + "\n";
                }

                return Content("An error occurred. \n" + errors);
                return View(role);

            }
            else
            {

                return View(role);
            }

            return Content("We have successfully submitted");
        }

        public async Task<IActionResult> Delete(string id)
        {

            IdentityRole role = await roleManager.FindByIdAsync(id);
            //roleManager.DeleteAsync(role);
            return Content("Attempting to delete with role id of " + id);
        }
        public async Task<IActionResult> ManageUsers(string id)
        {

            IdentityRole role = await roleManager.FindByIdAsync(id);

            if (role == null)
            {

                return RedirectToAction("Index");
            }

            List<IdentityUser> members = new List<IdentityUser>();
            List<IdentityUser> nonmembers = new List<IdentityUser>();

            foreach (IdentityUser currentUser in userManager.Users.ToList())
            {

                if (await userManager.IsInRoleAsync(currentUser, role.Name))
                {

                    members.Add(currentUser);
                }
                else
                {
                    nonmembers.Add(currentUser);
                }
            }

            RoleManagement model = new RoleManagement
            {
                Role = role,
                Members = members,
                NonMembers = nonmembers
            };
            return View(model);
        }

        [Route("RolesController/AddMemberToRole/{userId}/{roleId}")]
        public async Task<IActionResult> AddMemberToRole(string userId, string roleId)
        {


            //userManager.AddToRoleAsync(userObjectAsWhole, RoleName)

            return Content("UserID = " + userId + " RoleID = " + roleId);
        }

    }
}
