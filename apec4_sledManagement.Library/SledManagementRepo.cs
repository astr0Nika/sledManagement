using apec4_sledManagement.Library.Models;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;

namespace apec4_sledManagement.Library;

public class SledManagementRepo
{
    private readonly SledDbContext _dbContext;

    public SledManagementRepo(SledDbContext context)
    {
        _dbContext = context;
    }

    /// <summary>
    /// Plain password in user will be hashed
    /// </summary>
    /// <param name="user"></param>
    /// <returns>The number of changed entries in database</returns>
    public int CreateUser(User user)
    {
        Guid guid = Guid.NewGuid();
        string password = GetPasswordHash(user.PasswordHash, guid.ToString());

        _dbContext.Users.Add(new User
        {
            Guid = guid,
            UserName = user.UserName,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            PasswordHash = password,
            IsAdmin = false
        });

        return _dbContext.SaveChanges();
    }

    public string GetPasswordHash(string password, string salt)
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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sled"></param>
    /// <returns>The number of changed entries in database</returns>
    public int CreateSled(Sled sled)
    {
        _dbContext.Sleds.Add(sled);
        return _dbContext.SaveChanges();
    }

    public bool ReserveSled(Reservation reservation)
    {
        throw new NotImplementedException();
    }
}
