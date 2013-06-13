using System;
using System.Collections.Generic;
using System.Text;

namespace Ong.Friendly.FormsStandardControls.Generator
{
    /// <summary>
    /// 自動生成ユーティリティー
    /// </summary>
    static class GenerateUtility
    {
        /// <summary>
        /// 重複した関数の削除。
        /// </summary>
        /// <param name="name">名前。</param>
        /// <param name="list">リスト。</param>
        /// <param name="function">関数。</param>
        static internal void RemoveDuplicationFunction(string name, List<string> list, string function)
        {
            bool findChangeText = false;
            for (int i = list.Count - 1; 0 <= i; i--)
            {
                if (list[i].IndexOf(name + "." + function) == 0)
                {
                    if (findChangeText)
                    {
                        list.RemoveAt(i);
                    }
                    findChangeText = true;
                }
                else
                {
                    findChangeText = false;
                }
            }
        }

        /// <summary>
        /// テキストを調整する
        /// </summary>
        /// <param name="text">テキスト。</param>
        /// <returns>調整済み行。</returns>
        static internal string AdjustText(string text)
        {
            text = text.Replace("\"", "\"\"");
            string[] lines = text.Replace("\r\n", "\n").Replace("\r", "\n").Split(new char[] { '\n' });
            StringBuilder builder = new StringBuilder();
            foreach (string line in lines)
            {
                if (0 < builder.Length)
                {
                    builder.Append(" + Environment.NewLine + ");
                }
                builder.Append("@\"" + line + "\"");
            }
            return builder.ToString();
        }
    }
}
