using _Scripts.Data.Balls;

namespace _Scripts.Infrastructure.Providers
{
    public class DataProvider : IDataProvider
    {
        public DataProvider(BallData ballData)
        {
            BallData = ballData;
        }

        public BallData BallData { get; private set; }
    }
}