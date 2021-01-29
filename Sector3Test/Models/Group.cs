using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sector3Test.Models
{
    class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> StudentIds { get; set; } = new List<int>();
    }
}
