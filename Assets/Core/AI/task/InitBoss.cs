using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime.Tasks;
using Core.UI;

namespace Core.AI
{
    public class InitBooss : EnemyAction
    {
        public string bossName;

        public override TaskStatus OnUpdate()
        {
            GuiManager.Instance.ShowBossName(bossName);
            return TaskStatus.Success;
        }
    }
}

