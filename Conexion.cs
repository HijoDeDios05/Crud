using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;


namespace App1
{
    class Conexion
    {   
        
        private SqlConnection conexion = new SqlConnection(@"Data Source=DESKTOP-5AQ3CT6\SQLEXPRESS;Initial Catalog=Personas;Integrated Security=True");
        private DataSet ds;

        public DataTable MostrarDatos()
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("select * from Productos", conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];


            
        }

        public DataTable Buscar(string nombre)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("select * from Productos where Nombre like '%{0}%'", nombre), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public bool Insertar(string id, string nombre, string precio)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("insert into Productos values ({0}, '{1}', '{2}')", new string[] { id, nombre, precio }), conexion);
            int filasafectadas = cmd.ExecuteNonQuery();
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }

        public bool Eliminar(string id)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("delete from Productos where ID = {0}", id), conexion);
            int filasafectadas = cmd.ExecuteNonQuery();
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }

        public bool Actualizar(string id, string nombre, string precio)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("update Productos set Nombre = '{0}', Precio = '{1}' where ID = {2}", new string[] { nombre, precio, id }), conexion);
            int filasafectadas = cmd.ExecuteNonQuery();
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }
    }
}
