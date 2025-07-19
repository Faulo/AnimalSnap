using Unity.Properties;
using UnityEngine;

namespace Game {
    [CreateAssetMenu]
    sealed class Snapshot : ScriptableObject {
        internal static Snapshot CreateFromCamera(Camera camera) {
            var snapshot = CreateInstance<Snapshot>();

            var texture = new RenderTexture(new RenderTextureDescriptor(camera.pixelWidth, camera.pixelHeight) {
                depthBufferBits = 8,
            });
            camera.targetTexture = texture;
            camera.Render();
            camera.targetTexture = null;

            snapshot.texture = texture;

            return snapshot;
        }

        [SerializeField]
        [CreateProperty]
        internal Texture texture;

        void OnDestroy() {
            if (texture) {
                Destroy(texture);
            }
        }
    }
}
