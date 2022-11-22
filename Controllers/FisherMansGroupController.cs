using System;
using System.Collections.Generic;
using System.Linq;
using Boats.Data;
using fishers.Models;
using fishers.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fishers
{

    [ApiController]
    [Route("Api/FishermansGroup")]
    public class FisherMansGroupControler : ControllerBase{
        private readonly ApplicationDbContext dbContextRepo;

        public FisherMansGroupControler(ApplicationDbContext dbContext){
            dbContextRepo = dbContext;
        }

        [HttpPost]
        public ActionResult<FisherMansGroupResponse> insert(FisherMansGroupReq req) {
            try{
            FisherMansGroup fg = new FisherMansGroup();
            fg.crewName = req.crewName;
            fg.attachments = req.attachments;
            fg.district =req.district;
            fg.physicalAddress = req.physicalAddress;
            fg.region = req.region;
            fg.location = req.location;

            dbContextRepo.fisherMansgroup.Add(fg);
            dbContextRepo.SaveChanges();

//response
             FisherMansGroupResponse rep = new FisherMansGroupResponse();
            rep.crewName = fg.crewName;
            rep.attachments = fg.attachments;
            rep.district =fg.district;
            rep.physicalAddress = fg.physicalAddress;
            rep.region = fg.region;
            rep.location = fg.location;

             return Ok(rep);
            }catch(Exception){
                return StatusCode(500,"Ooops...Something Is Wrong");
            }
         }


        [HttpGet]
         public ActionResult<List<FisherMansGroupResponse>> getAllGroups() { 
            try{
            List<FisherMansGroup> fg = dbContextRepo.fisherMansgroup.ToList();

            List<FisherMansGroupResponse> response = new List<FisherMansGroupResponse>();
            foreach(FisherMansGroup fs in fg){
                FisherMansGroupResponse rep = new FisherMansGroupResponse();
                rep.crewName = fs.crewName;
                rep.attachments = fs.attachments;
                rep.district =fs.district;
                rep.physicalAddress = fs.physicalAddress;
                rep.region = fs.region;
                rep.location = fs.location;
                response.Add(rep);
            }

            return Ok(response);

            }catch(Exception){
                return StatusCode(500,"....Oops Something is wrong");
            }
          }

          [HttpGet("{id}")]
          public ActionResult<FisherMansGroupResponse> getById(int id) { 
            try{
            var fs = dbContextRepo.fisherMansgroup.FirstOrDefault(x => x.id == id);

            if (fs == null){
                return StatusCode(404,"Fishermansgroup Is Not Found");
            }

                FisherMansGroupResponse rep = new FisherMansGroupResponse();
                rep.crewName = fs.crewName;
                rep.attachments = fs.attachments;
                rep.district =fs.district;
                rep.physicalAddress = fs.physicalAddress;
                rep.region = fs.region;
                rep.location = fs.location;
               
               return Ok(rep);

            }catch(Exception){
                return StatusCode(500,"Opps...Something Is wrong");
            }

           }


           [HttpPut("{id}")]
           public ActionResult<FisherMansGroupResponse> update(int id,FisherMansGroupReq req) { 
            
            try{
                var fs = dbContextRepo.fisherMansgroup.FirstOrDefault(x => x.id == id);

                if (fs == null){
                return StatusCode(404,"Fishermansgroup Is Not Found");
            }

                fs.crewName = req.crewName;
                fs.attachments = req.attachments;
                fs.district =req.district;
                fs.physicalAddress = req.physicalAddress;
                fs.region = req.region;
                fs.location = req.location;

                dbContextRepo.Entry(fs).State = EntityState.Modified;
                dbContextRepo.SaveChanges();

                FisherMansGroupResponse rep = new FisherMansGroupResponse();
                rep.crewName = fs.crewName;
                rep.attachments = fs.attachments;
                rep.district =fs.district;
                rep.physicalAddress = fs.physicalAddress;
                rep.region = fs.region;
                rep.location = fs.location;

                return Ok(rep);
            }catch(Exception){
                return StatusCode(500,"Oppps..Something Is Wrong");
            }
            }

            [HttpDelete("{id}")]
            public ActionResult delete(int id) { 
                try{
                    var fs = dbContextRepo.fisherMansgroup.FirstOrDefault(x => x.id == id);

                    if(fs == null){
                        return StatusCode(404,"Group Is Not Found");
                    }

                    dbContextRepo.Entry(fs).State = EntityState.Deleted;
                    dbContextRepo.SaveChanges();
                    return Ok();
                }catch(Exception){
                    return StatusCode(500,"Opps...someThing Is Wrong");
                }
             }
    }
}