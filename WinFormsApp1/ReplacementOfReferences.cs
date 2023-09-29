using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WinFormsApp00000111
{
    internal class ReplacementOfReferences
    {
        public Regex rgproject = new Regex(@"IFCPROJECT\(");
        Regex rgBuilding = new Regex(@"IFCBUILDINGSTOREY\(");
        Regex rgApp = new Regex(@"IFCAPPLICATION\(");
        Regex rgOrg = new Regex(@"IFCORGANIZATION\(");
        Regex rgDir = new Regex(@"IFCDIRECTION\(");
        Regex rgSiu = new Regex(@"IFCSIUNIT\(");

        string ref2, name2;
        Dictionary<string, string> ifcproj2 = new Dictionary<string, string>();
        Dictionary<string, string> ifcbuild2 = new Dictionary<string, string>();
        Dictionary<string, string> ifcApp2 = new Dictionary<string, string>();
        Dictionary<string, string> ifcDir2 = new Dictionary<string, string>();
        Dictionary<string, string> ifcOrg2 = new Dictionary<string, string>();
        Dictionary<string, string> ifcSiu2 = new Dictionary<string, string>();
        //List<string> 
        //Dictionary<string, string> DictWithOtherNames = new Dictionary<string, string>();
 


        //string Line1Str = string.Join(Environment.NewLine, lines1.ToArray());
        //string Line2Str = string.Join(Environment.NewLine, lines2.ToArray());
        //string newLines2 = SumTwoFilesEd.ChangeFileNumbers(Line1Str, Line2Str);
        //List<string> ex = new List<string>();

        //List<string> Suml2 = newLines2.Select(c => c.ToString()).ToList();
        ////var aq = Suml2.AsReadOnly();
        //foreach(var i in Suml2)
        //{
        //    MessageBox.Show(i);
        //}
        string name, reff;
        List<string> ifcproj = new List<string>();
        Dictionary<string, string> ifcBuildingStorey = new Dictionary<string, string>();
        List<string> ifcApp = new List<string>();
        List<string> ifcOrg = new List<string>();
        List<string> ifcDir = new List<string>();
        List<string> ifcSiu = new List<string>();
        public static int MaxNumberFirstFile(List<string> lines1)
        {
            int lastNumber = 0;
            for(int i = 0; i<lines1.Count; i++)
            {
                foreach (Match match in Regex.Matches(lines1[i], @"(#+\w+)"))
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
            }
            return lastNumber;
        }
        public string TwoFiles(List<string> lines1, List<string> lines2)
        {
            return RefFirstFile(lines1, lines2);
        }
        public string RefFirstFile(List<string> lines1, List<string> lines2)
        {
            foreach (string line1 in lines1)
            {
                if (rgproject.IsMatch(line1))
                {
                    reff = line1.Split('=')[0];
                    ifcproj.Add(reff);
                }
                if (rgBuilding.IsMatch(line1))
                {
                    name = line1.Split(',')[2];
                    reff = line1.Split('=')[0];
                    ifcBuildingStorey.Add(reff, name);
                }
                if (rgApp.IsMatch(line1))
                {
                    reff = line1.Split('=')[0];
                    ifcApp.Add(reff);
                }
                if (rgOrg.IsMatch(line1))
                {
                    reff = line1.Split('=')[0];
                    ifcOrg.Add(reff);
                }
                if (rgDir.IsMatch(line1))
                {
                    reff = line1.Split('=')[0];
                    ifcDir.Add(reff);
                }
                if (rgSiu.IsMatch(line1))
                {
                    reff = line1.Split('=')[0];
                    ifcSiu.Add(reff);

                }
            }
            return SumFile2(lines1, lines2);
        }
        public string SumFile2(List<string> lines1, List<string> lines2)
        {
           
            for (int line2 = 0; line2 < lines2.Count; line2++)
            {
                if (line2 > 26)
                {
                    if (lines2[line2].Contains("ENDSEC;"))
                    {
                        break;
                    }
                    var MaxNumber = MaxNumberFirstFile(lines1);
                    foreach (Match match in Regex.Matches(lines2[line2], @"(#+\w+)"))
                    {
                        if (match.Success && match.Groups.Count > 0)
                        {
                            int Number = Convert.ToInt32(match.Value.Substring(1, match.Value.Length - 1));
                            string strnumber = Number.ToString();
                            int summ = 0;
                            summ = Number + MaxNumber;
                            lines2[line2] = Regex.Replace(lines2[line2], $@"(?<!\d\.?){Regex.Escape(strnumber)}(?!\.?\d)", summ.ToString());
                            summ = 0;
                            strnumber = string.Empty;
                        }
                    }
                }
            }
            return DublicateNamesDelete(lines1, lines2);
        }
        public string DublicateNamesDelete(List<string> lines1, List<string> lines2)
        {
            for (int line2 = 0; line2 < lines2.Count; line2++)
            {
                if (rgproject.IsMatch(lines2[line2]))
                {
                    ref2 = lines2[line2].Split('=')[0];
                    ifcproj2.Add(ref2, ifcproj[0]);
                    lines2.Remove(lines2[line2]);
                    --line2;
                    //continue;
                    //line2.Replace(line2, string.Empty);
                }
                if (rgBuilding.IsMatch(lines2[line2]))
                {
                    var first = ifcBuildingStorey.First();
                    var value = first.Value;

                    name2 = lines2[line2].Split(',')[2];
                    ref2 = lines2[line2].Split('=')[0];
                    foreach (KeyValuePair<string, string> kvp in ifcBuildingStorey)
                    {
                        if (name2 == kvp.Value)
                        {
                            ifcbuild2.Add(ref2, kvp.Key);
                            //line2.Replace(line2, string.Empty);
                            lines2.Remove(lines2[line2]);
                            --line2;

                            //continue;
                        }
                    }
                }
                if (rgApp.IsMatch(lines2[line2]))
                {
                    ref2 = lines2[line2].Split('=')[0];
                    ifcApp2.Add(ref2, ifcApp[0]);
                    lines2.Remove(lines2[line2]);
                    --line2;
                    //continue;
                }
                //if (rgDir.IsMatch(lines2[line2]))
                //{
                //    ref2 = lines2[line2].Split('=')[0];
                //    ifcDir2.Add(ref2, ifcDir[0]);
                //    lines2.Remove(lines2[line2]);
                //    --line2;

                //    //continue;
                //}
                if (rgOrg.IsMatch(lines2[line2]))
                {
                    ref2 = lines2[line2].Split('=')[0];
                    ifcOrg2.Add(ref2, ifcOrg[0]);
                    lines2.Remove(lines2[line2]);
                    --line2;

                    //continue;
                }
                if (rgSiu.IsMatch(lines2[line2]))
                {
                    ref2 = lines2[line2].Split('=')[0];
                    ifcSiu2.Add(ref2, ifcSiu[0]);
                    lines2.Remove(lines2[line2]);
                    //continue;
                    --line2;
                }
            }
            return RefReplacement(lines1, lines2);
        }
        public string  RefReplacement(List<string> lines1, List<string> lines2)
        {
            for (int line = 0; line < lines2.Count; line++)
            {

                foreach (KeyValuePair<string, string> i in ifcSiu2)
                {
                    Regex rg = new Regex(i.Key);
                    //Console.WriteLine(rg);

                    if (rg.IsMatch(lines2[line]))
                    {
                        //line.Replace(rg.Match(i.Key), i.Value);
                        lines2[line] = Regex.Replace(lines2[line], i.Key, i.Value);
                        //MessageBox.Show(i.Key);
                        //line = result;
                        //Console.WriteLine(result);
                        //finish.Add(result);
                    }
                }
                foreach (KeyValuePair<string, string> i in ifcApp2)
                {
                    Regex rg = new Regex(i.Key);
                    //Console.WriteLine(rg);

                    if (rg.IsMatch(lines2[line]))
                    {
                        //line.Replace(rg.Match(i.Key), i.Value);
                        lines2[line] = Regex.Replace(lines2[line], i.Key, i.Value);
                        //line = result;
                        //Console.WriteLine(result);
                        //finish.Add(result);

                    }
                }
                //foreach (KeyValuePair<string, string> i in ifcDir2)
                //{
                //    Regex rg = new Regex(i.Key);
                //    //Console.WriteLine(rg);

                //    if (rg.IsMatch(lines2[line]))
                //    {
                //        //line.Replace(rg.Match(i.Key), i.Value);
                //        lines2[line] = Regex.Replace(lines2[line], i.Key, i.Value);
                //        //line = result;
                //        //Console.WriteLine(result);
                //        //finish.Add(result);


                //    }
                //}
                foreach (KeyValuePair<string, string> i in ifcproj2)
                {
                    Regex rg = new Regex(i.Key);
                    //Console.WriteLine(rg);

                    if (rg.IsMatch(lines2[line]))
                    {
                        //line.Replace(rg.Match(i.Key), i.Value);
                        lines2[line] = Regex.Replace(lines2[line], i.Key, i.Value);
                        //line = result;
                        //Console.WriteLine(result);
                        //finish.Add(result);


                    }
                }
                foreach (KeyValuePair<string, string> i in ifcOrg2)
                {
                    Regex rg = new Regex(i.Key);
                    //Console.WriteLine(rg);

                    if (rg.IsMatch(lines2[line]))
                    {
                        //line.Replace(rg.Match(i.Key), i.Value);
                        lines2[line] = Regex.Replace(lines2[line], i.Key, i.Value);
                        //line = result;
                        //Console.WriteLine(result);
                        //finish.Add(result);


                    }
                }
                foreach (KeyValuePair<string, string> i in ifcbuild2)
                {
                    Regex rg = new Regex(i.Key);
                    //Console.WriteLine(rg);

                    if (rg.IsMatch(lines2[line]))
                    {
                        //line.Replace(rg.Match(i.Key), i.Value);
                        lines2[line] = Regex.Replace(lines2[line], i.Key, i.Value);
                        //line = result;
                        //Console.WriteLine(result);
                        //finish.Add(lines2[line]);
                    }

                }
                //foreach (KeyValuePair<string, string> i in DictWithOtherNames)
                //{
                //    lines2[line] = Regex.Replace(lines2[line], i.Key, i.Value);
                //}
            }
            return JoinFiles(lines1, lines2);
        }
        public string JoinFiles(List<string> lines1, List<string> lines2)
        {
            string longFile = string.Join(Environment.NewLine, lines1.ToList());
            string shortfile = string.Join(Environment.NewLine, lines2.ToList());
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
            return newFile.ToString();
        }
    }
}
