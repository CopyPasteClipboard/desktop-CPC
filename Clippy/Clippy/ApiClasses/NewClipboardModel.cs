namespace Clippy.ApiClasses
{
    /// <summary>
    /// This class is the model used to create a new clipboard with a Post API
    /// request.
    /// Created by Keola Dunn
    /// </summary>
    public class NewClipboardModel
    {
        public int user_id { get; set; } = -1;
        public string board_name { get; set; } = null;
    }
}
