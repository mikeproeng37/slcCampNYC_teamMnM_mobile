using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HelloSLC.Models
{
    public class Student
    {
        public string name { get; set; }
        public string id { get; set; }
        public List<FeedItem> feeds {get;set;}
        public List<Assessment> assessments { get; set; }
        public List<Event> eventObjs { get; set; }

        public static List<Student> getFakeStudents()
        {
            List<Student> students = new List<Student>();
            students.Add(new Student()
            {
                name = "Matt Sollars",
                feeds = FeedItem.getFakeFeeds()
            });
            students.Add(new Student()
            {
                name = "Karrie Sollars"
            });
            return students;
        }
    }
}
