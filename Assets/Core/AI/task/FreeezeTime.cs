using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace Core.AI
{
    public class FreezeTime : EnemyAction
    {

        public SharedFloat duration = 0.1f;

        public override TaskStatus OnUpdate()
        {
            GameManager.Instance.FreezeTime(duration.Value);
            return TaskStatus.Success;

        }
    }
}
    
