﻿namespace _2._4._32
{
    /*
     * 2.4.32
     * 
     * 下界。
     * 请证明，
     * 不存在一个基于比较的对 MinPQ 的 API 的实现
     * 能够使得插入元素和删除最小元素的操作都保证只使用 ~NloglogN 次比较。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // 如果这样的话，堆排序的只需要 ~nloglogn 次比较即可。
            // 根据 2.3 中的证明，基于比较的排序的下界是 ~nlogn。
            // 因此不存在这样的最小堆。
            // 注意上题的方法不能用于下沉操作，因为我们不能预知下沉的路径。
        }
    }
}
