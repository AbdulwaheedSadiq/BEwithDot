using System;
using System.Collections.Generic;
using System.Linq;
using auth;
using Boats.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using users.ViewModels;
using Users.Models;
using Users.ViewModels;

namespace Users.Controller{
    [ApiController]
    [Route("Api/Suppliers")]
    public class SuppliersController : ControllerBase{
        private readonly ApplicationDbContext dbContextRepo;
        public SuppliersController(ApplicationDbContext dbContext){
            dbContextRepo = dbContext;
        }

        [HttpPost]
        public ActionResult<SupplierResponse> insert(SupplierRequest supplier) { 
             try{
           //insert Login     
            Login login = new Login();
            login.UserName = supplier.email;
            login.passwords = "123";
            login.status = 1;
            login.RolesId = 1;

            dbContextRepo.logins.Add(login);
            dbContextRepo.SaveChanges();


            Supplier s = new Supplier();
           s.FirstName = supplier.FirstName;
           s.MiddleName= supplier.MiddleName;
           s.LastName = supplier.LastName;
           s.Dob = supplier.Dob;
           s.email = supplier.email;
           s.gender = supplier.gender;
           s.fromWhere = supplier.fromWhere;
           s.SupplierCode = supplier.SupplierCode;
           s.physicalAddress = supplier.physicalAddress;
           s.phoneNumber = supplier.phoneNumber;
           s.nationality = supplier.nationality;
           s.LoginId = login.LoginId;
           s.Login = login;

            dbContextRepo.suppliers.Add(s);
            dbContextRepo.SaveChanges();

            SupplierResponse response = new SupplierResponse();
            response.FirstName = s.FirstName;
           response.MiddleName= s.MiddleName;
           response.LastName = s.LastName;
           response.Dob = s.Dob;
           response.email = s.email;
           response.gender = s.gender;
           response.fromWhere = s.fromWhere;
           response.SupplierCode = s.SupplierCode;
           response.physicalAddress = s.physicalAddress;
           response.phoneNumber = s.phoneNumber;
           response.nationality =s.nationality;
           response.Login = s.Login;

            return Ok(response);
    }catch(Exception){
        return StatusCode(500,"Ooops something went wrong");
    }
         }

         [HttpGet]
         public ActionResult<SupplierResponse> findAll() { 
    try{
    List<Supplier> sl = dbContextRepo.suppliers.ToList();

    List<SupplierResponse> supplierResponses = new List<SupplierResponse>();
    foreach(Supplier s in sl){
          SupplierResponse response = new SupplierResponse();
            response.FirstName = s.FirstName;
           response.MiddleName= s.MiddleName;
           response.LastName = s.LastName;
           response.Dob = s.Dob;
           response.email = s.email;
           response.gender = s.gender;
           response.fromWhere = s.fromWhere;
           response.SupplierCode = s.SupplierCode;
           response.physicalAddress = s.physicalAddress;
           response.phoneNumber = s.phoneNumber;
           response.nationality =s.nationality;
        
          supplierResponses.Add(response);
    }
            return Ok(supplierResponses);
    }catch(Exception){
        return StatusCode(500,"Opps something went wrong");
    }


 }


 [HttpGet("{id}")]
 public ActionResult<SupplierResponse> getById(int id){
    try{
    var s = dbContextRepo.suppliers.FirstOrDefault(x => x.SupplierId == id);

    if(s == null){
        return StatusCode(404,"A member is not found");
    }
        SupplierResponse response = new SupplierResponse();
              response.FirstName = s.FirstName;
           response.MiddleName= s.MiddleName;
           response.LastName = s.LastName;
           response.Dob = s.Dob;
           response.email = s.email;
           response.gender = s.gender;
           response.fromWhere = s.fromWhere;
           response.SupplierCode = s.SupplierCode;
           response.physicalAddress = s.physicalAddress;
           response.phoneNumber = s.phoneNumber;
           response.nationality =s.nationality;

            return Ok(response);
    }catch(Exception){
        return StatusCode(500,"something is went wrong");
    }
 }

  [HttpPut("{id}")]
    public ActionResult<SupplierResponse> update(int id,SupplierRequest supplier) { 
        try{
    var s = dbContextRepo.suppliers.FirstOrDefault(x => x.SupplierId == id);

    if(s == null){
        return StatusCode(404,"A member is not found");
    }
           s.FirstName = supplier.FirstName;
           s.MiddleName= supplier.MiddleName;
           s.LastName = supplier.LastName;
           s.Dob = supplier.Dob;
           s.email = supplier.email;
           s.gender = supplier.gender;
           s.fromWhere = supplier.fromWhere;
           s.SupplierCode = supplier.SupplierCode;
           s.physicalAddress = supplier.physicalAddress;
           s.phoneNumber = supplier.phoneNumber;
           s.nationality = supplier.nationality;



            dbContextRepo.Entry(s).State = EntityState.Modified;
            dbContextRepo.SaveChanges();


   SupplierResponse response = new SupplierResponse();
              response.FirstName = s.FirstName;
           response.MiddleName= s.MiddleName;
           response.LastName = s.LastName;
           response.Dob = s.Dob;
           response.email = s.email;
           response.gender = s.gender;
           response.fromWhere = s.fromWhere;
           response.SupplierCode = s.SupplierCode;
           response.physicalAddress = s.physicalAddress;
           response.phoneNumber = s.phoneNumber;
           response.nationality =s.nationality;

            return Ok(response);
    }catch(Exception){
        return StatusCode(500,"something is went wrong");
    }
     }

        
    }
}