using System.Linq;
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

        public bool canEat {
            get => animator.GetBool(nameof(canEat));
            set => animator.SetBool(nameof(canEat), value);
        }

        void Start() {
            agent.avoidancePriority = Random.Range(0, 100);
        }

        [SerializeField]
        Transform mouth;
        [SerializeField]
        float eatRadius = 0.5f;
        [SerializeField]
        LayerMask eatLayers;

        readonly Collider[] eatColliders = new Collider[8];
        int eatColliderCount;

        void FixedUpdate() {
            hasDestination = agent.hasPath;
            eatColliderCount = Physics.OverlapSphereNonAlloc(mouth.transform.position, eatRadius, eatColliders, eatLayers);
            canEat = eatColliderCount > 0;
        }

        Rigidbody closestFruit => eatColliders
            .Take(eatColliderCount)
            .Where(c => c)
            .OrderBy(c => Vector3.Distance(mouth.transform.position, c.transform.position))
            .Select(c => c.attachedRigidbody)
            .FirstOrDefault();

        internal void Eat() {
            var fruit = eatColliders
                .Take(eatColliderCount)
                .Where(c => c)
                .OrderBy(c => Vector3.Distance(mouth.transform.position, c.transform.position))
                .FirstOrDefault();

            if (fruit) {
                Destroy(fruit.gameObject);
            }
        }

        internal bool SetDestination(in Vector3 targetPosition) {
            if (NavMesh.SamplePosition(targetPosition, out var hit, float.PositiveInfinity, NavMesh.AllAreas)) {
                agent.SetDestination(hit.position);
                return true;
            }

            return false;
        }

        internal void ClearDestination() {
            var fruit = closestFruit;
            if (closestFruit) {
                agent.SetDestination(closestFruit.worldCenterOfMass);
            } else {
                agent.SetDestination(transform.position);
            }
        }
    }
}