﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class ReversePolishNotation 
{  
    public static string FromString(string input)
    {
        string output = string.Empty; //Строка для хранения выражения
        Stack<char> operStack = new Stack<char>(); //Стек для хранения операторов

        string complexityOperator = "";

        for (int i = 0; i < input.Length; i++) //Для каждого символа в входной строке
        {
            //Разделители пропускаем
            if (IsDelimeter(input[i]))
                continue; //Переходим к следующему символу
            
            //Если символ - цифра, то считываем все число
            else if (char.IsDigit(input[i])) //Если цифра
            {
                //Читаем до разделителя или оператора, что бы получить число
                while (!IsDelimeter(input[i]) && !IsOperator(input[i]))
                {
                    output += input[i]; //Добавляем каждую цифру числа к нашей строке
                    i++; //Переходим к следующему символу

                    if (i == input.Length) break; //Если символ - последний, то выходим из цикла
                }

                output += " "; //Дописываем после числа пробел в строку с выражением
                i--; //Возвращаемся на один символ назад, к символу перед разделителем
            }

            //Если символ - оператор
            else if (IsOperator(input[i])) //Если оператор
            {
                if (input[i] == '(') //Если символ - открывающая скобка
                    operStack.Push(input[i]); //Записываем её в стек
                else if (input[i] == ')') //Если символ - закрывающая скобка
                {
                    //Выписываем все операторы до открывающей скобки в строку
                    char s = operStack.Pop();

                    while (s != '(')
                    {
                        output += s.ToString() + ' ';
                        s = operStack.Pop();
                    }
                }
                else //Если любой другой оператор
                {
                    if (operStack.Count > 0) //Если в стеке есть элементы
                        if (GetPriority(input[i]) <= GetPriority(operStack.Peek())) //И если приоритет нашего оператора меньше или равен приоритету оператора на вершине стека
                            output += operStack.Pop().ToString() + " "; //То добавляем последний оператор из стека в строку с выражением

                    operStack.Push(char.Parse(input[i].ToString())); //Если стек пуст, или же приоритет оператора выше - добавляем операторов на вершину стека

                }
            }

            // Если символ X
            else if (Operators.IsX(input[i].ToString()))
            {
                output += Operators.XSymbol + " ";
            }

            // если символ не распознан или является частью длинных операторов(sin, cos, tg ...)
            else
            {
                complexityOperator += input[i];

                if(Operators.IsOperator(complexityOperator))
                {                    
                    //output += complexityOperator + " ";
                    complexityOperator = "";
                }
            }
        }

        //Когда прошли по всем символам, выкидываем из стека все оставшиеся там операторы в строку
        while (operStack.Count > 0)
            output += operStack.Pop() + " ";        
        return output; //Возвращаем выражение в постфиксной записи
    }

    static private bool IsDelimeter(char symbol)
    {
        if ((" =".IndexOf(symbol) != -1))
            return true;
        return false;
    }

    static private bool IsOperator(char symbol)
    {
        if (Operators.ListSymbols.Contains(symbol.ToString()))
            return true;
        return false;
    }

    static private int GetPriority(char symbol)
    {
        if (Operators.ListSymbols.Contains(symbol.ToString()))
            return Operators.ListSymbols.IndexOf(symbol.ToString());
        else
            return Operators.ListSymbols.Count;
    }

    
}
