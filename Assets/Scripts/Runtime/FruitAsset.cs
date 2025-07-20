using Unity.Properties;
using UnityEngine;

namespace Game {
    [CreateAssetMenu]
    sealed class FruitAsset : ScriptableObject {
        [SerializeField]
        internal GameObject prefab;

        [SerializeField]
        [CreateProperty]
        internal Texture texture;
    }
}
