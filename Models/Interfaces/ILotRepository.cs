namespace Inventario.Models{
    public interface ILotRepository
    {
        List<Lot> getAll();
        Lot getById(int id);

        string insert(Lot item);
        string remove(int id);

        string update(Lot item);  
    }
}