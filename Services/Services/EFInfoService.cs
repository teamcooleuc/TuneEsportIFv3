using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuneEsportIFv2.Data;
using TuneEsportIFv2.Models;
using TuneEsportIFv2.Services.Interfaces;

namespace TuneEsportIFv2.Services.Services
{
    public class EFInfoService : IInfoService
    {
        private ApplicationDbContext context;

        public EFInfoService(ApplicationDbContext service)
        {
            context = service;
        }

        public void AddInfo(Info info)
        {
            context.Add(info);
            context.SaveChanges();
        }

        public void EditInfo(Info uInfo)
        {
            context.Infos.Update(uInfo);
            context.SaveChanges();
        }

        public void DeleteInfo(Info info)
        {
            context.Infos.Remove(info);
            context.SaveChanges();
        }

        public List<Info> GetAllInfo(Info info)
        {
            return context.Infos.ToList();
        }

        public Info GetInfo(int id)
        {
            var info = context.Infos.FirstOrDefault(m => m.infoId == id);
            return info;
        }
    }
}
