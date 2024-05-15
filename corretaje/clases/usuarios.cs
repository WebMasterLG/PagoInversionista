using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
namespace corretaje.Clases
{

    public class Usuarios
    {
        static readonly string PasswordHash = "P@@Sw0rd";
        static readonly string SaltKey = "S@LT&KEY";
        static readonly string VIKey = "@1B2c3D4e5F6g7H8";

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Rut { get; set; }
        public string DV { get; set; }
        public int IdSupervisor { get; set; }
        public string Supervisor { get; set; }
        public int IdPerfil { get; set; }
        public string Perfil { get; set; }
        public int IdSubPerfil { get; set; }
        public string SubPerfil { get; set; }
        public int IdArea { get; set; }
        public string Area { get; set; }
        public int IdCargo { get; set; }
        public string Cargo { get; set; }
        public string Email { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string Sucursales { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public int idSucursal { get; set; }
        public string originalPassword { get; set; }

        private string strPass;

        public string Pass
        {
            get { return strPass; }
            set
            {
                strPass = value;
                if (strPass != null)
                {
                    originalPassword = value;

                    byte[] plainTextBytes = Encoding.UTF8.GetBytes(strPass);

                    byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
                    var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
                    var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));

                    byte[] cipherTextBytes;

                    using (var memoryStream = new MemoryStream())
                    {
                        using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                        {
                            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                            cryptoStream.FlushFinalBlock();
                            cipherTextBytes = memoryStream.ToArray();
                            cryptoStream.Close();
                        }
                        memoryStream.Close();
                    }
                    strPass = Convert.ToBase64String(cipherTextBytes);
                    value = Convert.ToBase64String(cipherTextBytes);
                }
                else
                {
                    originalPassword = "";
                    strPass = "";
                    value = "";
                }
            }
        }




    }

    public class DatosUsuarioConectado
    {
        public string nombre { get; set; }
        public string perfil { get; set; }
        public string subperfil { get; set; }
        public string area { get; set; }
        public string hora { get; set; }
    }
}