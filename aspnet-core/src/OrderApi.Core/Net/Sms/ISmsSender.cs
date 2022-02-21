using System.Threading.Tasks;

namespace OrderApi.Net.Sms
{
    public interface ISmsSender
    {
        Task SendAsync(string number, string message);
    }
}