namespace API.DTO;

public class UpdateHotelDto
{
    public string Name { get; set; }
    public string Location { get; set; }
    public int Price { get; set; }
    
    public int Stars { get; set; }
}