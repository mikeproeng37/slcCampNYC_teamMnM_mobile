using HelloSLC.Global;
using HelloSLC.Helpers;
using HelloSLC.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace HelloSLC
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class HomePage : HelloSLC.Common.LayoutAwarePage
    {
        public ObservableCollection<MenuItem> MenuItems = new ObservableCollection<MenuItem>();
        public ObservableCollection<FeedItem> Feeds = new ObservableCollection<FeedItem>();
        public ObservableCollection<Student> Students = new ObservableCollection<Student>();
        private GestureRecognizer gr;

        private Point initialpoint;

        public HomePage()
        {
            this.InitializeComponent();
            this.DefaultViewModel["students"] = Students;
            bootstrap();
        }

       /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }

        private async void bootstrap()
        {
            setupMenuItems();

            // need an option to show feeds for all kids
            var kidAll = new Student()
            {
                name = "All",
                feeds = new List<FeedItem>()
            };

            List<Student> students = await getParentKids(Constants.parentId);
            students.Insert(0, kidAll);            
            foreach (Student s in students)
            {
                // get feeds for each student
                if (s.id != null)
                {
                    List<FeedItem> feeds = await getStudentFeeds(s.id);
                    s.feeds = feeds;
                    kidAll.feeds.AddRange(feeds);
                }
                Students.Add(s);
            }
            kidAll.feeds = kidAll.feeds.OrderByDescending(c=>c.Date).ToList();

            App.listStudents = students;
            this.DefaultViewModel["selectedStudent"] = kidAll;
        }

        /// <summary>
        /// Create the left hand menu items
        /// </summary>
        private void setupMenuItems()
        {
            MenuItems.Add(new MenuItem() { Title = "Home", Icon = "Assets/home.png" });
            MenuItems.Add(new MenuItem() { Title = "Assignments", Icon = "Assets/assignment.png" });
            MenuItems.Add(new MenuItem() { Title = "Events", Icon = "Assets/event.png" });

            this.DefaultViewModel["menuItems"] = MenuItems;
        }

        /// <summary>
        /// Pull in the feeds from SLC and add them to the list
        /// </summary>
        private async Task<List<FeedItem>> getStudentFeeds(string studentId)
        {
            List<FeedItem> feeds = new List<FeedItem>();

            var studentCustomAssociations = Constants.Student.CUSTOM.Replace(Constants.Student.STUDENT_ID, studentId);
            var studentCustom = await Utility.GetData(string.Format("{0}{1}", Constants.API_URI, studentCustomAssociations), App.ACCESSTOKEN);                
            var studentCustomJson = JsonObject.Parse(studentCustom);

            var studentFeedsArray = studentCustomJson.GetNamedArray("news");
            foreach (var feedItem in studentFeedsArray)
            {
                FeedItem fi = Mapper.mapFeedItemJsonToFeedItem(feedItem.GetObject());

                var icon = "Assets/";
                switch (fi.Type)
                {
                    case FeedItem.ASSIGNMENT:
                        icon += "assignment.png";
                        break;
                    case FeedItem.ASSESSMENT:
                        icon += "test.png";
                        break;
                    case FeedItem.EVENT:
                        icon += "event.png";
                        break;
                    case FeedItem.NOTE:
                        icon += "feed.png";
                        break;
                }
                fi.Icon = icon;                
                feeds.Add(fi);    
            }
            return feeds.OrderByDescending(c=>c.Date).ToList();            
        }

        /// <summary>
        /// Get the given parent's kids
        /// </summary>
        private async Task<List<Student>> getParentKids(string parentId)
        {
            List<Student> students = new List<Student>();

            var parentStudentAssociation = Constants.Parent.STUDENTS.Replace(Constants.Parent.PARENT_ID, parentId);
            var kids = await Utility.GetData(string.Format("{0}{1}", Constants.API_URI, parentStudentAssociation), App.ACCESSTOKEN);
            var kidsJsonArray = JsonArray.Parse(kids);
            foreach (var kid in kidsJsonArray)
            {
                Student s = Mapper.mapJsonToStudent(kid.GetObject());
                students.Add(s);
            }
            return students;
        }        

        /// <summary>
        /// Handler for menu selection event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuList_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            MenuItem selectedItem = (MenuItem)menuList.SelectedItem;
            switch (selectedItem.Title)
            {
                case "Assignments":
                    this.Frame.Navigate(typeof(AssessmentsPage));
                    break;
                case "Events":
                    this.Frame.Navigate(typeof(CalendarPage));
                    break;
                default:
                    this.Frame.Navigate(typeof(HomePage));
                    break;
            }
        }

        private void feedsList_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            FeedItem selectedFeedItem = (FeedItem)feedsList.SelectedItem;
            Student selectedStudent = (Student)studentList.SelectedItem;
            StudentTransfer dto = new StudentTransfer()
            {
                student = selectedStudent,
                feedItem = selectedFeedItem
            };
            switch (selectedFeedItem.Type)
            {
                case FeedItem.ASSESSMENT:
                case FeedItem.ASSIGNMENT:
                    this.Frame.Navigate(typeof(AssessmentsPage), dto);
                    break;
                case FeedItem.EVENT:
                    this.Frame.Navigate(typeof(CalendarPage), dto);
                    break;
            }
        }        
    }
}
