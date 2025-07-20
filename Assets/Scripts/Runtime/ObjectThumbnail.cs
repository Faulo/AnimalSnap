using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

namespace Game {
    [UxmlElement]
    sealed partial class ObjectThumbnail : Button {
        internal static readonly BindingId textureProperty = new(nameof(texture));

        readonly Image _image = new() {
            scaleMode = ScaleMode.ScaleAndCrop,
        };

        public ObjectThumbnail() {
            Add(_image);
            AddToClassList(ussClassName);
            AddToClassList("thumbnail");
        }

        [UxmlAttribute]
        [CreateProperty]
        public Texture texture {
            get => _image.image;
            set => _image.image = value;
        }
    }
}