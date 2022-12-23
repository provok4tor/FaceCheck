namespace TVprogram.Entity.Models;


public interface IBaseEntity
{
    Guid Id { get; set; }
    DateTime CreationTime { get; set; }
    DateTime ModificationTime { get; set; }

    bool IsNew();
    void Init();
}