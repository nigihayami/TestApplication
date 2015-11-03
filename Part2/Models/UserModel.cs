using System.ComponentModel.DataAnnotations.Schema;

namespace Part2.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        /// <summary>
        /// Имя пользователя
        /// </summary>
        [Index(IsUnique =true)]
        public string UserName { get; set; }
        /// <summary>
        /// Пароль - Не очень красиво
        /// </summary>
        public string Password { get; set; }
    }
}