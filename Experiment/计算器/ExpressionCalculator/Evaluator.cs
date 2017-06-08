using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionCalculator
{
    /// <summary>
    /// 表达式求值
    /// </summary>
    public class Evaluator
    {
        public Evaluator()
        {
            _toolBox = new ToolBox();
        }

        private ToolBox _toolBox = null;

        #region 运算表达式求值 - ExpressionEvaluate

        /// <summary>
        /// 表达式求值
        /// </summary>
        /// <param name="startLink"></param>
        /// <param name="endLink"></param>
        /// <returns></returns>
        public IOperand ExpressionEvaluate(TOKENLink startLink, TOKENLink endLink)
        {
            TOKENLink postfixLink = _toolBox.InfixToPostfix(startLink, endLink);
            TOKENLink link_new = null;
            IToken token = null;

            while (postfixLink.Next != null)
            {
                postfixLink = postfixLink.Next;

                if (postfixLink.Token.Type == ETokenType.token_operator)
                {
                    link_new = null;
                    token = null;
                    EOperatorType type = ((TOKEN<Operator>)postfixLink.Token).Tag.Type;
                    switch (type)
                    {
                        case EOperatorType.Positive:  //正
                        case EOperatorType.Negative:  //负
                            IOperand operand = ((TOKEN<IOperand>)postfixLink.Prev.Token).Tag;
                            if (type == EOperatorType.Negative)
                            {
                                if (operand.Type == EDataType.Dint)
                                {
                                    token = new TOKEN<IOperand>(ETokenType.token_operand,
                                        new Operand<int>(EDataType.Dint, -((Operand<int>)operand).TValue), postfixLink.Token.Index);
                                }
                                else if (operand.Type == EDataType.Ddouble)
                                {
                                    token = new TOKEN<IOperand>(ETokenType.token_operand,
                                        new Operand<double>(EDataType.Ddouble, -((Operand<double>)operand).TValue), postfixLink.Token.Index);
                                }
                            }
                            else
                            {
                                token = postfixLink.Prev.Token;
                            }

                            break;

                        case EOperatorType.Plus:
                        case EOperatorType.Minus:
                            if (((TOKEN<IOperand>)postfixLink.Prev.Token).Tag.Type == EDataType.Dstring ||
                                ((TOKEN<IOperand>)postfixLink.Prev.Prev.Token).Tag.Type == EDataType.Dstring)
                            {
                                if (type == EOperatorType.Plus)
                                {
                                    token = new TOKEN<IOperand>(ETokenType.token_operand,
                                        new Operand<string>(EDataType.Dstring, ((TOKEN<IOperand>)postfixLink.Prev.Prev.Token).Tag.ToString() +
                                        ((TOKEN<IOperand>)postfixLink.Prev.Token).Tag.ToString()), postfixLink.Token.Index);
                                }
                                else
                                {
                                    token = new TOKEN<IOperand>(ETokenType.token_operand,
                                        new Operand<string>(EDataType.Dstring,
                                            ((TOKEN<IOperand>)postfixLink.Prev.Prev.Token).Tag.ToString().Replace(((TOKEN<IOperand>)postfixLink.Prev.Token).Tag.ToString(), "")),
                                            postfixLink.Token.Index);

                                }
                            }
                            else if (((TOKEN<IOperand>)postfixLink.Prev.Token).Tag.Type == EDataType.Ddouble ||
                                ((TOKEN<IOperand>)postfixLink.Prev.Prev.Token).Tag.Type == EDataType.Ddouble)
                            {
                                if (type == EOperatorType.Plus)
                                {
                                    token = new TOKEN<IOperand>(ETokenType.token_operand, new Operand<double>(EDataType.Ddouble,
                                        Convert.ToDouble(((TOKEN<IOperand>)postfixLink.Prev.Prev.Token).Tag.Value) +
                                        Convert.ToDouble(((TOKEN<IOperand>)postfixLink.Prev.Token).Tag.Value)), postfixLink.Token.Index);
                                }
                                else
                                {
                                    token = new TOKEN<IOperand>(ETokenType.token_operand, new Operand<double>(EDataType.Ddouble,
                                        Convert.ToDouble(((TOKEN<IOperand>)postfixLink.Prev.Prev.Token).Tag.Value) -
                                        Convert.ToDouble(((TOKEN<IOperand>)postfixLink.Prev.Token).Tag.Value)), postfixLink.Token.Index);
                                }
                            }
                            else
                            {
                                if (type == EOperatorType.Plus)
                                {
                                    token = new TOKEN<IOperand>(ETokenType.token_operand, new Operand<int>(EDataType.Dint,
                                       ((Operand<int>)((TOKEN<IOperand>)postfixLink.Prev.Prev.Token).Tag).TValue +
                                       ((Operand<int>)((TOKEN<IOperand>)postfixLink.Prev.Token).Tag).TValue), postfixLink.Token.Index);
                                }
                                else
                                {
                                    token = new TOKEN<IOperand>(ETokenType.token_operand, new Operand<int>(EDataType.Dint,
                                       ((Operand<int>)((TOKEN<IOperand>)postfixLink.Prev.Prev.Token).Tag).TValue -
                                       ((Operand<int>)((TOKEN<IOperand>)postfixLink.Prev.Token).Tag).TValue), postfixLink.Token.Index);
                                }
                            }

                            break;

                        case EOperatorType.Multiply:
                            if (((TOKEN<IOperand>)postfixLink.Prev.Token).Tag.Type == EDataType.Ddouble ||
                                ((TOKEN<IOperand>)postfixLink.Prev.Prev.Token).Tag.Type == EDataType.Ddouble)
                            {
                                token = new TOKEN<IOperand>(ETokenType.token_operand, new Operand<double>(EDataType.Ddouble,
                                        Convert.ToDouble(((TOKEN<IOperand>)postfixLink.Prev.Prev.Token).Tag.Value) *
                                        Convert.ToDouble(((TOKEN<IOperand>)postfixLink.Prev.Token).Tag.Value)), postfixLink.Token.Index);
                            }
                            else
                            {
                                token = new TOKEN<IOperand>(ETokenType.token_operand, new Operand<int>(EDataType.Dint,
                                       ((Operand<int>)((TOKEN<IOperand>)postfixLink.Prev.Prev.Token).Tag).TValue *
                                       ((Operand<int>)((TOKEN<IOperand>)postfixLink.Prev.Token).Tag).TValue), postfixLink.Token.Index);
                            }

                            break;

                        case EOperatorType.Divide:
                            token = new TOKEN<IOperand>(ETokenType.token_operand, new Operand<double>(EDataType.Ddouble,
                                        Convert.ToDouble(((TOKEN<IOperand>)postfixLink.Prev.Prev.Token).Tag.Value) /
                                        Convert.ToDouble(((TOKEN<IOperand>)postfixLink.Prev.Token).Tag.Value)), postfixLink.Token.Index);

                            break;

                        case EOperatorType.Mod:
                            token = new TOKEN<IOperand>(ETokenType.token_operand, new Operand<double>(EDataType.Ddouble,
                                        Convert.ToDouble(((TOKEN<IOperand>)postfixLink.Prev.Prev.Token).Tag.Value) %
                                        Convert.ToDouble(((TOKEN<IOperand>)postfixLink.Prev.Token).Tag.Value)), postfixLink.Token.Index);

                            break;

                        case EOperatorType.LessThan:
                        case EOperatorType.GreaterThan:
                        case EOperatorType.GreaterEqual:
                        case EOperatorType.LessEqual:
                            bool result = false;

                            double first = Convert.ToDouble(((TOKEN<IOperand>)postfixLink.Prev.Prev.Token).Tag.Value);
                            double second = Convert.ToDouble(((TOKEN<IOperand>)postfixLink.Prev.Token).Tag.Value);

                            switch (type)
                            {
                                case EOperatorType.LessThan:
                                    result = first < second;
                                    break;
                                case EOperatorType.GreaterThan:
                                    result = first > second;
                                    break; ;
                                case EOperatorType.GreaterEqual:
                                    result = first >= second;
                                    break;
                                case EOperatorType.LessEqual:
                                    result = first <= second;
                                    break;
                            }

                            token = new TOKEN<IOperand>(ETokenType.token_operand, new Operand<bool>(EDataType.Dbool, result), postfixLink.Token.Index);

                            break;

                        case EOperatorType.Equal:
                        case EOperatorType.NotEqual:
                            bool r = false;
                            if (((TOKEN<IOperand>)postfixLink.Prev.Token).Tag.Type == EDataType.Dstring &&
                                ((TOKEN<IOperand>)postfixLink.Prev.Prev.Token).Tag.Type == EDataType.Dstring)
                            {
                                if (type == EOperatorType.Equal)
                                {
                                    r = ((TOKEN<IOperand>)postfixLink.Prev.Prev.Token).Tag.ToString().Equals(((TOKEN<IOperand>)postfixLink.Prev.Token).Tag.ToString());
                                }
                                else
                                {
                                    r = !((TOKEN<IOperand>)postfixLink.Prev.Prev.Token).Tag.ToString().Equals(((TOKEN<IOperand>)postfixLink.Prev.Token).Tag.ToString());
                                }
                            }
                            else if (((TOKEN<IOperand>)postfixLink.Prev.Token).Tag.Type == EDataType.Dbool &&
                                ((TOKEN<IOperand>)postfixLink.Prev.Prev.Token).Tag.Type == EDataType.Dbool)
                            {
                                bool f = ((Operand<bool>)((TOKEN<IOperand>)postfixLink.Prev.Prev.Token).Tag).TValue;
                                bool s = ((Operand<bool>)((TOKEN<IOperand>)postfixLink.Prev.Token).Tag).TValue;

                                if (type == EOperatorType.Equal)
                                {
                                    r = f == s;
                                }
                                else
                                {
                                    r = f != s;
                                }
                            }
                            else
                            {
                                double f = Convert.ToDouble(((TOKEN<IOperand>)postfixLink.Prev.Prev.Token).Tag.Value);
                                double s = Convert.ToDouble(((TOKEN<IOperand>)postfixLink.Prev.Token).Tag.Value);

                                if (type == EOperatorType.Equal)
                                {
                                    r = f == s;
                                }
                                else
                                {
                                    r = f != s;
                                }
                            }

                            token = new TOKEN<IOperand>(ETokenType.token_operand, new Operand<bool>(EDataType.Dbool, r), postfixLink.Token.Index);

                            break;

                        default:
                            break;
                    }

                    if (token != null)
                    {
                        link_new = new TOKENLink(token);

                        link_new.Next = postfixLink.Next;
                        if (postfixLink.Next != null)
                        {
                            postfixLink.Next.Prev = link_new;
                        }

                        if (((TOKEN<Operator>)postfixLink.Token).Tag.Dimension == 1)
                        {
                            //一元操作符
                            if (postfixLink.Prev.Prev != null)
                            {
                                link_new.Prev = postfixLink.Prev.Prev;
                                postfixLink.Prev.Prev.Next = link_new;
                            }
                        }
                        else if (((TOKEN<Operator>)postfixLink.Token).Tag.Dimension == 2)
                        {
                            //二元操作符
                            if (postfixLink.Prev.Prev.Prev != null)
                            {
                                link_new.Prev = postfixLink.Prev.Prev.Prev;
                                postfixLink.Prev.Prev.Prev.Next = link_new;
                            }
                        }

                        postfixLink = link_new;
                    }

                }//end if


            }//end while

            return ((TOKEN<IOperand>)postfixLink.Token).Tag;
        }

        #endregion
    }
}
