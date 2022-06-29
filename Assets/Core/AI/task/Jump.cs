using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime.Tasks;
using DG.Tweening;
using Core.Character;

namespace Core.AI
{
    public class Jump : EnemyAction
    {

        public float horForce = 5;
        public float jumpForce = 10;

        public float buildupJump;
        public float jumpTime;

        public string animationTriggerName;
        public bool shakeCameraOnLanding;

        private bool isLanded = false;

        private Tween jumpTween;
        private Tween buildupTween;

        // Use this for initialization
        public override void OnStart()
        {
            buildupTween = DOVirtual.DelayedCall(buildupJump, startJump);
            animator.SetTrigger(animationTriggerName);
        }

        public void startJump()
        {
            float direction = player.transform.position.x < transform.position.x ? -1 : 1;
            body.AddForce(new Vector2(horForce * direction, jumpForce), ForceMode2D.Impulse);
            jumpTween = DOVirtual.DelayedCall(jumpTime, () =>
            {
                isLanded = true;
                if (shakeCameraOnLanding)
                    CameraController.Instance.ShakeCamera(0.2f);
            });
        }

        // Update is called once per frame
        public override TaskStatus OnUpdate()
        {
            if (isLanded) return TaskStatus.Success;
            return TaskStatus.Running;
        }

        public override void OnEnd()
        {
            buildupTween.Kill();
            jumpTween.Kill();
            isLanded = false;
        }
    }
}

