using CodeBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя 
    /// </summary>
    public class UserController
    {
        public List<User> users { get; }
        public User CurrentUser { get; }

        public bool IsNewUser { get; } = false;
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым",nameof(userName)); 
            }

            users = new List<User>();

            CurrentUser = users.SingleOrDefault(u => u.Name == userName);

            if(CurrentUser == null)
            {
                CurrentUser = new User(userName);
                users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }

        }
        /// <summary>
        /// Сохранить данные пользователя
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using(var fs = new FileStream("users.dat",FileMode.Append))
            {
                formatter.Serialize(fs, users);
            }
        }

        public void SetNewUserDate(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            // Проверка 

            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();

        }
        /// <summary>
        /// Получить данные пользователя 
        /// </summary>
        /// <returns></returns>
        public User Load()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.Append))
            {
                return formatter.Deserialize(fs) as User;
            }
        }
        /// <summary>
        /// Получить сохранённый список пользователей 
        /// </summary>
        /// <returns></returns>
        private List<User> GetUsersData()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.Append))
            {
                if(formatter.Deserialize(fs) is List<User> users)
                {return users;}
                else
                { return new List<User>(); }
            }
        }
    }
}
