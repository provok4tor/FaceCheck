namespace FaceCheck.Entity.Models;
public class Chat:BaseEntity
{
   
    public virtual User us1 {get; set;}
    public virtual User us2 {get; set;}
    
}