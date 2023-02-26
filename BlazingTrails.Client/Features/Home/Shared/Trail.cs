namespace BlazingTrails.Client.Features.Home.Shared;

public class Trail
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public string Image { get; set; } = "";
    public string Location { get; set; } = "";
    public int TimeInMinutes { get; set; }
    public string TimeFormatted => $"{TimeInMinutes / 60}h {TimeInMinutes % 60}m";
    public int Length { get; set; }
    public IEnumerable<RouteInstructions> Route { get; set; } = Array.Empty<RouteInstructions>();
}

public class RouteInstructions
{
    public int Stage { get; set; }
    public string Description { get; set; } = "";
}
