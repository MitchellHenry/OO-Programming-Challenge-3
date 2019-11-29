using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using OO_Challenge_3_SEM_2.Models;

namespace OO_Challenge_3_SEM_2.Controllers
{
    public class RoomsController : ApiController
    {
        private civapiEntities db = new civapiEntities();

        // GET: api/Rooms
        public IQueryable<Room> GetRooms()
        {
            return db.Rooms;
        }

        [Route("api/Rooms/Unused")]
        public List<Room> GetUnusedRooms()
        {
            db.Configuration.LazyLoadingEnabled = true;
            List<Room> Rooms = new List<Room>();

            foreach (Room room in db.Rooms)
            {
                if (room.Classes.Count == 0)
                {
                    Rooms.Add(room);
                }
            }

            db.Configuration.LazyLoadingEnabled = false;
            return Rooms;
        }

        [Route("api/Rooms/Used")]
        public List<Room> GetUsedRooms()
        {
            List<Room> Rooms = new List<Room>();
            foreach (Room room in db.Rooms)
            {
                if (room.Classes.Count > 0)
                {
                    Rooms.Add(room);
                }
            }

            return Rooms;
        }

        [Route("api/Rooms/Computers")]
        public List<Room> GetRoomsWithComputers()
        {

            db.Configuration.LazyLoadingEnabled = true;

            List<Room> Rooms = new List<Room>();
            foreach (Room room in db.Rooms)
            {
                if (room.Computers.Count > 0)
                {
                    Rooms.Add(room);
                }
            }

            db.Configuration.LazyLoadingEnabled = false;

            return Rooms;
        }

        [Route("api/computers")]
        public List<Computer> GetComputers()
        {
            List<Computer> Computers = new List<Computer>();
            foreach (Computer computers in db.Computers)
            {
                    Computers.Add(computers);               
            }

            return Computers;
        }

    
        [Route("api/classes/{classcode}")]
        public Class[] GetClassByCode(string classcode)
        {
            List<Class> ParticularClass = new List<Class>();
            foreach (Class i in db.Classes)
            {
                if (i.ClassCode.Contains(classcode))
                {
                    ParticularClass.Add(i);
                }
            }
            
            return ParticularClass.ToArray();                    
        }

    }
}