using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuneEsportIFv2.Models;

namespace TuneEsportIFv2.Services.Interfaces
{
    public interface IGameService
    {
        List<Game> GetAllGames(Game game);

        Game GetGame(int id);

        void DeleteGame(Game game);

        void AddGame(Game game);

        void EditGame(Game uGame);
    }
}
