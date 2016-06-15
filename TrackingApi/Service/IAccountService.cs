using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackingApi.Models;
using TrackingApi.MongoIdentity;

namespace TrackingApi.Service
{
    public interface IAccountService
    {
        Task CreateAsync(IdentityUser user);

        Task<bool> AddRefreshToken(RefreshTokenModel token);

        Task<DeleteResult> RemoveRefreshToken(RefreshTokenModel token);

        Task<DeleteResult> RemoveRefreshToken(string tokenId);

        Task<RefreshTokenModel> FindRefreshToken(string tokenId);

        Task RegisterUser(UserModel model);
    }
}
