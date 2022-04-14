using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    internal class StringSort
    {
        public void PrintCenter(string data, int width) // 문구 센터에 정렬
        {
            Console.WriteLine(String.Format("{0}", data).PadLeft(width - ((width / 2) - (data.Length / 2))));
        }
        
        
    }
}
