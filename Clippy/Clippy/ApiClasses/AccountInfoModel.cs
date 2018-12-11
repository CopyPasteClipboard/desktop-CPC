namespace Clippy.ApiClasses
{
    /// <summary>
    /// Model class for updating an account's information. 
    /// Used primarily in AccountView.xaml.cs
    /// Created by Keola Dunn
    /// </summary>
    public class AccountInfoModel
    {
        public string username { get; set; } = null;
        public string password { get; set; } = null;
        public string phone_number { get; set; } = null;
    }
}
