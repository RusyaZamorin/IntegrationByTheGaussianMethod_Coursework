using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Application.Functions
{
    public class OpSin : DefaultOperator
    {
        public OpSin(IOperator leftOperand) : base(leftOperand, null)
        {
        }

        public override double GetValue() => Mathf.Sin((float)LeftOperand.GetValue());

    }
}

