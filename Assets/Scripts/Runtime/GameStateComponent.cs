using Slothsoft.UnityExtensions;
using UnityEngine;

namespace Game {
    sealed class GameStateComponent : MonoBehaviour {
        [SerializeField, Expandable]
        GameStateAsset asset;

        void OnEnable() {
            ResetState();
        }

        void OnDisable() {
            ResetState();
        }

        void FixedUpdate() {
            switch (asset.mode) {
                case GameMode.Night:
                    asset.time += Time.deltaTime * asset.timeMultiplier;
                    if (asset.time >= GameStateAsset.DAY + GameStateAsset.NOON) {
                        asset.mode = GameMode.Day;
                    }

                    break;
            }
        }

        void ResetState() {
            asset.time = 12 * 60 * 60;
            asset.mode = GameMode.Day;
        }
    }
}
