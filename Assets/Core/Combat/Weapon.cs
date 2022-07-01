using System;
using Core.Combat.Projectiles;
using UnityEngine;

namespace Core.Combat
{
    [Serializable]
    public class Weapon
    {
        public Transform weaponTransform;
        public AbstractProjectile projectilePrefab;
        //水平方向的力
        public float horizontalForce = 5.0f;
        //垂直方向的力
        public float verticalForce = 4.0f;
    }
}