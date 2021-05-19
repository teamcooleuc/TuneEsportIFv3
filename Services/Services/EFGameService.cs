using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuneEsportIFv2.Data;
using TuneEsportIFv2.Models;
using TuneEsportIFv2.Services.Interfaces;

namespace TuneEsportIFv2.Services.Services
{
    public class EFGameService : IGameService
    {
        private ApplicationDbContext context;
        public EFGameService(ApplicationDbContext service)
        {
            context = service;
        }
        public void AddGame(Game game)
        {
            context.Add(game);
            context.SaveChanges();
        }

        public void EditGame(Game uGame)
        {
            context.Games.Update(uGame);
            context.SaveChanges();
        }

        public void DeleteGame(Game game)
        {
            context.Games.Remove(game);
            context.SaveChanges();
        }

        public List<Game> GetAllGames(Game game)
        {
            return context.Games.ToList();
        }

        public Game GetGame(int id)
        {
            var game = context.Games.FirstOrDefault(m => m.gameID == id);
            return game;
        }
    }
}
