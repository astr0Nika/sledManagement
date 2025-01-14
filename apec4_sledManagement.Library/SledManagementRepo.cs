using apec4_sledManagement.Library.Models;

namespace apec4_sledManagement.Library;

public class SledManagementRepo
{
    private readonly SledDbContext _dbContext;

    public SledManagementRepo(SledDbContext context)
    {
        _dbContext = context;
    }

    public bool CreateUser(User user)
    {
        throw new NotImplementedException();
    }

    public bool LoginUser(Guid guid, string password)
    {
        throw new NotImplementedException();
    }

    public List<Sled> GetSleds()
    {
        return _dbContext.Sleds.ToList();
    }

    public bool CreateSled(Sled sled)
    {
        throw new NotImplementedException();
    }

    public bool ReserveSled(Reservation reservation)
    {
        throw new NotImplementedException();
    }
}
