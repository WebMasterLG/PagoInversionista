using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

/// <summary>
/// Summary description for BaseDAO
/// </summary>
public class BaseDAO
{
    private static readonly string connCorretaje = Environment.GetEnvironmentVariable("CORRETAJE", EnvironmentVariableTarget.Machine);

    private SqlConnection conn;

    /// <summary>
    /// Constructor
    /// </summary>
    public BaseDAO()
    {
    }

    /// <summary>
    /// Cerrar conexión a Base de Datos
    /// </summary>
    public void cerrarConexion()
    {
        try
        {
            this.conn.Close();
            this.conn.Dispose();
        }
        catch { }
    }

    /// <summary>
    /// Operaciones de retorno de Data
    /// </summary>
    /// <param name="spName"></param>
    /// <param name="parametros"></param>
    /// <param name="valores"></param>
    /// <returns></returns>
    public DataSet SelectCommand(string spName, ArrayList parametros, ArrayList valores)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        string str = this.StringConn();

        using (this.conn = new SqlConnection(str))
        {
            this.conn.StatisticsEnabled = false;

            using (SqlCommand cmd = new SqlCommand(spName, this.conn))
            {
                for (int i = 0; i < parametros.Count; i++)
                {
                    cmd.Parameters.Add(new SqlParameter(parametros[i].ToString(), valores[i].ToString()));
                }
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                da.Fill(ds);
            }
            return ds;
        }
    }

    /// <summary>
    /// Operaciones de no retorno a BD
    /// </summary>
    /// <param name="sqlQuery"></param>
    /// <param name="conn"></param>
    /// <param name="trans"></param>
    public void ExecuteNonQuery(string spName, ArrayList parametros, ArrayList valores)
    {
        try
        {
            string str = this.StringConn();
            using (this.conn = new SqlConnection(str))
            {
                this.conn.StatisticsEnabled = false;

                using (SqlCommand cmd = new SqlCommand(spName, this.conn))
                {
                    for (int i = 0; i < parametros.Count; i++)
                    {
                        cmd.Parameters.Add(new SqlParameter(parametros[i].ToString(), valores[i].ToString()));
                    }
                    this.conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    this.conn.Close();
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    /// <summary>
    /// Conexión a Base de datos
    /// </summary>
    /// <returns></returns>
    public string StringConn()
    {


        try
        {
            string conexionBaseDatos = connCorretaje;
            return (conexionBaseDatos);
        }
        catch { return (null); }
    }

}
