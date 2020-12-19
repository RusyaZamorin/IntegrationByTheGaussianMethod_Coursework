using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Application.Functions;
using TMPro;
using System;

namespace Application.Input
{
    public class FunctionCreater : MonoBehaviour
    {
        [SerializeField] private TMP_Text _printFunctionField;
        [SerializeField] private string _function;
        

        [ContextMenu("Test")]
        public void Test()
        {            
            var reversePolishNotation = ReversePolishNotation.FromString(_function);

            Debug.Log(reversePolishNotation);
            Function function = ConvertReversePolishNotationToFunction(reversePolishNotation);

            for(float i = 0; i < 10f; i++)
            {
                Debug.Log(function.Execute(i));
            }                                                  
        }

        private Function ConvertReversePolishNotationToFunction(string reversePolishNotation)
        {
            char[] separator = { ' ' };

            List<string> polishNotationList = new List<string>(reversePolishNotation.
                Split(separator, StringSplitOptions.RemoveEmptyEntries));

            Stack<IOperator> operatorsStack = new Stack<IOperator>();            
            IOperator firstOperator = null;           

            foreach(string notationElement in polishNotationList)
            {
                if(Operators.IsOperator(notationElement))
                {
                    IOperator opert = Operators.GetOperator(notationElement);
                    
                    if(Operators.IsUnaryOperator(opert))
                    {
                        opert.LeftOperand = operatorsStack.Pop();
                    }
                    else
                    {
                        opert.RightOperand = operatorsStack.Pop();
                        opert.LeftOperand = operatorsStack.Pop();
                    }

                    operatorsStack.Push(opert);
                }
                else if(Operators.IsX(notationElement))
                {
                    operatorsStack.Push(new Operannd_X());
                }
                else
                {
                    operatorsStack.Push(new Operand_Value( double.Parse(notationElement) ));
                }
            }

            firstOperator = operatorsStack.Pop();

            return new Function(firstOperator);
        }
    }

}

