namespace Inventario.Models{
    public interface IProductRepository
    {
        List<Product> getAll();
        Product getById(int id);

        string insert(Product item);
        string remove(int id);

        string update(Product item);  
    }
}