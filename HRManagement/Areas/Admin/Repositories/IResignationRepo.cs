﻿namespace HRManagement.Models
{
    public interface IResignationRepo
    {
        void AddEmployeeResignation(ResignationDetail resignation);
        ResignationDetail GetResignationById(int id);
        //List<ResignationDetail> GetDepartmentDetail(int deptid);
        ResignationDetail GetResignationByEmployeeId(int empid);
        void DeleteEmployeeResignation(int id);

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

        //change you wanted
        public ResignationDetail GetResignationById(int id)
        {
            ResignationDetail r = _context.ResignationDetails.Find(id);
            if (r == null)
            {
                throw new InvalidOperationException($"There is no Resignation Details associated with the ID = {id}");
            }
            return r;
        }

        void IResignationRepo.DeleteEmployeeResignation(int id)
        {

            ResignationDetail r = _context.ResignationDetails.Find(id);
            if (r == null)
            {
                throw new InvalidOperationException($"There is no Resignation Details associated with the ID = {id}");
            }
            _context.ResignationDetails.Remove(r);  
            _context.SaveChanges();
        }

        ResignationDetail IResignationRepo.GetResignationByEmployeeId(int empid)
        {
            ResignationDetail r = _context.ResignationDetails.FirstOrDefault(x => x.EmployeeId==empid);
            if (r == null)
            {
                throw new InvalidOperationException($"No Emmployee is found having ID ={empid}");
            }
            return r;
        }
    }

}