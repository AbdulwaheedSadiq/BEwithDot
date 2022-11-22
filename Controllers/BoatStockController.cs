using System;
using System.Collections.Generic;
using System.Linq;
using boats.Models;
using boats.ViewModel;
using Boats.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace boats.Controllers{
    [ApiController]
    [Route("Api/BoatStock")]
    public class BoatStockController : ControllerBase{

        private readonly ApplicationDbContext dbContextRepo;

        public BoatStockController(ApplicationDbContext dbContext){
            dbContextRepo = dbContext;
        }

//get
        [HttpGet]
        public ActionResult<List<BoatStockResponse>> getBoatStock(){

            List<BoatStock> bt = dbContextRepo.boatStock.ToList();

            List<BoatStockResponse> response = new List<BoatStockResponse>();
            foreach(BoatStock bs in bt){
                BoatStockResponse resp = new BoatStockResponse();
                resp.boatLength  = bs.boatLength;
                 resp.boatPrice = bs.boatPrice;
                resp.lifeJacket = bs.lifeJacket;
                resp.type=bs.type;
                resp.sneg = bs.sneg;
                resp.sneb = bs.sneb;
                resp.status = bs.status;
                resp.noAnchor = bs.noAnchor;
                resp.noOfRope  = bs.noOfRope;
                response.Add(resp);
            }
         return Ok(response);

    }

    [HttpPost]
    public ActionResult<BoatStockRequest> insert(BoatStockRequest boatStock){
        try{
        BoatStock bt = new BoatStock();
        bt.boatLength = boatStock.boatLength;
                bt.boatPrice = boatStock.boatPrice;
                bt.lifeJacket = boatStock.lifeJacket;
                bt.type=boatStock.type;
                bt.sneg = boatStock.sneg;
                bt.sneb = boatStock.sneb;
                bt.status = boatStock.status;
                bt.noAnchor = boatStock.noAnchor;
                bt.noOfRope  = boatStock.noOfRope;
        
        dbContextRepo.boatStock.Add(bt);
        dbContextRepo.SaveChanges();
        }catch(Exception){
            return StatusCode(500,"...SomeThing is Wrong");
        }
        return Ok(boatStock);
    }

    [HttpGet("{id}")]
    public ActionResult<BoatStockResponse> getById(int id) { 
        var bt = dbContextRepo.boatStock.FirstOrDefault(x => x.BoatStockId == id);
        try{
            if(bt == null){
                return StatusCode(404,"BoatStock Not Found");
            }

            BoatStockResponse response = new BoatStockResponse();
               response.boatLength = bt.boatLength;
                response.boatPrice = bt.boatPrice;
                response.lifeJacket = bt.lifeJacket;
                response.type=bt.type;
                response.sneg = bt.sneg;
                response.sneb = bt.sneb;
                response.status = bt.status;
                response.noAnchor = bt.noAnchor;
                response.noOfRope  = bt.noOfRope;
                response.Response = "Fetching SuccessFull";
             return response;
             

        }catch{
            return StatusCode(500,"...Oops SomeThing Is Wrong");
        }
     }

     [HttpPut("{id}")]
     public ActionResult<BoatStockResponse> update(int id,BoatStockRequest boatStock) { 
        var bt = dbContextRepo.boatStock.FirstOrDefault(x=> x.BoatStockId == id);
        try{
            if (bt==null){
            return StatusCode(404,"user NotFound");
            }
                bt.boatLength = boatStock.boatLength;
                bt.boatPrice = boatStock.boatPrice;
                bt.lifeJacket = boatStock.lifeJacket;
                bt.type=boatStock.type;
                bt.sneg = boatStock.sneg;
                bt.sneb = boatStock.sneb;
                bt.status = boatStock.status;
                bt.noAnchor = boatStock.noAnchor;
                bt.noOfRope  = boatStock.noOfRope;

                dbContextRepo.Entry(bt).State = EntityState.Modified;
                dbContextRepo.SaveChanges();
        }catch{
            return StatusCode(500,"something is wrong");
        }
         BoatStockResponse response = new BoatStockResponse();
               response.boatLength = bt.boatLength;
                response.boatPrice = bt.boatPrice;
                response.lifeJacket = bt.lifeJacket;
                response.type=bt.type;
                response.sneg = bt.sneg;
                response.sneb = bt.sneb;
                response.status = bt.status;
                response.noAnchor = bt.noAnchor;
                response.noOfRope  = bt.noOfRope;
                response.Response = "Updated SuccessFull";

        return Ok(response);
      }

      [HttpDelete("{id}")]
      public ActionResult delete(int id) { 
        try{
            var bt = dbContextRepo.boatStock.FirstOrDefault(x => x.BoatStockId==id);
            if(bt==null){
                return StatusCode(404,"Boat Is Not Found");
            }
            dbContextRepo.Entry(bt).State = EntityState.Deleted;
            dbContextRepo.SaveChanges();
        }catch(Exception){
            return StatusCode(500,"Not Deleted");
        }
        return Ok();
       }
}
}