using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime.Tasks;

namespace Core.AI{

    public class FacePlayer : EnemyAction
    { 
        private float baseScaleX;
        public override void OnStart()
        {
            base.OnAwake();
            baseScaleX = Mathf.Abs(transform.localScale.x);
      
        }

        public override TaskStatus OnUpdate()
        {
            var scale = transform.localScale;
            scale.x = transform.position.x > player.transform.position.x ? -baseScaleX : baseScaleX;
            Debug.LogError(scale.x);
            transform.localScale = scale;
            return TaskStatus.Success;
        }
    }

}
