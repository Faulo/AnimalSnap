using UnityEngine;

namespace Game {
    interface ISpawnable {
        bool canSpawn { get; }
        GameObject Spawn();
    }
}
