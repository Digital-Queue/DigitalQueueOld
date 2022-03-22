using System.Security.Claims;

using DigitalQueue.Web.Data.Entities;
using DigitalQueue.Web.Services.MailService;

using MediatR;

using Microsoft.AspNetCore.Identity;

namespace DigitalQueue.Web.Areas.Accounts.Commands;

public class CreateEmailConfirmationTokenCommand : IRequest<bool>
{
    public ClaimsPrincipal Principal { get; }

    public CreateEmailConfirmationTokenCommand(ClaimsPrincipal principal)
    {
        Principal = principal;
    }
    
    public class CreateEmailConfirmationTokenCommandHandler : IRequestHandler<CreateEmailConfirmationTokenCommand, bool>
    {
        private readonly UserManager<User> _userManager;
        private readonly MailService _mailService;
        private readonly LinkGenerator _linkGenerator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<CreateEmailConfirmationTokenCommandHandler> _logger;

        public CreateEmailConfirmationTokenCommandHandler(
            UserManager<User> userManager,
            MailService mailService, 
            LinkGenerator linkGenerator, 
            IHttpContextAccessor httpContextAccessor,
            ILogger<CreateEmailConfirmationTokenCommandHandler> logger)
        {
            _userManager = userManager;
            _mailService = mailService;
            _linkGenerator = linkGenerator;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }
        
        public async Task<bool> Handle(CreateEmailConfirmationTokenCommand request, CancellationToken cancellationToken)
        {
            // TODO: enqueue this message to a message broker or pub-sub
            // for asynchronous processing because SMTP execution is slow
            try
            {
                User user = await this._userManager.GetUserAsync(request.Principal);
                
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                
                var confirmationLink =
                    this._linkGenerator.GetUriByPage(_httpContextAccessor.HttpContext, 
                        "/ConfirmEmail", 
                        null, 
                        new { token, email = user.Email, area = "Accounts" });

                await this._mailService.SendEmailConfirmation(user.Email, confirmationLink);

                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Unable to send e-mail confirmation");

                return false;
            }
        }
    }
}
