﻿using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using UnionFind;

namespace _1._5._26
{
    /*
     * 1.5.26
     * 
     * Erdös-Renyi 模型的均摊成本图像。
     * 开发一个用例，
     * 从命令行接受一个 int 值 N，在 0 到 N-1 之间产生随机整数对，
     * 调用 connected() 判断它们是否相连，
     * 如果不是则用 union() 方法（和我们的开发用例一样）。
     * 不断循环直到所有触点互通。
     * 按照正文的样式将所有操作的均摊成本绘制成图像。
     * 
     */
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Compute();
            Application.Run(new Form1());
        }

        static void Compute()
        {
            int size = 200;
            QuickFindUF quickFind = new QuickFindUF(size);
            QuickUnionUF quickUnion = new QuickUnionUF(size);
            WeightedQuickUnionUF weightedQuickUnion = new WeightedQuickUnionUF(size);
            Connection[] connections = ErdosRenyi.Generate(size);

            int[] quickFindResult = new int[size];
            int[] quickUnionResult = new int[size];
            int[] weightedQuickUnionResult = new int[size];
            int p, q;
            for (int i = 0; i < size; i++)
            {
                p = connections[i].P;
                q = connections[i].Q;

                quickFind.Union(p, q);
                quickUnion.Union(p, q);
                weightedQuickUnion.Union(p, q);
                quickFindResult[i] = quickFind.ArrayVisitCount;
                quickUnionResult[i] = quickUnion.ArrayVisitCount;
                weightedQuickUnionResult[i] = weightedQuickUnion.ArrayParentVisitCount + weightedQuickUnion.ArraySizeVisitCount;

                quickFind.ResetArrayCount();
                quickUnion.ResetArrayCount();
                weightedQuickUnion.ResetArrayCount();
            }

            Draw(quickFindResult, "Quick-Find");
            Draw(quickUnionResult, "Quick-Union");
            Draw(weightedQuickUnionResult, "Weighted Quick-Union");
        }

        static void Draw(int[] cost, string title)
        {
            // 构建 total 数组。
            int[] total = new int[cost.Length];
            total[0] = cost[0];
            for (int i = 1; i < cost.Length; i++)
            {
                total[i] = total[i - 1] + cost[i];
            }

            // 获得最大值。
            int costMax = cost.Max();

            // 新建绘图窗口。
            Form2 plot = new Form2();
            plot.Text = title;
            plot.Show();
            Graphics graphics = plot.CreateGraphics();

            // 获得绘图区矩形。
            RectangleF rect = plot.ClientRectangle;
            float unitX = rect.Width / 10;
            float unitY = rect.Width / 10;

            // 添加 10% 边距作为文字区域。
            RectangleF center = new RectangleF
                (rect.X + unitX, rect.Y + unitY,
                rect.Width - 2 * unitX, rect.Height - 2 * unitY);

            // 绘制坐标系。
            graphics.DrawLine(Pens.Black, center.Left, center.Top, center.Left, center.Bottom);
            graphics.DrawLine(Pens.Black, center.Left, center.Bottom, center.Right, center.Bottom);
            graphics.DrawString(costMax.ToString(), plot.Font, Brushes.Black, rect.Location);
            graphics.DrawString(cost.Length.ToString(), plot.Font, Brushes.Black, center.Right, center.Bottom);
            graphics.DrawString("0", plot.Font, Brushes.Black, rect.Left, center.Bottom);

            // 初始化点。
            PointF[] grayPoints = new PointF[cost.Length];
            PointF[] redPoints = new PointF[cost.Length];
            unitX = center.Width / cost.Length;
            unitY = center.Width / costMax;

            for (int i = 0; i < cost.Length; i++)
            {
                grayPoints[i] = new PointF(center.Left + unitX * (i + 1), center.Bottom - (cost[i] * unitY));
                redPoints[i] = new PointF(center.Left + unitX * (i + 1), center.Bottom - ((total[i] / (i + 1)) * unitY));
            }

            // 绘制点。
            for (int i = 0; i < cost.Length; i++)
            {
                graphics.FillEllipse(Brushes.Gray, new RectangleF(grayPoints[i], new SizeF(5, 5)));
                graphics.FillEllipse(Brushes.Red, new RectangleF(redPoints[i], new SizeF(5, 5)));
            }

            graphics.Dispose();
        }
    }
}
