namespace HRManagement.Models
{
    interface IResignationRepo
    {
        void AddEmployeeResignation(ResignationDetail resignation);
        ResignationDetail GetResignationById(int id);
        //List<ResignationDetail> GetDepartmentDetail(int deptid);
    }

    public class ResignationRepo : IResignationRepo
    {

        HRManagementDBContext _context;
        public ResignationRepo(HRManagementDBContext context)
        {
            _context = context;
        }


        public void AddEmployeeResignation(ResignationDetail resignation)
        {
            _context.ResignationDetails.Add(resignation);
            _context.SaveChanges();

        }

       

        public ResignationDetail GetResignationById(int id)
        {
            ResignationDetail r = _context.ResignationDetails.Find(id);
            return r;
        }
    }

}



