namespace Service.Interfaces;

public interface IDistanceSolverService
{
    double DistanceCalculator(double studentlat, double studentlon, double instructorlat, double instructorlon);
    double ToRadians(double degrees);
    bool InAcceptableRange(double studentdistance, double acceptableRange);

}

