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
        public IEnumerable<TrainingStat> GetAllTrainingStats()
        {
            return context.TrainingStats.ToList();
        }

        public TrainingStat GetTrainingStat(int id)
        {
            var trainingStat = context.TrainingStats.FirstOrDefault(t => t.TrainingStatId == id);
            return trainingStat;
        }

        public void DeleteTrainingStat(TrainingStat trainingStat)
        {
            context.TrainingStats.Remove(trainingStat);
            context.SaveChanges();
        }

        public void AddTrainingStat(TrainingStat trainingStat)
        {
            context.Add(trainingStat);
            context.SaveChanges();
        }

        public void EditTrainingStat(TrainingStat trainingStat)
        {
            context.TrainingStats.Update(trainingStat);
            context.SaveChanges();
        }
    }
}
