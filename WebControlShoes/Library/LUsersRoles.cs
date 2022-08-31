using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebControlShoes.Library
{
    public class LUsersRoles
    {
        public List<SelectListItem> getRoles(RoleManager<IdentityRole> roleManager)
        {
            List<SelectListItem> _selectLists = new List<SelectListItem>();
            var roles = roleManager.Roles.ToList();
            roles.ForEach(item => {
            _selectLists.Add(new SelectListItem
            {
                Value = item.Id,
                    Text = item.Name
                });
            });
        return _selectLists;
        }
    }
}
