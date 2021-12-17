using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Core.Entities
{
    public class Todo : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
