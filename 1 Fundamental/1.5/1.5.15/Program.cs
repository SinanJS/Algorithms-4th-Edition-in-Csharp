﻿namespace _1._5._15
{
    /*
     * 1.5.15
     * 
     * 二项树。
     * 请证明，对于加权 quick-union 算法，
     * 在最坏情况下树中的每一层的节点数均为二项式系数。
     * 在这种情况下，计算含有 N=2^n 个节点的树中节点的平均深度。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // 最坏情况：每次合并的两棵树大小均相同。
            // 递推：初始为 1 个结点
            // 第一次合并，每层各有一个结点： 1 1
            // 第二次合并：1 2 1
            // 第三次合并：1 3 3 1
            // ……
            // 根据合并的规律，我们可以发现如下结论：
            // 最坏情况下，
            // 假设第 k 层的结点数量为 S(k)，则每次合并操作后的 S'(k) = S(k) + S(k-1)
            // 这符合杨辉三角的递推规律，因此符合二项式系数，得证。
            // 
            // 根据二项式系数的求和公式（Σ(n, k) = 2^n），n 阶二项式系数的和为 2^n。
            // 根据公式 Σ(n, k)×k = nΣ(n-1, k-1) = nΣ(n-1, s) = n*(2^(n-1))，
            // 可求平均深度为 n/2。
        }
    }
}
