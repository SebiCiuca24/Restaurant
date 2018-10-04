namespace Restaurant.Business.Utils
{
    public interface IPasswordEncrypter
    {
        string EncryptPassword(string password);
    }
}

