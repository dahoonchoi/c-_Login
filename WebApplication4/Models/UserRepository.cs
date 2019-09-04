using Dapper;
using System;
using System.Linq;
using System.Security.Claims;
using WebApplication4.Models;
using WebApplication4.Models.Connection;

namespace WebApplication4
{
    public class UserRepository : IUserRepository
    {
        
        //인증
        public ClaimsPrincipal GetClaimsPrincipal(UserLoginModel model)

        {
            var userData = ReadUser(model.Id);
           
            var claims = new Claim[]
            {
                new Claim("id", userData.Id),
                new Claim("pw", userData.Pw)
            };

            var ci = new ClaimsIdentity(claims, model.Pw);

            return new ClaimsPrincipal(ci);
        }

        public User ReadUser(string id)
        {
            string query = "SELECT * FROM [dbo].[User] WHERE ID = @ID";

            var connection = DbRepository.MsConnection();
            var searchModel = new { id = id };


            return connection.Query<User>(query, searchModel).FirstOrDefault();
        }
        public  bool isCorrectUser(UserLoginModel model)
        {
            string query = "SELECT * FROM [dbo].[User] WHERE ID= @id AND PW=@pw ";

            var connection = DbRepository.MsConnection();
            var searchModel = new { id = model.Id, pw = model.Pw };

            var list = connection.Query<User>(query, searchModel).ToList();
           System.Diagnostics.Trace.WriteLine("Count : " +list.Count);
            return (list.Count == 1);
        }


    }
}