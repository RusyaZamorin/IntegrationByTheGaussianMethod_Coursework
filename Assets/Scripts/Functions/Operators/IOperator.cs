using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Application.Functions
{
    public interface IOperator 
    {
        IOperator LeftOperand { get; set; }
        IOperator RightOperand { get; set; }
        string Symbol { get; }


        double GetValue();

        void SetX(double x);                
    }
}

