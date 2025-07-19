using Unity.Properties;
using UnityEngine;

namespace Game {
    [CreateAssetMenu]
    sealed class GameStateAsset : ScriptableObject {
        [SerializeField]
        internal GameMode mode = GameMode.Nothing;

        [CreateProperty(ReadOnly = true)]
        bool showActionMenu => mode is GameMode.Day;

        [CreateProperty(ReadOnly = true)]
        bool showPlaybackMenu => mode is GameMode.Night;

        [SerializeField]
        internal float time = 12 * 60 * 60;

        int timeInSeconds => Mathf.RoundToInt(time);

        int timeInMinutes => Mathf.RoundToInt(time / 60);

        int timeInHours => Mathf.RoundToInt(time / 3600);

        [SerializeField]
        internal int timeMultiplier = 60;

        [CreateProperty(ReadOnly = true)]
        string timeString => $"{timeInHours % 24:D2}:{timeInMinutes % 60:D2}";
    }
}