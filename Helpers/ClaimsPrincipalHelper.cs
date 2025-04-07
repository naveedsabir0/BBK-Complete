using System.Security.Claims;
using MovieDatabaseBlazorServerApp.Data;

namespace MovieDatabaseBlazorServerApp.Helpers
{
    public static class ClaimsPrincipalHelper
    {
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            var id = principal
            .Claims
            .Where(c => c.Type == ClaimTypes.NameIdentifier)
            .Select(c => c.Value)
            .SingleOrDefault();

            return id;
        }

        public static string GetFullName(this ClaimsPrincipal principal)
        {
            var firstName = principal
                .Claims
                .Where(c => c.Type == ClaimTypes.GivenName)
                .Select(c => c.Value)
                .SingleOrDefault();

            var lastName = principal
                .Claims
                .Where(c => c.Type == ClaimTypes.Surname)
                .Select(c => c.Value)
                .SingleOrDefault();

            return $"{firstName} {lastName}";
        }

        public static bool IsAdmin(this ClaimsPrincipal principal) => principal.IsInRole(Roles.Admin);

        public static bool IsStaff(this ClaimsPrincipal principal) => principal.IsInRole(Roles.Staff);

        public static bool IsPremium(this ClaimsPrincipal principal) => principal.IsInRole(Roles.Premium);
    }
}
