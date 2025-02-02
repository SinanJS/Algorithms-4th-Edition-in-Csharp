﻿using System;
using System.Text;
using SortApplication;

namespace _2._5._33
{
    /// <summary>
    /// 随机交易生成器。
    /// </summary>
    class TransactionGenerator
    {
        private static Random random = new Random();

        /// <summary>
        /// 生成 n 条随机交易记录。
        /// </summary>
        /// <param name="n">交易记录的数量。</param>
        /// <returns></returns>
        public static Transaction[] Generate(int n)
        {
            Transaction[] trans = new Transaction[n];
            for (int i = 0; i < n; i++)
            {
                trans[i] = new Transaction
                    (GenerateName(), 
                    GenerateDate(), 
                    random.NextDouble() * 1000);
            }
            return trans;
        }

        /// <summary>
        /// 获取随机姓名。
        /// </summary>
        /// <returns></returns>
        private static string GenerateName()
        {
            int nameLength = random.Next(4, 7);
            StringBuilder sb = new StringBuilder();

            sb.Append(random.Next('A', 'Z' + 1));
            for (int i = 1; i < nameLength; i++)
                sb.Append(random.Next('a', 'z' + 1));

            return sb.ToString();
        }

        /// <summary>
        /// 获取随机日期。
        /// </summary>
        /// <returns></returns>
        private static Date GenerateDate()
        {
            int year = random.Next(2017, 2019);
            int month = random.Next(1, 13);
            int day;
            if (month == 2)
                day = random.Next(1, 29);
            else if ((month < 8 && month % 2 == 1) ||
                (month > 7 && month % 2 == 0))
                day = random.Next(1, 32);
            else
                day = random.Next(1, 31);

            Date date = new Date(month, day, year);
            return date;
        }
    }
}
