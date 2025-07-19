using Unity.Properties;
using UnityEngine;

namespace Game {
    [CreateAssetMenu]
    sealed class GameStateAsset : ScriptableObject {
        internal const int MORNING = 6 * 60 * 60;
        internal const int NOON = 12 * 60 * 60;
        internal const int DAY = 24 * 60 * 60;

        [SerializeField]
        internal GameMode mode = GameMode.Nothing;

        [CreateProperty(ReadOnly = true)]
        bool showActionMenu => mode is GameMode.Day;

        [CreateProperty(ReadOnly = true)]
        bool showPlaybackMenu => mode is GameMode.Night;

        [CreateProperty(ReadOnly = true)]
        bool showCreditsMenu => mode is GameMode.Credits;

        [SerializeField]
        internal float time = NOON;

        internal float normalizedTime => time / DAY;

        int timeInSeconds => Mathf.RoundToInt(time);

        int timeInMinutes => Mathf.RoundToInt(time / 60);

        int timeInHours => Mathf.RoundToInt(time / 3600);

        int timeInDays => Mathf.CeilToInt(time / DAY);

        [SerializeField]
        internal int timeMultiplier = 60;

        [CreateProperty(ReadOnly = true)]
        string timeString => $"{timeInHours % 24:D2}:{timeInMinutes % 60:D2}";

        [CreateProperty(ReadOnly = true)]
        string dayString => $"Day {timeInDays}";

        [SerializeField]
        float sunStrength = 1;

        internal float sunIntensity => sunStrength * Mathf.Clamp01(Mathf.Cos((normalizedTime * 2 * Mathf.PI) + Mathf.PI));
    }
}