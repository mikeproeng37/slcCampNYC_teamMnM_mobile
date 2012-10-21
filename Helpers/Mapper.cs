using HelloSLC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace HelloSLC.Helpers
{
    public class Mapper
    {
        public static Student mapJsonToStudent(JsonObject studentJson)
        {
            JsonObject name = studentJson.GetNamedObject("name");
            Student s = new Student();
            s.name = string.Format("{0} {1}", name.GetNamedString("firstName"),name.GetNamedString("lastSurname"));
            s.id = studentJson.GetNamedString("id");
            return s;
        }        

        public static FeedItem mapFeedItemJsonToFeedItem(JsonObject feedItemJson)
        {
            FeedItem fi = new FeedItem();            
            fi.Id = getJsonStringProp(feedItemJson, "relatedObjectId");
            fi.Title = getJsonStringProp(feedItemJson, "title");
            fi.Date =  getJsonDateProp(feedItemJson, "createdDate");
            fi.Type = getJsonStringProp(feedItemJson, "type");
            fi.Description = getJsonStringProp(feedItemJson, "description");
            fi.DueDate = getJsonDateProp(feedItemJson, "dueDate");            
            return fi;
        }

        public static Assessment mapAssessmentJsonToAssessment(JsonObject assessmentJson)
        {
            Assessment assessment = new Assessment();
            assessment.id = assessmentJson.GetNamedString("id");
            assessment.title = assessmentJson.GetNamedString("assessmentTitle");
            assessment.subject = assessmentJson.GetNamedString("academicSubject");
            assessment.category = assessmentJson.GetNamedString("assessmentCategory");

            var studentAssessmentArray = assessmentJson.GetNamedArray("studentAssessmentAssociation");
            var studentAssessment = studentAssessmentArray[0].GetObject();

            try
            {
                var startDate = studentAssessment.GetNamedString("administrationDate");
                if (startDate != null) assessment.startDate = DateTime.Parse(startDate);

                var endDate = studentAssessment.GetNamedString("administrationEndDate");
                if (endDate != null) assessment.endDate = DateTime.Parse(endDate);

                var scoreResults = studentAssessment.GetNamedArray("scoreResults");
                var firstScore = scoreResults[0];
                assessment.score = firstScore.GetObject().GetNamedString("result") + "/" + assessmentJson.GetNamedNumber("maxRawScore");
            }
            catch (Exception e)
            {

            }
            assessment.description = "Bacon ipsum dolor sit amet meatloaf tail doner, sausage pig jowl flank chicken beef ribs drumstick leberkas ham rump ball tip prosciutto. Boudin pig prosciutto, leberkas ball tip meatloaf ham hock hamburger ribeye salami beef jerky. Pork belly pork chop tongue pancetta salami biltong capicola meatloaf prosciutto pastrami sirloin spare ribs. Tri-tip filet mignon tail beef ribs. Biltong flank ribeye short ribs, cow ground round brisket jerky pork.\n\n Turkey frankfurter meatball, shank fatback ball tip boudin shankle chuck. Shankle shoulder shank pig ham turkey brisket pork chop filet mignon. Strip steak sausage turkey, shank fatback filet mignon hamburger jowl. Pig bacon drumstick, swine chicken sausage prosciutto brisket strip steak doner ham pork loin bresaola shank. Doner beef capicola fatback pork belly, pork chop t-bone shank turducken andouille corned beef. Tail turducken sausage andouille chuck kielbasa pig bacon corned beef t-bone flank beef. Tenderloin chicken sirloin, tail swine turkey short ribs tongue meatball capicola ham spare ribs filet mignon kielbasa meatloaf.";
            return assessment;
        }

        public static Section mapSectionJsonToSection(JsonObject sectionJson)
        {
            Section section = new Section();
            section.id = sectionJson.GetNamedString("id");
            return section;
        }

        public static Event mapEventJsonToEvent(JsonObject eventJson)
        {
            Event eventObj = new Event();
            eventObj.id = eventJson.GetNamedString("id");
            eventObj.title = eventJson.GetNamedString("title");
            eventObj.description = eventJson.GetNamedString("description");
            eventObj.date = DateTime.Parse(eventJson.GetNamedString("dueDate"));
            eventObj.type = eventJson.GetNamedString("type");
            eventObj.description = "Bacon ipsum dolor sit amet meatloaf tail doner, sausage pig jowl flank chicken beef ribs drumstick leberkas ham rump ball tip prosciutto. Boudin pig prosciutto, leberkas ball tip meatloaf ham hock hamburger ribeye salami beef jerky.";
            return eventObj;
        }

        private static string getJsonStringProp(JsonObject obj, string propName) 
        {
            try
            {
                return obj.GetNamedString(propName);
            }
            catch (Exception e)
            {
                // do something
            }
             return null;
        }

        private static DateTime getJsonDateProp(JsonObject obj, string propName)
        {
            try
            {
                return DateTime.Parse(obj.GetNamedString(propName));
            }
            catch (Exception e)
            {
                // do something
            }
            return new DateTime();
        }
    }
}
