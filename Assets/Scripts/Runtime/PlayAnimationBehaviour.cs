using UnityEngine;

namespace Game {
    public class PlayAnimationBehaviour : StateMachineBehaviour {
        [SerializeField]
        AnimalAnimation animation;
        [SerializeField]
        float fixedTransitionDuration = 0.2f;
        [SerializeField]
        float fixedTimeOffset = 0f;
        [SerializeField]
        float normalizedTransitionTime = 0f;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            foreach (Transform child in animator.transform) {
                if (child.TryGetComponent<Animator>(out var childAnimator)) {
                    childAnimator.CrossFadeInFixedTime(animation.ToString(), fixedTransitionDuration, 0, fixedTimeOffset, normalizedTransitionTime);
                    return;
                }
            }
        }
    }
}