using System.ComponentModel.DataAnnotations;
using Core.Entities.Base;

namespace Core.Entities;

public class Hotel: BaseEntity
{
    public string Name { get; set; }
    public string Location { get; set; }
    public int Price { get; set; }
    
    [Range(1, 5)]
    public int Stars { get; set; }
}