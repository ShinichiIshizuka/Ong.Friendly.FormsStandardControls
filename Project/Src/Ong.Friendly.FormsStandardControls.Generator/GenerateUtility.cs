using System;
using System.Collections.Generic;
using System.Text;
using Codeer.TestAssistant.GeneratorToolKit;

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
        /// <param name="generator">ジェネレータ。</param>
        /// <param name="list">リスト。</param>
        /// <param name="function">関数。</param>
        internal static void RemoveDuplicationFunction(GeneratorBase generator, List<Sentence> list, string function)
        {
            bool findChangeText = false;
            for (int i = list.Count - 1; 0 <= i; i--)
            {
                if (IsDuplicationFunction(generator, list[i], function))
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
        /// 重複した関数であるか。
        /// </summary>
        /// <param name="generator">ジェネレータ。</param>
        /// <param name="sentence">センテンス。</param>
        /// <param name="function">関数。</param>
        /// <returns>重複した関数であるか。</returns>
        private static bool IsDuplicationFunction(GeneratorBase generator, Sentence sentence, string function)
        {
            if (!ReferenceEquals(generator, sentence.Owner))
            {
                return false;
            }
            if (sentence.Tokens.Length <= 2)
            {
                return false;
            }
            if (!(sentence.Tokens[0] is TokenName) ||
                (sentence.Tokens[1] == null))
            {
                return false;
            }
            return sentence.Tokens[1].ToString().IndexOf("." + function) == 0;
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
