namespace HospitalApi.Model
{
    public class tbl_paciente
    {
        public int Id { get; set; }
        public int IdTipoIdentificacion { get; set; }
        public string ?NumeroDocumento { get; set; }
        public string ?Nombre { get; set; }
        public DateTime ?FechaNacimiento { get; set; }
        public string ?CorreoElectronico { get; set; }
        public int IdGenero { get; set; }
        public string ?Direccion { get; set; }
        public string ?NumeroTelefono { get; set; }
        public int IdEstado { get; set; }
    }
}
