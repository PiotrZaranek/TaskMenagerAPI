using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMenager.Domain.Model
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public DateTime RealizationDate { get; set; }
    }
}
