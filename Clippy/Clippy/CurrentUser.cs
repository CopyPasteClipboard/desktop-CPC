using System.Collections.Generic;

namespace Clippy
{
    /// <summary>
    /// Class representing the current user signed into the app and all of
    /// the user's needed/available information
    /// Created by Keola Dunn
    /// </summary>
    public class CurrentUser
    {
        // User information
        private string Username { get; } = null;
        private int UserId { get; } = -1;
        private string Password { get; } = null;
        private string Phone { get; } = null;
        private List<ClipboardModel> Clipboards { get; set; } = null; 

        /// <summary>
        /// Alt Ctor for a CurrentUser with a UserLoginInfoModel parameter
        /// </summary>
        /// <param name="info">
        /// UserLoginInfoModel from login containing most of the user information
        /// </param>
        public CurrentUser(UserLoginInfoModel info)
        {
            Username = info.username;
            UserId = info.id;
        }

        /// <summary>
        /// returns the CurrentUser username
        /// </summary>
        /// <returns>
        /// String Username member
        /// </returns>
        public string GetUsername()
        {
            return Username;
        }

        /// <summary>
        /// Returns the current user phone number
        /// </summary>
        /// <returns>
        /// String Phone member
        /// </returns>
        public string GetPhoneNumber()
        {
            return Phone;
        }

        /// <summary>
        /// Returns the current user's ID
        /// </summary>
        /// <returns>
        /// Int UserId member
        /// </returns>
        public int GetUserId()
        {
            return UserId;
        }

        /// <summary>
        /// Gives the CurrentUser clipboards
        /// </summary>
        /// <param name="boards">
        /// List of ClipboardModels containing all of the user's clipboards
        /// </param>
        public void SetClipboards(List<ClipboardModel> boards)
        {
            Clipboards = boards;
        }

        /// <summary>
        /// Find a boardId based on a boardname parameter for the user
        /// </summary>
        /// <param name="boardName">
        /// String representing the name of a Clipboard
        /// </param>
        /// <returns>
        /// ID of the board with the name passed as a parameter. -1 if the
        /// board does not exist
        /// </returns>
        public int GetBoardId(string boardName)
        {
            int ret = -1;
            if (Clipboards != null)
            {
                foreach (ClipboardModel board in Clipboards)
                {
                    if (board.board_name.Equals(boardName.Trim()))
                    {
                        ret = board.id;
                        break;
                    }
                }
            }
            return ret;
        }
    }
}
