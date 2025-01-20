using apec4_sledManagement.Library.Models;
using System.Security.Cryptography;
using System.Text;

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

        User newUser = new User
        {
            Guid = guid,
            UserName = user.UserName,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            PasswordHash = password,
            IsAdmin = false
        };

        _dbContext.Users.Add(newUser);
        return _dbContext.SaveChanges();
    }

    public string GetPasswordHash(string password, string salt)
    {
        HashAlgorithm hashAlg = SHA256.Create();
        byte[] bytes = hashAlg.ComputeHash(Encoding.UTF8.GetBytes(password + salt));

        StringBuilder stringBuilder = new StringBuilder();
        foreach (byte b in bytes)
        {
            stringBuilder.Append(b.ToString("X2"));
        }

        return stringBuilder.ToString();
    }

    public bool LoginUser(string username, string password)
    {
        User? user = _dbContext.Users.FirstOrDefault(x => x.UserName == username);
        if (user == null)
        {
            return false;
        }

        var pwd = GetPasswordHash(password, user.Guid.ToString());
        if (pwd == user.PasswordHash)
        {
            return true;
        }

        return false;
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

    public bool ReserveSled(DateTime startDate, DateTime endDate, SledType sledType)
    {
        throw new NotImplementedException();
    }
}
