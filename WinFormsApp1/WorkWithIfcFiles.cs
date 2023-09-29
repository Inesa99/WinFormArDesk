using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public static class WorkWithIfcFiles
    {/*
        public static List<string> KardalFileic(string path)
        {
            List<string> a = WorkWithIfcFiles.DownloadLines(path);
            return a;

        }

        public static string CreateFile(String result)
        {
            string tempFile = @"C:\Users\Student\Desktop\newTempFile.ifc";
            using (FileStream fs = new FileStream(tempFile, FileMode.OpenOrCreate))
            {
                fs.Seek(0, SeekOrigin.End);
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(result);
                }
            }
            return tempFile;
        }
        //path-ayn path-y voric piti ktriskizby ev verjy
        //newPath-ayn texy vortex piti stexci nor fily
       /* public static List<string> getNumbersLines(string path){
            List<string> file = DownloadLines(path);
            List<string> newList = new List<string>();
            for (int i = 0; i < file.Count; i++) {
                if (file[i].Contains('#'))
                {
                    newList.Add(file[i]);
                }
            }
            return newList;
        }
        public static void Create3ThFile(string path, string newPath,List<string> file2)
        {

            //path = @"C:\Users\User\OneDrive\Desktop\Project02.ifc";
            //newPath = @"C:\Users\User\OneDrive\Desktop\Project03.ifc";
            List<string> a = KardalFileic(path);
            using (FileStream fs = new FileStream(newPath, FileMode.OpenOrCreate))
            {
                fs.Seek(0, SeekOrigin.End);
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    for (int i = 0; i < a.Count; i++)
                    {
                        if (!a[i].Contains('#'))
                        {
                            sw.WriteLine(a[i]);
                        }
                        else
                        {
                            break;
                        }
                    }
                    for (int i = 0; i < a.Count; i++)
                    {
                        if (a[i].Contains('#'))
                        {
                            sw.WriteLine(a[i]);
                        }
                    }
                    for(int i = 0; i < file2.Count; i++)
                    {
                        if (file2[i].Contains('#'))
                        {
                            sw.WriteLine(file2[i]);
                        }
                    }
                    List<string> verj = new List<string>();
                    for (int i = a.Count - 1; i >= 0; i--)
                    {
                        if (!a[i].Contains('#'))
                        {
                            verj.Add(a[i]);
                        }
                        else
                        {
                            break;
                        }
                    }
                    for (int i = verj.Count - 1; i >= 0; i--)
                    {
                        sw.WriteLine(verj[i]);
                    }


                }
            }
        }
        //faylic hanum e toxery ev lcnum list-i mej
        public static List<string> DownloadLines(string hostUrl)
        {
            List<string> strContent = new List<string>();
            var webRequest = WebRequest.Create(hostUrl);
            using (var response = webRequest.GetResponse())
            using (var content = response.GetResponseStream())
            using (var reader = new StreamReader(content))
            {
                while (!reader.EndOfStream)
                {
                    strContent.Add(reader.ReadLine());
                }
            }
            return strContent;
        }*/

    }

}
