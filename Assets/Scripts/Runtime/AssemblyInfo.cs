using System.Runtime.CompilerServices;
using Game;

[assembly: InternalsVisibleTo(AssemblyInfo.NAMESPACE_EDITOR)]
[assembly: InternalsVisibleTo(AssemblyInfo.NAMESPACE_TESTS_EDITMODE)]
[assembly: InternalsVisibleTo(AssemblyInfo.NAMESPACE_TESTS_PLAYMODE)]
[assembly: InternalsVisibleTo(AssemblyInfo.NAMESPACE_PROXYGEN)]

namespace Game {
    static class AssemblyInfo {
        public const string NAMESPACE_RUNTIME = "Game";
        public const string NAMESPACE_EDITOR = "Game.Editor";
        public const string NAMESPACE_TESTS_EDITMODE = "Game.Tests.EditMode";
        public const string NAMESPACE_TESTS_PLAYMODE = "Game.Tests.PlayMode";

        public const string NAMESPACE_PROXYGEN = "DynamicProxyGenAssembly2";
    }
}