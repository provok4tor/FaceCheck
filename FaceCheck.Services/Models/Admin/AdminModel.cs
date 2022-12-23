using FaceCheck.Entity.Models;
namespace FaceCheck.Services.Models;
 public class AdminModel:BaseModel
 {
   public Guid Id{get;set;}
     public string? Login{get; set;}
   
 }