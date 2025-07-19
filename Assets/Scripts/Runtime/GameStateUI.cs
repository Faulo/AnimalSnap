using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

namespace Game {
    sealed class GameStateUI : MonoBehaviour {
        [SerializeField]
        UIDocument document;
        [SerializeField]
        GameStateAsset asset;

        void Start() {
            RegisterCallback("Sleep", asset.Sleep);
            RegisterCallback("Credits", () => asset.mode = GameMode.Credits);
            RegisterCallback("Back", () => asset.mode = GameMode.Day);

            document.rootVisualElement.Q<Button>("Quit").clicked += OnQuit;
        }

        void RegisterCallback(string name, Action callback) {
            foreach (var button in document.rootVisualElement.Query(name).Build().OfType<Button>()) {
                button.clicked += callback;
            }
        }

        void OnCredits() {
            asset.mode = GameMode.Credits;
        }

        void OnQuit() {
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
#endif
        }
    }
}
