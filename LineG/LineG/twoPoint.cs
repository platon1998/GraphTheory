using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineG
{
    class twoPoint
    {
        public int fnum;
        public int snum;
        public Point X;
        public Point Y;
        public int num;
        public int weight;
        public Color colormy2;
        public bool ischoose;
        public twoPoint(int fnum2, int snum2, Point x, Point y, int curnum, int weight2, Color colmy2, bool choose)
        {
            fnum = fnum2;
            snum = snum2;
            X = x;
            Y = y;
            num = curnum;
            weight = weight2;
            colormy2 = colmy2;
            ischoose = choose;
        }
    }

    class PointClass
    {
        public int px;
        public int py;
        public int num;
        public int radius;
        public Color colormy;
        public string textp;
        public bool ischoose;
        public PointClass(int x, int y, int n, int r2dist,Color colorx, string textp2, bool choose)
        {
            px = x;
            py = y;
            num = n;
            radius = r2dist;
            colormy = colorx;
            textp = textp2;
            ischoose = choose;
        }
    }

}
