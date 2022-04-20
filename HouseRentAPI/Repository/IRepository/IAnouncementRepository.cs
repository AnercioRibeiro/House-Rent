using HouseRentAPI.Models;
using System.Collections.Generic;

namespace HouseRentAPI.Repository.IRepository
{
    public interface IAnouncementRepository
    {
        Anouncement GetAnouncement(int anouncementId);
        ICollection<Anouncement> GetAnouncements();
        bool AnouncementExists(int identifier);
        bool CreateAnouncement(Anouncement anouncement);
        bool UpdateAnouncement(Anouncement anouncement);
        bool DeleteAannouncement(Anouncement anouncement);
        bool SearchAnouncementByProvince();
        string GenerateRandomIdentifier(int identifier);

    }
}
