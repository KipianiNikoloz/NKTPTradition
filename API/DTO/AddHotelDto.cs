namespace API.DTO;

public class AddHotelDto
{
    public string Name { get; set; }
    public string Location { get; set; }
    public int Price { get; set; }
    
    public int Stars { get; set; }
}