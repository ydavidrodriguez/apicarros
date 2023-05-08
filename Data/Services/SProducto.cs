using Data.Interface;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{

    public class SProducto : IProducto
    {

        public List<MProducto> Listproduct()
        {
            var lista = new List<MProducto>();
            string cadenaConexion = "Data Source=YEFERSON;DataBase=Carrito;Integrated Security=true";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();
            SqlCommand cmd = new SqlCommand("ListProduct", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drlector = cmd.ExecuteReader();


            while (drlector.Read())
            {
                MProducto oProductoEntity = new MProducto();

                oProductoEntity.id = Convert.ToInt32(drlector["Id"]);
                oProductoEntity.nombre = drlector["Nombre"].ToString().Trim();
                oProductoEntity.descripcion = drlector["Descripcion"].ToString().Trim();
                oProductoEntity.valor = Convert.ToInt32(drlector["Valor"].ToString().Trim());
                oProductoEntity.stock = Convert.ToInt32(drlector["Stock"].ToString().Trim());

                lista.Add(oProductoEntity);
            }
            return lista;


        }
        public bool CreateShop(MMovimientoS mMovimientoS) 
        {
            try
            {

                string cadenaConexion = "Data Source=YEFERSON;DataBase=Carrito;Integrated Security=true";
                SqlConnection cn = new SqlConnection(cadenaConexion);
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_Creatshop", cn);
                cmd.Parameters.Add(new SqlParameter("@idcliente", SqlDbType.Int)).Value = mMovimientoS.MVentaf.id_cliente;
                
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                foreach(var i in mMovimientoS.MVentad) 
                {

                    SqlCommand sqlCommand = new SqlCommand("SP_CreatshopDet", cn);
                    sqlCommand.Parameters.Add(new SqlParameter("@idproducto", SqlDbType.Int)).Value = i.idproducto;
                    sqlCommand.Parameters.Add(new SqlParameter("@cantidad", SqlDbType.Int)).Value = i.cantidad;

                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.ExecuteNonQuery();

                }

                return true;

            }
            catch (Exception)
            {

                return false;
            }
           

        }


    }
}
