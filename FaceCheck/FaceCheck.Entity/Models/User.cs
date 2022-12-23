namespace FaceCheck.Entity.Models;
public class AccessLevel:BaseEntity
{
   public  AccessLevel AccessLevel{get; set;}
   public string number {get; set;}
   public image avatar {get; set;}//класс картинки
    public string describe {get; set;}
    public string city {get; set;}


    #region BaseEntity

    public DateTime CreationTime { get; set; }
    public DateTime ModificationTime { get; set; }

    public bool IsNew()
    {
        return Id == Guid.Empty;
    }

    public void Init()
    {
        Id = Guid.NewGuid();
        CreationTime = DateTime.UtcNow;
        ModificationTime = DateTime.UtcNow;
    }

    #endregion

}