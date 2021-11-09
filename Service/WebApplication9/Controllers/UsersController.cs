using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication9.Data.DTO;
using WebApplication9.Data.Entities;
using WebApplication9.Services;


namespace WebApplication9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]//if we can jwt token correctly we can enter controller. if not we can get 401 code response
    public class UsersController : ControllerBase
    {
        private readonly UsersService service;
        private readonly JwtService jwt;
        public UsersController(UsersService service, JwtService jwt)
        {
            this.service = service;
            this.jwt = jwt;
        }
        //[AllowAnonymous]
        [Route("{id?}")]
        public ActionResult GetUsers(int id = 0)//קבלה
        {            
            if (id < 1)
            {
                List<Users> result = service.Get();
                //service.GetData();
                return Ok(result);
            }
            string idFromJwt = jwt.GetTokenClaims();
            id = int.Parse(idFromJwt);
            Users resultUsers = service.GetUsers(id);
            return Ok(resultUsers);
        }
        [AllowAnonymous]
        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteUser(int id)
        {
            ResponseDTO response = service.Delete(id);
            if (response.Status == Data.DTO.StatusCode.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult PostUser(UserDTO user)//למה את דיטיאו?
        {
            if (user != null || user.Password != null || user.Email != null||service.Validation(user.Email) == false)//add null and etc'
            {
                bool isOk = service.Add(user);
                if (isOk)
                {
                    return Created("", null);
                }
            }

            return BadRequest(Data.DTO.StatusCode.Error);
            //throw new Exception("Problam when trying add user to db");

        }
        [HttpPost]
        [Route("auth")]
        [AllowAnonymous]//allowed enter in this func
        public IActionResult Auth([FromBody] AuthRequestDTO request)
        {
            if (string.IsNullOrEmpty(request.Email)  || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest("יש להזין אימייל וסיסמא !");
            }
            Users userFoundInDb = service.GetUserForAuth(request.Email, request.Password);

            if (userFoundInDb !=  null)
            {
                string jwtUser = jwt.GenerateToken(userFoundInDb.Id.ToString());
                return Ok(jwtUser);
            }
            return Unauthorized("משתמש לא זוהה במערכת");
        }
        [HttpPut]
        [AllowAnonymous]
        [Route("{id}")]

        public ActionResult PutUser(int id , UserDTO user)
        {
            ResponseDTO response = service.Update(id, user);
            if (response.Status == Data.DTO.StatusCode.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
