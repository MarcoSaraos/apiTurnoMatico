namespace apiTurnoMatico.Model.DTO
{
    public class DTOOficina
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }
        public int Aforo { get; set; }
        public int CajasDisponibles { get; set; }
        public bool esMoto { get; set; }

    }
}
