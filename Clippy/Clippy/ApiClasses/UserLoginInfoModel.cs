namespace Clippy
{
    /// <summary>
    /// Class representing the returned data from API Post log in request.
    /// Created by Keola Dunn
    /// </summary>
    public class UserLoginInfoModel
    {
        public int id { get; set; } = -1;
        public string username { get; set; } = null;

        // could be implemented as a Date/Time in the future
        public string inserted_at { get; set; } = null; 
    }
}
