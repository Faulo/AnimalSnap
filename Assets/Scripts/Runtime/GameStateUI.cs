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
        [SerializeField]
        Camera attachedCamera;

        SimpleListView snapshotsList;

        void Start() {
            RegisterCallback("Sleep", asset.Sleep);
            RegisterCallback("Credits", () => asset.mode = GameMode.Credits);
            RegisterCallback("Help", () => asset.mode = GameMode.Help);
            RegisterCallback("Back", () => asset.mode = GameMode.Day);
            RegisterCallback("Quit", OnQuit);
            RegisterCallback("Camera", OnCamera);

            InitializeObjects();

            InitializeSnapshots();

            InitializePlaybackButtons();
        }

        void InitializeObjects() {
            var container = document.rootVisualElement.Q<VisualElement>("Objects");

            var list = new SimpleListView {
                makeItem = () => {
                    var item = new ObjectThumbnail();
                    item.SetBinding(ObjectThumbnail.textureProperty, new DataBinding() {
                        dataSourcePath = new(nameof(FruitAsset.texture)),
                        bindingMode = BindingMode.ToTarget,
                    });
                    return item;
                },
                itemsSource = asset.objects,
            };

            container.Add(list);
        }

        void InitializeSnapshots() {
            var snapshotsContainer = document.rootVisualElement.Q<VisualElement>("Snapshots");

            snapshotsList = new SimpleListView {
                makeItem = () => {
                    var item = new SnapshotThumbnail();
                    item.SetBinding(SnapshotThumbnail.textureProperty, new DataBinding() {
                        dataSourcePath = new(nameof(Snapshot.texture)),
                        bindingMode = BindingMode.ToTarget,
                    });
                    return item;
                },
                itemsSource = asset.snapshots,
            };

            snapshotsContainer.Add(snapshotsList);
        }

        void InitializePlaybackButtons() {
            var playbackButtons = document.rootVisualElement.Q<PlaybackButtons>();
            playbackButtons.SetBinding(PlaybackButtons.scaleProperty, new DataBinding() {
                dataSourcePath = new(nameof(GameStateAsset.timeScaleMode)),
                bindingMode = BindingMode.TwoWay,
            });
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

        [SerializeField]
        Snapshot lastSnapshot;

        void OnCamera() {
            lastSnapshot = Snapshot.CreateFromCamera(attachedCamera);
            asset.snapshots.Add(lastSnapshot);
            snapshotsList.Update();
        }
    }
}
