using HRManagement.Models;

namespace HRManagement.Areas.Admin.Models
{

        public interface IAdminLoginRepo
        {
            bool validateuser(string uname, string pwd,string role);
        }

public class AdminLoginRepo : IAdminLoginRepo
    {
        HRManagementDBContext _context;
        public AdminLoginRepo(HRManagementDBContext context)
        {
            _context = context;
        }

        public bool validateuser(string uname, string pwd,string role)
        {
            AdminLogin login=_context.AdminLoginDetails.SingleOrDefault(u => u.Username == uname);
            if (login != null && login.Password ==pwd && login.Role == role)
            {
                return true;
            }
            return false;
        }
    }

    }

