using Susami_Anixe.Core.Model.Entities;
using Susami_Anixe.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Susami_Anixe.DataAccess.Repositories
{   
    public class HotelRepository : IHotelRepository
    {
        public void Create(Hotel hotel) { 
        
        }

        public List<Hotel> GetByName(string Name) 
        {                     
            return new List<Hotel>();
        }
    }
}
