﻿using apec4_sledManagement.Library.Models;
using apec4_sledManagement.Library.TransferOfDataModels;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace apec4_sledManagement.Library;

public partial class SledManagementRepo
{
    private readonly SledDbContext _dbContext;

    public SledManagementRepo(SledDbContext context)
    {
        _dbContext = context;
    }

    /// <summary>
    /// Create an entry of user and hash the given password
    /// </summary>
    /// <param name="user"></param>
    /// <returns>Sucess: bool, Message: string</returns>
    public RepoResult CreateUser(UserInputModel user)
    {
        try
        {
            Guid guid = Guid.NewGuid();
            string passwordHash = GetPasswordHash(user.Password, guid.ToString());

            User newUser = new User
            {
                UserId = guid,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PasswordHash = passwordHash,
                IsAdmin = false
            };

            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            return new RepoResult()
            {
                Successful = false,
                Message = ex.Message,
            };
        }

        return new RepoResult()
        {
            Successful = true,
            Message = "New User was created."
        };
    }

    private string GetPasswordHash(string password, string salt)
    {
        HashAlgorithm hashAlg = SHA256.Create();
        byte[] bytes = hashAlg.ComputeHash(Encoding.UTF8.GetBytes(password + salt));

        StringBuilder stringBuilder = new();
        foreach (byte b in bytes)
        {
            stringBuilder.Append(b.ToString("X2"));
        }

        return stringBuilder.ToString();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns>Success: bool, Message: string</returns>
    public RepoResult CanUserLogin(string username, string password)
    {
        // get user by username
        User? user = _dbContext.Users.FirstOrDefault(x => x.Username == username);
        if (user != null)
        {
            // compare hashed passwords
            var pwd = GetPasswordHash(password, user.UserId.ToString());
            if (pwd == user.PasswordHash)
            {
                return new RepoResult()
                {
                    Successful = true,
                    Message = "Password is correct."
                };
            }
        }

        return new RepoResult()
        {
            Successful = false,
            Message = "Username or password does not match."
        };
    }

    public Task<List<Sled>> GetSledsAsync()
    {
        return _dbContext.Sleds.ToListAsync();
    }

    /// <summary>
    /// Create an entry of sled
    /// </summary>
    /// <param name="sled"></param>
    /// <returns>Success: bool, Message: string</returns>
    public RepoResult CreateSled(Sled sled)
    {
        try
        {
            // SledNumber is generated by database

            _dbContext.Sleds.Add(sled);
            _dbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            return new RepoResult()
            {
                Successful = false,
                Message = ex.Message
            };
        }

        return new RepoResult()
        {
            Successful = true,
            Message = "New sled was created."
        };
    }

    /// <summary>
    /// Create an entry of reservation
    /// </summary>
    /// <param name="reservaton"></param>
    /// <returns>Success: bool, Message: string</returns>
    public RepoResult CreateReservationOfSled(ReserveSledInputModel reservaton)
    {
        // get sled by type
        var filterdSled = _dbContext.Sleds.FirstOrDefault(x => x.Type == reservaton.Type);
        if (filterdSled == null)
        {
            return new RepoResult()
            {
                Successful = false,
                Message = "Your chosen type sled does currently not exist.",
            };
        }

        // are there any time overlaps
        var canReserve = CanReservationBeMade(filterdSled.SledNumber, reservaton.StartDate, reservaton.EndDate);
        if (!canReserve)
        {
            return new RepoResult()
            {
                Successful = false,
                Message = "At your given time, no sleds with your wished type are available."
            };
        }

        try
        {
            // new entry
            var newReservation = new Reservation()
            {
                CreateDate = DateTime.Now,
                StartDate = reservaton.StartDate,
                EndDate = reservaton.EndDate,
                SledNumber = filterdSled.SledNumber,
                // TODO: guid of loged user
                UserId = new Guid("0e39d385-a139-45ed-97fb-e34134dab494")
            };

            _dbContext.Reservations.Add(newReservation);
            _dbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            return new RepoResult()
            {
                Successful = false,
                Message = ex.Message,
            };
        }

        return new RepoResult()
        {
            Successful = true,
            Message = "Reservation was succesfully made."
        };
    }

    private bool CanReservationBeMade(int sledNr, DateTime newBeginDate, DateTime newEndDate)
    {
        // filter reservations for the same sled
        var sledReservations = _dbContext.Reservations.Where(r => r.SledNumber == sledNr);

        // check for overlap
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
