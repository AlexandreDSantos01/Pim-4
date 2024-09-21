namespace Web.Services // ou o namespace apropriado do seu projeto
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity.UI.Services;

    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            // Aqui você implementará a lógica real para enviar e-mails.
            return Task.CompletedTask; // Apenas para fins de exemplo
        }
    }
}
