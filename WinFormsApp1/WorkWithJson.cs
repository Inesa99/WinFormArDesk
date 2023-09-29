using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Text.Json;
namespace WinFormsApp1
{
    public class WorkWidthJson
    {
         public List<User> users;
        

         public object JsonConvert { get; }

         public WorkWidthJson()
         {
            string startupPath = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(startupPath).Parent.Parent.FullName + @"\users.json";
            string json = File.ReadAllText(projectDirectory);
            users = System.Text.Json.JsonSerializer.Deserialize<List<User>>(json);
         }
         public List<User> getJsonList()
         {
             string startupPath = Environment.CurrentDirectory;
             string projectDirectory = Directory.GetParent(startupPath).Parent.Parent.FullName + @"\users.json";
             string json = File.ReadAllText(projectDirectory);
             //users = JsonConvert.DeserializeObject<List<User>>(json);
             users = System.Text.Json.JsonSerializer.Deserialize<List<User>>(json);

             return users;
         }
         public void AddUserToJson(User u)
         {
             string startupPath = Environment.CurrentDirectory;
             string projectDirectory = Directory.GetParent(startupPath).Parent.Parent.FullName + @"\users.json";
             string json = File.ReadAllText(projectDirectory);
             users.Add(u);
             var opt = new JsonSerializerOptions() { WriteIndented = true };
             File.WriteAllText(projectDirectory, String.Empty);
              string strJson = System.Text.Json.JsonSerializer.Serialize<IList<User>>(users, opt);
             using (StreamWriter sw = new StreamWriter(projectDirectory))
             {
                /*sw.WriteLine("[");
                foreach (User user in users)
                {
                    sw.WriteLine(user.ToString());
                }
                sw.WriteLine("]");*/
                sw.WriteLine(strJson);

             }
         }

     }


        public class User
        {
            public string Name { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }

            public override string ToString()
            {
                return "{" + "'Name' : '" + Name + "'," + "'Password' : '" + Password + "'," + "'Email' : '" + Email + "'},";
            }
        }
    
}
