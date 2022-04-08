using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class LoginUser
    {

        public int SearchLoginUser() // 로그인한 사람의 index를 return함
        {

            for (int index = 1; index < LibraryStart.userList.Count; index++)
            {
                if (LibraryStart.userList[0].Id == LibraryStart.userList[index].Id)
                    return index;
            }
            return -1;
        }

    }
}
