﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;


namespace TP_INTEGRADOR_P1
{
    internal class manejadorVentas
    {
        public static string cadenaConexion = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public List<Venta> obtenerVentas(int idUsuario)
        {
            List<Venta> ventas = new List<Venta>();
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand($"select * from Ventas where IdUsuario = '{idUsuario}'", conn);
                conn.Open();
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Venta ventaTemporal = new Venta();
                        ventaTemporal.Id = reader.GetInt64(0);
                        ventaTemporal.Comentario = reader.GetString(1);
                        ventaTemporal.IdUsuario = reader.GetInt64(2);
                        

                        ventas.Add(ventaTemporal);
                    }
                }
                return ventas;
            }
        }
}
