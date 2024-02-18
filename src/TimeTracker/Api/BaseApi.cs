namespace TimeTracker.Api
{
    public class BaseApi
    {
        protected ILogger Logger;

        public BaseApi()
        {
            
        }

        public virtual void Registr(WebApplication app)
        {
        }
    }
}
