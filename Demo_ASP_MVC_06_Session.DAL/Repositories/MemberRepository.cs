﻿using Demo_ASP_MVC_06_Session.DAL.Interfaces;
using Demo_ASP_MVC_06_Session.DAL.Utils;
using Demo_ASP_MVC_06_Session.Domain.Entities;
using System.Data;

namespace Demo_ASP_MVC_06_Session.DAL.Repositories
{
    public class MemberRepository : RepositoryBase<int, Member>
    , IMember
    {
        public MemberRepository(IDbConnection connection) : base(connection)
        {
        }
        protected override Member Mapper(IDataRecord record)
        {
            return new Member()
            {
                MemberId = (int)record["Member_Id"],
                Pseudo = (string)record["Pseudo"],
                Email = (string)record["Email"]
            };
        }
        public override int Add(Member entity)
        {
            // "༼ つ ◕_◕ ༽つ";
            string cmd =  "INSERT INTO [Member](Email, Pseudo, Pwd_Hash)" +
            " OUTPUT [inserted].[Member_Id] " +
            " VALUES  (@Email, @Pseudo, @Pwd_Hash) ";
            IDbCommand command = _connection.CreateQueryCommand(cmd);

            command.AddParam("@Email", entity.Email);
            command.AddParam("@Pseudo", entity.Pseudo);
            DbUtils.AddParam(command, "@Pwd_Hash", entity.Password);
 
            _connection.Open();
            int? id = (int?)command.ExecuteScalar();
            _connection.Close();

            return id ?? -1;
        }

        public override bool Delete(int id)
        {
            string cmd =         "DELETE FROM [Member] WHERE [Member_Id] = @Id";
            IDbCommand command = _connection.CreateQueryCommand(cmd);

            command.AddParam("@Id", id);
           
            _connection.Open();

            int nbRowDeleted = command.ExecuteNonQuery();

            _connection.Close();

            return nbRowDeleted == 1;
        }

        public override IEnumerable<Member> GetAll()
        {
            string cmd = "SELECT * FROM [Member]";
            IDbCommand command = _connection.CreateQueryCommand(cmd);

            _connection.Open();

            using (IDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    yield return Mapper(reader);
                }
            }
            _connection.Close();
        }

        public override Member? GetById(int id)
        {

            string cmd = "SELECT * FROM [Member] WHERE [Member_Id] = @id";
            IDbCommand command = _connection.CreateQueryCommand(cmd);
            command.AddParam("@id", id);
          

            int cpt = 0;
            _connection.Open();
            Member? member = null;
            using (IDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    cpt++;
                    member = Mapper(reader);
                }
            }
            _connection.Close();
            if (cpt > 1)
            {
                throw new Exception(@"On a pas trouvé sorry ¯\_(ツ)_/¯");
            }
            return member;
        }

        public Member? GetByPseudo(string pseudo)
        {
            string cmd = "SELECT * FROM [Member] WHERE [Pseudo] = @pseudo";
            IDbCommand command = _connection.CreateQueryCommand(cmd);
            command.AddParam("@pseudo", pseudo);
         

            int cpt = 0;
            _connection.Open();
            Member? member = null;
            using (IDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    cpt++;
                    member = Mapper(reader);
                }
            }
            _connection.Close();
            if (cpt > 1)
            {
                throw new Exception(@"On a pas trouvé sorry ¯\_(ツ)_/¯");
            }
            return member;
        }
        public override bool Update(int id, Member entity)
        {
            throw new NotImplementedException();
        }


    }
}
