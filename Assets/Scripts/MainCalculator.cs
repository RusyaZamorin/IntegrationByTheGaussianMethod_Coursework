using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Application.Functions;
using TMPro;

namespace Application
{
    public class MainCalculator : MonoBehaviour
    {
        private Function _function = null;
        [SerializeField] private TMP_InputField _aField;
        [SerializeField] private TMP_InputField _bField;
        [SerializeField] private TMP_InputField _nField;

        [SerializeField] private TMP_Text _resultField;

        public void SetFunction(string function)
        {
            _function = FunctionCreater.FromString(function);
        }

        public void CalculateValue()
        {
            if (_function == null)
                return;

            float a = float.Parse(_aField.text);
            float b = float.Parse(_bField.text);
            int n = int.Parse(_nField.text);

            double result = GaussianIntegration.Execute(n, _function, a, b);

            Output(result);
        }

        private void Output(double resultValue)
        {
            _resultField.text = "I= " + resultValue.ToString();
        }
    }
}


