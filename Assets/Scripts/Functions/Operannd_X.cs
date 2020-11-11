using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Application.Functions
{
    public class Operannd_X : DefaultOperator
    {
        private double _valueX;

        public Operannd_X() : base(null, null) { }        

        public override double GetValue()
        {
            return _valueX;
        }

        public override void SetX(double x)
        {
            _valueX = x;
        }
    }
}

