using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;

namespace Core.AI
{
    public class SetHealth : EnemyAction
    {
        public SharedInt Health;
     
        public override TaskStatus OnUpdate()
        {
            hazardCollider.enabled = true;
            destructable.CurrentHealth = Health.Value;
            return TaskStatus.Success;
        }
    }

}
