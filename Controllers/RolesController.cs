using System;
using System.Collections.Generic;
using System.Linq;
using Boats.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace auth{
    [ApiController]
    [Route("Api/Roles")]
    public class RolesControllers : ControllerBase{
        private readonly ApplicationDbContext dbContextRepo;
        public RolesControllers(ApplicationDbContext dbContext){
            dbContextRepo  = dbContext;
        }

[HttpPost]
    public ActionResult<RoleDto> insert(RoleDto role) {
        try{
            Roles rol = new Roles();
            rol.RoleName = role.RoleName;
            dbContextRepo.roles.Add(rol);
            dbContextRepo.SaveChanges();

            RoleDto res = new RoleDto();
            res.RoleName = rol.RoleName;
            return Ok(res);
        }catch(Exception){
            return StatusCode(500,"something went wrong");
        }

     }

     [HttpGet]
     public ActionResult<List<RoleDto>> findAll() { 
        try{
            List<Roles> role = dbContextRepo.roles.ToList();

            List<RoleDto> response = new List<RoleDto>();
            foreach(Roles r in role){
                RoleDto ro = new RoleDto();
                ro.RoleName = r.RoleName;
                response.Add(ro);
            }
        return Ok(response);

        }catch(Exception){
            return StatusCode(500,"something went wrong");
        }
      }

      [HttpGet("{id}")]
      public ActionResult<RoleDto> getById(int id) { 
        try{
        var role = dbContextRepo.roles.FirstOrDefault(x => x.RolesId == id);

        if (role == null){
            return StatusCode(404,"Role Not found");
        }
         RoleDto res = new RoleDto();
            res.RoleName = role.RoleName;
            return Ok(res);

        }catch(Exception){
            return StatusCode(500,"Something Went wrong");
        }
       }

       [HttpPut("{id}")]
       public ActionResult<Roles> update(int id,RoleDto roleDto) { 
         try{
        var role = dbContextRepo.roles.FirstOrDefault(x => x.RolesId == id);

        if (role == null){
            return StatusCode(404,"Role Not found");
        }
        role.RoleName = roleDto.RoleName;
        dbContextRepo.Entry(role).State = EntityState.Modified;

         RoleDto res = new RoleDto();
            res.RoleName = role.RoleName;
            return Ok(res);

        }catch(Exception){
            return StatusCode(500,"Something Went wrong");
        }
        }

    }
}
