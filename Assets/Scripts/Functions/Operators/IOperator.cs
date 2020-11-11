using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Application.Functions
{
    public interface IOperator 
    {
        IOperator LeftOperand { get; set; }
        IOperator RightOperand { get; set; }

        double GetValue();

        void SetX(double x);
    }
}

