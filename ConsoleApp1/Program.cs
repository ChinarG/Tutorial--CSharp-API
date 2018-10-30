using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 写操作

            ////使用 using 这里可以直接调用 FileStream 中的析构函数，免除双关！
            //using (FileStream streamWrite = new FileStream(@"C:\Users\Administrator\Desktop\Chinar.txt", FileMode.Create, FileAccess.Write))
            //{
            //    byte[] bytes = Encoding.UTF8.GetBytes("Chinar测试 —— 创建文本");
            //    streamWrite.Write(bytes, 0, bytes.Length);
            //}
            //Console.WriteLine("写入完成！");
            //Console.ReadLine();

            #endregion


            #region 读取操作

            using (FileStream streamRead = new FileStream(@"C:\Users\Administrator\Desktop\Chinar.txt", FileMode.Open, FileAccess.Read))
            {
                byte[] bytes   = new byte[1024];
                var    lenRead = streamRead.Read(bytes, 0, bytes.Length);
                while (lenRead > 0)
                {
                    string str = Encoding.UTF8.GetString(bytes, 0, lenRead); //读到文本的最长就行，后边的都为空不需要再读
                    Console.WriteLine(str);
                    lenRead = streamRead.Read(bytes, 0, bytes.Length); //lenRead为0，如果文件内容比1024打，那么需要分好多次，读完为止
                }
            }
            Console.ReadLine();

            #endregion
        }
    }
}