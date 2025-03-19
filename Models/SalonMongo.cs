public class SalonMongo
{
    public string Edificio { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Uso { get; set; } = string.Empty;
    public decimal Largo { get; set; }
    public decimal Ancho { get; set; }
    public int Capacidad { get; set; }
    public List<string> Grupos { get; set; }
}
