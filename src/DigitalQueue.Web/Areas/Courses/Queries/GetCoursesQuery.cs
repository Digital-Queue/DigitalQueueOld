using DigitalQueue.Web.Areas.Courses.Dtos;
using DigitalQueue.Web.Data;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace DigitalQueue.Web.Areas.Courses.Queries;

public class GetCoursesQuery : IRequest<IEnumerable<CourseDto>>
{
    
    public class GetCourseQueryHandler : IRequestHandler<GetCoursesQuery, IEnumerable<CourseDto>>
    {
        private readonly DigitalQueueContext _context;

        public GetCourseQueryHandler(DigitalQueueContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<CourseDto>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
        {
            var courses = await _context.Courses
                .AsNoTracking()
                .OrderByDescending(c => c.CreateAt)
                .Include(c => c.Teachers)
                .Where(c => !c.IsArchived)
                .Select(
                    course => new CourseDto
                    {
                        Id = course.Id, Title = course.Title, Year = course.Year, CreatedAt = course.CreateAt, Teachers = course.Teachers.Count
                    }
                )
                .ToArrayAsync(cancellationToken);

            return courses;
        }
    }
}
