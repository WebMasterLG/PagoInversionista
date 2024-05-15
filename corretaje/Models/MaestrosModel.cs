using corretaje.Clases;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace corretaje.Models
{
    public class MaestrosModel
    {
        private static readonly string connCorretaje = Environment.GetEnvironmentVariable("CORRETAJE", EnvironmentVariableTarget.Machine);

        public static List<Lista> CargarLista(int idLista)
        {
            List<Lista> lstLista = new List<Lista>();
            SqlDataAdapter adp = new SqlDataAdapter("exec Carga_Combo_Listas_Generales " + idLista.ToString(), connCorretaje);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                lstLista.Add(new Lista
                {
                    IdLista = row["id"].ToString(),
                    Descripcion = row["descripcion"].ToString()
                });

            }
            return lstLista;
        }

        public static List<Lista> CargaInmobAsesor(int rut)
        {
            List<Lista> lstLista = new List<Lista>();
            SqlDataAdapter adp = new SqlDataAdapter("exec Carga_Combo_Inmobiliaria_Asesor " + rut, connCorretaje);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                lstLista.Add(new Lista
                {
                    IdLista = row["c_item"].ToString(),
                    Descripcion = row["g_glosa1"].ToString()
                });

            }
            return lstLista;
        }


        public static List<Lista> CargaComunas(int idRegion)
        {
            List<Lista> lstLista = new List<Lista>();
            SqlDataAdapter adp = new SqlDataAdapter("exec dbo.Carga_Comunas " + idRegion.ToString(), connCorretaje);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                lstLista.Add(new Lista
                {
                    IdLista = row["c_item"].ToString(),
                    Descripcion = row["g_glosa1"].ToString()
                });

            }
            return lstLista;
        }

        public static List<Lista> CargaProyectos(int idInmobiliaria)
        {
            List<Lista> lstLista = new List<Lista>();
            SqlDataAdapter adp = new SqlDataAdapter("exec dbo.Carga_Combo_Proyectos " + idInmobiliaria.ToString(), connCorretaje);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                lstLista.Add(new Lista
                {
                    IdLista = row["id_pry"].ToString(),
                    Descripcion = row["g_nom_pry"].ToString()
                });

            }
            return lstLista;
        }

        public static List<Lista> CargaProyectosUsuario(int idInmobiliaria, int rut)
        {
            List<Lista> lstLista = new List<Lista>();
            SqlDataAdapter adp = new SqlDataAdapter("exec Carga_Combo_Proyectos_asesor " + idInmobiliaria +", " + rut, connCorretaje);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                lstLista.Add(new Lista
                {
                    IdLista = row["id_pry"].ToString(),
                    Descripcion = row["g_nom_pry"].ToString()
                });

            }
            return lstLista;
        }

        public static List<Lista> CargaUnidades(int idProyecto)
        {
            List<Lista> lstLista = new List<Lista>();
            SqlDataAdapter adp = new SqlDataAdapter("exec dbo.Carga_Combo_Propiedad " + idProyecto.ToString(), connCorretaje);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                lstLista.Add(new Lista
                {
                    IdLista = row["id_prop"].ToString(),
                    Descripcion = row["n_dep"].ToString()
                });

            }
            return lstLista;
        }

        public static List<Lista> Giros_SII(int usuario)
        {
            List<Lista> lstLista = new List<Lista>();
            SqlDataAdapter adp = new SqlDataAdapter("exec dbo.Carga_Combo_Giros " + usuario.ToString(), connCorretaje);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                lstLista.Add(new Lista
                {
                    IdLista = row["c_giro"].ToString(),
                    Descripcion = row["glosa"].ToString()
                });

            }
            return lstLista;
        }

    }
}