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

        void FixedUpdate() {
            switch (asset.mode) {
                case GameMode.Night:
                    asset.time += Time.deltaTime * asset.timeMultiplier;
                    if (asset.time >= asset.timeEnd) {
                        asset.mode = GameMode.Day;
                    }

                    break;
            }
        }
    }
}
