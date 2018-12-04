using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clippy
{
    /// <summary>
    /// Class representing the current user signed into the app and all of
    /// their needed/available information
    /// </summary>
    public class CurrentUser
    {
        //User variables
        private string Username { get; } = null;
        private int UserId { get; } = -1;
        private string Password { get; } = null;
        private string Phone { get; } = null;
        private List<ClipboardModel> Clipboards { get; set; } = null; 

        /// <summary>
        /// Ctor for a CurrentUser based on a UserLoginInfoModel
        /// </summary>
        /// <param name="info"></param>
        public CurrentUser(UserLoginInfoModel info)
        {
            Username = info.username;
            UserId = info.id;
        }

        /// <summary>
        /// returns the CurrentUser username
        /// </summary>
        /// <returns></returns>
        public string GetUsername()
        {
            return Username;
        }

        /// <summary>
        /// Returns the current user phone number
        /// </summary>
        /// <returns></returns>
        public string GetPhoneNumber()
        {
            return Phone;
        }

        /// <summary>
        /// Returns the current user's ID
        /// </summary>
        /// <returns></returns>
        public int GetUserId()
        {
            return UserId;
        }

        /// <summary>
        /// Gives the CurrentUser clipboards
        /// </summary>
        /// <param name="boards"></param>
        public void SetClipboards(List<ClipboardModel> boards)
        {
            Clipboards = boards;
        }

        /// <summary>
        /// Find a boardId based on a boardname parameter for the user
        /// </summary>
        /// <param name="boardName"></param>
        /// <returns></returns>
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
