﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Quick;

namespace _2._3._26
{
    public partial class Form2 : Form
    {
        private int M;
        private int N;

        public Form2(int m, int n)
        {
            InitializeComponent();
            this.M = m;
            this.N = n;
        }

        /// <summary>
        /// 启动页面时启动后台测试。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form2_Shown(object sender, EventArgs e)
        {
            this.Text = "正在绘图";
            this.backgroundWorker1.RunWorkerAsync();
        }

        /// <summary>
        /// 后台测试方法。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            QuickSortInsertion quickSortInsertion = new QuickSortInsertion
            {
                M = this.M
            };
            int[] data = SortCompare.GetRandomArrayInt(this.N);
            worker.ReportProgress(50);
            quickSortInsertion.Sort(data);
            e.Result = quickSortInsertion.Counts;
        }

        /// <summary>
        /// 更新后台进度方法。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.Text = "正在绘图，已完成 " + e.ProgressPercentage + " %";
        }

        /// <summary>
        /// 测试完毕，进行绘图的方法。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            //新建画布
            Graphics graphics = this.CreateGraphics();

            //翻转默认坐标系
            graphics.TranslateTransform(0, this.Height);
            graphics.ScaleTransform(1, -1);

            int[] countsOrigin = e.Result as int[];
            int[] counts = new int[countsOrigin.Length - 1];
            for (int i = 0; i < counts.Length; i++)
            {
                counts[i] = countsOrigin[i + 1];
            }

            //获取最大值
            double max = counts.Max();
            //计算间距
            double unit = this.Width / (3.0 * counts.Length + 1);
            double marginTop = 100;
            //计算直方图的矩形
            Rectangle[] rects = new Rectangle[counts.Length];
            rects[0].X = (int)unit;
            rects[0].Y = 0;
            rects[0].Width = (int)(2 * unit);
            rects[0].Height = (int)((counts[0] / max) * (this.Height - marginTop));
            for (int i = 1; i < counts.Length; ++i)
            {
                rects[i].X = (int)(rects[i - 1].X + 3 * unit);
                rects[i].Y = 0;
                rects[i].Width = (int)(2 * unit);
                rects[i].Height = (int)((counts[i] / (max + 1)) * (this.Height - marginTop));
            }

            //绘图
            graphics.FillRectangles(Brushes.Black, rects);

            //释放资源
            graphics.Dispose();

            this.Text = "绘图结果，最高次数：" + counts.Max() + " 最低次数：" + counts.Min();
        }
    }
}
