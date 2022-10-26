using Demo_ASP_MVC_06_Session.Domain.Entities;
using System.Text.Json;

namespace Demo_ASP_MVC_06_Session.WebApp.Services
{
    public class SessionService
    {
        private readonly ISession _session;

        public SessionService(IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;
        }

        public bool IsConnected
        {
            get { return _session.GetString("Member") != null; }
        }

        public Member? GetConnectedMember()
        {
            string? memberJson = _session.GetString("Member");

            if (memberJson is null)
            {
                return null;
            }

            return JsonSerializer.Deserialize<Member>(memberJson);
        }

        public void Login(Member member)
        {
            string memberJson = JsonSerializer.Serialize(member);

            _session.SetString("Member", memberJson);
        }

        public void Logout()
        {
            _session.Clear();
        }
    }
}
