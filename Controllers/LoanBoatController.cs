using System;
using System.Collections.Generic;
using System.Linq;
using BoatPayments.Models;
using boats.Models;
using Boats.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace loans{
    [ApiController]
    [Route("Api/loanBoat")]
    public class LoanBoatController : ControllerBase{
        private readonly ApplicationDbContext dbContextrepo;

        public LoanBoatController(ApplicationDbContext dbContext){
            dbContextrepo = dbContext;
        }

    [HttpPost]
    public ActionResult<LoanBoatResponse> insert(LoanBoatRequest loanBoat) { 
        try{

           var boatStock = dbContextrepo.boatStock.Find(loanBoat.BoatStockId);
           var gr = dbContextrepo.boatStock.Find(loanBoat.BoatStockId);
           if(boatStock == null){
                return StatusCode(404,"cannot find boat Stock id");
           }else{

                var cr = boatStock.boatPrice;

                  var today = System.DateTime.Now;
            LoanBoat l = new LoanBoat();
            l.attachment = loanBoat.attachment;
            l.BoatCodeNumbergenerated = "123default";
            l.status = "hired";
            l.date = today;
            l.HiredBy = "waheedUsername";
            l.CreditCost = cr;
            l.BoatStockId = loanBoat.BoatStockId;
            l.FisherMansGroupId = loanBoat.FisherMansGroupId;

            dbContextrepo.Add(l);
            dbContextrepo.SaveChanges();


            Payment p = new Payment();
            p.ammountCredited = cr;
            p.ammountdebited = 0;
            p.Status = 0;
            p.Paidby = "waheedUserName";
            p.BoatStockId=loanBoat.BoatStockId;
            p.FisherMansGroupId = loanBoat.FisherMansGroupId;

            dbContextrepo.payments.Add(p);
            dbContextrepo.SaveChanges();


            LoanBoatResponse response = new LoanBoatResponse();
            response.attachment = l.attachment;
            response.BoatCodeNumbergenerated = l.BoatCodeNumbergenerated;
            response.status = l.status;
            response.date = l.date;
            response.HiredBy = l.HiredBy;
            response.CreditCost=l.CreditCost;
            response.BoatStock = l.BoatStock;
            response.FisherMansGroup = l.FisherMansGroup;
            
            return Ok(response);
           }
        }catch (Exception){
            return StatusCode(500,"Something is wrong");
        }
        
    }

[HttpGet]
    public ActionResult<List<LoanBoatResponse>> getAll() { 

            List<LoanBoat> loanBoats = dbContextrepo.loanBoats
            .Include(x=>x.BoatStock)
            .Include(x=>x.FisherMansGroup)
            .ToList();

            List<LoanBoatResponse> response = new List<LoanBoatResponse>();
            foreach(LoanBoat l in loanBoats){  
            LoanBoatResponse res = new LoanBoatResponse();
            res.attachment = l.attachment;
            res.BoatCodeNumbergenerated = l.BoatCodeNumbergenerated;
            res.status = l.status;
            res.date = l.date;
            res.HiredBy = l.HiredBy;
            res.CreditCost=l.CreditCost;
            res.BoatStock = l.BoatStock;
            res.FisherMansGroup = l.FisherMansGroup;
            response.Add(res);
            }
            return Ok(response);
    
        
     }

[HttpGet("{id}")]
     public ActionResult<LoanBoatResponse> getById(int id) { 
        try{
        var l = dbContextrepo.loanBoats.FirstOrDefault(x=> x.LoanBoatId == id);
         if(l == null){
            return StatusCode(404,"Not Found");
         }
         LoanBoatResponse res = new LoanBoatResponse();
            res.attachment = l.attachment;
            res.BoatCodeNumbergenerated = l.BoatCodeNumbergenerated;
            res.status = l.status;
            res.date = l.date;
            res.HiredBy = l.HiredBy;
            res.CreditCost=l.CreditCost;
            res.BoatStock = l.BoatStock;
            res.FisherMansGroup = l.FisherMansGroup;

            return Ok(res);

        }catch(Exception){
            return StatusCode(500,"something is Wrong");
        }

      }

[HttpPut("{id}")]
      public ActionResult<LoanBoatResponse> update(int id,LoanBoatRequest loan) { 
           try{
        var l = dbContextrepo.loanBoats.FirstOrDefault(x=> x.LoanBoatId == id);
         if(l == null){
            return StatusCode(404,"Not Found");
         }

        l.attachment = loan.attachment;


         LoanBoatResponse res = new LoanBoatResponse();
            res.attachment = l.attachment;
            res.BoatCodeNumbergenerated = l.BoatCodeNumbergenerated;
            res.status = l.status;
            res.date = l.date;
            res.HiredBy = l.HiredBy;
            res.CreditCost=l.CreditCost;
            res.BoatStock = l.BoatStock;
            res.FisherMansGroup = l.FisherMansGroup;

            return Ok(res);

        }catch(Exception){
            return StatusCode(500,"something is Wrong");
        }

       }


    }
}