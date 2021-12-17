using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Core.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; }
    }
}
