namespace Lab2;

public static class Oil
{
    public static readonly List<int> TestWells = [-5, 5, 6, 9, 22, -41, -4, 23];

    public static double OptimalMainCanal(IEnumerable<int> wellVerticalCoordinates)
    {
        var avgVertical = wellVerticalCoordinates.Average();
        return avgVertical;
    }
}