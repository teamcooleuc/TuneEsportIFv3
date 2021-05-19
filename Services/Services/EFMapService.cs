using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuneEsportIFv2.Data;
using TuneEsportIFv2.Models;
using TuneEsportIFv2.Services.Interfaces;

namespace TuneEsportIFv2.Services.Services
{
    public class EFMapService : IMapService
    {
        private ApplicationDbContext context;

        public EFMapService(ApplicationDbContext service)
        {
            context = service;
        }

        public void AddMap(Map map)
        {
            context.Add(map);
            context.SaveChanges();
        }

        public void EditMap(Map uMap)
        {
            context.Maps.Update(uMap);
            context.SaveChanges();
        }

        public void DeleteMap(Map map)
        {
            context.Maps.Remove(map);
            context.SaveChanges();
        }

        public List<Map> GetAllMaps(Map map)
        {
            return context.Maps.ToList();
        }

        public Map GetMap(int id)
        {
            var map = context.Maps.FirstOrDefault(m => m.mapsId == id);
            return map;
        }



    }
}
