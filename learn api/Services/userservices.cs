using learn_api.Models;

namespace learn_api.Services
{
    public class userservices
    {
        static List<user> list_user   { get; }
        static int next_user = 3;
        static userservices()
        {
            list_user = new List<user>() {
                 new user { id =1,name="mo",age=12, salary=1222 },
                 new user { id = 2, name = "fahd", age = 22, salary = 2222 }
            };
        }
        public static List<user> getall()
        {
            return list_user;
        }
        public static user getone(int id)
        {
            return list_user.FirstOrDefault(x=>x.id == id);
        }
        public static void setone(user u)
        {
            u.id=next_user++;
            list_user.Add(u);
        }
        public static void update(user u)
        {
           var idex=list_user.FindIndex(x=>x.id==u.id);
            if (idex != null)
            {
                list_user[idex] = u;
            }
            else
                return;
        }
        public static void delete(int id)
        {
            var temp_user = getone(id);
            if (temp_user != null)
            {
                list_user.Remove(temp_user);
            }
            else
                return;
        }
    }
}
