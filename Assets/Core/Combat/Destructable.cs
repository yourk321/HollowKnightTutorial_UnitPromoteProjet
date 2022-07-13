﻿using System;
using UnityEngine;

namespace Core.Combat
{
    public class Destructable : Hittable
    {
        public int health = 10;

        public int CurrentHealth { get; set; }
        public bool Invincible { get; set; }

        public event Action OnDestroyed;

        protected override void Awake()
        {
            base.Awake();
            CurrentHealth = health;
            Invincible = false;
        }

        public override void OnAttackHit(Vector2 position, Vector2 force, int damage)
        {
            if (CurrentHealth <= 0 || Invincible)
                return;

            DealDamage(damage);

            base.OnAttackHit(position, force, damage); // Order of this call is important
        }

        public void DealDamage(int damage)
        {
            CurrentHealth -= damage;
            Debug.LogError("boss hurt!");
            if (CurrentHealth <= 0)
            {
                Debug.LogError("boss DEAD!");
                OnDestroyed?.Invoke();
            }
        }

        public void Revive()
        {
            CurrentHealth = health;
        }
    }
}