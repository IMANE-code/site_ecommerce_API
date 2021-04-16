using produit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace produit.Repositorie
{
    public interface ICatégorieRepository
    {
        Task<IEnumerable<Catégorie>> Get();
        Task<Catégorie> Get(int id);
        Task<Catégorie> Create(Catégorie catégorie);
        Task Update(Catégorie catégorie);
        Task Delete(int id);
    }
}
