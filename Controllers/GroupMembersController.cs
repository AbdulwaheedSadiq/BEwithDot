using System;
using System.Collections.Generic;
using System.Linq;
using Boats.Data;
using fishers.Models;
using fishers.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fishers.Controllers{

[ApiController]
[Route("Api/GroupMembers")]
    public class GroupMembersController:ControllerBase{
        private readonly ApplicationDbContext dbContextRepo;

    public GroupMembersController(ApplicationDbContext dbContext){
        dbContextRepo = dbContext;
    }

[HttpPost]
    public ActionResult<GroupMembersRequest> insert(GroupMembersRequest groupMembers) {
        try{
            GroupMembers g = new GroupMembers();
            g.GroupMembersFirstName = groupMembers.GroupMembersFirstName;
            g.GroupMembersMiddleName = groupMembers.GroupMembersMiddleName;
            g.GroupMembersLastName = groupMembers.GroupMembersLastName;
            g.gender = groupMembers.gender;
            g.GroupMembersPosition = groupMembers.GroupMembersPosition;
            g.GroupMembersZMANumber = groupMembers.GroupMembersZMANumber;
            g.FisherMansGroupId = groupMembers.FisherMansGroupId;

            dbContextRepo.fisherMansGroupMembers.Add(g);
            dbContextRepo.SaveChanges();

            GroupMembersResponse response = new GroupMembersResponse();
            response.GroupMembersFirstName = g.GroupMembersFirstName;
            response.GroupMembersMiddleName = g.GroupMembersMiddleName;
            response.GroupMembersLastName = g.GroupMembersLastName;
            response.gender = g.gender;
            response.GroupMembersPosition = g.GroupMembersPosition;
            response.GroupMembersZMANumber = g.GroupMembersZMANumber;

            return Ok(response);
    }catch(Exception){
        return StatusCode(500,"Ooops something went wrong");
    }
    
    }

[HttpGet]
public ActionResult<GroupMembersResponse> findAll() { 
    try{
    List<GroupMembers> gr = dbContextRepo.fisherMansGroupMembers.ToList();

    List<GroupMembersResponse> groupMembersResponses = new List<GroupMembersResponse>();
    foreach(GroupMembers g in gr){
          GroupMembersResponse response = new GroupMembersResponse();
            response.GroupMembersFirstName = g.GroupMembersFirstName;
            response.GroupMembersMiddleName = g.GroupMembersMiddleName;
            response.GroupMembersLastName = g.GroupMembersLastName;
            response.gender = g.gender;
            response.GroupMembersPosition = g.GroupMembersPosition;
            response.GroupMembersZMANumber = g.GroupMembersZMANumber;
        
            groupMembersResponses.Add(response);
    }


    return Ok(groupMembersResponses);
    }catch(Exception){
        return StatusCode(500,"Opps something went wrong");
    }


 }

 [HttpGet("{id}")]
 public ActionResult<GroupMembersResponse> getById(int id){
    try{
    var member = dbContextRepo.fisherMansGroupMembers.FirstOrDefault(x => x.GroupMembersId == id);

    if(member == null){
        return StatusCode(404,"A member is not found");
    }
        GroupMembersResponse response = new GroupMembersResponse();
            response.GroupMembersFirstName = member.GroupMembersFirstName;
            response.GroupMembersMiddleName = member.GroupMembersMiddleName;
            response.GroupMembersLastName = member.GroupMembersLastName;
            response.gender = member.gender;
            response.GroupMembersPosition = member.GroupMembersPosition;
            response.GroupMembersZMANumber = member.GroupMembersZMANumber;

            return Ok(response);
    }catch(Exception){
        return StatusCode(500,"something is went wrong");
    }
 }


    [HttpPut("{id}")]
    public ActionResult<GroupMembersResponse> update(int id,GroupMembersRequest groupMembers) { 
        try{
    var member = dbContextRepo.fisherMansGroupMembers.FirstOrDefault(x => x.GroupMembersId == id);

    if(member == null){
        return StatusCode(404,"A member is not found");
    }
            member.GroupMembersFirstName = groupMembers.GroupMembersFirstName;
            member.GroupMembersMiddleName = groupMembers.GroupMembersMiddleName;
            member.GroupMembersLastName = groupMembers.GroupMembersLastName;
            member.gender = groupMembers.gender;
            member.GroupMembersPosition = groupMembers.GroupMembersPosition;
            member.GroupMembersZMANumber = groupMembers.GroupMembersZMANumber;
            member.FisherMansGroupId = groupMembers.FisherMansGroupId;

            dbContextRepo.Entry(member).State = EntityState.Modified;
            dbContextRepo.SaveChanges();


        GroupMembersResponse response = new GroupMembersResponse();
            response.GroupMembersFirstName = member.GroupMembersFirstName;
            response.GroupMembersMiddleName = member.GroupMembersMiddleName;
            response.GroupMembersLastName = member.GroupMembersLastName;
            response.gender = member.gender;
            response.GroupMembersPosition = member.GroupMembersPosition;
            response.GroupMembersZMANumber = member.GroupMembersZMANumber;

            return Ok(response);
    }catch(Exception){
        return StatusCode(500,"something is went wrong");
    }
     }

     [HttpDelete("{id}")]
     public ActionResult delete(int id) { 
         try{
    var member = dbContextRepo.fisherMansGroupMembers.FirstOrDefault(x => x.GroupMembersId == id);

    if(member == null){
        return StatusCode(404,"A member is not found");
    }

        dbContextRepo.Entry(member).State = EntityState.Deleted;
        dbContextRepo.SaveChanges();

    

      }catch(Exception){
        StatusCode(500,"SomeThing Whent Wrong");
      }
         return Ok();
    }
    }
}