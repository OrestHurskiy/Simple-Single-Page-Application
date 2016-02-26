namespace CoreValueContacts.Services.Services.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICryptoService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string GenerateSalt();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="salt"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        string EncryptPassword(string salt, string password);
    }
}
