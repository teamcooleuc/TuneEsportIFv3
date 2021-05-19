using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TuneEsportIFv2.Areas.Identity.Data;
using TuneEsportIFv2.Data;
using TuneEsportIFv2.Models;
using TuneEsportIFv2.Services.Interfaces;

namespace TuneEsportIFv2.Services.Services
{
    public class EFScoreBoardService : IScoreBoardService
    {
        private ApplicationDbContext context;
        private readonly UserManager<TuneEsportIfv2User> _userManager;

        public EFScoreBoardService(ApplicationDbContext service, UserManager<TuneEsportIfv2User> userManager)
        {
            context = service;
            _userManager = userManager;
        }

        public void AddScoreBoard(ScoreBoard scoreBoard)
        {
            context.Add(scoreBoard);
            context.SaveChanges();
        }

        public void EditScoreBoard(ScoreBoard uScoreBoard)
        {
            context.ScoreBoards.Update(uScoreBoard);
            context.SaveChanges();
        }

        public void DeleteScoreBoard(ScoreBoard scoreBoard)
        {
            context.ScoreBoards.Remove(scoreBoard);
            context.SaveChanges();
        }

        public List<ScoreBoard> GetAllScoreBoards(ScoreBoard scoreBoard)
        {
            return context.ScoreBoards.ToList();
        }

        public ScoreBoard GetScoreBoard(int id)
        {
            var ScoreBoard = context.ScoreBoards.FirstOrDefault(s => s.ScoreId == id);
            return ScoreBoard;
        }

        public void GetAllScoreBoardsByUserName(UserManager<TuneEsportIfv2User> AspUserName)
        {

            var ScoreBoard = context.ScoreBoards.Find(AspUserName);
        }



    }
}
