namespace ApiPdtTechLeilao.Models
{
    public class Allotment
    {
        public int Id {get; set;}
        public string? Category {get; set;}
        public string? Description {get; set;}
        public float StartBuilding {get; set;}
        public string? City {get; set;}
        public string? State {get; set;}
        public string? Region {get; set;}
        public string? Title {get; set;}
        public string? OccupationStatus {get; set;}
        public string? Address {get; set;}
        public DateTime ClosingDate {get; set;}
        public string? Registration {get; set;}
        public string? Notice {get; set;}
    }
}
