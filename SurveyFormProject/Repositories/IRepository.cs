using SurveyFormProject.Models;

namespace SurveyFormProject.Repositories
{
    public interface IRepository
    {
        public void AddResponse(GuestResponseDto response);
        public IEnumerable<GuestResponseDto> GetResponsesWillAttend();
    }
}
