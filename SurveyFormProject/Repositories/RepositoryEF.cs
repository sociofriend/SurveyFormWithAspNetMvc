using AutoMapper;
using SurveyFormProject.Controllers;
using SurveyFormProject.DbContexts;
using SurveyFormProject.Entities;
using SurveyFormProject.Models;

namespace SurveyFormProject.Repositories
{
    public class RepositoryEF : IRepository
    {

        private readonly SurveyFormContext _context;
        private readonly IMapper _mapper;

        public RepositoryEF(SurveyFormContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public void AddResponse(GuestResponseDto response)
        {
            var mappedEntity = _mapper.Map<GuestResponse>(response);
            _context.GuestResponses.Add(mappedEntity);
            _context.SaveChanges();
        }

        public IEnumerable<GuestResponseDto> GetResponsesWillAttend()
        {
            var entities = _context.GuestResponses.Where(r => r.WillAttend);

            var result = _mapper.Map<IEnumerable<GuestResponseDto>>(entities);
            return result;
        }
    }
}
