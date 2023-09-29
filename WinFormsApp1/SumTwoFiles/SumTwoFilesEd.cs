using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WinFormsApp1.SumTwoFiles
{
    public class SumTwoFilesEd
    {
        public static int lastNumber = 0;
        public static StringBuilder CompareTwoFiles(string file1,string file2)
        {
            if(file1.Length> file2.Length)
            {
                return SumTwoNewFiles(file1, file2);
            }
            else
            {
                return SumTwoNewFiles(file2, file1);
            }
        }
        public static StringBuilder CompareTwoFiles1(string file1, string file2)
        {
            return JoinFiles(file1, file2);
        }

        //todo change
        public static StringBuilder SumTwoNewFiles(string longFile, string shortfile)
        {
            StringBuilder newFile = new StringBuilder();
            int indexOfSubstring = longFile.IndexOf("DATA;")+5;
            string longFile1 = longFile.Remove(indexOfSubstring);
            newFile.Append(longFile1);
            string longFile2 = longFile.Remove(0, indexOfSubstring);
            int indexOfSubstring2 = longFile2.IndexOf("ENDSEC;");
            string longFile3 = longFile2.Remove(indexOfSubstring2);
            newFile.Append(longFile2);
            newFile.Append(ChangeFileNumbers(longFile, shortfile));
            return newFile;
        }
        public static StringBuilder JoinFiles(string longFile, string shortfile)
        {
            StringBuilder newFile = new StringBuilder();
            int indexOfSubstring = longFile.IndexOf("DATA;") + 5;
            string longFile1 = longFile.Remove(indexOfSubstring);
            newFile.Append(longFile1);
            string longFile2 = longFile.Remove(0, indexOfSubstring);
            int indexOfSubstring2 = longFile2.IndexOf("ENDSEC;");
            string longFile3 = longFile2.Remove(indexOfSubstring2);
            //var resultLongFile = Regex.Replace(longFile3, @"^\s+$[\r\n]*", string.Empty, RegexOptions.Multiline);
            newFile.Append(longFile3);
            int ShortindexOfSubstring = longFile.IndexOf("DATA;") + 5;
            shortfile = shortfile.Remove(0, ShortindexOfSubstring);
            var resultShortFile = Regex.Replace(shortfile, @"^\s+$[\r\n]*", string.Empty, RegexOptions.Multiline);
            newFile.Append(resultShortFile);
            return newFile;
        }
        public static string chengeNumber(Match m, int lastNumber)
        {
            int a = (int)Convert.ToInt32(m.Value.Substring(1, m.Length - 1));
            return "#" + (a + lastNumber).ToString();
        }
        public static string ChangeFileNumbers(string longFile, string shortfile)
        {
            int indexOfSubstring = longFile.IndexOf("#1");
             shortfile = shortfile.Remove(0, indexOfSubstring);


            // string text1 = enterFileText1.Text;
            foreach (Match match in Regex.Matches(longFile, @"(#+\w+)"))
            {
                if (match.Success && match.Groups.Count > 0)
                {
                    int maxNumber = Convert.ToInt32(match.Value.Substring(1, match.Value.Length - 1));
                    if (lastNumber < maxNumber)
                    {
                        lastNumber = maxNumber;
                    }
                }
            }
            string variableNumbers = @"(#+\w+)";
            //string text2 = enterFileText2.Text;

            shortfile = Regex.Replace(shortfile, variableNumbers, m => chengeNumber(m, lastNumber));
            return shortfile;
        }
    }
}