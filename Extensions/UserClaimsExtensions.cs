using System.Security.Claims;

namespace Treasures.Common.Extensions; 

public static class UserClaimsExtensions {
    /// <summary>
    /// Retrieves an email of the signed in user from the ClaimsPrincipal
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public static string RetrieveEmailFromPrincipal(this ClaimsPrincipal user) => user
        .FindFirstValue(ClaimTypes.Email);

    /// <summary>
    /// Retrieves a list of the currently signed in user roles from the ClaimsPrincipal
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public static List<string> RetrieveRolesFromPrincipal(this ClaimsPrincipal user) => user
        .FindAll(ClaimTypes.Role).Select(c => c.Value).ToList();
    
    /// <summary>
    /// Retrieves a userId of the signed in user from the ClaimsPrincipal
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public static string RetrieveUserIdFromPrincipal(this ClaimsPrincipal user) => user
        .FindFirstValue(ClaimTypes.Actor);
}