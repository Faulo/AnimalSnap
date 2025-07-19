using UnityEngine;
using UnityEngine.UIElements;

namespace Game {
    static class BoolToDisplayStyleConverter {
        static readonly StyleEnum<DisplayStyle> displayFlex = new(DisplayStyle.Flex);
        static readonly StyleEnum<DisplayStyle> displayNone = new(DisplayStyle.None);

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#endif
        static void Register() {
            ConverterGroups.RegisterGlobalConverter((ref bool value) => value ? displayFlex : displayNone);
        }
    }
}