using System;
using System.Collections.Generic;
using System.Linq;
using BoatPayments.Models;
using Boats.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BoatPayments{
[ApiController]
[Route("Api/Payments")]
    public class PaymentController : ControllerBase{
        
        private readonly ApplicationDbContext dbContextRepo;

        public PaymentController(ApplicationDbContext dbContext){
            dbContextRepo = dbContext;
        }

    [HttpGet]
    public ActionResult<List<PaymentDto>> getAll() { 
        List<Payment> py = dbContextRepo.payments
        .Include(x => x.BoatStock)
        .Include(x=> x.FisherMansGroup)
        .ToList();

        List<PaymentDto> res = new List<PaymentDto>();
        foreach(Payment p in py){
            PaymentDto r = new PaymentDto();
            r.ammountCredited = p.ammountCredited;
            r.ammountdebited = p.ammountdebited;
            r.Status= p.Status;
            r.Paidby = p.Paidby;
            r.BoatStock = p.BoatStock;
            r.FisherMansGroup = p.FisherMansGroup;
            res.Add(r);
        }
        return(res);
     }

[HttpGet("{id}")]
     public ActionResult<PaymentDto> getById(int id) { 
        try{
        var p = dbContextRepo.payments.FirstOrDefault(x => x.PaymentId == id);
        if (p == null){
            StatusCode(404,"No Payments Data Found");
        }
          PaymentDto r = new PaymentDto();
            r.ammountCredited = p.ammountCredited;
            r.ammountdebited = p.ammountdebited;
            r.Status= p.Status;
            r.Paidby = p.Paidby;
            r.BoatStock = p.BoatStock;
            r.FisherMansGroup = p.FisherMansGroup;

            return Ok(r);
        }catch(Exception){
            return StatusCode(500,"something is wrong");
        }
      }

      [HttpPut("{id}")]
      public ActionResult<PaymentDto> update(int id,PaymentRequest paymentDto) { 
        try{
        var p = dbContextRepo.payments.FirstOrDefault(x => x.PaymentId == id);
        if (p == null){
            StatusCode(404,"No Payments Data Found");
        }

        p.ammountdebited = paymentDto.ammountdebited;
        p.Paidby = paymentDto.Paidby;
        dbContextRepo.Entry(p).State = EntityState.Modified;
        dbContextRepo.SaveChanges();


          PaymentDto r = new PaymentDto();
            r.ammountCredited = p.ammountCredited;
            r.ammountdebited = p.ammountdebited;
            r.Status= p.Status;
            r.Paidby = p.Paidby;
            r.BoatStock = p.BoatStock;
            r.FisherMansGroup = p.FisherMansGroup;

            return Ok(r);
        }catch(Exception){
            return StatusCode(500,"something is wrong");
        }

       }


    }
}