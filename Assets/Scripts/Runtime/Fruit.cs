using UnityEngine;

namespace Game {
    sealed class Fruit : MonoBehaviour {
        [SerializeField]
        internal FruitAsset asset;

        GameObject model;
    }
}
