using System;
using System.Collections.Generic;
using System.Text;

namespace ng_project.Entities
{
    /// <summary>
    /// Новости проекта
    /// </summary>
    public class News : Entity <int>
    {
        /// <summary>
        /// Изображения новости
        /// </summary>
        public List<NewsImage> NewsImages { get; set; }
        /// <summary>
        /// Заголовок 
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Текст 
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Дата публикации
        /// </summary>
        public DateTime PublishDate { get; set; }
        public Teg Teg { get; set; }
        public int TegId { get; set; }
        /// <summary>
        /// Идентификатор проекта
        /// </summary>
        public int ProjectId { get; set; }
        /// <summary>
        /// Ссылка на проект
        /// </summary>

        public Project Project { get; set; }
        
    }
}
