using HouseRentAPI.Data;
using HouseRentAPI.Models;
using HouseRentAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HouseRentAPI.Repository
{
    public class AnouncementRepository : IAnouncementRepository
    {
        private readonly ApplicationDbContext _db;
        public AnouncementRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool AnouncementExists(int identifier)
        {
            bool value = _db.Anouncements.Any(a=>a.Identifier.ToString().Trim() == identifier.ToString().Trim());
            return value;
        }

        public bool CreateAnouncement(Anouncement anouncement)
        {
            _db.Anouncements.Add(anouncement);
            return Save();
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool DeleteAannouncement(Anouncement anouncement)
        {
            throw new System.NotImplementedException();
        }

        public Anouncement GetAnouncement(int anouncementId)
        {
            return _db.Anouncements.Include(p=>p.Province).FirstOrDefault(a=>a.Id == anouncementId);
        }

        public bool UpdateAnouncement(Anouncement anouncement)
        {
            _db.Anouncements.Update(anouncement);
            return Save();
        }

        public ICollection<Anouncement> GetAnouncements()
        {

            return _db.Anouncements.OrderBy(a => a.Id).ToList();
        }

        public bool SearchAnouncementByProvince()
        {
            throw new System.NotImplementedException();
        }

        public string GenerateRandomIdentifier(int identifier)
        {
            Random rnd = new Random();
            int ident = rnd.Next();
            if (AnouncementExists(ident))
            {
                return "";
            }
            return ""+ident;
        }
    }
}
