using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime.Tasks;

namespace Core.AI
{
    public class TurnAround : EnemyAction
    {
        public override TaskStatus OnUpdate()
        {
            var scale = this.gameObject.transform.localScale;
            scale.x *= -1;
            this.transform.localScale = scale;
            return TaskStatus.Success;
        }
    }
}

