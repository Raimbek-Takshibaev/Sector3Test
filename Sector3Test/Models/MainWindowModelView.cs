using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Sector3Test.Models
{
    class MainWindowModelView
    {
        public GroupWithStudents[] Groups { get; set; }
        public ObservableCollection<Student> CurStudents { get; set; }
    }
}
