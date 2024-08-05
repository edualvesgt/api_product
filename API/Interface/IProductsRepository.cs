using API_Product.Domains;

namespace API_Product.Interface
{
    public interface IProductsRepository
    {
        List<Products> List();
        
        Products GetById(Guid id);

        void Create(Products newProduct);

        void Update(Products newProduct, Guid id);

        void Delete(Guid id);
    }
}
