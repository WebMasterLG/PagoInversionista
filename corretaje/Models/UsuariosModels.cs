using corretaje.Clases;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace corretaje.Models
{
    public class UsuariosModels
    {
        private static readonly string connCorretaje = Environment.GetEnvironmentVariable("CORRETAJE", EnvironmentVariableTarget.Machine);
        public static List<Usuarios> CargarPerfilUsuario(Usuarios cUsuario)
        {
            string[] rut = cUsuario.Rut.Split('-');
            List<Usuarios> lstTabla = new List<Usuarios>();


            return lstTabla;
        }


        public static List<Usuarios> CargarUsuarios(int rut_usuario)
        {
            //cmd.Parameters.Add("@ID_USU", SqlDbType.Int).Value = idUsuario;

            List<Usuarios> lstUsuario = new List<Usuarios>();

            SqlDataAdapter adp = new SqlDataAdapter("exec dbo.usuarios_carga " + rut_usuario,connCorretaje);

            DataSet ds = new DataSet();
            adp.Fill(ds);
            foreach (DataRow row in ds.Tables[0].Rows)

            {
                lstUsuario.Add(new Usuarios
                {
                    Id = int.Parse(row["id_usu"].ToString()),
                    Nombre = row["g_nom"].ToString(),
                    Paterno = row["g_ape_pat"].ToString(),
                    Materno = row["g_ape_mat"].ToString(),
                    Email = row["g_mail"].ToString(),
                    IdCargo = int.Parse(row["id_cargo"].ToString()),
                    IdArea = int.Parse(row["id_area"].ToString()),
                    IdPerfil = int.Parse(row["id_per"].ToString()),
                    Perfil = row["perfil"].ToString(),
                    IdSubPerfil = String.IsNullOrEmpty(row["id_sub_per"].ToString()) ? 0 : int.Parse(row["id_sub_per"].ToString()),
                    SubPerfil = row["subperfil"].ToString(),
                    Rut = row["g_rut"].ToString() + "-" + row["g_dv"].ToString(),
                    IdSupervisor = int.Parse(row["id_sup"].ToString()),
                    idSucursal = int.Parse(row["id_suc"].ToString())
                });
            }

            foreach (var usuario in lstUsuario)
            {
                adp = new SqlDataAdapter("exec dbo.Usuarios_Obtiene_Area " + usuario.Id,connCorretaje);
                DataSet dsArea = new DataSet();
                adp.Fill(dsArea);
                foreach (DataRow row in dsArea.Tables[0].Rows)

                {
                    usuario.IdArea = (int)((long)row["id_area"]);
                }
            }
            return lstUsuario;
        }

        public static int IngresarUsuario(Usuarios usuario)
        {
            int exitoso = 1;
            try
            {
                using (SqlConnection con = new SqlConnection(connCorretaje))
                {
                    using (SqlCommand cmd = new SqlCommand("usuario_ingresa", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@g_nom", SqlDbType.VarChar).Value = usuario.Nombre;
                        cmd.Parameters.Add("@g_ape_pat", SqlDbType.VarChar).Value = usuario.Paterno;
                        cmd.Parameters.Add("@g_ape_mat", SqlDbType.VarChar).Value = usuario.Materno;
                        cmd.Parameters.Add("@g_key", SqlDbType.VarChar).Value = usuario.Pass;
                        cmd.Parameters.Add("@g_mail", SqlDbType.VarChar).Value = usuario.Email;
                        cmd.Parameters.Add("@id_cargo", SqlDbType.Int).Value = usuario.IdCargo;
                        cmd.Parameters.Add("@id_area", SqlDbType.Int).Value = usuario.IdArea;
                        cmd.Parameters.Add("@id_per", SqlDbType.Int).Value = usuario.IdPerfil;
                        cmd.Parameters.Add("@id_sub_per", SqlDbType.Int).Value = usuario.IdSubPerfil;
                        cmd.Parameters.Add("@g_rut", SqlDbType.VarChar).Value = usuario.Rut.Split('-')[0];
                        cmd.Parameters.Add("@g_dv", SqlDbType.VarChar).Value = usuario.DV;
                        cmd.Parameters.Add("@pk_usu", SqlDbType.Int).Value = usuario.IdSupervisor;
                        cmd.Parameters.Add("@id_suc", SqlDbType.Int).Value = usuario.idSucursal;
                        cmd.Parameters.Add("@id_sup", SqlDbType.Int).Value = usuario.IdSupervisor;
                        con.Open();
                        
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                exitoso = int.Parse(reader[0].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                exitoso = 0;
            }
            return exitoso;
        }

        public static int ActualizarUsuario(Usuarios usuario)
        {
            int exitoso = 1;
            try
            {
                using (SqlConnection con = new SqlConnection(connCorretaje))
                {
                    //usuario.Pass

                    if (string.IsNullOrEmpty(usuario.Pass))
                    {
                        using (SqlCommand cmd = new SqlCommand("Actualiza_Usuario_Sin_Clave", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@id_usu", SqlDbType.Int).Value = usuario.Id;
                            cmd.Parameters.Add("@g_nom", SqlDbType.VarChar).Value = usuario.Nombre;
                            cmd.Parameters.Add("@g_ape_pat", SqlDbType.VarChar).Value = usuario.Paterno;
                            cmd.Parameters.Add("@g_ape_mat", SqlDbType.VarChar).Value = usuario.Materno;
                            // cmd.Parameters.Add("@g_key", SqlDbType.VarChar).Value = usuario.Pass;
                            cmd.Parameters.Add("@g_mail", SqlDbType.VarChar).Value = usuario.Email;
                            cmd.Parameters.Add("@id_cargo", SqlDbType.Int).Value = usuario.IdCargo;
                            cmd.Parameters.Add("@id_area", SqlDbType.Int).Value = usuario.IdArea;
                            cmd.Parameters.Add("@id_per", SqlDbType.Int).Value = usuario.IdPerfil;
                            cmd.Parameters.Add("@id_sub_per", SqlDbType.Int).Value = usuario.IdSubPerfil;
                            cmd.Parameters.Add("@g_rut", SqlDbType.VarChar).Value = usuario.Rut;
                            cmd.Parameters.Add("@g_dv", SqlDbType.VarChar).Value = usuario.DV;
                            cmd.Parameters.Add("@pk_usu", SqlDbType.Int).Value = usuario.IdSupervisor;
                            cmd.Parameters.Add("@id_suc", SqlDbType.Int).Value = usuario.idSucursal;
                            cmd.Parameters.Add("@id_sup", SqlDbType.Int).Value = usuario.IdSupervisor;
                            con.Open();
                            
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    exitoso = int.Parse(reader[0].ToString());
                                }
                            }
                        }
                    }
                    else
                    {
                        using (SqlCommand cmd = new SqlCommand("usuarios_actualiza", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@id_usu", SqlDbType.Int).Value = usuario.Id;
                            cmd.Parameters.Add("@g_nom", SqlDbType.VarChar).Value = usuario.Nombre;
                            cmd.Parameters.Add("@g_ape_pat", SqlDbType.VarChar).Value = usuario.Paterno;
                            cmd.Parameters.Add("@g_ape_mat", SqlDbType.VarChar).Value = usuario.Materno;
                            cmd.Parameters.Add("@g_key", SqlDbType.VarChar).Value = usuario.Pass;
                            cmd.Parameters.Add("@g_mail", SqlDbType.VarChar).Value = usuario.Email;
                            cmd.Parameters.Add("@id_cargo", SqlDbType.Int).Value = usuario.IdCargo;
                            cmd.Parameters.Add("@id_area", SqlDbType.Int).Value = usuario.IdArea;
                            cmd.Parameters.Add("@id_per", SqlDbType.Int).Value = usuario.IdPerfil;
                            cmd.Parameters.Add("@id_sub_per", SqlDbType.Int).Value = usuario.IdSubPerfil;
                            cmd.Parameters.Add("@g_rut", SqlDbType.VarChar).Value = usuario.Rut;
                            cmd.Parameters.Add("@g_dv", SqlDbType.VarChar).Value = usuario.DV;
                            cmd.Parameters.Add("@pk_usu", SqlDbType.Int).Value = usuario.IdSupervisor;
                            cmd.Parameters.Add("@id_suc", SqlDbType.Int).Value = usuario.idSucursal;
                            cmd.Parameters.Add("@id_sup", SqlDbType.Int).Value = usuario.IdSupervisor;
                            con.Open();
                            
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    exitoso = int.Parse(reader[0].ToString());
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                exitoso = 0;
            }
            return exitoso;
        }

        public static int EliminarUsuario(int idUsuario)
        {
            int exitoso = 1;
            try
            {
                using (SqlConnection con = new SqlConnection(connCorretaje))
                {
                    using (SqlCommand cmd = new SqlCommand("usuario_elimina", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@id_usu", SqlDbType.Int).Value = idUsuario;
                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                exitoso = int.Parse(reader[0].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                exitoso = 0;
            }
            return exitoso;
        }

        public static Usuarios CargarUsuario(int idUsuario)
        {
            //string[] rutUsuario = User.Identity.Name.Split('-');
            Usuarios usuario = new Usuarios();
            using (SqlConnection con = new SqlConnection(connCorretaje))
            {
                using (SqlCommand cmd = new SqlCommand("Usuarios_Carga_datos", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@id_usuario", SqlDbType.Int).Value = idUsuario;
                    con.Open();
                    
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usuario = new Usuarios
                            {
                                Id = int.Parse(reader["id_usu"].ToString()),
                                Nombre = reader["g_nom"].ToString(),
                                Paterno = reader["g_ape_pat"].ToString(),
                                Materno = reader["g_ape_mat"].ToString(),
                                Email = reader["g_mail"].ToString(),
                                IdCargo = int.Parse(reader["id_cargo"].ToString()),
                                IdArea = int.Parse(reader["id_area"].ToString()),
                                IdPerfil = int.Parse(reader["id_per"].ToString()),
                                IdSubPerfil = String.IsNullOrEmpty(reader["id_sub_per"].ToString()) ? 0 : int.Parse(reader["id_sub_per"].ToString()),
                                Rut = reader["g_rut"].ToString() + "-" + reader["g_dv"].ToString(),
                                idSucursal = int.Parse(reader["id_suc"].ToString()),
                                IdSupervisor = int.Parse(reader["id_sup"].ToString())
                            };
                        }
                    }
                    //exitoso = int.Parse(cmd.Parameters["@RESULTADO"].Value.ToString());
                }
            }
            return usuario;
        }

        public static bool ValidaUsuario(string rut, string pass)
        {
            string[] rutArray = rut.Split('-');
            int exitoso = 0;
            using (SqlConnection con = new SqlConnection(connCorretaje))
            {
                using (SqlCommand cmd = new SqlCommand("usuarios_valida", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RUT", SqlDbType.Int).Value = rutArray[0];
                    cmd.Parameters.Add("@PASS", SqlDbType.VarChar).Value = pass;
                    cmd.Parameters.Add("@RESULTADO", SqlDbType.Int).Value = 1;
                    con.Open();
                    
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            exitoso = reader.GetInt32(0);
                        }
                    }
                    //exitoso = int.Parse(cmd.Parameters["@RESULTADO"].Value.ToString());
                }
            }
            return exitoso == 1 ? true : false;
        }

        public static DatosUsuarioConectado Trae_Datos_Usuario_Conectado(int id_usu)
        {
            DatosUsuarioConectado res = new DatosUsuarioConectado();
            using (SqlConnection conn = new SqlConnection(connCorretaje))
            {
                using (SqlCommand cmd = new SqlCommand("Carga_Datos_Usuario_Conectado", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_usu", id_usu);
                    conn.Open();
                    
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            res = new DatosUsuarioConectado
                            {
                                nombre = reader["nombre"].ToString(),
                                perfil = reader["perfil"].ToString(),
                                subperfil = reader["subperfil"].ToString(),
                                area = reader["area"].ToString(),
                                hora = reader["hora"].ToString(),
                            };
                        }
                    }
                }
            }
            return res;
        }

    }
}