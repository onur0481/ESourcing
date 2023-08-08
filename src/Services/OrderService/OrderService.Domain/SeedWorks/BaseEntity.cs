namespace OrderService.Domain.SeedWorks;

public abstract class BaseEntity
{
    public int ID { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public BaseEntity Clone()
    {
        return (BaseEntity)this.MemberwiseClone(); 
    }
}
