using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace corretaje.Clases
{
    public class Cliente
    {
        public string Rut { get; set; }
        public string Dv { get; set; }
        public string FechaNacimiento { get; set; }
        public string Nombre { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string IdPais { get; set; }
        public string IdEstadoCivil { get; set; }        
        public string IdProfesion { get; set; }
        public string OtraProfesion { get; set; }
        public string AntLab { get; set; }
        public string NombreConyugue { get; set; }
        public string RutConyugue { get; set; }
        public string DvConyugue { get; set; }
        public string IdProfesionConyugue { get; set; }
        public string OtraProfesionConyugue { get; set; }
        public string AntLabConyugue { get; set; }
        public string NroHijos { get; set; }
        public string DomicilioParticular { get; set; }
        public string NumeroCasa { get; set; }
        public string Departamento { get; set; }
        public string Poblacion { get; set; }
        public string IdComuna { get; set; }
        public string IdRegion { get; set; }
        public string FonoParticular { get; set; }
        public string FonoCelular { get; set; }
        public string Email { get; set; }
        public string InvAnt { get; set; }
        public string DondeCon { get; set; }
        public string NumDepartamento { get; set; }
        public string ArriendosTotales { get; set; }
        public string DivTotal { get; set; }
        public string CasaPropia { get; set; }
        public string MontoDeseaInvertir { get; set; }
        public string ArchivoSubido { get; set; }
        public string MontoDiv { get; set; }
        public string CuotasDiv { get; set; }
        public string CuotasConsumo { get; set; }
        public string NroCuotaAuto { get; set; }
        public string MontoCreditoAuto { get; set; }
        public string MontoCreditoCons { get; set; }
        public string RentaPromedio { get; set; }
        public string RentaPromedioCon { get; set; }
        public string AhorroDisponible { get; set; }
        public string InvTentativa { get; set; }
        public string JubilacionDeseada { get; set; }
        public string StgoCentro { get; set; }
        public string EstCentral { get; set; }
        public string Nunoa { get; set; }
        public string SanMiguel { get; set; }
        public string Independencia { get; set; }
        public string Otros { get; set; }
        public string NombreEmp { get; set; }
        public string RutEmpresa { get; set; }
        public string DvEmpresa { get; set; }
        public string DomEmpresa { get; set; }
        public string IdRegionEmpresa { get; set; }
        public string IdComunaEmpresa { get; set; }        
        public string RepresentanteLegal { get; set; }
        public string IdNacionalidadRepLegal { get; set; }
        public string IdEstadoCivilRepLegal { get; set; }
        public string FechaNacimientoRepLegal { get; set; }
        public string IdProfesionRepLegal { get; set; }
        public string OtraProfesionRepLegal { get; set; }
        public string RutRepLegal { get; set; }
        public string DvRepLegal { get; set; }
        public string DomRepLegal { get; set; }        
        public string IdComunaRepLegal { get; set; }
        public string IdRegionRepLegal { get; set; }
        public string Referido { get; set; }
        public string FonoReferido { get; set; }
        public string Comentarios { get; set; }
        public string FechaPrimContacto { get; set; }
        public string IdEjecutivo { get; set; }
        public string FechaReunion { get; set; }
        public string FechaPlanInv { get; set; }
        public string Membresia { get; set; }
        public string FechaMembresia { get; set; }
        public string MontoMembresia { get; set; }
        public string FechaCierre { get; set; }
        public string FormaPago { get; set; }
        public string TipoProyecto { get; set; }
        public string InvertirEn{ get; set; }
        public string Key { get; set; }
        public string Nombre_Asesor { get; set; }
    }

    public class ListadoClientes
    {
        public string estado { get; set; }
        public string mensaje { get; set; }
        public string rut_cli { get; set; }
        public string nombre { get; set; }
        public string g_fon_par { get; set; }
        public string g_fon_cel { get; set; }
        public string g_mail_per { get; set; }
        public string codigo { get; set; }
    }
}