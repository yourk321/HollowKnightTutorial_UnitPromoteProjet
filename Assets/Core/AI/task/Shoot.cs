using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Combat;
using Core.Character;
using BehaviorDesigner.Runtime.Tasks;

namespace Core.AI {

    public class Shoot :EnemyAction
    {
        public Weapon weapon;

        public bool isShakeCamera;

        public override void OnStart()
        {
        }

        public override TaskStatus OnUpdate()
        {
            //foreach (var weapon in weapons)
            {
                var projectile = Object.Instantiate(weapon.projectilePrefab, weapon.weaponTransform.position, Quaternion.identity);
                projectile.Shooter = this.gameObject;

                //保证子弹和boss是一个方向
                var force = new Vector2(weapon.horizontalForce * transform.localScale.x, weapon.verticalForce);
                projectile.SetForce(force);

                if (isShakeCamera)
                    CameraController.Instance.ShakeCamera(0.2f);
            }
            return TaskStatus.Success;
        }
    }
}
