using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace to_do
{
    public class Todo
    {
        public Todo()
        {
            Desc = string.Empty; 
        }
        public string Desc {  get; set; }
        public string Check { get; set; }
    }
}
