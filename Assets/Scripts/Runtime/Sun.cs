using UnityEngine;

namespace Game {
    [ExecuteAlways]
    sealed class Sun : MonoBehaviour {
        [SerializeField]
        Light attachedLight;
        [SerializeField]
        GameStateAsset asset;
        [SerializeField]
        float sunDepth = 1;

        void LateUpdate() {
            if (!asset || !attachedLight) {
                return;
            }

            transform.position = new Vector3 {
                x = Mathf.Sin((asset.normalizedTime * 2 * Mathf.PI) + Mathf.PI),
                y = Mathf.Cos((asset.normalizedTime * 2 * Mathf.PI) + Mathf.PI),
                z = sunDepth
            };

            transform.LookAt(Vector3.zero);

            attachedLight.intensity = asset.sunIntensity;
        }
    }
}