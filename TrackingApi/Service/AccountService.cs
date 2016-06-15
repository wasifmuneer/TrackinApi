using Microsoft.AspNet.Identity;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackingApi.Entities;
using TrackingApi.Extensions;
using TrackingApi.Models;
using TrackingApi.MongoIdentity;

namespace TrackingApi.Service
{
    public class AccountService:IAccountService,IDisposable
    {
        private IUserStore<IdentityUser> _users = null;

        private string connection = "";

        private MongoClient client = null;

        private IMongoCollection<IdentityUser> _userscollection = null;

        private IMongoCollection<RefreshToken> _TokenCollection = null;

        private IMongoCollection<Client> _Client = null;

        public AccountService()
        {

            connection = ConfigurationManager.ConnectionStrings["MongoConnection"].ToString();

            client = new MongoClient(connection);

            var db = client.GetDatabase("Contacts");

            _userscollection = db.GetCollection<IdentityUser>("IdentityUser");

            _users = new UserStore<IdentityUser>(_userscollection);

            IndexChecks.EnsureUniqueIndexOnUserName(_userscollection);

            _TokenCollection = db.GetCollection<RefreshToken>("RefreshToken");

            _Client = db.GetCollection<Client>("Client");
        }

        public Task CreateAsync(IdentityUser user)
        {
            var result= _users.CreateAsync(user);

            return result;
        }

        public async Task RegisterUser(UserModel userModel)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = userModel.UserName,
                PasswordHash=userModel.Password
            };

            //var result = await _userscollection.CreateAsync(user, userModel.Password);
             await _userscollection.InsertOneAsync(user);

            
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user =  _userscollection.Find(r => r.UserName==userName && r.PasswordHash==password).SingleOrDefault();

            return user;
        }

        public ClientModel FindClient(string clientId)
        {
            var clientEntity = _Client.Find(r => r.Id == clientId).SingleOrDefault();//_ctx.Clients.Find(clientId);

            var model = MappingExtensions.ToModel(clientEntity);

            return model;
        }

        public async Task<bool> AddRefreshToken(RefreshTokenModel token)
        {

            var existingToken = _TokenCollection.Find(r => r.Subject == token.Subject && r.ClientId == token.ClientId).SingleOrDefault();

            if (existingToken != null)
            {
                var model = MappingExtensions.ToModel(existingToken);

                var result = await RemoveRefreshToken(model);
            }

            var entity = MappingExtensions.ToEntity(token);

            await _TokenCollection.InsertOneAsync(entity);

            return true;//await _ctx.SaveChangesAsync() > 0;
        }

        public async Task<DeleteResult> RemoveRefreshToken(string refreshTokenId)
        {
            var refreshToken =  _TokenCollection.Find(r => r.Id == refreshTokenId);

            if (refreshToken != null)
            {

                var result = await _TokenCollection.DeleteOneAsync(r => r.Id == refreshTokenId);
                //_ctx.RefreshTokens.Remove(refreshToken);
                return result;
            }

            return null;
        }

        public async Task<DeleteResult> RemoveRefreshToken(RefreshTokenModel refreshToken)
        {
             var result= await _TokenCollection.DeleteOneAsync(r=>r.Id==refreshToken.Id) ;

             return result;

            //return await _ctx.SaveChangesAsync() > 0;
        }

        public async Task<RefreshTokenModel> FindRefreshToken(string refreshTokenId)
        {
            var refreshToken =  _TokenCollection.Find(r=>r.Id==refreshTokenId).SingleOrDefault();

            var model= MappingExtensions.ToModel (refreshToken);

            return model;
        }

        public List<RefreshToken> GetAllRefreshTokens()
        {
            //var refreshToken = _TokenCollection.Find() ;
            //return _ctx.RefreshTokens.ToList();

            return null;
        }


        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
