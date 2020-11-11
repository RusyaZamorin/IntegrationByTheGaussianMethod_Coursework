using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Application.Functions
{
    public class OpMinus : DefaultOperator
    {
        public OpMinus(IOperator leftOperand, IOperator rightOperand) : base(leftOperand, rightOperand)
        {
        }

        public override double GetValue() => LeftOperand.GetValue() - RightOperand.GetValue();

    }
}
