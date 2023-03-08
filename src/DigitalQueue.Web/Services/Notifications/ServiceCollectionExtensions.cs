using System.Text;

using FirebaseAdmin;

using Google.Apis.Auth.OAuth2;

namespace DigitalQueue.Web.Services.Notifications;

public static class ServiceCollectionExtensions
{
    public static void AddNotificationService(this IServiceCollection service, IConfiguration configuration)
    {
        var raw = Encoding.UTF8.GetBytes(configuration.GetValue<string>("Firebase:ServiceAccount"));
        FirebaseApp.Create(new AppOptions()
        {
            Credential = GoogleCredential.FromServiceAccountCredential(
                ServiceAccountCredential.FromServiceAccountData(new MemoryStream(raw))
            )
        });

        service.Configure<SmtpConfig>(configuration.GetSection("SmtpConfig"));
        service.AddSingleton<MailService>();
        service.AddSingleton<FirebaseNotificationService>();

        service.AddSingleton<NotificationService>();
    }
}
