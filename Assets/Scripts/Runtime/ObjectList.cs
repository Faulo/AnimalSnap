using System;
using Unity.Properties;
using UnityEngine.UIElements;

namespace Game {
    [UxmlElement]
    sealed partial class ButtonList : SimpleListView {
        internal static readonly BindingId selectionProperty = new(nameof(selection));

        internal event Action<object> onSelectionChange;

        Button _selection;

        [UxmlAttribute]
        [CreateProperty]
        internal Button selection {
            get => _selection;
            set {
                if (_selection != value) {
                    _selection?.RemoveFromClassList("active");
                    _selection = value;
                    _selection?.AddToClassList("active");
                    NotifyPropertyChanged(selectionProperty);
                    onSelectionChange?.Invoke(value);
                }
            }
        }

        public ButtonList() {
        }

        protected override void Rebuild() {
            base.Rebuild();

            foreach (var element in elements) {
                if (element is Button button) {
                    button.clicked += () => {
                        if (selection == button) {
                            selection = null;
                        } else {
                            selection = button;
                        }
                    };
                }
            }
        }
    }
}