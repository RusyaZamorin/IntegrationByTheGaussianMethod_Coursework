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

            double result = ConvertReversePolishNotationToFunction(reversePolishNotation).Execute(5f);
                          
            Debug.Log(result);
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
                        opert.RightOperand = operatorsStack.Pop();
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

