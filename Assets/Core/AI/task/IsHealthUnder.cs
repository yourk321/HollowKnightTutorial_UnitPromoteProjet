using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;

namespace Core.AI
{
    public class IsHealthUnder : EnemyConditional
    {
        public SharedInt healthTreshold;
        //生命极限阈值
        
        public override TaskStatus OnUpdate()
        {
            
            if(destructable.CurrentHealth < healthTreshold.Value)
            {
                return TaskStatus.Success; 
            }
            return TaskStatus.Failure;
        }
    }
}

