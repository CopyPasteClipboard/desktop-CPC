namespace Clippy.ApiClasses
{
    /// <summary>
    /// This is a simplified class used in the log in process for the clippy app. =
    /// The class serves as the parameter for the Login post request. In a final project,
    /// this class would have more information, such as password, but for now serves to 
    /// simply get the application implementation up.
    /// Created by Keola Dunn
    /// </summary>
    public class SimpleLoginPostModel
    {
        public string username { get; set; } = null;
    }
}
