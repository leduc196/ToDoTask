using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TasksServer.Models
{
    public class Tasks
    {
        [Key]
        public int taskid { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool status { get; set; }
    }
}
