using Service.Interfaces;

namespace Service.Services;

public class DistanceSolverService : IDistanceSolverService
{
    #region Fields
    private const double EarthRadius = 6371.0e3;
    private readonly IDistanceSolverService _distanceSolverService;
    #endregion
    #region Constructor
    public DistanceSolverService()
    {
    }
    #endregion

    #region Methods
    //1                                          //2
    public double DistanceCalculator(double instructorlat, double instructorlon, double studentlat, double studentlon)
    {
        studentlat = ToRadians(studentlat);
        studentlon = ToRadians(studentlon);
        instructorlat = ToRadians(instructorlat);
        instructorlon = ToRadians(instructorlon);

        double dLat = studentlat - instructorlat;
        double dLon = studentlon - instructorlon;

        // Haversine formula intermediate calculations
        double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                   Math.Cos(instructorlat) * Math.Cos(studentlat) * Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
        double c = 2 * Math.Asin(Math.Sqrt(a));

        return EarthRadius * c;
    }

    public bool InAcceptableRange(double studentdistance, double acceptableRange)
    {
        if (studentdistance <= acceptableRange)
            return true;
        return false;
    }

    public double ToRadians(double degrees)
    {
        return degrees * (Math.PI / 180);
    }
    #endregion
}
