using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Application.Functions
{
    public class OpCos : DefaultOperator
    {
        public OpCos(IOperator leftOperand) : base(leftOperand, null)
        {
        }

        public override double GetValue() => Mathf.Cos((float)LeftOperand.GetValue());

    }
}

