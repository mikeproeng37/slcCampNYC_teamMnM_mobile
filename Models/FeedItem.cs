using HelloSLC.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloSLC.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class FeedItem
    {
        public const string ASSIGNMENT = "ASSIGNMENT";
        public const string ASSESSMENT = "ASSESSMENT";
        public const string ATTENDANCE = "ATTENDANCE";
        public const string EVENT = "EVENT";
        public const string NOTE = "NOTE";

        public string Id { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public DateTime DueDate { get; set; }

        public FeedItem()
        {
        }

        public static List<FeedItem> getFakeFeeds()
        {
            List<FeedItem> feeds = new List<FeedItem>();
            feeds.Add(new FeedItem()
            {
                Title = "Update",
                Description = "Shin Chan got into a fight this morning with his fellow classmate over a girl. He punch the other kid in the face and left him with a black and blue.",
                Type = FeedItem.NOTE,
                Date = DateTime.Today,
            });
            feeds.Add(new FeedItem()
            {
                Title = "Math Assignment",
                Description = "Please complete exercises 1-10 from pgs 33-36.",
                Date = DateTime.Today.AddDays(1),
                Type = FeedItem.ASSIGNMENT
            });
            feeds.Add(new FeedItem()
            {
                Title = "Social Studies Quiz",
                Description = "There will be a quiz this Monday on Native American geography.",
                Date = DateTime.Today.AddDays(2),
                Type = FeedItem.ASSESSMENT
            });
            
            return feeds.OrderByDescending(c=>c.Date).ToList();
        }
    }
}
