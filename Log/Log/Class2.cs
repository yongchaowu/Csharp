using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
namespace Log
{
 /// <summary>
    /// 日志类
    /// </summary>
    public class LogfileExport
    {
        private string pathLogFile;//日志存储路径

        public LogfileExport(string path)
        {
            this.pathLogFile = path;
        }
        public LogfileExport()
        {
            this.pathLogFile = "./";
        }

        /// <summary>
        /// 创建日志
        /// </summary>
        /// <param name="message">日志信息</param>
        /// <param name="title">日志标题</param>
        public void Log(string message)
        {
            string path = this.pathLogFile;
            string filename = path + "API.log";

            #region 生成文件日志
            FileStream fsLog;
            if (!File.Exists(filename))
            {
                fsLog = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
            }
            else
            {
                fsLog = new FileStream(filename, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            }

            StreamWriter exportMess = new StreamWriter(fsLog);
            exportMess.WriteLine("-------------------------------Begin---------------------------------------------");
            // n.WriteLine("*****" + title + "*****");
            exportMess.WriteLine("时间：" + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss:fff"));
            exportMess.WriteLine("信息：" + message);
            exportMess.WriteLine("-------------------------------end---------------------------------------------");
            exportMess.Close();
            fsLog.Close();

            FileInfo fileInf = new FileInfo(filename);
            if (fileInf.Length >= 1024 * 1024 * 4)
            {
                try
                {
                    string NewName = path + "API(Bak)"+ ".log";
                    File.Copy(filename, NewName,true);
                }
                catch (System.Exception ex)
                {
                    ex.Message.ToString();
                	
                }
                File.Delete(filename);
            }

            //
            //if (fileInf.Length >= 1024*100)
            //{
            //    string NewName = path + "Log" + time() + ".txt";
            //    File.Move(filename, NewName);
            //    //File.Copy(filename, NewName);
            //    File.Delete(filename);
            //}
            #endregion
        }
        /// <summary>
        /// 系统时间
        /// </summary>
        /// <returns></returns>
        public string time()
        {
            string strNowTime = DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss_fff");//.Replace("/", "").Replace(":", "").Replace("-", "").Trim();//.Trim().Replace("/", "").Replace(":", "");
            string strTime = strNowTime.ToString();
            return strTime;
        }
    }
}
;