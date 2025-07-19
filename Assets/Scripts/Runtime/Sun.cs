using UnityEngine;

namespace Game {
    sealed class Sun : MonoBehaviour {
        [SerializeField]
        Light attachedLight;
        [SerializeField]
        GameStateAsset asset;
        [SerializeField]
        Vector3 referencePosition = Vector3.one;

        void LateUpdate() {
            var position = referencePosition;
            position.x = Mathf.Sin((asset.normalizedTime * 2 * Mathf.PI) + Mathf.PI);
            position.y = Mathf.Cos((asset.normalizedTime * 2 * Mathf.PI) + Mathf.PI);

            transform.position = position;
            transform.LookAt(Vector3.zero);

            attachedLight.intensity = asset.sunIntensity;
        }
    }
}