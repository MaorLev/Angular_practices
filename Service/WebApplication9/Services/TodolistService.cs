using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication9.Data;
using WebApplication9.Data.DTO;
using WebApplication9.Data.Entities;

namespace WebApplication9.Services
{
    public class TodolistService
    {
        private readonly TodolistDBContext m_db;

        public TodolistService(TodolistDBContext db)
        {
            m_db = db;
        }
        public bool Add(ItemDTO item)
        {
            Item itemFromDB  = new Item();
            itemFromDB.Active = true;//true for default
            itemFromDB.CompanyName = item.ItemCompanyName;
            itemFromDB.Count = item.ItemCount;
            itemFromDB.Name = item.ItemName;
            itemFromDB.Price = item.ItemPrice;
            itemFromDB.Serial = item.ItemSerial;

            m_db.Item.Add(itemFromDB);//ref to item virtual in dbContext for add or any actions

            int c = m_db.SaveChanges();//save changes and return how many added tables
            return c > 0;//return if we added more than zero tables 
        }
        public List<Item> Get()
        {
            return m_db.Item.ToList();
        }

        public Item GetItem(int id)
        {
            return m_db.Item.Where(i => i.Id == id).FirstOrDefault();
        }

        public ResponseDTO Update(int id, ItemDTO itemToUpdate)
        {
            Item itemFromDB = GetItem(id);//get original memory address of item from DB in new instance
            if (itemFromDB == null)//if the instance empty\not exists return bad requst to controller
            {
                return new ResponseDTO()//new instance status for return request
                {
                    Status = StatusCode.Error,//insert statusCo error from ResponseDTO class to answer(return)
                    StatusText = $"Item {itemToUpdate.ItemName} with id {id} not found in DB"
                };
            }
            else if(itemFromDB.Serial != itemToUpdate.ItemSerial)//check vlidation of serial(like check match password in another site)
            {
                return new ResponseDTO()
                {
                    Status = StatusCode.Error,
                    StatusText = $"Item {itemToUpdate.ItemName} with SN {itemToUpdate.ItemSerial} Not match to DB"
                };
            }

            //if active not exists with request return active of Db(in this configuration work with bool and string)
            itemFromDB.Active = itemToUpdate.ItemActive ?? itemFromDB.Active;
            itemFromDB.CompanyName = itemToUpdate.ItemCompanyName ?? itemFromDB.CompanyName;
            //in this configuration work with int(with small problem, not allowed put '0' number.)
            itemFromDB.Count = (itemToUpdate.ItemCount == 0) ? itemFromDB.Count : itemToUpdate.ItemCount;
            itemFromDB.Name = itemToUpdate.ItemName ?? itemFromDB.Name;
            itemFromDB.Price = itemToUpdate.ItemPrice;
            itemFromDB.Serial = itemToUpdate.ItemSerial;
            
            int c = m_db.SaveChanges();//save changes in DB
            ResponseDTO response = new ResponseDTO();//another way to send response back to controller
            if (c > 0)//check if applied changes on DB and how many item affacted
            {
                //text and status code for instance respone(associated to responseDTO class)
                response.StatusText = c + " items affected";
                response.Status = StatusCode.Success;
            }
            else
            {
                response.Status = StatusCode.Error;
                response.StatusText = "faild no items affacted";
            }
            return response;// return answer\response
        }
        public ResponseDTO Delete(int id)
        {
            Item itemToDelete = GetItem(id);
            if(itemToDelete == null)
            {
                return new ResponseDTO() { StatusText = "this object not exists", Status = StatusCode.Error };
            }
            m_db.Item.Remove(itemToDelete);
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

    }

}