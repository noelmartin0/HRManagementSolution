using HRManagement.Models;

namespace HRManagement.Areas.Admin.Models
{
    public interface IResumeRepo
    {
        
            ResumeTrackingDetail GetResumeById(int id);
            List<ResumeTrackingDetail> GetAllResumes();
            void AddResume(ResumeTrackingDetail resume);

            void DeleteResume(int id);
            void UpdateResume(int id, ResumeTrackingDetail resume);

            //Write the promote() function
     }

        public class ResumeTrackingRepo : IResumeRepo
        {

            HRManagementDBContext _context;
            public ResumeTrackingRepo(HRManagementDBContext context)
            {
                _context = context;
            }

            public void AddResume(ResumeTrackingDetail resume)
            {

                _context.ResumeTrackingDetails.Add(resume);
                _context.SaveChanges();
            }

            public void DeleteResume(int id)
            {
                ResumeTrackingDetail m = _context.ResumeTrackingDetails.Find(id);
                _context.ResumeTrackingDetails.Remove(m);
            _context.SaveChanges();

            }

            public List<ResumeTrackingDetail> GetAllResumes()
            {
                return _context.ResumeTrackingDetails.ToList();
            }

            public ResumeTrackingDetail GetResumeById(int id)
            {
                ResumeTrackingDetail m = _context.ResumeTrackingDetails.Find(id);
                return m;
            }

            public void UpdateResume(int id, ResumeTrackingDetail resume)
            {
                ResumeTrackingDetail r = _context.ResumeTrackingDetails.Find(id);
                r.ApplicantName = resume.ApplicantName;
                r.PhoneNo = resume.PhoneNo;
                r.Experience = resume.Experience;
                r.Specialization = resume.Specialization;
                r.AreaOfInterest = resume.AreaOfInterest;
                r.Qualification = resume.Qualification;
            r.Certifications = resume.Certifications;
                _context.SaveChanges();
            }


        }

   }

