using BehaviorDesigner.Runtime.Tasks;
using Core.Character;
using Core.Combat;
using UnityEngine;

namespace Core.AI
{
    public class EnemyAction : Action
    {
        protected Rigidbody2D body;
        protected BoxCollider2D attackCollider;
        protected Animator animator;
        protected Destructable destructable;
        protected PlayerController player;
        
        public override void OnAwake()
        {
            body = GetComponent<Rigidbody2D>();
            attackCollider =  this.transform.Find("attack collider").GetComponent<BoxCollider2D>();
            player = PlayerController.Instance;
            destructable = GetComponent<Destructable>();
            animator = gameObject.GetComponentInChildren<Animator>();
        }
    }
}