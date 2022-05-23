using CSharpCourse.MerchandiseApi.Domain.Root;

namespace CSharpCourse.MerchandiseApi.Domain.AggregationModels.SkuPreset
{
    /// <summary>
    /// Наборы мерча, выдываемые сотруднику
    /// </summary>
    public class PresetType : Enumeration
    {
        /// <summary>
        /// Мерч новому сотруднику
        /// </summary>
        public static PresetType WelcomePack = new(1, "welcome_pack");

        /// <summary>
        /// Мер слушателю конференции
        /// </summary>
        public static PresetType ConferenceListenerPack = new(2, "conference_listener_pack");

        /// <summary>
        /// Мерч спикеру
        /// </summary>
        public static PresetType ConferenceSpeakerPack = new(3, "conference_speaker_pack");

        /// <summary>
        /// Мерч, выдаваемый после завершения испытательного срока
        /// </summary>
        public static PresetType ProbationPeriodEndingPack = new(4, "probation_period_ending_pack");

        /// <summary>
        /// Мерч, выдаваемый сотруднику долго проработавшему в компании
        /// </summary>
        public static PresetType VeteranPack = new(5, "veteran_pack");

        private PresetType(int id, string name)
            : base(id, name)
        {
        }

        public static PresetType Parse(string size)
            => size?.ToUpper() switch
            {
                "welcome_pack" => WelcomePack,
                "conference_listener_pack" => ConferenceListenerPack,
                "conference_speaker_pack" => ConferenceSpeakerPack,
                "probation_period_ending_pack" => ProbationPeriodEndingPack,
                "veteran_pack" => VeteranPack,
                _ => throw new DomainException("Unknown preset type")
            };
    }
}
