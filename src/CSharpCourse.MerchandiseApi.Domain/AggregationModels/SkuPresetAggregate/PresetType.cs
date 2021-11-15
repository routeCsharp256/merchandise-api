using CSharpCourse.MerchandiseApi.Domain.Models;

namespace CSharpCourse.MerchandiseApi.Domain.AggregationModels.SkuPresetAggregate
{
    public class PresetType : Enumeration
    {
        public static PresetType WelcomePack = new(1, "welcome_pack");
        public static PresetType ConferenceListenerPack = new(2, "conference_listener_pack");
        public static PresetType ConferenceSpeakerPack = new(3, "conference_speaker_pack");
        public static PresetType ProbationPeriodEndingPack = new(4, "probation_period_ending_pack");
        public static PresetType VeteranPack = new(5, "veteran_pack");
        
        public PresetType(int id, string name) : base(id, name)
        {
        }
    }
}