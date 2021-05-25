using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuneEsportIFv2.Models;

namespace TuneEsportIFv2.Services.Interface
{
    interface ITrainingStatService
    {
        IEnumerable<TrainingStats> GetAllTrainingStats();
        TrainingStats GetTrainingStat(int id);

        void DeleteTrainingStat(TrainingStats trainingStats);

        void AddTrainingStat(TrainingStats trainingStats);

        void EditTrainingStat(TrainingStats trainingStats);


    }
}
