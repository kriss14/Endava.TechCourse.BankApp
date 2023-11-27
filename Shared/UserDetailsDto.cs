using System.Collections.Generic;

namespace Endava.TechCourse.BankApp.Shared;

public class UserDetailsDto
{
    public bool IsAuthenticated { get; set; } = false;
    public string Id { get; set; }
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public Dictionary<string, string> Claims { get; set; }
    public string[] Roles { get; set; }
}