namespace Zura.Application.Common;

internal abstract class BaseEntity<T> where T : struct
{

    public T Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
}