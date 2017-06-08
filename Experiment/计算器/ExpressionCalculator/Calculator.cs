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
    /// 表达式计算器
    /// </summary>
    public class Calculator
    {
        public Calculator()
            : this("")
        { }

        public Calculator(string expression)
        {
            _expression = expression;
        }

        private string _expression = string.Empty;
        private Link_OP _link_OP = null;
        private Evaluator _eval = new Evaluator();

        #region 获取分词

        /// <summary>
        /// 获取后缀分词
        /// </summary>
        public List<string> PostfixWords
        {
            get
            {
                Analyze();
                SyntaxAnalyzer a = new SyntaxAnalyzer();
                return a.PostfixWords(_link_OP.Head, _link_OP.Tail);
            }
        }

        /// <summary>
        /// 获取表达式分词
        /// </summary>
        public List<string> Words
        {
            get
            {
                Analyze();

                TOKENLink link = _link_OP.Head;
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
        }

        #endregion

        #region 表达式

        /// <summary>
        /// 获取或赋值表达式
        /// </summary>
        public string Expression
        {
            get
            {
                return _expression;
            }
            set
            {
                _expression = value.Trim();
                _link_OP = null;
            }
        }

        #endregion

        /// <summary>
        /// 检查语法
        /// </summary>
        /// <returns></returns>
        public bool Check(ref string mes)
        {
            bool result = false;
            try
            {
                Analyze();
                SyntaxAnalyzer a = new SyntaxAnalyzer();
                a.Analyze(_link_OP.Head, _link_OP.Tail);
                mes = "Success!";
                result = true;
            }
            catch (Exception ex)
            {
                mes = ex.Message;
            }

            return result;
        }

        /// <summary>
        /// 表达式式执行
        /// </summary>
        public IOperand Execute()
        {
            Analyze();
            return _eval.ExpressionEvaluate(_link_OP.Head, _link_OP.Tail);
        }

        /// <summary>
        /// 表达式式执行-返回字符串结果
        /// </summary>
        public string ExecuteToString()
        {
            return Execute().ToString();
        }

        /// <summary>
        /// 解析
        /// </summary>
        private void Analyze()
        {
            if (_link_OP == null)
            {
                if (_expression.Trim().Length > 0)
                {
                    PhraseAnalyzer analyze = new PhraseAnalyzer(_expression);
                    _link_OP = analyze.Analyze();
                }
                else
                {
                    throw new Exception("Error! 表达式为空");
                }
            }
        }
    }
}
