namespace Car_Salon_App.Entities
{
    public class Engine
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public double Capacity { get; set; }
        public string Display => $"{Capacity.ToString("F1")} {Type}";
        public ICollection<Car>? Cars { get; set; }
        
    }
}
