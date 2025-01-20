using apec4_sledManagement.Library.InputModels;
using apec4_sledManagement.Library.Models;
using Microsoft.EntityFrameworkCore;
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
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <returns>The number of changed entries in database</returns>
    public int CreateUser(UserInputModel user)
    {
        Guid guid = Guid.NewGuid();
        string password = GetPasswordHash(user.Password, guid.ToString());

        User newUser = new User
        {
            UserId = guid,
            Username = user.Username,
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
        User? user = _dbContext.Users.FirstOrDefault(x => x.Username == username);
        if (user == null)
        {
            return false;
        }

        var pwd = GetPasswordHash(password, user.UserId.ToString());
        if (pwd == user.PasswordHash)
        {
            return true;
        }

        return false;
    }

    public Task<List<Sled>> GetSledsAsync()
    {
        return _dbContext.Sleds.ToListAsync();
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

    public bool ReserveSled(ReserveSledInputModel reservaton)
    {
        var filterdSled = _dbContext.Sleds.FirstOrDefault(x => x.Type == reservaton.Type);
        if (filterdSled == null)
        {
            return false;
        }

        var canReserve = CanReservationBeMade(filterdSled.SledNumber, reservaton.StartDate, reservaton.EndDate);
        if (!canReserve)
        {
            return false;
        }

        var newReservation = new Reservation()
        {
            CreateDate = DateTime.Now,
            StartDate = reservaton.StartDate,
            EndDate = reservaton.EndDate,
            SledNumber = filterdSled.SledNumber,
            UserId = new Guid("0e39d385-a139-45ed-97fb-e34134dab494")
        };

        _dbContext.Reservations.Add(newReservation);
        _dbContext.SaveChanges();

        return true;
    }

    public bool CanReservationBeMade(int sledNr, DateTime newBeginDate, DateTime newEndDate)
    {
        // Filter reservations for the same sled
        var sledReservations = _dbContext.Reservations.Where(r => r.SledNumber == sledNr);

        // Check for overlap
        foreach (var reservation in sledReservations)
        {
            if (newBeginDate < reservation.EndDate && newEndDate > reservation.StartDate)
            {
                return false;
            }
        }

        return true;
    }
}
