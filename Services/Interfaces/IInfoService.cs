using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuneEsportIFv2.Models;

namespace TuneEsportIFv2.Services.Interfaces
{
    public interface IInfoService
    {
        List<Info> GetAllInfo(Info info);

        Info GetInfo(int id);

        void DeleteInfo(Info info);

        void AddInfo(Info info);

        void EditInfo(Info uInfo);
    }
}
