﻿namespace _2._5._30
{
    /*
     * 2.5.30
     * 
     * Boerner 定理。
     * 真假判断：
     * 如果你先将一个矩阵的每一列排序，再将矩阵的每一行排序，
     * 所有的列仍然是有序的。
     * 证明你的结论。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // 正确。
            // 不妨按照升序排序，设 x11 代表第 1 列第 1 行的元素。
            // 首先保证矩阵的各列是有序的。
            // 接下来考虑第一列的第一个元素 x11，现在对第一行排序。
            // 排序结果无非两种，要么 x11 不变，或者 x11 和另一个更小的元素交换。
            // 如果 x11 不变，显然第一列仍然有序。
            // 如果 x11 被另一个元素替代，那么这个元素一定比 x11 小（行升序排序）。
            // 于是第一列仍然有序，即对第一行排序不影响已经排序的第一列。
            // 对于其他列也有同样的结论，因此对第一行排序不会影响每一列的有序性。
            // 
            // 于是第一行排序之后，矩阵变为第一行有序，每一列都有序
            // 我们再次考虑 x11，
            // 显然现在 x11 小于第一行的所有元素，也小于第一列的所有元素。
            // 又由于矩阵每一列都有序，即第一行每个元素都是本列的最小值，
            // 于是 x11 就是整个矩阵的最小值
            // 因此在第二行不存在比 x11 更小的元素
            // 考虑选择排序，我们把第二行的最小值交换到 x12 的位置上，暂时去掉第一列。
            // 剩下的子矩阵又变成了开始的情况，以此类推可以把整个第二行排序。
            // 同时可以保证第二行没有元素会小于同列的第一行元素。
            // 于是第二行排序之后整个矩阵仍然列有序，同时第一行和第二行也有序。
            // 
            // 剩下的行都能以此类推，于是定理得证。
        }
    }
}
