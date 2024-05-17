namespace Data.MetaData;

public static class Router
{
    public const string RouteName = "Api";
    public const string Version = "V0.1";
    public const string Rule = RouteName + "/" + Version + "/";


    public static class LocationRouting
    {
        public const string Prefix = Rule + "Locations";
        public const string AddLocation = Prefix;
        public const string GetLocations = Prefix;
        public const string GetLocation = Prefix;
        public const string DeleteLocation = Prefix;
        public const string UpdateLocation = Prefix + "/{locationId}";
    }
    public static class AttendanceSessionRouting
    {
        public const string Prefix = Rule + "instructors/{instructorId}/courses/{courseId}/Sessions";
        public const string AddSession = Prefix + "/addsession";
        public const string GetSession = Prefix + "/{sessionId}";
        public const string GetSessions = Rule + "courses/{courseId}/Sessions/List";
    }
    public static class AttendnaceRecordRouting
    {
        public const string Prefix = Rule + "students/{studentId}/sessions/{sessionId}/Records";
        public const string MarkAttendnace = Prefix + "/mark";
    }

}
