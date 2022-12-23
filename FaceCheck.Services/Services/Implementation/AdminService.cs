using AutoMapper;
using FaceCheck.Entity.Models;
using FaceCheck.Repository;
using FaceCheck.Services.Abstract;
using FaceCheck.Services.Models;

namespace FaceCheck.Services.Implementation;

public class AdminService :IAdminService
{
    private readonly IRepository<Admin> adminRepository;
    private readonly IMapper mapper;
    public AdminService(IRepository<Admin> adminRepository, IMapper mapper)
    {
        this.adminRepository=adminRepository;
        this.mapper = mapper;
    }

    public void DeleteAdmin(Guid id)
    {
        var adminToDelete =adminRepository.GetById(id);
        if (adminToDelete == null)
        {
            throw new Exception("Admin not found");
        }
        adminRepository.Delete(adminToDelete);
    }

    public AdminModel GetAdmin(Guid id)
    {
        var admin =adminRepository.GetById(id);
        return mapper.Map<AdminModel>(admin);
    }

    public PageModel<AdminPreviewModel> GetAdmins(int limit = 20, int offset = 0)
    {
        var admin =adminRepository.GetAll();
        int totalCount =admin.Count();
        var chunk=admin.OrderBy(x=>x.Login).Skip(offset).Take(limit);

        return new PageModel<AdminPreviewModel>()
        {
            Items = mapper.Map<IEnumerable<AdminPreviewModel>>(admin),
            TotalCount = totalCount
        };
    }

    public AdminModel UpdateAdmin(Guid id, UpdateAdminModel admin)
    {
        var existingAdmin = adminRepository.GetById(id);
        if (existingAdmin == null)
        {
            throw new Exception("Admin not found");
        }
        existingAdmin.Login=admin.Login;
        existingAdmin = adminRepository.Save(existingAdmin);
        return mapper.Map<AdminModel>(existingAdmin);
    }
    public AdminModel CreateAdmin(AdminModel adminModel)
    {
      if(adminRepository.GetAll(x=>x.Id==adminModel.Id).FirstOrDefault()!=null)
       {
        throw new Exception ("Attempt to create a non-unique object!");
       }
       AdminModel create=new AdminModel();
       create.Login=adminModel.Login;
       adminRepository.Save(mapper.Map<Entity.Models.Admin>(create));
       return create;

    }
}