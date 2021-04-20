using Microsoft.EntityFrameworkCore;
using produit.Data;
using produit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace produit.Repositorie
{
    public class ProduitRepository: IProduitRepository
    {
        private readonly ApplicationDbContext _context;
        public ProduitRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Produit> Create(Produit produit)
        {
            _context.produits.Add(produit);
            await _context.SaveChangesAsync();
            return produit;
        }

        public async Task Delete(int id)
        {
            var ProduitToDelete = await _context.produits.FindAsync(id);
            _context.produits.Remove(ProduitToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Produit>> Get()
        {
            return await _context.produits.ToListAsync();
        }

        public async Task<Produit> Get(int id)
        {
            return await _context.produits.FindAsync(id);
        }

        public async Task Update(Produit produit)
        {
            _context.Entry(produit).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
