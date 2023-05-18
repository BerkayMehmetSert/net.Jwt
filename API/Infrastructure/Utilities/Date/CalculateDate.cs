namespace API.Infrastructure.Utilities.Date;

public static class CalculateDate
{
    public static DateTime GetCurrentDate()
    {
        return DateTime.UtcNow;
    }
}