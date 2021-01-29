using System;
using System.Collections.Generic;
using System.Text;

namespace Sector3Test.Models
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string GroupName { get; set; }
        public string GetString { get { return $"{Name} {Id}"; } }
    }
}
