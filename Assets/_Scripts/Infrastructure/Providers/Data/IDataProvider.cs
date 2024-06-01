using _Scripts.Data.Balls;
using _Scripts.Infrastructure.Singleton;

namespace _Scripts.Infrastructure.Providers
{
    public interface IDataProvider : IService
    {
        BallData BallData { get; }
    }
}