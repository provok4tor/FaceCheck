namespace FaceCheck.Entity.Models;
public class UserComplaint:BaseEntity
{
    public  User us {get; set;}
    public string cause {get; set;}
}