using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackingApi.Entities;
using TrackingApi.Models;

namespace TrackingApi.Extensions
{
    public static class MappingExtensions
    {

        /// <summary>
        /// Client model generation from client entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Client Model</returns>
        public static ClientModel ToModel(this Client entity)
        {
            var model = new ClientModel() 
            {
                Id=entity.Id
                ,
                Name= entity.Name
                ,
                Secret=entity.Secret
                ,
                RefreshTokenLifeTime=entity.RefreshTokenLifeTime
                ,
                ApplicationType=entity.ApplicationType
                ,
                AllowedOrigin=entity.AllowedOrigin
                ,
                Active=entity.Active

            };

            return model;

        }


        /// <summary>
        /// Client entity generation from client model
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Client Entity</returns>
        public static Client ToEntity(this ClientModel model)
        {
            var entity = new Client()
            {
                Id = ObjectId.GenerateNewId ().ToString ()
                ,
                Name = model.Name
                ,
                Secret = model.Secret
                ,
                RefreshTokenLifeTime = model.RefreshTokenLifeTime
                ,
                ApplicationType = model.ApplicationType
                ,
                AllowedOrigin = model.AllowedOrigin
                ,
                Active = model.Active

            };

            return entity;

        }

        /// <summary>
        /// RefreshToken model generation from refreshtoken entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>RefreshToken model</returns>
        public static RefreshTokenModel ToModel(this RefreshToken entity)
        {
            if (entity == null)
                return null;

            var model = new RefreshTokenModel() 
            {
                Id=entity.Id
                ,
                Subject=entity.Subject
                ,
                ProtectedTicket=entity.ProtectedTicket
                ,
                IssuedUtc=entity.IssuedUtc
                ,
                ExpiresUtc=entity.ExpiresUtc
                ,
                ClientId=entity.ClientId
            };

            return model;
        }


        /// <summary>
        /// RefreshToken entity generation from RefreshToken model
        /// </summary>
        /// <param name="model"></param>
        /// <returns>RefreshToken Entity</returns>
        public static RefreshToken ToEntity(this RefreshTokenModel model)
        {
            if (model == null)
            { return null; }

            var entity = new RefreshToken() 
            {
                Id=ObjectId.GenerateNewId ().ToString ()
                ,
                ClientId=model.ClientId
                ,
                ExpiresUtc=model.ExpiresUtc
                ,
                IssuedUtc=model.IssuedUtc
                ,
                ProtectedTicket=model.ProtectedTicket
                ,
                Subject=model.Subject
            };

            return entity;
        }
    }
}
