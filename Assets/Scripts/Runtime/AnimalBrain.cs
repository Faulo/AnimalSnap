using UnityEngine;
using UnityEngine.AI;

namespace Game {
    sealed class AnimalBrain : MonoBehaviour {
        [SerializeField]
        Animator animator;
        [SerializeField]
        NavMeshAgent agent;

        public bool hasDestination {
            get => animator.GetBool(nameof(hasDestination));
            set => animator.SetBool(nameof(hasDestination), value);
        }

        void Start() {
            agent.avoidancePriority = Random.Range(0, 100);
        }

        void FixedUpdate() {
            hasDestination = agent.hasPath;
        }

        internal bool SetDestination(in Vector3 targetPosition) {
            if (NavMesh.SamplePosition(targetPosition, out var hit, float.PositiveInfinity, NavMesh.AllAreas)) {
                agent.SetDestination(hit.position);
                return true;
            }

            return false;
        }
    }
}