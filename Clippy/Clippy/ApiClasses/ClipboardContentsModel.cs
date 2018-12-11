namespace Clippy
{
    /// <summary>
    /// Model representing the data stored in a clipboard (returned from call). 
    /// Mainly used in HomeScreen.xaml.cs
    /// Created by Keola Dunn
    /// </summary>
    public class ClipboardContentsModel
    {
        public int id { get; set; }
        public int board_id { get; set; }
        public string text_content { get; set; } = null;
    }
}
