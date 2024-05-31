using System.Text;
using System.Text.Json;
using Dev.Plugin.Auth.Core.Domain;
using Dev.Plugin.Auth.Infrastructure.Data;

namespace Dev.Plugin.Auth.IntergrationTests.Base;

public class Utilities
{
    public static StringContent ConvertToJsonContent(object obj)
    {
        var json = JsonSerializer.Serialize(obj);
        return new StringContent(json, Encoding.UTF8, "application/json");
    }
    public static void InitializeDbForTests(AuthenDbContext context)
    {
        //Admin account
        User admin = new User
        {
            Id = Guid.NewGuid(),
            Email = "admin@devbetter.net",
            Username = "admin",
            FullName = "Admin",
            Active = true,
            Deleted = false,
            IsSystemAccount = true,
            CreatedOnUtc = DateTime.UtcNow
        };
        UserPassword adminPassword = new UserPassword
        {
            Id = Guid.NewGuid(),
            UserId = admin.Id,
            Password = "1qaz!QAZ",
            CreatedOnUtc = DateTime.UtcNow
        };
        context.UserPasswords.Add(adminPassword);


        context.SaveChanges();   
    }
}
