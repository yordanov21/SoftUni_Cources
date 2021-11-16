namespace MyCustomHttpServer
{
    using System.Threading.Tasks;
    public interface IHttpServer
    {
        void Start();

        void Stop();

        Task StartAsync();
    }
}