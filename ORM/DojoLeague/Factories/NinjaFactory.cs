using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using DojoLeague.Models;
 
namespace DojoLeague.Factory
{
    public class NinjaFactory : IFactory<Dojo>
    {
        private string connectionString;
        public NinjaFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=3306;database=DojoLeague;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(connectionString);
            }
        }

        // ************ DOJO LEAGUE QUERY STUFF HERE ************ //

        public void AddNINJA(Ninja ninja)
        {
            using (IDbConnection dbConnection = Connection)
            {
                if (ninja.dojos_Id == 0)
                {
                    string query = "INSERT INTO ninjas (NinjaName, NinjaLevel, NinjaDescription, dojos_Id) VALUES (@NinjaName, @NinjaLevel, @NinjaDescription, dojos_Id=0)";
                    dbConnection.Open();
                    dbConnection.Execute(query, ninja);
                }
                else
                {
                    string query = "INSERT INTO ninjas (NinjaName, NinjaLevel, dojos_Id, NinjaDescription) VALUES (@NinjaName, @NinjaLevel, @dojos_Id, @NinjaDescription)";
                    dbConnection.Open();
                    dbConnection.Execute(query, ninja);
                }

            }
        }
        public IEnumerable<Ninja> FindNINJAAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Ninja>("SELECT dojos.DojoName, dojos_Id, ninjas.Id, ninjas.NinjaName FROM ninjas LEFT JOIN dojos ON ninjas.dojos_Id = dojos.Id");
            }
        }
        public IEnumerable<Ninja> FindRogueNINJAS()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Ninja>("SELECT * FROM ninjas WHERE dojos_Id is null");
            }
        }
        public Ninja FindNINJAByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Ninja>("SELECT dojos.DojoName, ninjas.Id, ninjas.NinjaName, ninjas.NinjaLevel, ninjas.NinjaDescription, dojos_Id FROM ninjas JOIN dojos WHERE ninjas.dojos_id = dojos.Id AND ninjas.Id = @Id", new { Id = id }).FirstOrDefault();
            }
        }
        public Ninja FindRogueNINJAByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Ninja>("SELECT * FROM ninjas WHERE id= @Id", new { Id = id }).FirstOrDefault();
              
            }
        }
        public IEnumerable<Ninja> FindNINJAByDOJO(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Ninja>("SELECT * FROM ninjas WHERE dojos_Id = @Dojo_Id", new { Dojo_id = id });
            }
        }
        public void BanishNINJA(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = $"UPDATE ninjas SET dojos_Id = null WHERE Id = {id}";
                dbConnection.Open();
                dbConnection.Execute(query);
            }
        }
        public void RecruitNINJA(int id, int dojoID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = $"UPDATE ninjas SET dojos_Id = {dojoID} WHERE Id = {id}";
                dbConnection.Open();
                dbConnection.Execute(query);
            }
        }
    }
}