using MySql.Data.MySqlClient;

namespace Inventario.Models{
    public class ProductRepository : IProductRepository
    {
        private readonly string conexionString;
        public ProductRepository(){
            conexionString = "Server=127.0.0.1;Port=3306;Database=dbinventory;User=cbonilla;password=NRU_QEAfW4Q_Yg21;";
        }

        public List<Product> getAll()
        {
            List<Product> result = new List<Product>();
            Product item = new Product();
            using(MySqlConnection conexion = new MySqlConnection(conexionString))
            {
                conexion.Open();
                MySqlCommand command = new MySqlCommand();
                command.CommandText = "select * from Product";
                command.Connection = conexion;
                
                using(var reader =command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        item.idPro = Convert.ToInt32(reader["idPro"]);
                        item.name = reader["name"].ToString();
                        item.description = reader["description"].ToString();
                        item.price = Convert.ToInt32(reader["price"]);
                        item.idLot = Convert.ToInt32(reader["idLot"]);
                        item.idProSta = Convert.ToInt32(reader["idProSta"]);
                        item.idWer = Convert.ToInt32(reader["idWer"]);

                        result.Add(item);
                    }
                    return result;
                }
            } 
        }

        public Product getById(int id)
        {
            Product item = new Product();
            using(MySqlConnection conexion = new MySqlConnection(conexionString))
            {
                conexion.Open();
                MySqlCommand command = new MySqlCommand();
                command.CommandText = "SELECT * from Product p WHERE p.idPro = ?idProduct";
                command.Parameters.Add("?idProduct", MySqlDbType.Int32).Value = id; // to avoid sql injection
                command.Connection = conexion;
                
                using(var reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        item.idPro = Convert.ToInt32(reader["idPro"]);
                        item.name = reader["name"].ToString();
                        item.description = reader["description"].ToString();
                        item.price = Convert.ToInt32(reader["price"]);
                        item.idLot = Convert.ToInt32(reader["idLot"]);
                        item.idProSta = Convert.ToInt32(reader["idProSta"]);
                        item.idWer = Convert.ToInt32(reader["idWer"]);
                    }
                    return item;
                }
            } 
        }

        public string insert(Product item)
        {
            using(MySqlConnection conexion = new MySqlConnection(conexionString))
            {
                conexion.Open();
                MySqlCommand command = new MySqlCommand();
                command.CommandText = "INSERT INTO Product (`name`,`description`,`price`,`idLot`,`idProSta`,`idWer`) VALUES (?name,?description,?price,?idLot,?idProSta,?idWer)";
                // to avoid sql injection
                command.Parameters.Add("?name", MySqlDbType.String).Value = item.name; 
                command.Parameters.Add("?description", MySqlDbType.String).Value = item.description; 
                command.Parameters.Add("?price", MySqlDbType.Int32).Value = item.price; 
                command.Parameters.Add("?idLot", MySqlDbType.Int32).Value = item.idLot; 
                command.Parameters.Add("?idProSta", MySqlDbType.Int32).Value = item.idProSta; 
                command.Parameters.Add("?idWer", MySqlDbType.Int32).Value = item.idWer; 
                command.Connection = conexion;
                try
                {
                    command.ExecuteNonQuery();
                    return "Producto " + command.LastInsertedId + " ingresado correctamente."; 
                }
                catch (System.Exception ex)
                {
                     return "Error (" + ex.ToString() + ") No se pudo agregar el producto, revise los datos e intente nuevamente.";
                }
                
                
            } 
        }

        public string remove(int id)
        {
            using(MySqlConnection conexion = new MySqlConnection(conexionString))
            {
                conexion.Open();
                MySqlCommand command = new MySqlCommand();
                command.CommandText = "DELETE FROM Product WHERE idPro = ?idPro";
                // to avoid sql injection
                command.Parameters.Add("?idPro", MySqlDbType.Int32).Value = id;
                command.Connection = conexion;
                try
                {
                    command.ExecuteNonQuery();
                    return "Producto eliminado correctamente."; 
                }
                catch (System.Exception ex)
                {
                     return "Error (" + ex.ToString() + "), No se pudo eliminar el producto.";
                }
                
                
            }
        }

        public string update(Product item)
        {
            using(MySqlConnection conexion = new MySqlConnection(conexionString))
            {
                conexion.Open();
                MySqlCommand command = new MySqlCommand();
                command.CommandText = "UPDATE Product SET name = ?name, description = ?description, price = ?price, idLot = ?idLot, idProSta = ?idProSta, idWer = ?idWer where idPro = ?idPro";
                // to avoid sql injection
                command.Parameters.Add("?idPro", MySqlDbType.Int32).Value = item.idPro; 
                command.Parameters.Add("?name", MySqlDbType.String).Value = item.name; 
                command.Parameters.Add("?description", MySqlDbType.String).Value = item.description; 
                command.Parameters.Add("?price", MySqlDbType.Int32).Value = item.price; 
                command.Parameters.Add("?idLot", MySqlDbType.Int32).Value = item.idLot; 
                command.Parameters.Add("?idProSta", MySqlDbType.Int32).Value = item.idProSta; 
                command.Parameters.Add("?idWer", MySqlDbType.Int32).Value = item.idWer; 
                command.Connection = conexion;
                try
                {
                    command.ExecuteNonQuery();
                    return "Producto " + item.name + " editado correctamente."; 
                }
                catch (System.Exception ex)
                {
                     return "Error (" + ex.ToString() + ") No se pudo editar el producto" + item.name +" , revise los datos e intente nuevamente.";
                }
                
                
            }
        }
    }
}

