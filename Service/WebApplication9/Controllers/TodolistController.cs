using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication9.Data.DTO;
using WebApplication9.Services;

namespace WebApplication9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodolistController : ControllerBase
    {
        private readonly TodolistService service;
        public TodolistController(TodolistService service)
        {
            this.service = service;
        }
        [Route("{id?}")]
        public ActionResult GetItems(int id = 0)//קבלה
        {
            if (id < 1)
            {
                List<Data.Entities.Item> result = service.Get();
                //service.GetData();
                return Ok(result);
            }
            Data.Entities.Item resultitem = service.GetItem(id);
            return Ok(resultitem);
        }
        //[Route("add")]
        [HttpPost]//הוספה   
        public ActionResult Post([FromBody] ItemDTO item)//get json from body of postman
        {
            bool ok = service.Add(item);//if we added tables then enterd to if and..
            if (ok)
            {
                return Created("", null);//return created code 201
            }
            return BadRequest();//or return bad request
        }
        [Route("{id}")]
        [HttpPut]//עדכון
        public ActionResult Put( int id,[FromBody]ItemDTO item)
        {
            
            ResponseDTO res = service.Update(id,item);//get answer with code and update
            if (res.Status == Data.DTO.StatusCode.Error)//if return to res status error 
            {
                return BadRequest(res);// return to client bad request with adapter status
            }
            else
            {
                return Ok(res);// return to client success request with return status from service
            }

        }
        [Route("{id}")]
        [HttpDelete]
        public ActionResult Delete(int id) 
        {
            ResponseDTO res = service.Delete(id);
            if (res.Status == Data.DTO.StatusCode.Error)
            {
                return BadRequest(res);
            }
            else
            {
                return Ok(res);
            }
        }
    }
}
