using HRManagement.Models;

namespace HRManagement.Areas.Admin.Models
{

        public interface IAdminLoginRepo
        {
            bool validateuser(string uname, string pwd,string role);
        public void AddUser(AdminLogin user);
        }

public class AdminLoginRepo : IAdminLoginRepo
    {
        HRManagementDBContext _context;
        public AdminLoginRepo(HRManagementDBContext context)
        {
            _context = context;
        }

        public void AddUser(AdminLogin user)
        { 
            _context.AdminLoginDetails.Add(user);
            _context.SaveChanges();
        }

        public bool validateuser(string uname, string pwd,string role)
        {
            AdminLogin login=_context.AdminLoginDetails.SingleOrDefault(u => u.Username == uname);
            if (login != null && BCrypt.Net.BCrypt.Verify(pwd,login.Password) && login.Role == role)
            {
                return true;
            }
            else
                throw new InvalidOperationException($"Incorrect username or password");

           // return false;
        }
    }

    }

