using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Application.Input
{
    public class FunctionInputManager : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _functionInputField;

        public void HandleChangeFunction(string value)
        {

        }

        private void Validation(string value)
        {
            for(int i = 0; i < value.Length; i++)
            {
                if(value[i] == ',')
                {
                    //value[i] = '.';
                }
            }
            
        }

        private void SetValueTo_FunctionInputField(string value)
        {
            //_functionInputField
        }
    }
}

