using Slothsoft.UnityExtensions;
using UnityEngine;

namespace Game {
    sealed class GoToRandomPoint : StateMachineBehaviour {
        [SerializeField]
        float minDistance = 1f;
        [SerializeField]
        float maxDistance = 1f;

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            if (animator.TryGetComponent<AnimalBrain>(out var brain)) {
                if (!brain.hasDestination) {
                    var position = animator.transform.position;
                    position += (Random.Range(minDistance, maxDistance) * Random.insideUnitCircle).SwizzleXZ();
                    brain.SetDestination(position);
                }
            }
        }
    }
}