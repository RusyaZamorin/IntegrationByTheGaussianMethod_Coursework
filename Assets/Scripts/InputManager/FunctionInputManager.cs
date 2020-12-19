using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Application.Input
{
    public class FunctionInputManager : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _functionInputField;
        [SerializeField] private MainCalculator _calculator;

        public void HandleChangeFunction(string function)
        {
            Validation(function);
        }

        public void SetFunction(string function)
        {
            _calculator.SetFunction(function);
        }

        private void Validation(string function)
        {
            function = function.Replace('.', ',');
            function = function.Replace('х', 'x');
            function = function.Replace('Х', 'x');

            SetValueTo_FunctionInputField(function);
        }

        private void SetValueTo_FunctionInputField(string function)
        {
            _functionInputField.text = function;
        }
    }
}

