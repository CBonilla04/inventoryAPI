namespace Inventario.Models{
    public interface ILotRepository
    {
        List<Lot> getAll();
        Lot getById(int id);

        void insert(Lot item);
        void remove(int id);

        void update(Lot item);  
    }
}