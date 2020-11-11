using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Application.Functions;

namespace Tests
{
    public class TestFunction : MonoBehaviour
    {
        private Function _function;

        public void Start()
        {
            var operator1 = new OpPlus(new Operand_Value(5f), new Operannd_X());
            var operator2 = new OpMultiply(operator1, new Operand_Value(2f));
            var operator3 = new OpSplit(operator2, new Operand_Value(3f));
            _function = new Function(operator3);
        }

        public void Exetute(float x)
        {
            Debug.Log("((5+x)*2)/3");

            Debug.Log(_function.Execute(x));
        }

        
    }
}

