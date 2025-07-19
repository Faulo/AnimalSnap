using Slothsoft.UnityExtensions;
using UnityEngine;

namespace Game {
    sealed class Sun : MonoBehaviour {
        [SerializeField]
        GameStateAsset asset;

        void Update() {
            float t = asset.time / 86400f;
            float elevation = Mathf.Cos((t * 2 * Mathf.PI) + Mathf.PI) * 90f;

            transform.rotation = Quaternion.Euler(transform.eulerAngles.WithX(elevation));
        }
    }
}