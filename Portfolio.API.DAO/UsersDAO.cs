﻿using MongoDB.Driver;
using Portfolio.API.Model.Security;
using System;

namespace Portfolio.API.DAO
{
    public class UsersDAO
    {
        private MongoClient mongo;

        public UsersDAO()
        {
            mongo = new MongoClient("mongodb://lsimoes:5826L0492*Cdb@cluster0-shard-00-00.jliuf.mongodb.net:27017,cluster0-shard-00-01.jliuf.mongodb.net:27017,cluster0-shard-00-02.jliuf.mongodb.net:27017/dbportfoliosite?ssl=true&replicaSet=atlas-edysej-shard-0&authSource=admin&retryWrites=true&w=majority");
        }

        public User FindByUser(string userID)
        {
            try
            {
                IMongoDatabase database = mongo.GetDatabase("dbsite");
                IMongoCollection<User> userdb = database.GetCollection<User>("security");
                var responseMongo = userdb.Find(x => x.UserID.Equals(userID)).FirstOrDefault();

                if (responseMongo == null)
                {
                    return null;
                }

                return new User() { UserID = responseMongo.UserID, AccessKey = responseMongo.AccessKey };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
