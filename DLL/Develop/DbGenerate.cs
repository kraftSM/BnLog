using BnLog.DLL.Models.Security;

namespace BnLog.DLL.Develop
{
    public class DbGenerate
    {
       // public readonly string[] RoleNames = new string[] { "Администратор", "Модератор", "Пользователь"};
        
        public readonly string[] maleNames = new string[] { "Александро", "Борис", "Василий", "Игорь", "Даниил", "Сергей", "Евгений", "Алексей", "Геогрий", "Валентин" };
        public readonly string[] femaleNames = new string[] { "Анна", "Мария", "Станислава", "Елена" };
        public readonly string[] lastNames = new string[] { "Тестов", "Титов", "Потапов", "Джабаев", "Иванов" };


        public List<Role> GenerateRoles()
        {
            var roles = new List<Role>();
            var item = new Role()
            {
                Name = "Администратор",
                SecurityLvl = 2
            };
            roles.Add(item);

            var item1 = new Role()
            {
                Name = "Модератор",
                SecurityLvl = 1
            };
            roles.Add(item1);

            var item2 = new Role()
            {
                Name = "Пользователь",
                SecurityLvl = 0
            };
            roles.Add(item2);
            return roles;
        }
            public List<User> GenerateSetOfUser(int count)
        {
            var users = new List<User>();
            for (int i = 1; i < count; i++)
            {
                string firstName;
                var rand = new Random();

                var male = rand.Next(1, 2) == 1;

                var lastName = lastNames[rand.Next(0, lastNames.Length - 1)];
                if (male)
                {
                    firstName = maleNames[rand.Next(0, maleNames.Length - 1)];
                }
                else
                {
                    lastName = lastName + "a";
                    firstName = femaleNames[rand.Next(0, femaleNames.Length - 1)];
                }

                var item = new User()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    // BirthDate = DateTime.Now.AddDays(-rand.Next(1, (DateTime.Now - DateTime.Now.AddYears(-25)).Days)),
                    Email = "test" + rand.Next(0, 1204) + "@test.com",
                };

                item.UserName = item.Email;
                //item.Image = "https://thispersondoesnotexist.com/image";

                users.Add(item);
            }

            return users;
        }
    }
}
