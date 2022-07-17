using UnityEngine;
using System.Collections;
using Core.Util;
using DG.Tweening;
using Core.Character;
using BehaviorDesigner.Runtime.Tasks;

namespace Core.AI
{
    public class DestroyBoss : EnemyAction
    {
        public float bleedTime;
        public ParticleSystem bleedSystem;
        public ParticleSystem explodeSystem;

        private bool isDestroy = false;
        public override void OnStart()
        {
            EffectManager.Instance.PlayOneShot(bleedSystem, this.gameObject.transform.position);
            DOVirtual.DelayedCall(bleedTime, ()=> {

                EffectManager.Instance.PlayOneShot(explodeSystem, this.transform.position);
                CameraController.Instance.ShakeCamera(0.7f);
                GameObject.Destroy(this.gameObject);

                isDestroy = true;
            }
            , false);
        }

        public override TaskStatus OnUpdate()
        {
            if (isDestroy)
            {
                return TaskStatus.Success;
            }
            return TaskStatus.Running;
        }
    }
}