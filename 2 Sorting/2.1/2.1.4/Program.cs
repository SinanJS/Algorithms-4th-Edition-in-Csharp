﻿namespace _2._1._4
{
    /*
     * 2.1.4
     * 
     * 按照算法 2.2 所示轨迹的格式给出插入排序是如何将
     * 数组 E A S Y Q U E S T I O N 排序的。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // i    j                               a[]
            //              0   1   2   3   4   5   6   7   8   9   10  11
            // 0    0       E   A   S   Y   Q   U   E   S   T   I   O   N
            // 1    0       A   E   S   Y   Q   U   E   S   T   I   O   N
            // 2    2       A   E   S   Y   Q   U   E   S   T   I   O   N
            // 3    3       A   E   S   Y   Q   U   E   S   T   I   O   N
            // 4    2       A   E   Q   S   Y   U   E   S   T   I   O   N
            // 5    4       A   E   Q   S   U   Y   E   S   T   I   O   N
            // 6    2       A   E   E   Q   S   U   Y   S   T   I   O   N
            // 7    5       A   E   E   Q   S   S   U   Y   T   I   O   N
            // 8    6       A   E   E   Q   S   S   T   U   Y   I   O   N
            // 9    3       A   E   E   I   Q   S   S   T   U   Y   O   N
            // 10   4       A   E   E   I   O   Q   S   S   T   U   Y   N
            // 11   4       A   E   E   I   N   O   Q   S   S   T   U   Y
        }
    }
}
