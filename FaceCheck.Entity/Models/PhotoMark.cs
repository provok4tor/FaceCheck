namespace FaceCheck.Entity.Models;
public class PhotoMark:BaseEntity
{
   
    public  Photo photo {get; set;}
    public  User user {get; set;}

    public int mark {get; set;}
}