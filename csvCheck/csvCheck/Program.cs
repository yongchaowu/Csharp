using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace csvCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            //DataTable dtTagName = OpenCSV("C:\\Users\\yongchao\\Desktop\\wsx.csv");
            //DataTable dtTagName1 = OpenCSV("C:\\Users\\yongchao\\Desktop\\qaaz.csv");
            Dictionary<string,string> dicTag = new Dictionary<string,string>();
            CSVFileHelper.OpenCSV("C:\\Users\\yongchao\\Desktop\\8.csv", dicTag, 0);

            Dictionary<string, string> dicTagdel = new Dictionary<string, string>();
            CSVFileHelper.OpenCSV("C:\\Users\\yongchao\\Desktop\\Diagnosis000.csv", dicTagdel, 1);

            CSVFileHelper.RemoveUnknown(dicTagdel, dicTag);

            Encoding encoding = CSVFileHelper.GetType("C:\\Users\\yongchao\\Desktop\\qaaz.csv");
            CSVFileHelper.SaveCSV(dicTag, "C:\\Users\\yongchao\\Desktop\\801.csv", encoding);
        }
    }
       
}
