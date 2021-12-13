namespace WebAPIDynamicExample.Configuration.Interfaces
{
    public interface IConfigRetriever
    {
        //Add 'Get' method which returns project specific object 
        public WebAPIDynamicExampleConfiguration Get();

    }
}
