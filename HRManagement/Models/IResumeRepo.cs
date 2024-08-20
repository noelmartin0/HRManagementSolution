namespace HRManagement.Models
{
    interface IResumeRepo
    {
        ResumeTrackingDetail GetResumeById(int id);
        List<ResumeTrackingDetail> GetAllResumes();
        void AddResume(ResumeTrackingDetail resume);
        //void UpdateResumeTrackingDetail(ResumeTrackingDetail resume);
        void DeleteResume(int id);
        void UpdateResume(int id, ResumeTrackingDetail resume);

    }
}
