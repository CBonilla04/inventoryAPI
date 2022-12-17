using MySql.Data.MySqlClient;

namespace Inventario.Models{
    public class LotRepository : ILotRepository
    {
        private readonly string conexionString;
        public LotRepository(){
            conexionString = "Server=127.0.0.1;Port=3306;Database=dbinventory;User=cbonilla;password=NRU_QEAfW4Q_Yg21;";
        }
        public List<Lot> getAll()
        {
            List<Lot> result = new List<Lot>();
            Lot item = new Lot();
            using(MySqlConnection conexion = new MySqlConnection(conexionString))
            {
                conexion.Open();
                MySqlCommand command = new MySqlCommand();
                command.CommandText = "select * from lot";
                command.Connection = conexion;
                
                using(var reader =command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        item.idLot = Convert.ToInt32(reader["idLot"]);
                        item.lotNumber = reader["lotNumber"].ToString();
                        item.dueDate = (DateTime)reader["dueDate"];
                        item.creationDate = (DateTime)reader["creationDate"];

                        result.Add(item);
                    }
                    return result;
                }
            }        
        }

        public Lot getById(int id)
        {
            throw new NotImplementedException();
        }

        public void insert(Lot item)
        {
            throw new NotImplementedException();
        }

        public void remove(int id)
        {
            throw new NotImplementedException();
        }

        public void update(Lot item)
        {
            throw new NotImplementedException();
        }
    }
}

