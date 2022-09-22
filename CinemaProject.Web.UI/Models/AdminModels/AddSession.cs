namespace CinemaProject.Models.AdminModels
{
    public class AddSession
    {
        public long MovieId { get; set; }
        public long HallId { get; set; }
        public long CinamaId { get; set; }
        public long DemonstrationId { get; set; }
        public string SessionTime { get; set; }
        public string SessionLasts { get; set; }
        public string SessionDate { get; set; }
    }
}
