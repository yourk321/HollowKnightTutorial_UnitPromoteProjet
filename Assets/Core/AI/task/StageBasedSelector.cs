using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;
using System.Collections.Generic;

namespace Core.AI
{
    public class StageBasedSelector : Composite
    {
        public SharedInt CurrentStage;
        public List<string> stageList;//关卡列表

        public int seed = 0;
        public bool useSeed = false;

        // A list of indexes of every child task. This list is used by the Fischer-Yates shuffle algorithm.
        private List<int> childIndexList = new List<int>();
        // The random child index execution order.
        private Stack<int> childrenExecutionOrder = new Stack<int>();
        // The task status of the last child ran.
        private TaskStatus executionStatus = TaskStatus.Inactive;

        public override void OnAwake()
        {
            // If specified, use the seed provided.
            if (useSeed)
            {
                Random.InitState(seed);
            }

            // Add the index of each child to a list to make the Fischer-Yates shuffle possible
        }

        public override void OnStart()
        {
            //因为数量是可变的，所以每次进入该循环都要进行stage的复制
            childIndexList.Clear();
            //for (int i = 0; i < children.Count; ++i)
            //{
            //    childIndexList.Add(i);
            //}
            var stageArray = stageList[CurrentStage.Value].Split(','); ;//sel(int.Parse);
            for (int i = 0; i < stageArray.Length; ++i)
            {
                childIndexList.Add(int.Parse(stageArray[i]));
            }
            // Randomize the indecies
            ShuffleChilden();
        }

        public override int CurrentChildIndex()
        {
            // Peek will return the index at the top of the stack.
            return childrenExecutionOrder.Peek();
        }

        public override bool CanExecute()
        {
            // Continue exectuion if no task has return success and indexes still exist on the stack.
            return childrenExecutionOrder.Count > 0 && executionStatus != TaskStatus.Success;
        }

        public override void OnChildExecuted(TaskStatus childStatus)
        {
            // Pop the top index from the stack and set the execution status.
            if (childrenExecutionOrder.Count > 0)
            {
                childrenExecutionOrder.Pop();
            }
            executionStatus = childStatus;
        }

        public override void OnConditionalAbort(int childIndex)
        {
            // Start from the beginning on an abort
            childrenExecutionOrder.Clear();
            executionStatus = TaskStatus.Inactive;
            ShuffleChilden();
        }

        public override void OnEnd()
        {
            // All of the children have run. Reset the variables back to their starting values.
            executionStatus = TaskStatus.Inactive;
            childrenExecutionOrder.Clear();
        }

        public override void OnReset()
        {
            // Reset the public properties back to their original values
            seed = 0;
            useSeed = false;
        }

        private void ShuffleChilden()
        {
            // Use Fischer-Yates shuffle to randomize the child index order.
            for (int i = childIndexList.Count; i > 0; --i)
            {
                int j = Random.Range(0, i);
                int index = childIndexList[j];
                childrenExecutionOrder.Push(index);
                childIndexList[j] = childIndexList[i - 1];
                childIndexList[i - 1] = index;
            }
        }
    }


}

