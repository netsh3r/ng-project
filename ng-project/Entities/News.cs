using System;
using System.Collections.Generic;
using System.Text;

namespace ng_project.Entities
{
    public class News : Entity <long>
    {

        public string Titel { get; set; }

        public string Text { get; set; }

        public DateTime PublishDate { get; set; }
        //TODO: заменить на список 
        public string Teg { get; set; }
        public long ProjectId { get; set; }

        public virtual Project Project { get; set; }


        
    }
}
