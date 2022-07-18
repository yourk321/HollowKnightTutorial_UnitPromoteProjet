using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime.Tasks;

namespace Core.AI
{
    public class DeadDeal : EnemyAction
    {
        public override void OnStart()
        {
            attackCollider.enabled = false;//关闭攻击区域
        }

        public override TaskStatus OnUpdate()
        {
            return TaskStatus.Success;
        }
    }
}
