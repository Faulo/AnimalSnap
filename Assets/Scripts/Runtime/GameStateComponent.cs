using Slothsoft.UnityExtensions;
using UnityEngine;

namespace Game {
    sealed class GameStateComponent : MonoBehaviour {
        [SerializeField, Expandable]
        GameStateAsset asset;

        void OnEnable() {
            asset.ResetState();
        }

        void OnDisable() {
            asset.ResetState();
        }

        void Update() {
            asset.time += Time.deltaTime * asset.timeMultiplier;

            switch (asset.mode) {
                case GameMode.Night:
                    Time.timeScale = asset.timeScale;

                    if (asset.time >= asset.timeEnd) {
                        asset.time = asset.timeEnd;
                        asset.mode = GameMode.Day;
                    }

                    break;
                default:
                    Time.timeScale = 0;
                    break;
            }
        }
    }
}
