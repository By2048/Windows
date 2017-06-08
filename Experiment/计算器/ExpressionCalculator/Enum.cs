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
    /// 操作符类型
    /// </summary>
    public enum EOperatorType
    {
        /// <summary>
        /// 左括号
        /// </summary>
        LeftParen = 0,
        /// <summary>
        /// 右括号
        /// </summary>
        RightParen,
        /// <summary>
        /// 加
        /// </summary>
        Plus,
        /// <summary>
        /// 减 
        /// </summary>
        Minus,
        /// <summary>
        /// 乘
        /// </summary>
        Multiply,
        /// <summary>
        /// 除
        /// </summary>
        Divide,
        /// <summary>
        /// 模
        /// </summary>
        Mod,
        /// <summary>
        /// 正号
        /// </summary>
        Positive,
        /// <summary>
        /// 负号
        /// </summary>
        Negative,

        // 关系运算 relation
        /// <summary>
        /// 小于
        /// </summary>
        LessThan,
        /// <summary>
        /// 大于
        /// </summary>
        GreaterThan,
        /// <summary>
        /// 等于
        /// </summary>
        Equal,
        /// <summary>
        /// 不等于
        /// </summary>
        NotEqual,
        /// <summary>
        /// 不大于
        /// </summary>
        LessEqual,
        /// <summary>
        /// 不小于
        /// </summary>
        GreaterEqual

    }

    /// <summary>
    /// 数据类型
    /// </summary>
    public enum EDataType
    {
        Dbool,
        Dint,
        Ddouble,
        Dstring
    }

    /// <summary>
    /// 标记类型
    /// </summary>
    public enum ETokenType
    {
        /// <summary>
        /// 操作数
        /// </summary>
        token_operand,
        /// <summary>
        /// 操作符
        /// </summary>
        token_operator,
    }

    /// <summary>
    /// 有限状态自动机
    /// </summary>
    public enum EDFAState
    {
        /// <summary>
        /// 初态
        /// </summary>
        Start,
        /// <summary>
        /// 整数串，不带小数点
        /// </summary>
        IntStr,
        /// <summary>
        /// 浮点数串
        /// </summary>
        DoubleStr,
        /// <summary>
        /// 字符串
        /// </summary>
        CharStr,
        /// <summary>
        /// 操作符
        /// </summary>
        OperatorStr
    }
}
