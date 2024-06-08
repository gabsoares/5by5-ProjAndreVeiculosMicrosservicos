using Models;
using Repositories.Repositories_DAPPER;

namespace Services.Services_DAPPER
{
    public class JobService
    {
        private JobRepository _jobRepository;

        public JobService()
        {
            _jobRepository = new JobRepository();
        }

        public List<Job> GetAllJobs(byte type)
        {
            return _jobRepository.GetAllJobs(type);
        }
    }
}