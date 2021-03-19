using System;
using System.Collections.Generic;
using System.Text;

namespace ng_project.Entities
{
    public class News : Entity <int>
    {
        public NewsImage NewsImage { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public DateTime PublishDate { get; set; }
        //TODO: заменить на список 
        public string Teg { get; set; }
        public int ProjectId { get; set; }

        public Project Project { get; set; }
        
    }
}
