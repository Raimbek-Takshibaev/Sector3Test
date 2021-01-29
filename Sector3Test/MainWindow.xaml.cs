using Sector3Test.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sector3Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        public MainWindow()
        {
            Group[] groups = new Group[0];
            List<Student> students = new List<Student>();           
            try
            {
                groups = JsonSerializer.Deserialize<Group[]>(File.ReadAllText("~/Groups.json"));
                students = JsonSerializer.Deserialize<Student[]>(File.ReadAllText("~/Groups.json")).ToList();
            }
            catch (Exception)
            {
                string[] groupNames = new string[3] { "math", "history", "jojo" };
                groups = new Group[groupNames.Length];
                for (int i = 0; i < groupNames.Length; i++)
                {
                    Group group = new Group() { Id = i + 1, Name = groupNames[i] };
                    for (int a = 0; a < 8; a++)
                    {
                        Student student = new Student() { Id = a + 1, Name = $"{group.Name} student", GroupName = groupNames[i] };
                        group.StudentIds.Add(a + 1);
                        students.Add(student);
                    }
                    groups[i] = group;
                }
                File.WriteAllText("Groups.json", JsonSerializer.Serialize(groups));
                File.WriteAllText("Students.json", JsonSerializer.Serialize(students.ToArray()));             
            }
            GroupWithStudents[] groupsWithStudents = (from g in groups
                                                     select new GroupWithStudents
                                                     {
                                                         GroupId = g.Id,
                                                         GroupName = g.Name,
                                                         Students = students.Where(s => s.GroupName == g.Name).ToArray()
                                                     }).ToArray();
            this.DataContext = new MainWindowModelView() { Groups = groupsWithStudents};
            InitializeComponent();
        }
        public void Get_Students(object sender, RoutedEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            MainWindowModelView model = this.DataContext as MainWindowModelView;
            model.CurStudents = new ObservableCollection<Student>((textBlock.DataContext as GroupWithStudents).Students);
            this.DataContext = model;
            students.ItemsSource = model.CurStudents;
        }
    }
} 
