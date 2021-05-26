using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The_Quizer.Models
{
    public interface IExamStore
    {
        /// <summary>
        ///     Adds a user to a role
        /// </summary>
        /// <param name="user"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
        Task AddToRoleAsync(ApplicationUser user, string roleName);

        /// <summary>
        ///     Removes the role for the user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
        Task RemoveFromRoleAsync(ApplicationUser user, string roleName);

        /// <summary>
        ///     Returns the roles for this user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<IList<string>> GetRolesAsync(ApplicationUser user);

        /// <summary>
        ///     Returns true if a user is in the role
        /// </summary>
        /// <param name="user"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
        Task<bool> IsInRoleAsync(ApplicationUser user, string roleName);
    }
}
