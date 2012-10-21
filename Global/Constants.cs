using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloSLC.Global
{
    public class Constants
    {
        /// <summary>
        /// General app constants
        /// </summary>
        #region api

        // daomannhi
        public const string clientId = "kLFafZgwmJ";
        public const string clientSecret = "UiyOPRbuuALUngj4T95OSIwfVePuqEFYhlcPq8zOx7Xm3Euc";
        // mikeng13
        //public const string clientId = "N30jIMMLEB";
        //public const string clientSecret = "fpb1AWyVXUJ5JTl2zwLAzxgCwCe43pIGaUVGstTYpEeZrsjm";
        public const string redirectUri = "http://localhost:49611/start.aspx";
        public const string API_URI = "https://api.sandbox.slcedu.org/api/rest/v1/";

        public const string parentId = "2012ay-81d9db53-0b25-11e2-985e-024775596ac8";

        #endregion

        /// <summary>
        /// the rel names in the links related to the students in the /students API call
        /// </summary>
        #region methods
        public const string SELF = "self";
        public const string CUSTOM = "custom";
        public const string STUDENT_DISCIPLINE_INCIDENT_ASSOCIATIONS = "getStudentDisciplineIncidentAssociations";
        public const string GET_DISCIPLINE_INCIDENTS = "getDisciplineIncidents";
        public const string GET_STUDENT_DISCIPLINE_INCIDENT_ASSOCIATION = "getStudentDisciplineIncidentAssociations";
        public const string GET_STUDENT_ASSESSMENTS = "getStudentAssessments";
        public const string GET_ASSESSMENTS = "getAssessments";
        public const string GET_STUDENT_PARENT_ASSOCIATIONS = "getStudentParentAssociations";
        public const string GET_PARENTS = "getParents";
        public const string GET_STUDENT_GRADEBOOK_ENTRIES = "getStudentGradebookEntries";
        public const string GET_STUDENT_PROGRAM_ASSOCIATIONS = "getStudentProgramAssociations";
        public const string GET_PROGRAMS = "getPrograms";
        public const string GET_COURSE_TRANSCRIPTS = "getCourseTranscripts";
        public const string GET_COURSES = "getCourses";
        public const string GET_STUDENT_SCHOOL_ASSOCIATIONS = "getStudentSchoolAssociations";
        public const string GET_SCHOOLS = "getSchools";
        public const string GET_REPORT_CARDS = "getReportCards";
        public const string GET_STUDENT_COHORT_ASSOCIATIONS = "getStudentCohortAssociations";
        public const string GET_COHORTS = "getCohorts";
        public const string GET_ATTENDANCES = "getAttendances";
        public const string GET_DISCIPLINE_ACTIONS = "getDisciplineActions";
        public const string GET_STUDENT_ACADEMIC_RECORDS = "getStudentAcademicRecords";
        public const string GET_STUDENT_SECTION_ASSOCIATIONS = "getStudentSectionAssociations";
        public const string GET_SECTIONS = "getSections";
        #endregion

        /// <summary>
        /// API calls for students entity
        /// </summary>
        public class Student
        {
            public const string STUDENT_ID = "{studentId}";
            public const string STUDENTS = "students";
            public const string PROGRAMS = "students/{studentId}/studentProgramAssociations/programs";
            public const string STUDENT_ASSESSMENTS = "students/{studentId}/studentAssessments";
            public const string STUDENT_COHORT_ASSOCIATIONS = "students/{studentId}/studentCohortAssociations";
            public const string COURSE_TRANSCRIPTS = "students/{studentId}/courseTranscripts";
            public const string STUDENT_PARENT_ASSOCIATIONS = "students/{studentId}/studentParentAssociations";
            public const string STUDENT_DISCIPLINE_INCIDENT_ASSOCIATIONS = "students/{studentId}/studentDisciplineIncidentAssociations";
            public const string REPORT_CARDS = "students/{studentId}/reportCards";
            public const string PARENTS = "students/{studentId}/studentParentAssociations/parents";
            public const string STUDENT_PROGRAM_ASSOCIATIONS = "students/{studentId}/studentProgramAssociations";
            public const string STUDENT_SCHOOL_ASSOCIATIONS = "students/{studentId}/studentSchoolAssociations";
            public const string STUDENT_SECTION_ASSOCIATIONS = "students/{studentId}/studentSectionAssociations";
            public const string SECTIONS = "students/{studentId}/studentSectionAssociations/sections";
            public const string SCHOOLS = "students/{studentId}/studentSchoolAssociations/schools";
            public const string ASSESSMENTS = "students/{studentId}/studentAssessments/assessments";
            public const string ATTENDANCES = "students/{studentId}/attendances";
            public const string COURSES = "students/{studentId}/courseTranscripts/courses";
            public const string DISCIPLINE_INCIDENTS = "students/{studentId}/studentDisciplineIncidentAssociations/disciplineIncidents";
            public const string COHORTS = "students/{studentId}/studentCohortAssociations/cohorts";
            public const string STUDENT = "students/{studentId}";
            public const string CUSTOM = "students/{studentId}/custom";
        }

        public class Cohort
        {
            public const string COHORT_ID = "{cohortId}";
            public const string COHORTS = "cohorts";
            public const string CUSTOM = "cohorts/{cohortId}/custom";
        }

        public class Parent
        {
            public const string PARENT_ID = "{parentId}";
            public const string STUDENTS = "parents/{parentId}/studentParentAssociations/students";
        }

        public class Section
        {
            public const string SECTION_ID = "{sectionId}";
            public const string CUSTOM = "sections/{sectionId}/custom";
        }

        public class Assessment
        {
            public const string ASSESSMENT_ID = "{assessmentId}";
            public const string CUSTOM = "assessments/{assessmentId}/custom";
        }
    }
}
