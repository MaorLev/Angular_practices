using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebApplication9.Data;
using WebApplication9.Data.DTO;
using WebApplication9.Data.Entities;

namespace WebApplication9.Services
{
    public class UsersService
    {
        private readonly TodolistDBContext m_db;

        public UsersService(TodolistDBContext db)
        {
            m_db = db;
        }
        public bool Add(UserDTO user)
        {
            Users UserFromDB = new Users();
            
            UserFromDB.Password = GetMD5(user.Password);

            UserFromDB.FirstName = user.FirstName; 
            UserFromDB.LastName = user.LastName;
            UserFromDB.Email = user.Email;
            UserFromDB.Phone = user.Phone;
            


            m_db.Users.Add(UserFromDB);//ref to item virtual in dbContext for add or any actions

            int c = m_db.SaveChanges();//save changes and return how many added tables
            return c > 0;//return if we added more than zero tables 
        }
        public List<Users> Get()
        {
            return m_db.Users.ToList();
        }

        public Users GetUsers(int id)
        {
            return m_db.Users.Where(i => i.Id == id).FirstOrDefault();
        }
        public Users GetUserForAuth(string email, string pass)
        {
            return m_db
                .Users
                .Where(u => u.Email.ToLower() == email.ToLower() && u.Password == GetMD5(pass) )
                .FirstOrDefault();
        }

        public ResponseDTO Update(int id, UserDTO UserToUpdate)
        {
            Users UserFromDB = GetUsers(id);//get original memory address of item from DB in new instance
            if (UserFromDB == null)//if the instance empty\not exists return bad requst to controller
            {
                return new ResponseDTO()//new instance status for return request
                {
                    Status = StatusCode.Error,//insert statusCo error from ResponseDTO class to answer(return)
                    StatusText = $"Item {UserToUpdate.FirstName} with id {id} not found in DB"
                };
            }//checkkk it !!
            //else if (UserFromDB.Password != GetMD5(UserToUpdate.Password))//check vlidation of serial(like check match password in another site)
            //{
            //    return new ResponseDTO()
            //    {
            //        Status = StatusCode.Error,
            //        StatusText = $"Item {UserToUpdate.FirstName} with SN {UserToUpdate.Password} Not match to DB"
            //    };
            //}

   
            UserFromDB.FirstName = UserToUpdate.FirstName ?? UserFromDB.FirstName;
            //in this configuration work with int(with small problem, not allowed put '0' number.)
            UserFromDB.LastName = UserToUpdate.LastName ?? UserFromDB.LastName;
            UserFromDB.Email = UserToUpdate.Email ?? UserFromDB.Email;
            UserFromDB.Phone = UserToUpdate.Phone ?? UserFromDB.Phone;
            UserFromDB.Password = GetMD5(UserToUpdate.Password) ?? UserFromDB.Password;

            int c = m_db.SaveChanges();//save changes in DB
            ResponseDTO response = new ResponseDTO();//another way to send response back to controller
            if (c > 0)//check if applied changes on DB and how many item affacted
            {
                //text and status code for instance respone(associated to responseDTO class)
                response.StatusText = c + " User affected";
                response.Status = StatusCode.Success;
            }
            else
            {
                response.Status = StatusCode.Error;
                response.StatusText = "faild no Users affacted";
            }
            return response;// return answer\response
        }
        public ResponseDTO Delete(int id)
        {
            Users userToDelete = GetUsers(id);
            if (userToDelete == null)
            {
                return new ResponseDTO() { StatusText = "this object not exists", Status = StatusCode.Error };
            }
            m_db.Users.Remove(userToDelete);
            int c = m_db.SaveChanges();
            ResponseDTO response = new ResponseDTO();
            if (c > 0)
            {
                response.StatusText = "Successfully object deleted";
                response.Status = StatusCode.Success;
            }
            else
            {
                response.Status = StatusCode.Error;
            }
            return response;
        }
        public bool Validation(string emai)
        {
            if (m_db.Users.Where(i => i.Email == emai).FirstOrDefault() != null )
            {
                return true;
            }
            return false;
        }

        private string GetMD5(string input) //123
        {
            if (input == null)
            {
                return null;
            }
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(input));
                var strResult = BitConverter.ToString(result);
                return strResult.Replace("-", "");
            }
        }


    }
}
