using UnityEngine;

namespace Game {
    sealed class EatBehaviour : StateMachineBehaviour {
        [SerializeField]
        float eatDuration = 0.2f;

        float timer = 0;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            timer = 0;
            if (animator.TryGetComponent<AnimalBrain>(out var brain)) {
                brain.ClearDestination();
            }
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            timer += Time.deltaTime;
            if (timer > eatDuration) {
                timer = 0;
                if (animator.TryGetComponent<AnimalBrain>(out var brain)) {
                    brain.Eat();
                }
            }
        }
    }
}