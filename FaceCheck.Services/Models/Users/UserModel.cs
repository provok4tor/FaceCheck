using FaceCheck.Entity.Models;
namespace FaceCheck.Services.Models;
 public class UserModel:BaseModel
 {
     public Guid Id { get; set; }
    public string Name{get;set;}
     public string? Email{get; set;}
   
 }