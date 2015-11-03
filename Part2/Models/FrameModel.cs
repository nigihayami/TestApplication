using System.ComponentModel.DataAnnotations.Schema;

namespace Part2.Models
{
    public class FrameModel
    {
        public int Id { get; set; }
        /// <summary>
        /// Внутреннее название фрейма
        /// </summary>
        [Index(IsUnique =true)]
        public string FrameName { get; set; }
        /// <summary>
        /// Описание фрейма - для разработчиков
        /// </summary>
        public string FrameDescription { get; set; }
    }
}