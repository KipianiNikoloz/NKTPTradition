using System.Collections.ObjectModel;
using Core.Entities.Base;

namespace Core.Entities;

public class Region: BaseEntity
{
    public string Name { get; set; }
    public Collection<Tradition> Traditions { get; set; }
}