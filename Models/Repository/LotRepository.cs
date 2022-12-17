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
            Lot item = new Lot();
            using(MySqlConnection conexion = new MySqlConnection(conexionString))
            {
                conexion.Open();
                MySqlCommand command = new MySqlCommand();
                command.CommandText = "SELECT * from Lot l WHERE l.idLot = ?idLot";
                command.Parameters.Add("?idLot", MySqlDbType.Int32).Value = id; // to avoid sql injection
                command.Connection = conexion;
                
                using(var reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        item.idLot = Convert.ToInt32(reader["idLot"]);
                        item.lotNumber = reader["lotNumber"].ToString();
                        item.dueDate = (DateTime)reader["dueDate"];
                        item.creationDate = (DateTime)reader["creationDate"];
                    }
                    return item;
                }
            } 
        }

        public string insert(Lot item)
        {
            using(MySqlConnection conexion = new MySqlConnection(conexionString))
            {
                conexion.Open();
                MySqlCommand command = new MySqlCommand();
                command.CommandText = "INSERT INTO Lot (`lotNumber`,`dueDate`,`creationDate`) VALUES (?lotNumber,?dueDate,?creationDate)";
                // to avoid sql injection
                command.Parameters.Add("?lotNumber", MySqlDbType.String).Value = item.lotNumber; 
                command.Parameters.Add("?dueDate", MySqlDbType.String).Value = item.dueDate; 
                command.Parameters.Add("?creationDate", MySqlDbType.String).Value = item.creationDate; 
                command.Connection = conexion;
                try
                {
                    command.ExecuteNonQuery();
                    return "Lote " + command.LastInsertedId + " ingresado correctamente."; 
                }
                catch (System.Exception ex)
                {
                     return "Error (" + ex.ToString() + ") No se pudo agregar el lote, revise los datos e intente nuevamente.";
                }
                
                
            }
        }

        public string remove(int id)
        {
            using(MySqlConnection conexion = new MySqlConnection(conexionString))
            {
                conexion.Open();
                MySqlCommand command = new MySqlCommand();
                command.CommandText = "DELETE FROM Lot WHERE idLot = ?idLot";
                // to avoid sql injection
                command.Parameters.Add("?idLot", MySqlDbType.Int32).Value = id;
                command.Connection = conexion;
                try
                {
                    command.ExecuteNonQuery();
                    return "Lote eliminado correctamente."; 
                }
                catch (System.Exception ex)
                {
                     return "Error (" + ex.ToString() + "), No se pudo eliminar el Lote.";
                }
                
                
            }
        }

        public string update(Lot item)
        {
            using(MySqlConnection conexion = new MySqlConnection(conexionString))
            {
                conexion.Open();
                MySqlCommand command = new MySqlCommand();
                command.CommandText = "UPDATE Lot SET lotNumber = ?lotNumber, dueDate = ?dueDate, creationDate = ?creationDate";
                // to avoid sql injection
                command.Parameters.Add("?idLot", MySqlDbType.Int32).Value = item.idLot; 
                command.Parameters.Add("?lotNumber", MySqlDbType.String).Value = item.lotNumber; 
                command.Parameters.Add("?dueDate", MySqlDbType.String).Value = item.dueDate; 
                command.Parameters.Add("?creationDate", MySqlDbType.String).Value = item.creationDate; 
                command.Connection = conexion;
                try
                {
                    command.ExecuteNonQuery();
                    return "Lote " + item.lotNumber + " editado correctamente."; 
                }
                catch (System.Exception ex)
                {
                     return "Error (" + ex.ToString() + ") No se pudo editar el lote" + item.lotNumber +" , revise los datos e intente nuevamente.";
                }
                
                
            }
        }
    }
}

