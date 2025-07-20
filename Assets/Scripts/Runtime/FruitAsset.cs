using Unity.Properties;
using UnityEngine;

namespace Game {
    [CreateAssetMenu]
    sealed class FruitAsset : ScriptableObject, ISpawnable {
        [SerializeField]
        internal GameObject prefab;

        [SerializeField]
        [CreateProperty]
        internal Texture texture;

        public bool canSpawn => prefab;

        public GameObject Spawn() => Instantiate(prefab);
    }
}
