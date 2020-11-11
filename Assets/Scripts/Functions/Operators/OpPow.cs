using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Application.Functions
{
    public class OpPow : DefaultOperator
    {
        public OpPow(IOperator leftOperand, IOperator rightOperand) : base(leftOperand, rightOperand)
        {
        }

        public override double GetValue() => Mathf.Pow((float)LeftOperand.GetValue(), (float)RightOperand.GetValue());

    }
}

