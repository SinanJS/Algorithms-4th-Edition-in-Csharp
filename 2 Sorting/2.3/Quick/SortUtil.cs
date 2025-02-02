﻿using System;

namespace Quick
{
    /// <summary>
    /// 静态类，包含用于生成排序算法测试数据的方法。
    /// </summary>
    public static class SortUtil
    {

        /// <summary>
        /// 随机数发生器，所有对象共享同一个随机数发生器。
        /// </summary>
        public static Random UniformGenerator = new Random();

        /// <summary>
        /// 产生符合正态分布的随机数。
        /// </summary>
        /// <param name="average">正态分布的期望值 μ。</param>
        /// <param name="standardDeviation">正态分布的标准差 σ。</param>
        /// <returns>符合正态分布的随机数。</returns>
        public static double Normal(double average, double standardDeviation)
        {
            double u1 = UniformGenerator.NextDouble();
            double u2 = UniformGenerator.NextDouble();

            double z0 = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Cos(Math.PI * 2 * u2);
            
            return z0 * standardDeviation + average;
        }

        /// <summary>
        /// 生成符合泊松分布的随机数。
        /// </summary>
        /// <param name="average">泊松分布的期望值 λ。</param>
        /// <returns>一个符合泊松分布的随机数。</returns>
        public static double Poission(double average)
        {
            double x = 0;
            double p = Math.Pow(Math.E, -average);
            double s = p;
            double u = UniformGenerator.NextDouble();
            do
            {
                x++;
                p *= average / x;
                s += p;
            } while (u > s);
            return x;
        }

        /// <summary>
        /// 生成符合几何分布的随机数。
        /// </summary>
        /// <param name="p">几何分布的概率 p，这应该是一个小于 1 的非负数。</param>
        /// <exception cref="ArgumentOutOfRangeException">概率不能大于 1.</exception>
        /// <returns>符合几何分布的随机数。</returns>
        public static double Geometry(double p)
        {
            if (p > 1)
            {
                throw new ArgumentOutOfRangeException("p", "概率不能大于 1");
            }

            double result;
            result = Math.Ceiling(Math.Log(1 - UniformGenerator.NextDouble()) / Math.Log(1 - p));

            return result;
        }

        /// <summary>
        /// 根据指定的几率数组产生符合离散分布的随机数。
        /// </summary>
        /// <param name="probabilities">各取值的可能性。</param>
        /// <returns>符合随机分布的随机整数。</returns>
        public static double Discrete(double[] probabilities)
        {
            if (probabilities == null)
            {
                throw new ArgumentNullException("Argument array is null");
            }

            double EPSION = 1E-14;
            double sum = 0;
            for (int i = 0; i < probabilities.Length; i++)
            {
                if (probabilities[i] <= 0)
                {
                    throw new ArgumentException("array entry " + i + " must be nonnegative:" + probabilities[i]);
                }

                sum += probabilities[i];
            }

            if (sum > 1.0 + EPSION || sum < 1.0 - EPSION)
            {
                throw new ArgumentException("sum of array entries does not equal 1.0:" + sum);
            }

            while (true)
            {
                double r = UniformGenerator.NextDouble();
                sum = 0.0;
                for (int i = 0; i < probabilities.Length; i++)
                {
                    sum += probabilities[i];
                    if (sum > r)
                    {
                        return i;
                    }
                }
            }
        }
    }
}
