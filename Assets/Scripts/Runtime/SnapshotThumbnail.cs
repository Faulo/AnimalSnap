using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

namespace Game {
    [UxmlElement]
    sealed partial class SnapshotThumbnail : VisualElement {
        internal static readonly BindingId textureProperty = new(nameof(texture));

        readonly Image _image = new() {
            scaleMode = ScaleMode.ScaleAndCrop,
        };

        public SnapshotThumbnail() {
            Add(_image);
        }

        [UxmlAttribute]
        [CreateProperty]
        public Texture texture {
            get => _image.image;
            set => _image.image = value;
        }
    }
}