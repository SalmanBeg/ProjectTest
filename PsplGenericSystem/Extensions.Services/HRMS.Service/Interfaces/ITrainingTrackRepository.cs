using HRMS.Service.Models.EDM;
using HRMS.Service.Models.ExtensionProc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Service.Interfaces
{
    public interface ITrainingTrackRepository
    {
        List<TrainingTrack> SelectAllTrainingTrack(int companyId);

        bool AddTrainingTrack(TrainingTrack trainingTrackObj, List<ExtendedStoredProcedures.UdtTrainingClassIds> lstUdtTrainingClassIds);

        TrainingTrack SelectTrainingTrackById(int companyId, int trainingTrackId);

        bool UpdateTrainingTrack(TrainingTrack trainingTrackObj, List<ExtendedStoredProcedures.UdtTrainingClassIds> lstUdtTrainingClassIds);

        TrainingTrackClass SelectTrainingTrackClassById(int trainingTrackClassId);

        List<TrainingTrackClass> SelectAllTrainingTrackClass();

        bool DeletTrainingTrack(int companyId, int trainingTrackId);
    }
}
