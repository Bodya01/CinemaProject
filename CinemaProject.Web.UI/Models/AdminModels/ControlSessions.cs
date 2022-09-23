using CinemaProject.Data;
using CinemaProject.Data.Models.Entities;
using System.Collections.Generic;

namespace CinemaProject.Models.AdminModels
{
    public class ControlSessions
    {
        public long SessionId { get; set; }
        public long MovieId { get; set; }
        public long CinemaId { get; set; }
        public long HallId { get; set; }
        public long DemonstrationId { get; set; }
        public string SessionDate { get; set; }
        public string SessionTime { get; set; }
        public string SessionEnds { get; set; }
        public string SessionLasts { get; set; }
        public List<Session> Sessions { get; set; }
    }
}
