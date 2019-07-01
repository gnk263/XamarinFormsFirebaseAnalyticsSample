using Firebase.Analytics;

namespace FASample.Droid
{
    public class AnalyticsSingleton
    {
        public static AnalyticsSingleton GetInstance { get; } = new AnalyticsSingleton();

        public FirebaseAnalytics Analytics { get; set; }

        private AnalyticsSingleton()
        {
            
        }
    }
}