using Portfolio.MVC.Models;
using System.Threading.Tasks;

namespace Portfolio.MVC.Contracts
{
    public interface IEmailService
    {
        Task SendMail(EmailViewModel model);
    }
}
