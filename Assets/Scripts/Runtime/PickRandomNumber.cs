using UnityEngine;

namespace Game {
    sealed class PickRandomNumber : StateMachineBehaviour {
        [SerializeField]
        string parameterName = "randomNumber";
        [SerializeField]
        int mininum = 0;
        [SerializeField]
        int maximum = 10;
        [SerializeField]
        float waitDuration = 1f;

        float timer = 0;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            SetNumber(animator);
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            timer += Time.deltaTime;
            if (timer > waitDuration) {
                SetNumber(animator);
            }
        }

        void SetNumber(Animator animator) {
            timer = 0;
            animator.SetInteger(parameterName, Random.Range(mininum, maximum + 1));
        }
    }
}