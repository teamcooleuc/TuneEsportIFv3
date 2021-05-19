using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuneEsportIFv2.Models;

namespace TuneEsportIFv2.Services.Interfaces
{
    public interface IMapService
    {
        List<Map> GetAllMaps(Map map);

        Map GetMap(int id);

        void DeleteMap(Map map);

        void AddMap(Map map);

        void EditMap(Map uMap);

        // void Attach(Map map);
    }
}
