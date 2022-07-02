
using UnityEngine;
using System.Collections;
using Core.Combat;
using Core.Combat.Projectiles;
using BehaviorDesigner.Runtime.Tasks;
using DG.Tweening;

namespace Core.AI
{
    public class SpawnFallingRock : EnemyAction
    {
        public Collider2D spawnArea;
        public AbstractProjectile rockPrefab;
        public int spawCount = 4;
        public float spawInterval = 0.3f;


        public override TaskStatus OnUpdate()
        {
            var seq = DOTween.Sequence();
            for (int i=0; i<spawCount; i++)
            {
                seq.AppendCallback(spawIns);
                seq.AppendInterval(spawInterval);
            }
            
            return TaskStatus.Success;
        }

        private void spawIns()
        {
            float x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
            var rock = Object.Instantiate(rockPrefab, new Vector3(x, spawnArea.bounds.min.y), Quaternion.identity);
            rock.SetForce(Vector2.zero);
        }
    }

}
