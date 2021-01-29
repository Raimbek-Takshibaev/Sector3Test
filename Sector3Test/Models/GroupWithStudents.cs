using System;
using System.Collections.Generic;
using System.Text;

namespace Sector3Test.Models
{
    class GroupWithStudents
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public Student[] Students { get; set; }
        public string GetString { get { return $"{GroupName} {GroupId}"; } }
    }
}
