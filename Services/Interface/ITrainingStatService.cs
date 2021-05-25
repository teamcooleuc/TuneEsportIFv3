using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuneEsportIFv2.Models;

namespace TuneEsportIFv2.Services.Interface
{
    interface ITrainingStatService
    {
        IEnumerable<TrainingStat> GetAllTrainingStats();
        TrainingStat GetTrainingStat(int id);

        void DeleteTrainingStat(TrainingStat trainingStats);

        void AddTrainingStat(TrainingStat trainingStats);

        void EditTrainingStat(TrainingStat trainingStats);


    }
}
