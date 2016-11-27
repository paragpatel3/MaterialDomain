namespace MatStore.WebUI.Infrastructure.Abstract
{
    public interface IAuthProvider //decouple controller from static methods
    {
        bool Authenticate(string username, string password);
    }
}
