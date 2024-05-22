namespace Users.Dominio ;
using Common;

    public class Intensity : BaseDomainModel
    {
        public Intensity()
        {
            RecordTrainingSessions = new HashSet<RecordTrainingSession>();
        }

        public string Name { get; set; }
        public ICollection<RecordTrainingSession> RecordTrainingSessions { get; set; }
    }
