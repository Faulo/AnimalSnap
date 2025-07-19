using Slothsoft.UnityExtensions;
using UnityEngine;

namespace Game {
    sealed class GameStateComponent : MonoBehaviour {
        [SerializeField, Expandable]
        GameStateAsset asset;

        void Start() {
            asset.time = 12 * 60 * 60;
            asset.mode = GameMode.Day;
        }

        void FixedUpdate() {
            switch (asset.mode) {
                case GameMode.Night:
                    asset.time += Time.deltaTime * asset.timeMultiplier;
                    break;
            }
        }
    }
}
