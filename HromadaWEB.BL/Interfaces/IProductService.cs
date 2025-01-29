using HromadaWEB.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HromadaWEB.BL.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductModel>> GetProducts();
    }
}
