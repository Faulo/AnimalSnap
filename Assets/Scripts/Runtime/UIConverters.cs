using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace Game {
    static class UIConverters {
        static readonly StyleEnum<DisplayStyle> displayFlex = new(DisplayStyle.Flex);
        static readonly StyleEnum<DisplayStyle> displayNone = new(DisplayStyle.None);

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#endif
        static void Register() {
            ConverterGroups.RegisterGlobalConverter((ref bool value) => value ? displayFlex : displayNone);
            ConverterGroups.RegisterGlobalConverter((ref DateTime value) => $"{value.Year:D4} {value.Month:D2} {value.Day:D2}");
        }
    }
}