/********************************************
 * 
 * http://blog.csdn.net/welliu
 * 
 * Email:lgjwell@gmail.com
 * 
 * QQ:147620454
 * 
 *******************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionCalculator
{
    /// <summary>
    /// 语法分析程序
    /// </summary>
    public class SyntaxAnalyzer
    {
        public SyntaxAnalyzer()
        {
            _toolBox = new ToolBox();
        }

        private ToolBox _toolBox;

        #region 获取分词

        /// <summary>
        /// 获取后缀分词 - 用于测试分析
        /// </summary>
        public List<string> PostfixWords(TOKENLink startLink, TOKENLink endLink)
        {
            CheckParen(startLink, endLink);
            //先检查再进行后缀表达式转换
            TokenEnvirAnalyze(startLink, endLink);

            TOKENLink link = _toolBox.InfixToPostfix(startLink, endLink);
            List<string> wordList = new List<string>();
            while (link != null)
            {
                if (link.Token.Type == ETokenType.token_operand)
                {
                    wordList.Add(((TOKEN<IOperand>)link.Token).Tag.ToString());
                }
                else
                {
                    Operator op = ((TOKEN<Operator>)link.Token).Tag;

                    if (op.Value == "+" || op.Value == "-")
                    {
                        wordList.Add(op.Value + "  " + op.Type.ToString());
                    }
                    else
                    {
                        wordList.Add(op.Value);
                    }
                }

                link = link.Next;

            }

            return wordList;
        }

        #endregion

        #region 语法分析

        /// <summary>
        /// 语法分析
        /// </summary>
        /// <param name="startLink"></param>
        /// <param name="endLink"></param>
        public IOperand Analyze(TOKENLink startLink, TOKENLink endLink)
        {
            //分三步
            //1、括弧有效性判断
            //2、操作符和操作数应用环境分析
            //3、操作符好操作数匹配类型分析

            //第一步
            CheckParen(startLink, endLink);

            //第二步
            TokenEnvirAnalyze(startLink, endLink);

            //第三步
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
                            if (operand.Type == EDataType.Ddouble || operand.Type == EDataType.Dint)
                            {
                                token = postfixLink.Prev.Token;
                            }
                            else
                            {
                                throw new Exception(string.Format("Error! 运算符“{0}”无法应用于“{2}”类型的操作数（索引:{1}）",
                                    ((TOKEN<Operator>)postfixLink.Token).Tag.Value, postfixLink.Token.Index.ToString(), operand.Type.ToString()));
                            }

                            break;

                        case EOperatorType.Plus:
                        case EOperatorType.Minus:
                        case EOperatorType.Multiply:
                        case EOperatorType.Divide:
                        case EOperatorType.Mod:
                            if ((((TOKEN<IOperand>)postfixLink.Prev.Token).Tag.Type == EDataType.Dstring ||
                                ((TOKEN<IOperand>)postfixLink.Prev.Prev.Token).Tag.Type == EDataType.Dstring) &&
                                (type == EOperatorType.Plus || type == EOperatorType.Minus))
                            {
                                token = new TOKEN<IOperand>(ETokenType.token_operand,
                                        new Operand<string>(EDataType.Dstring, ""), postfixLink.Token.Index);

                            }
                            else if ((((TOKEN<IOperand>)postfixLink.Prev.Token).Tag.Type == EDataType.Ddouble ||
                                ((TOKEN<IOperand>)postfixLink.Prev.Token).Tag.Type == EDataType.Dint) &&
                                (((TOKEN<IOperand>)postfixLink.Prev.Prev.Token).Tag.Type == EDataType.Ddouble ||
                                ((TOKEN<IOperand>)postfixLink.Prev.Prev.Token).Tag.Type == EDataType.Dint))
                            {
                                if ((((TOKEN<IOperand>)postfixLink.Prev.Prev.Token).Tag.Type == EDataType.Ddouble ||
                                    ((TOKEN<IOperand>)postfixLink.Prev.Token).Tag.Type == EDataType.Ddouble) ||
                                    (type == EOperatorType.Divide || type == EOperatorType.Mod))
                                {
                                    token = new TOKEN<IOperand>(ETokenType.token_operand, new Operand<double>(EDataType.Ddouble, 0), postfixLink.Token.Index);
                                }
                                else
                                {
                                    token = new TOKEN<IOperand>(ETokenType.token_operand, new Operand<int>(EDataType.Dint, 0), postfixLink.Token.Index);
                                }
                            }
                            else
                            {
                                throw new Exception(string.Format("Error! 运算符“{0}”无法应用于“{2}”和“{3}”类型的操作数（索引:{1}）",
                                    ((TOKEN<Operator>)postfixLink.Token).Tag.Value, postfixLink.Token.Index.ToString(),
                                    ((TOKEN<IOperand>)postfixLink.Prev.Prev.Token).Tag.Type.ToString(),
                                    ((TOKEN<IOperand>)postfixLink.Prev.Token).Tag.Type.ToString()));
                            }

                            break;

                        case EOperatorType.LessThan:
                        case EOperatorType.GreaterThan:
                        case EOperatorType.Equal:
                        case EOperatorType.NotEqual:
                        case EOperatorType.GreaterEqual:
                        case EOperatorType.LessEqual:

                            if (((((TOKEN<IOperand>)postfixLink.Prev.Token).Tag.Type == EDataType.Ddouble ||
                                ((TOKEN<IOperand>)postfixLink.Prev.Token).Tag.Type == EDataType.Dint) &&
                                (((TOKEN<IOperand>)postfixLink.Prev.Prev.Token).Tag.Type == EDataType.Ddouble ||
                                ((TOKEN<IOperand>)postfixLink.Prev.Prev.Token).Tag.Type == EDataType.Dint)) ||
                                (((((TOKEN<IOperand>)postfixLink.Prev.Token).Tag.Type == EDataType.Dstring &&
                                ((TOKEN<IOperand>)postfixLink.Prev.Prev.Token).Tag.Type == EDataType.Dstring) ||
                                (((TOKEN<IOperand>)postfixLink.Prev.Token).Tag.Type == EDataType.Dbool &&
                                ((TOKEN<IOperand>)postfixLink.Prev.Prev.Token).Tag.Type == EDataType.Dbool)) &&
                                (type == EOperatorType.Equal || type == EOperatorType.NotEqual)))
                            {
                                token = new TOKEN<IOperand>(ETokenType.token_operand, new Operand<bool>(EDataType.Dbool, true), postfixLink.Token.Index);
                            }
                            else
                            {
                                throw new Exception(string.Format("Error! 运算符“{0}”无法应用于“{2}”和“{3}”类型的操作数（索引:{1}）",
                                    ((TOKEN<Operator>)postfixLink.Token).Tag.Value, postfixLink.Token.Index.ToString(),
                                    ((TOKEN<IOperand>)postfixLink.Prev.Prev.Token).Tag.Type.ToString(),
                                    ((TOKEN<IOperand>)postfixLink.Prev.Token).Tag.Type.ToString()));
                            }

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

        #region 检查标记应用环境

        /// <summary>
        /// 检查标记应用环境 
        /// </summary>
        /// <param name="startLink"></param>
        /// <param name="endLink"></param>
        private void TokenEnvirAnalyze(TOKENLink startLink, TOKENLink endLink)
        {
            TOKENLink curLink = startLink;

            while (true)
            {
                switch (curLink.Token.Type)
                {
                    case ETokenType.token_operand:
                        if (curLink.Prev != null && (curLink.Prev.Token.Type == ETokenType.token_operand ||
                            (curLink.Prev.Token.Type == ETokenType.token_operator &&
                            ((TOKEN<Operator>)curLink.Prev.Token).Tag.Type == EOperatorType.RightParen)))
                        {
                            throw new Exception(string.Format("Error! 操作数“{0}”附近有语法错误（索引：{1}）",
                                    ((TOKEN<IOperand>)curLink.Token).Tag.ToString(), curLink.Token.Index.ToString()));
                        }

                        break;

                    case ETokenType.token_operator:
                        EOperatorType type = ((TOKEN<Operator>)curLink.Token).Tag.Type;
                        switch (type)
                        {
                            case EOperatorType.Positive:  //正
                            case EOperatorType.Negative:  //负
                                if (!(curLink.Next != null && (curLink.Next.Token.Type == ETokenType.token_operand ||
                                    (curLink.Next.Token.Type == ETokenType.token_operator &&
                                    ((TOKEN<Operator>)curLink.Next.Token).Tag.Type == EOperatorType.LeftParen))))
                                {
                                    throw new Exception(string.Format("Error! 一元操作符“{0}”附近有语法错误（索引：{1}）",
                                        ((TOKEN<Operator>)curLink.Token).Tag.Value, curLink.Token.Index.ToString()));
                                }

                                break;

                            case EOperatorType.LeftParen:
                                if (curLink.Prev != null && (curLink.Prev.Token.Type == ETokenType.token_operand ||
                                   (curLink.Prev.Token.Type == ETokenType.token_operator &&
                                   ((TOKEN<Operator>)curLink.Prev.Token).Tag.Type == EOperatorType.RightParen)))
                                {
                                    throw new Exception(string.Format("Error! 左括弧“{0}”附近有语法错误（索引：{1}）",
                                        ((TOKEN<Operator>)curLink.Token).Tag.Value, curLink.Token.Index.ToString()));
                                }

                                break;

                            case EOperatorType.RightParen:
                                if (curLink.Prev == null || (curLink.Prev.Token.Type == ETokenType.token_operator &&
                                    ((TOKEN<Operator>)curLink.Prev.Token).Tag.Type == EOperatorType.LeftParen))
                                {
                                    throw new Exception(string.Format("Error! 右括弧“{0}”附近有语法错误（索引：{1}）",
                                        ((TOKEN<Operator>)curLink.Token).Tag.Value, curLink.Token.Index.ToString()));
                                }

                                break;

                            default:
                                if (!((curLink.Prev != null && (curLink.Prev.Token.Type == ETokenType.token_operand ||
                                    (curLink.Prev.Token.Type == ETokenType.token_operator &&
                                    ((TOKEN<Operator>)curLink.Prev.Token).Tag.Type == EOperatorType.RightParen))) &&
                                        (curLink.Next != null && (curLink.Next.Token.Type == ETokenType.token_operand ||
                                    (curLink.Next.Token.Type == ETokenType.token_operator &&
                                    (((TOKEN<Operator>)curLink.Next.Token).Tag.Type == EOperatorType.LeftParen ||
                                    ((TOKEN<Operator>)curLink.Next.Token).Tag.Type == EOperatorType.Negative ||
                                    ((TOKEN<Operator>)curLink.Next.Token).Tag.Type == EOperatorType.Positive))))))
                                {
                                    throw new Exception(string.Format("Error! 二元操作符“{0}”附近有语法错误（索引：{1}）",
                                        ((TOKEN<Operator>)curLink.Token).Tag.Value, curLink.Token.Index.ToString()));
                                }

                                break;
                        }

                        break;

                    default:
                        break;
                }

                if (curLink == endLink)
                {
                    break;
                }
                else
                {
                    curLink = curLink.Next;
                }
            }
        }

        #endregion

        #region 括弧对称性验证

        /// <summary>
        /// 括弧必须成对出现，并且先有“(”才有“)”
        /// </summary>
        /// <param name="startLink"></param>
        /// <param name="endLink"></param>
        private void CheckParen(TOKENLink startLink, TOKENLink endLink)
        {
            TOKENLink curLink = startLink;
            int cout = 0;

            while (true)
            {
                if (curLink.Token.Type == ETokenType.token_operator)
                {
                    if (((TOKEN<Operator>)curLink.Token).Tag.Type == EOperatorType.LeftParen)
                    {
                        cout++;
                    }
                    else if (((TOKEN<Operator>)curLink.Token).Tag.Type == EOperatorType.RightParen)
                    {
                        cout--;
                    }

                    if (cout < 0)
                    {
                        throw new Exception(string.Format("Error! 缺少左括弧（索引：{0}）", curLink.Token.Index.ToString()));
                    }
                }

                if (curLink == endLink)
                {
                    break;
                }

                curLink = curLink.Next;
            }

            if (cout > 0)
            {
                throw new Exception(string.Format("Error! 缺少“{0}”个右括弧", cout.ToString()));
            }
        }

        #endregion
    }
}
