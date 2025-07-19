using System;
using System.Collections.Generic;
using System.Linq;
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
        [SerializeField]
        internal int timeEnd = DAY + NOON;

        internal float normalizedTime => time / DAY;

        int timeInSeconds => Mathf.RoundToInt(time);

        int timeInMinutes => Mathf.RoundToInt(time / 60);

        int timeInHours => Mathf.RoundToInt(time / 3600);

        int timeInDays => Mathf.FloorToInt(time / DAY);

        [SerializeField]
        internal int timeMultiplier = 60;

        [CreateProperty(ReadOnly = true)]
        string timeString => $"{timeInHours % 24:D2}:{timeInMinutes % 60:D2}";

        [CreateProperty(ReadOnly = true)]
        DateTime dayString => DateTime.Now.AddDays(timeInDays);

        [SerializeField]
        float sunStrength = 1;

        internal float sunIntensity => sunStrength * Mathf.Clamp01(Mathf.Cos((normalizedTime * 2 * Mathf.PI) + Mathf.PI));

        internal void SetTimeEnd() {
            timeEnd = (timeInDays * DAY) + DAY + NOON;
        }

        internal void Sleep() {
            SetTimeEnd();
            mode = GameMode.Night;
        }

        internal void ResetState() {
            time = 12 * 60 * 60;
            mode = GameMode.Day;
            SetTimeEnd();

            foreach (var snapshot in snapshots) {
                if (snapshot) {
                    if (startingSnapshots.Contains(snapshot)) {
                        continue;
                    }

                    Destroy(snapshot);
                }
            }

            snapshots.Clear();

            snapshots.AddRange(startingSnapshots);
        }

        [SerializeField]
        internal Snapshot[] startingSnapshots = Array.Empty<Snapshot>();

        [SerializeField]
        internal List<Snapshot> snapshots = new();
    }
}