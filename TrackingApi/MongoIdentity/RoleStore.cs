using Microsoft.AspNet.Identity;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingApi.MongoIdentity
{
    public class RoleStore<TRole>:IRoleStore<TRole>, IQueryableRoleStore<TRole> 
        where TRole :IdentityRole
    {

        private readonly IMongoCollection<TRole> _Roles;

        public RoleStore(IMongoCollection<TRole> roles)
        {
            _Roles = roles;
        }


        public virtual Task CreateAsync(TRole role)
        {
            return _Roles.InsertOneAsync(role);
        }

        public virtual Task DeleteAsync(TRole role)
        {
            return _Roles.DeleteOneAsync(r => r.Id == role.Id);
        }

        public virtual Task<TRole> FindByIdAsync(string roleId)
        {
            return _Roles.Find(r => r.Id == roleId).FirstOrDefaultAsync();
        }

        public virtual Task<TRole> FindByNameAsync(string roleName)
        {
            return _Roles.Find(r => r.Name == roleName).FirstOrDefaultAsync();
        }

        public virtual Task UpdateAsync(TRole role)
        {
            return _Roles.ReplaceOneAsync(r => r.Id == role.Id, role);
        }

        public virtual void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TRole> Roles
        {
            get { return _Roles.AsQueryable(); }
        }
    }
}
