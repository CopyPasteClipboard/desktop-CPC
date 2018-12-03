using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clippy
{
    public class CurrentUser
    {
        private string Username { get; } = null;
        private int UserId { get; } = -1;
        private string Password { get; } = null;
        private string Phone { get; } = null;
        private List<ClipboardModel> Clipboards { get; set; } = null; 


        public CurrentUser(UserLoginInfoModel info)
        {
            Username = info.Username;
            UserId = info.ID;
            Phone = info.Phone_number;
        }

        public string GetUsername()
        {
            return Username;
        }

        public string GetPhoneNumber()
        {
            return Phone;
        }

        public void SetClipboards(List<ClipboardModel> boards)
        {
            Clipboards = boards;
        }

        public int GetBoardId(string boardName)
        {
            int ret = -1;
            foreach(ClipboardModel board in Clipboards)
            {
                if (board.board_name.Equals(boardName.Trim()))
                {
                    ret = board.id;
                    break;
                }
            }
            return ret;
        }

        public int GetUserId()
        {
            return UserId;
        }
    }
}
