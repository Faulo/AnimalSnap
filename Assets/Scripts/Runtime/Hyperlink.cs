using UnityEngine;
using UnityEngine.UIElements;

namespace Game {
    [UxmlElement]
    sealed partial class Hyperlink : Label {
        string _href;

        [UxmlAttribute]
        public string href {
            get => _href;
            set {
                _href = value;
                tooltip = _href;
            }
        }

        public Hyperlink() {
            AddToClassList(ussClassName);
            RegisterCallback<ClickEvent>(_ => {
                if (!string.IsNullOrEmpty(_href)) {
                    Application.OpenURL(_href);
                }
            });
        }
    }
}