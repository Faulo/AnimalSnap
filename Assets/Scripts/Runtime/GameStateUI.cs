using UnityEngine;
using UnityEngine.UIElements;

namespace Game {
    sealed class GameStateUI : MonoBehaviour {
        [SerializeField]
        UIDocument document;
        [SerializeField]
        GameStateAsset asset;

        void Start() {
            document.rootVisualElement.Q<Button>("Sleep").clicked += OnSleep;
        }

        void OnSleep() {
            asset.mode = GameMode.Night;
        }
    }
}
