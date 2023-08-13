using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.DBAccess;
using DataAccess.Models;

namespace DataAccess.Data;

public class UserData : IUserData
{
    private readonly ISqlDataAccess db;

    public UserData(ISqlDataAccess db)
    {
        this.db = db;
    }

    //GET users function
    public Task<IEnumerable<UserModel>> GetUsers() =>
        this.db.LoadData<UserModel, dynamic>("dbo.spUser_GetAll", new { });

    //GET user by ID
    public async Task<UserModel?> GetUser(int id)
    {
        var results = await this.db.LoadData<UserModel, dynamic>(
            "dbo.spUser_Get",
            new { Id = id});

        return results.FirstOrDefault();
    }

    //Insert user
    public Task InsertUser(UserModel user) =>
        this.db.SaveData("dbo.spUser_Insert", new{ user.FirstName, user.LastName});

    //Update user
    public Task UpdateUser(UserModel user) =>
        this.db.SaveData("dbo.spUser_Update", user);
    
    //Delete User
    public Task DeleteUser(int id) =>
        this.db.SaveData("dbo.spUser_Delete", new { Id = id});
}