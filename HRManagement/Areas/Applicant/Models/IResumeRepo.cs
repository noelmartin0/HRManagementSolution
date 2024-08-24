namespace HRManagement.Models
{
    public interface IResumeRepo
    {

        void AddResume(ResumeTrackingDetail resume);

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


    }


}
