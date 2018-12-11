namespace Clippy.ApiClasses
{
    /// <summary>
    /// Class used as a model to create a new account using the api. Members are
    /// api post params
    /// Created by Keola Dunn
    /// </summary>
    public class CreateAccountModel
    {
        public string username { get; set; } = null;
        public string password { get; set; } = null;
        public string phone_number { get; set; } = null;
    }
}
