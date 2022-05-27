using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniShopApp.WebUI.EmailServices
{
    public interface IEmailSender
    {
        //Bu interface farklı mailserver tekniklerine göre mail gönderme
        //metorlarımızı yapılandırabilmek için genel olarak tasarlanmıstır
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}
