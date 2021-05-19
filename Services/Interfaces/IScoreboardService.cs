using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TuneEsportIFv2.Areas.Identity.Data;
using TuneEsportIFv2.Models;

namespace TuneEsportIFv2.Services.Interfaces
{
    public interface IScoreBoardService
    {
        List<ScoreBoard> GetAllScoreBoards(ScoreBoard scoreBoard);

        ScoreBoard GetScoreBoard(int id);

        void DeleteScoreBoard(ScoreBoard scoreBoard);

        void AddScoreBoard(ScoreBoard scoreBoard);

        void EditScoreBoard(ScoreBoard uScoreBoard);

        void GetAllScoreBoardsByUserName(UserManager<TuneEsportIfv2User> AspUserName);

        // void Attach(Map map);
    }
}
