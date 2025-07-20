using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

namespace Game {
    [UxmlElement]
    sealed partial class PlaybackButtons : VisualElement {
        internal static readonly BindingId scaleProperty = new(nameof(scale));

        readonly Dictionary<TimeScale, Button> buttons = new() {
            [TimeScale.Stop] = new(),
            [TimeScale.Pause] = new(),
            [TimeScale.Slow] = new(),
            [TimeScale.Mid] = new(),
            [TimeScale.Fast] = new(),
            [TimeScale.Fastest] = new(),
        };

        readonly Image _image = new() {
            scaleMode = ScaleMode.ScaleAndCrop,
        };

        public PlaybackButtons() {
            foreach (var (mode, button) in buttons) {
                button.clicked += () => scale = mode;

                Add(button);
            }
        }

        TimeScale _scale;

        [UxmlAttribute]
        [CreateProperty]
        TimeScale scale {
            get => _scale;
            set {
                buttons[_scale].RemoveFromClassList("active");
                _scale = value;
                buttons[_scale].AddToClassList("active");

                NotifyPropertyChanged(scaleProperty);
            }
        }

        [UxmlAttribute]
        [CreateProperty]
        public Sprite stopSprite {
            get => buttons[TimeScale.Stop].style.backgroundImage.value.sprite;
            set => buttons[TimeScale.Stop].style.backgroundImage = new(value);
        }

        [UxmlAttribute]
        [CreateProperty]
        public Sprite pauseSprite {
            get => buttons[TimeScale.Pause].style.backgroundImage.value.sprite;
            set => buttons[TimeScale.Pause].style.backgroundImage = new(value);
        }

        [UxmlAttribute]
        [CreateProperty]
        public Sprite slowSprite {
            get => buttons[TimeScale.Slow].style.backgroundImage.value.sprite;
            set => buttons[TimeScale.Slow].style.backgroundImage = new(value);
        }

        [UxmlAttribute]
        [CreateProperty]
        public Sprite midSprite {
            get => buttons[TimeScale.Mid].style.backgroundImage.value.sprite;
            set => buttons[TimeScale.Mid].style.backgroundImage = new(value);
        }

        [UxmlAttribute]
        [CreateProperty]
        public Sprite fastSprite {
            get => buttons[TimeScale.Fast].style.backgroundImage.value.sprite;
            set => buttons[TimeScale.Fast].style.backgroundImage = new(value);
        }

        [UxmlAttribute]
        [CreateProperty]
        public Sprite fastestSprite {
            get => buttons[TimeScale.Fastest].style.backgroundImage.value.sprite;
            set => buttons[TimeScale.Fastest].style.backgroundImage = new(value);
        }
    }
}