using DigitalQueue.Web.Data;
using DigitalQueue.Web.Data.Entities;

using MediatR;

using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;

using ILogger = Microsoft.Build.Framework.ILogger;

namespace DigitalQueue.Web.Areas.Courses.Commands;

public class CreateCourseCommand : IRequest<Course?>
{
    public CreateCourseCommand(string title, string[] teachers)
    {
        Title = title;
        Teachers = teachers;
    }

    [Required]
    public string Title { get; }

    [Required]
    public string[]? Teachers { get; }
    
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, Course?>
    {
        private readonly DigitalQueueContext _context;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<CreateCourseCommandHandler> _logger;

        public CreateCourseCommandHandler(DigitalQueueContext context, UserManager<User> userManager, ILogger<CreateCourseCommandHandler> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }
        
        public async Task<Course?> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            if (request.Teachers is null || request.Teachers.Length == 0)
            {
                return null;
            }
            
            await using(var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
            {
                try
                {
                    var teachers = await _userManager.Users
                        .Where(u => request.Teachers.Contains(u.Id))
                        .ToArrayAsync(cancellationToken);
            
                    var course = new Course
                    {
                        Title = request.Title, 
                        Teachers = teachers
                    };

                    await _context.AddAsync(course, cancellationToken);
                    
                    await _context.SaveChangesAsync(cancellationToken);
                    await transaction.CommitAsync(cancellationToken);
            
                    return course;
                }
                catch (Exception exception)
                {
                    await transaction.RollbackAsync(cancellationToken);
                    _logger.LogError(exception, "Unable to create course");
                }
            }

            return null;
        }
    }
}
 
