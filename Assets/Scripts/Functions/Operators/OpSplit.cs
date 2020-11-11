using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Application.Functions
{
    public class OpSplit : DefaultOperator
    {
        public OpSplit(IOperator leftOperand, IOperator rightOperand) : base(leftOperand, rightOperand)
        {
        }

        public override double GetValue()
        {
            if (RightOperand.GetValue() == 0f)
            {
                Debug.Log("Error split on zerro");
                return 0f;
            }                
            else
                return LeftOperand.GetValue() / RightOperand.GetValue();
        }

    }
}
