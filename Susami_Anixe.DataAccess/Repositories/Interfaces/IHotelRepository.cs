using Susami_Anixe.Core.Model.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Susami_Anixe.DataAccess.Repositories.Interfaces
{
    public interface IHotelRepository
    {
        void Create(Hotel hotel);
        List<Hotel> GetByName(string Name);
    }
}
