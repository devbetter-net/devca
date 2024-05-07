namespace Dev.Infrastructure.Data;

public interface IDevDbContext
{
    string GenerateCreateScript();
}
