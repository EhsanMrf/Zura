namespace Zura.Domain.Common;

public abstract class BaseEntity<T> where T : struct
{
    public T Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }

    protected void Creating()
    {
        CreatedAt= DateTime.Now;
    }
    protected void Updating()
    {
        UpdatedAt= DateTime.Now;
    }

    public void Deleted()
    {
        IsDeleted=true;
    }
}