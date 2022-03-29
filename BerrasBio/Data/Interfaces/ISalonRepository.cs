using BerrasBio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerrasBio.Data.Interfaces
{
    public interface ISalonRepository
    {
        Task<Salon> GetSalonById(int? id);
    }
}
