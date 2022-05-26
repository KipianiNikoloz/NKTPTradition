using Core.Entities.Base;

namespace Core.Entities;

public class Tradition: BaseEntity
{
    public string Name { get; set; }
    public string Text { get; set; }
    public DateTime PublishDate { get; set; }
    
    public int RegionId { get; set; }
    public Region Region { get; set; }
}