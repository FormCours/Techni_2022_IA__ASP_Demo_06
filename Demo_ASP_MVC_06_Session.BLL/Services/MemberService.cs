using Demo_ASP_MVC_06_Session.BLL.Exceptions;
using Demo_ASP_MVC_06_Session.BLL.Interfaces;
using Demo_ASP_MVC_06_Session.DAL.Interfaces;
using Demo_ASP_MVC_06_Session.Domain.Entities;
using Isopoh.Cryptography.Argon2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_ASP_MVC_06_Session.BLL.Services
{
    public class MemberService : IMemberService
    {
        private IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public Member? Login(string identifiant, string password)
        {
            if (string.IsNullOrWhiteSpace(identifiant) || string.IsNullOrWhiteSpace(password)) 
            {
                throw new ArgumentException();
            }

            string? hashPwd = _memberRepository.GetHashPwd(identifiant);
            if(hashPwd is null)
            {
                throw new IdentifiantNotExistsException();
            }

            if (!Argon2.Verify(hashPwd, password))
            {
                throw new IdentifiantIsNotValidException();
            }

            return _memberRepository.GetByIdentifiant(identifiant);
        }

        public Member? Register(Member memberData)
        {
            if (string.IsNullOrWhiteSpace(memberData.Email) || string.IsNullOrWhiteSpace(memberData.Pseudo) || string.IsNullOrWhiteSpace(memberData.Password))
            {
                throw new ArgumentException();
            }
            
            if(_memberRepository.GetByIdentifiant(memberData.Pseudo,
                memberData.Email) != null)
            {
                throw new IdentifiantAlreadyExistsException();
            }

            // Hash password
            memberData.HashPwd = Argon2.Hash(memberData.Password);
            memberData.Password = null;

            int memberId = _memberRepository.Add(memberData);
            return _memberRepository.GetById(memberId);
        }
    }
}
