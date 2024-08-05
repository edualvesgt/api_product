using API_Product.Contexts;
using API_Product.Domains;
using API_Product.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_Product.Repository
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ProductsContext _context;

        // Construtor que aceita ProductsContext via injeção de dependência
        public ProductsRepository(ProductsContext context)
        {
            _context = context;
        }

        public void Create(Products newProduct)
        {
            try
            {
                _context.Products.Add(newProduct);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(Guid id)
        {
            try
            {
                var product = _context.Products.Find(id);
                if (product != null)
                {
                    _context.Products.Remove(product);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Products GetById(Guid id)
        {
            try
            {
                return _context.Products.FirstOrDefault(x => x.ID == id)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Products> List()
        {
            try
            {
                return _context.Products.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Products newProduct, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
