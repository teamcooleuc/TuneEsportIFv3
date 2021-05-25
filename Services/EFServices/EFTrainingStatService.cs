using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuneEsportIFv2.Data;
using TuneEsportIFv2.Models;
using TuneEsportIFv2.Services.Interface;

namespace TuneEsportIFv2.Services.EFServices
{
    public class EFTrainingStatService : ITrainingStatService
    {
        private ApplicationDbContext context;

        public EFTrainingStatService(ApplicationDbContext service)
        {
            context = service;
        }
        public IEnumerable<TrainingStats> GetAllTrainingStats()
        {
            return context.TrainingStats.ToList();
        }

        public TrainingStats GetTrainingStat(int id)
        {
            var trainingStat = context.TrainingStats.FirstOrDefault(t => t.TrainingStatId == id);
            return trainingStat;
        }

        public void DeleteTrainingStat(TrainingStats trainingStat)
        {
            context.TrainingStats.Remove(trainingStat);
            context.SaveChanges();
        }

        public void AddTrainingStat(TrainingStats trainingStat)
        {
            context.Add(trainingStat);
            context.SaveChanges();
        }

        public void EditTrainingStat(TrainingStats trainingStat)
        {
            context.TrainingStats.Update(trainingStat);
            context.SaveChanges();
        }
    }
}
