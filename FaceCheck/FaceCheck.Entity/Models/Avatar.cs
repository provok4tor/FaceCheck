namespace FaceCheck.Entity.Models;
public class Avatar:BaseEntity
{
    
    public  User user {get; set;}
    public DateTime dateUpload {get; set;}
    public image avatar {get; set;}
}