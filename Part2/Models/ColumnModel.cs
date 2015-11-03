using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Part2.Models
{
    public class ColumnModel
    {
        public int Id { get; set; }
        /// <summary>
        /// Фрейм
        /// </summary>
        public FrameModel FrameId { get; set; }
        /// <summary>
        /// Пользователь
        /// </summary>
        public UserModel UserId { get; set; }
        /// <summary>
        /// GUID Компонента
        /// </summary>
        public Guid ComponentGuid { get; set; }
        /// <summary>
        /// Название колонки внутреннее
        /// </summary>
        public string ColumnName { get; set; }
        /// <summary>
        /// Название колонки - отображаемое
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// Размер
        /// </summary>
        public int ColumnWidth { get; set; }
        /// <summary>
        /// Видимость
        /// </summary>
        public bool IsVisible { get; set; }

        /// <summary>
        /// Позиция колонки
        /// </summary>
        public int Position { get; set; }

        //А дальше список можно расширять и расширять
    }
}
