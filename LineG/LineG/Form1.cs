using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Drawing.Drawing2D;

namespace LineG
{
    public partial class Form1 : Form
    {
        int MAXN = 100;
        List<twoPoint> twoPoint = new List<twoPoint> { };
        List<PointClass> mypoint = new List<PointClass> { };
        List<List<int>> G = new List<List<int>>();
        List<int> check = new List<int>();
        List<List<int>> P = new List<List<int>>();
        List<bool> useddfs = new List<bool>();
        List<int> a = new List<int>();
        List<int> b = new List<int>();
        List<int> c = new List<int>();
        int X;
        int Y;
        int X1;
        int Y1;
        int cX;
        int cY;
        int vvod;
        int currentpointnumber;
        int currentlinenumber;
        int nextpoint = 0;
        bool clickonpoint = false;
        bool tapnew = true;
        bool upnew = true;
        bool ifclick = false;
        bool newlineisok = true;
        bool newpointblue = true;
        //bool newlineforpaint = true;
        bool tap = false;
        bool isclickliine = true;
        bool isitpoint = true;
        bool isitmoved = false;
        bool drawlineforclick = true;
        bool isitclick = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            isclickliine = true;
            clickonpoint = false;
            newpointblue = true;
            isitpoint = true;
            MouseEventArgs my = (MouseEventArgs)e;
            switch (my.Button)
            {
                case MouseButtons.Right:
                    foreach (var q in mypoint)
                        q.ischoose = false;
                    foreach (var q in twoPoint)
                        q.ischoose = false;
                    pictureBox1.Invalidate();
                    isitclick = true;
                    ifclick = true;
                    int CurX = my.X;
                    int CurY = my.Y;
                    foreach (var q in mypoint)
                    {
                        double dist = Math.Sqrt((CurX - q.px) * (CurX - q.px) + (CurY - q.py) * (CurY - q.py));
                        if (dist <= q.radius * 2)
                        {
                            q.ischoose = true;
                            clickonpoint = true;
                            Console.Write("last");
                            Number.Clear();
                            Number.Text += q.num;
                            currentpointnumber = q.num;
                            Size.Clear();
                            Size.Text += q.radius;
                            ChooseColor.BackColor = q.colormy;
                            isclickliine = false;
                        }
                    }
                    if (isclickliine)
                    {
                        isitpoint = false;
                        foreach (var q in twoPoint)
                        {
                            int x1 = q.X.X; // Px
                            int y1 = q.X.Y; // Py
                            int x2 = q.Y.X; // Qx
                            int y2 = q.Y.Y; // Qy
                            double Mx = my.X;
                            double My = my.Y;
                            double A = y1 - y2;
                            double B = x2 - x1;
                            double C = -1 * A * x1 - B * y1;
                            double dis = (Math.Abs(A * Mx + B * My + C)) / (Math.Sqrt(A * A + B * B));
                            if (dis < 10)
                            {
                                q.ischoose = true;
                                currentlinenumber = q.num;
                                //MessageBox.Show("))");
                                Number.Clear();
                                Number.Text += q.num;
                                Size.Clear();
                                Size.Text += q.weight;
                                ChooseColor.BackColor = q.colormy2;
                                break;
                            }
                        }
                    }
                    tapnew = false;
                    break;

                case MouseButtons.Left:
                    /*cX = my.X;
                    cY = my.Y;
                    bool clickyes = true;
                    foreach (var q in mypoint){
                        double dist = Math.Sqrt((cX - q.px) * (cX - q.px) + (cY - q.py) * (cY - q.py));
                        if (dist <= q.radius * 2){
                            clickyes = false;
                        }
                    }
                    if (clickyes)
                    {
                        drawlineforclick = false;
                        mypoint.Add(new PointClass(cX, cY, nextpoint, 10, Color.Blue));
                        //for (int i = 0; i < G.Count; i++ )
                            //MessageBox.Show("1");
                        G.Add(new List<int>());
                        //for (int i = 0; i < G.Count; i++)
                          //  MessageBox.Show("1.1");
                        //check.Add(nextpoint);
                        P.Add(new List<int>());
                        P[nextpoint].Add(cX);
                        P[nextpoint].Add(cY);

                        nextpoint++;
                    }
                    pictureBox1.Invalidate();*/
                    break;
            }
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            newpointblue = true;
            switch (e.Button)
            {
                case MouseButtons.Left:
                    tap = true;
                    X = e.X;
                    Y = e.Y;
                    foreach (var q in mypoint)
                    {
                        double dist = Math.Sqrt((X - q.px) * (X - q.px) + (Y - q.py) * (Y - q.py));
                        if (dist <= q.radius * 2)
                        {
                            X = q.px;
                            Y = q.py;
                            tapnew = false;
                        }
                    }
                    break;
            }
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (tap)
            {
                isitmoved = true;
                X1 = e.X;
                Y1 = e.Y;
                pictureBox1.Invalidate();
                foreach (var q in mypoint)
                {
                    double dist = Math.Sqrt((e.X - q.px) * (e.X - q.px) + (e.Y - q.py) * (e.Y - q.py));
                    if (dist <= q.radius * 2)
                    {
                        X1 = q.px;
                        Y1 = q.py;
                        //if(X1 != X && Y1 != Y)
                        //  upnew = false;
                    }
                }
                double dist2 = Math.Sqrt((e.X - X) * (e.X - X) + (e.Y - Y) * (e.Y - Y));
                if (dist2 <= 10 * 2)
                {
                    X1 = X;
                    Y1 = Y;
                }
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            MouseEventArgs M = (MouseEventArgs)e;
            switch (M.Button)
            {
                case MouseButtons.Left:
                    tap = false;
                    newpointblue = true;
                    X1 = e.X;
                    Y1 = e.Y;
                    double distfornew = Math.Sqrt((X - e.X) * (X - e.X) + (Y - e.Y) * (Y - e.Y));
                    if (distfornew <= 20)
                    {
                        X1 = X;
                        Y1 = Y;
                    }
                    foreach (var q in mypoint)
                    {
                        double dist = Math.Sqrt((e.X - q.px) * (e.X - q.px) + (e.Y - q.py) * (e.Y - q.py));
                        if (dist <= q.radius * 2)
                        {
                            X1 = q.px;
                            Y1 = q.py;
                            upnew = false;
                        }
                    }
                    if (X1 != X && Y1 != Y && !isitclick) // && isitmoved)
                    {
                        /*nextpoint--;
                        mypoint.RemoveAt(nextpoint);
                        G.RemoveAt(nextpoint);
                        P.RemoveAt(nextpoint);*/

                        Point currentpointforlineX = new Point(X, Y);
                        Point currentpointforlineY = new Point(X1, Y1);
                        foreach (var q in twoPoint)
                        {
                            if ((q.X == currentpointforlineX && q.Y == currentpointforlineY) || (q.X == currentpointforlineX && q.Y == currentpointforlineY))
                            {
                                newlineisok = false;
                                //newlineforpaint = false;
                            }
                        }

                        foreach (var q in mypoint)
                        {
                            if (X1 == q.px && Y1 == q.py && X != q.px && Y != q.py)
                            {
                                pictureBox1.Invalidate();
                                upnew = false;
                            }
                        }
                        /////////*

                        if (tapnew)
                        {

                            mypoint.Add(new PointClass(X, Y, nextpoint, 10, Color.Blue, "", false));
                            //for (int i = 0; i < G.Count; i++)
                            //MessageBox.Show("2");
                            G.Add(new List<int>());
                            //for (int i = 0; i < G.Count; i++)
                            //  MessageBox.Show("2.1");
                            //check.Add(nextpoint);

                            P.Add(new List<int>());
                            P[nextpoint].Add(X);
                            P[nextpoint].Add(Y);

                            nextpoint++;
                        }
                        if (upnew)
                        {
                            mypoint.Add(new PointClass(X1, Y1, nextpoint, 10, Color.Blue, "", false));
                            G.Add(new List<int>());
                            //check.Add(nextpoint);

                            P.Add(new List<int>());
                            P[nextpoint].Add(X1);
                            P[nextpoint].Add(Y1);
                            //MessageBox.Show("lolok");
                            pictureBox1.Invalidate();
                            nextpoint++;
                        }
                        //for X,Y
                        int firstnum = -1;
                        int secondnum = -1;
                        bool addnew = false;
                        bool addnew2 = false;
                        foreach (var q in mypoint)
                        {
                            if (X == q.px && Y == q.py)
                            {
                                firstnum = q.num;
                                addnew = true;
                            }
                            if (X1 == q.px && Y1 == q.py)
                            {
                                addnew2 = true;
                                secondnum = q.num;
                            }
                        }
                        //CHECK
                        //if (upnew || tapnew)
                        //{
                        //  G[firstnum].Add(secondnum);
                        //  G[secondnum].Add(firstnum);
                        //}
                        Point c1xy = new Point(X, Y);
                        Point c2xy = new Point(X1, Y1);
                        bool newline = true;
                        foreach (var q in twoPoint)
                        {
                            if (q.X == c1xy && q.Y == c2xy)
                                newline = false;
                        }
                        if (newline && addnew && addnew2)
                        {
                            G[firstnum].Add(secondnum);
                            G[secondnum].Add(firstnum);
                        }
                        if (newlineisok)
                        {
                            twoPoint.Add(new twoPoint(firstnum, secondnum, new Point(X, Y), new Point(X1, Y1), currentlinenumber, 0, Color.Black, false));
                            currentlinenumber++;
                        }
                        newlineisok = true;
                        newline = true;
                        upnew = true;
                        addnew = false;
                        addnew2 = false;
                    }
                    else
                    {
                        if (tapnew && !isitclick)// && isitmoved)
                        {
                            mypoint.Add(new PointClass(X, Y, nextpoint, 10, Color.Blue, "", false));
                            G.Add(new List<int>());
                            //check.Add(nextpoint);

                            P.Add(new List<int>());
                            P[nextpoint].Add(X);
                            P[nextpoint].Add(Y);

                            nextpoint++;
                            pictureBox1.Invalidate();
                        }
                    }
                    tapnew = true;
                    ifclick = false;
                    isitmoved = false;
                    isitclick = false;
                    break;
            }
            newlineisok = true;
            upnew = true;
            tapnew = true;
            ifclick = false;
            isitmoved = false;
            isitclick = false;
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black);
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            if (newpointblue && drawlineforclick && !ifclick)
            {
                e.Graphics.DrawLine(pen, new Point(X, Y), new Point(X1, Y1));
                e.Graphics.DrawEllipse(Pens.Blue, X - 10, Y - 10, 20, 20);
                e.Graphics.FillEllipse(Brushes.Blue, X - 10, Y - 10, 20, 20);
                e.Graphics.DrawEllipse(Pens.Blue, X1 - 10, Y1 - 10, 20, 20);
                e.Graphics.FillEllipse(Brushes.Blue, X1 - 10, Y1 - 10, 20, 20);
            }
            drawlineforclick = true;
            Pen penchoose = new Pen(Color.Orange);
            SolidBrush choosebrush = new SolidBrush(Color.Orange);
            foreach (var p in twoPoint)
            {
                if (p.ischoose)
                {
                    Point fc1 = new Point(p.X.X, p.X.Y);
                    Point fc2 = new Point(p.Y.X, p.Y.Y);
                    fc1.X--;
                    fc2.X--;
                    e.Graphics.DrawLine(penchoose, fc1, fc2);
                    fc1.X--;
                    fc2.X--;
                    e.Graphics.DrawLine(penchoose, fc1, fc2);
                    fc1.X--;
                    fc2.X--;
                    e.Graphics.DrawLine(penchoose, fc1, fc2);
                    fc1.X += 4;
                    fc2.X += 4;
                    e.Graphics.DrawLine(penchoose, fc1, fc2);
                    fc1.X++;
                    fc2.X++;
                    e.Graphics.DrawLine(penchoose, fc1, fc2);
                    fc1.X++;
                    fc2.X++;
                    e.Graphics.DrawLine(penchoose, fc1, fc2);
                    fc1.X -= 3;
                    fc2.X -= 3;
                    fc1.Y--;
                    fc2.Y--;
                    e.Graphics.DrawLine(penchoose, fc1, fc2);
                    fc1.Y--;
                    fc2.Y--;
                    e.Graphics.DrawLine(penchoose, fc1, fc2);
                    fc1.Y--;
                    fc2.Y--;
                    e.Graphics.DrawLine(penchoose, fc1, fc2);
                    fc1.Y += 4;
                    fc2.Y += 4;
                    e.Graphics.DrawLine(penchoose, fc1, fc2);
                    fc1.Y++;
                    fc2.Y++;
                    e.Graphics.DrawLine(penchoose, fc1, fc2);
                    fc1.Y++;
                    fc2.Y++;
                    e.Graphics.DrawLine(penchoose, fc1, fc2);
                }
                Pen penforline = new Pen(p.colormy2);
                e.Graphics.DrawLine(penforline, p.X, p.Y);
            }
            foreach (var q in mypoint)
            {
                Pen penforpoint = new Pen(q.colormy);
                SolidBrush myBrush = new SolidBrush(q.colormy);
                if (q.ischoose)
                {
                    e.Graphics.DrawEllipse(penchoose, q.px - q.radius - 4, q.py - q.radius - 4, q.radius * 2 + 8, q.radius * 2 + 8);
                    e.Graphics.FillEllipse(choosebrush, q.px - q.radius - 4, q.py - q.radius - 4, q.radius * 2 + 8, q.radius * 2 + 8);
                }
                e.Graphics.DrawEllipse(penforpoint, q.px - q.radius, q.py - q.radius, q.radius * 2, q.radius * 2);
                e.Graphics.FillEllipse(myBrush, q.px - q.radius, q.py - q.radius, q.radius * 2, q.radius * 2);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (int q in check)
            {
                Console.Write(check[q]);
            }
            Console.WriteLine(" ");
            foreach (var q in mypoint)
            {
                Console.Write(q.num);
            }
            Console.Write(nextpoint);
            Console.WriteLine(" answer ");
            for (int i = 0; i < nextpoint; i++)
            {
                for (int q = 0; q < G[i].Count; q++)
                    Console.Write(G[i][q]);
                Console.WriteLine(" ");
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\project\answer.txt");
            for (int i = 0; i < nextpoint; i++)
            {
                file.Write(P[i][0]);
                file.Write(" ");
                file.Write(P[i][1]);
                file.Write(" ");

                for (int q = 0; q < G[i].Count; q++)
                {
                    file.Write(G[i][q]);
                    file.Write(" ");
                }
                file.WriteLine(" ");
            }
            file.Close();
            Console.WriteLine("Ok. File has been updated.");
            // Process.Start(/*"Notepad.exe", */"C:\myPath\answer.txt");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("Notepad.exe", "C:\\project\\answer.txt");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Process.Start("C:/Dop/latextex/miktex/bin/x64/texworks.exe", "C:\\project\\fortex.txt");
            Process.Start(@"C:/Dop/MyTest.tex");
        }

        private void button5_Click(object sender, EventArgs e)
        {


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

            string path = @"c:\Dop\MyTest.tex";

            // Delete the file if it exists.
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using (FileStream fs = File.Create(path))
            {
                AddText(fs, "\\documentclass[20p]{beamer}\n");
                AddText(fs, "\\usepackage[all]{xy}\n");
                AddText(fs, "\\usepackage{float}\n");
                AddText(fs, "\\usepackage{graphicx}\n");
                AddText(fs, "\\usepackage{tikz}\n");
                AddText(fs, "\\usepackage{caption}\n");
                AddText(fs, "\\usetikzlibrary{graphs}\n");
                AddText(fs, "\\usetikzlibrary{shapes}\n");
                AddText(fs, "\\newfloat{figure}{htbp}{figs}\n");
                AddText(fs, "\\setbeamertemplate{navigation symbols}{}\n");
                AddText(fs, "\\begin{document}\n");
                AddText(fs, "\\begin{frame}\n");
                //AddText(fs, "\\begin{picture}(500,500)\n");
                AddText(fs, "\\begin{tikzpicture}[scale=0.0263]\n");
                for (int i = 0; i < nextpoint; i++)
                {
                    AddText(fs, "\\draw(" + P[i][0] + "," + (500 - P[i][1]) + ")[fill = black]circle(6);" + '\n');
                    AddText(fs, "\\draw(" + P[i][0] + "," + (500 - P[i][1]) + ")node[below left] {$" + i + "$};" + '\n');
                }
                //\draw [black] (0,0) -- (50, 25);
                for (int i = 0; i < nextpoint; i++)
                {
                    int curx = P[i][0];
                    int cury = P[i][1];
                    for (int j = 0; j < G[i].Count; j++)
                    {
                        AddText(fs, "\\draw (" + P[i][0] + "," + (500 - P[i][1]) + ") -- (" + P[G[i][j]][0] + "," + (500 - P[G[i][j]][1]) + ");\n");
                    }
                }
                AddText(fs, "\\end{tikzpicture}\n");
                //AddText(fs, "\\end{picture}\n");
                AddText(fs, "\\end{frame}\n");
                AddText(fs, "\\end{document}\n");
                fs.Close();
            }
            //Open the stream and read it back.
            using (FileStream fs = File.OpenRead(path))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);
                while (fs.Read(b, 0, b.Length) > 0)
                {
                    Console.WriteLine(temp.GetString(b));
                }
                fs.Close();
            }
        }
        void start()
        {
            string path = @"c:\Dop\MyTest.tex";
            using (StreamWriter fs = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                fs.Write("\\documentclass[20p]{beamer}\n");
                fs.Write("\\usepackage[all]{xy}\n");
                fs.Write("\\usepackage{float}\n");
                fs.Write("\\usepackage{graphicx}\n");
                fs.Write("\\usepackage{tikz}\n");
                fs.Write("\\usepackage{caption}\n");
                fs.Write("\\usetikzlibrary{graphs}\n");
                fs.Write("\\usetikzlibrary{shapes}\n");
                fs.Write("\\newfloat{figure}{htbp}{figs}\n");
                fs.Write("\\setbeamertemplate{navigation symbols}{}\n");
                fs.Write("\\usetheme{CambridgeUS}\n");
                fs.Write("\\title{Depth first search}\n");
                fs.Write("\\author{RTM, 11 cmc}\n");
                fs.Write("\\begin{document}\n");
                fs.Write("\\begin{frame}\n");
                fs.Write("\\titlepage\n");
                fs.Write("\\end{frame}\n");
                fs.Close();
            }
        }
        void end()
        {
            string path = @"c:\Dop\MyTest.tex";
            using (StreamWriter fs = new StreamWriter(path, true, System.Text.Encoding.Default))
            {
                fs.Write("\\begin{frame}{Final slide}\n");
                fs.Write("\\begin{center}\n");
                fs.Write("\\textup{Thank you for attention!}\n");
                fs.Write("\\end{center}\n");
                fs.Write("\\end{frame}\n");
                fs.Write("\\end{document}\n");
                fs.Close();
            }
        }
        void bone()
        {
            string path = @"c:\Dop\MyTest.tex";
            using (StreamWriter fs = new StreamWriter(path, true, System.Text.Encoding.Default))
            {
                fs.Write("\\begin{tikzpicture}[scale=0.0263]\n");
                for (int i = 0; i < nextpoint; i++)
                {
                    fs.Write("\\draw(" + P[i][0] + "," + (500 - P[i][1]) + ")[fill =" + "black" + "]circle(6);" + '\n');
                    fs.Write("\\draw(" + P[i][0] + "," + (500 - P[i][1]) + ")node[below left] {$" + i + "$};" + '\n');
                }
                for (int i = 0; i < nextpoint; i++)
                {
                    int curx = P[i][0];
                    int cury = P[i][1];
                    for (int j = 0; j < G[i].Count; j++)
                    {
                        fs.Write("\\draw (" + P[i][0] + "," + (500 - P[i][1]) + ") -- (" + P[G[i][j]][0] + "," + (500 - P[G[i][j]][1]) + ");\n");
                    }
                }
                fs.Write("\\end{tikzpicture}\n");
            }
        }
        void pointtext(int numberofp, string kiki)
        {
            string path = @"c:\Dop\MyTest.tex";
            using (StreamWriter fs = new StreamWriter(path, true, System.Text.Encoding.Default))
            {
                fs.Close();
            }
        }
        void bone2()
        {
            string path = @"c:\Dop\MyTest.tex";
            using (StreamWriter fs = new StreamWriter(path, true, System.Text.Encoding.Default))
            {
                fs.Write("\\begin{tikzpicture}[scale=0.0263]\n");
                foreach (var q in twoPoint)
                {
                    string currentcolor = q.colormy2.Name;
                    currentcolor = currentcolor.ToLower();
                    fs.Write("\\draw[" + currentcolor + "](" + q.X.X + "," + (500 - q.X.Y) + ")--(" + q.Y.X + "," + (500 - q.Y.Y) + ");\n");
                }
                foreach (var q in twoPoint)
                {
                    int Xw = (q.X.X + q.Y.X) / 2;
                    int Yw = (q.X.Y + q.Y.Y) / 2;
                    fs.Write("\\draw(" + Xw + "," + (500 - Yw) + ")node[color=red]{$" + q.weight + "$};" + '\n');
                }
                foreach (var q in mypoint)
                {
                    string currentcolor = q.colormy.Name;
                    currentcolor = currentcolor.ToLower();
                    fs.Write("\\draw(" + q.px + "," + (500 - q.py) + ")[fill=" + currentcolor + "]circle(" + (q.radius + 3) + ");\n");
                    if (q.ischoose)
                        fs.Write("\\draw(" + q.px + "," + (500 - q.py) + ")[fill=cyan]circle(" + q.radius + ");\n");
                    else
                        fs.Write("\\draw(" + q.px + "," + (500 - q.py) + ")[fill=white]circle(" + q.radius + ");\n");
                    fs.Write("\\draw(" + q.px + "," + (500 - q.py) + ")node{$" + q.num + "$};" + '\n');
                    //fs.Write("\\draw(" + q.px + "," + (500 - q.py + 20) + ")node{" + q.textp + "}" +'\n');
                }
                fs.Write("\\end{tikzpicture}\n");

                fs.Close();
            }
        }
        void open()
        {
            string path = @"c:\Dop\MyTest.tex";
            using (StreamWriter fs = new StreamWriter(path, true, System.Text.Encoding.Default))
            {
                fs.Write("\\begin{frame}\n");
                fs.Close();
            }
        }
        void close()
        {
            string path = @"c:\Dop\MyTest.tex";
            using (StreamWriter fs = new StreamWriter(path, true, System.Text.Encoding.Default))
            {
                fs.Write("\\end{frame}\n");
                fs.Close();
            }
        }
        void ColorLine(int fp, int sp, Color curcol)
        {
            Point fpcolor = new Point(P[fp][0], P[fp][1]);
            Point spcolor = new Point(P[sp][0], P[sp][1]);
            foreach (var q in twoPoint)
            {
                if ((fpcolor == q.X && spcolor == q.Y) || (fpcolor == q.Y && spcolor == q.X))
                    q.colormy2 = curcol;
            }
        }
        void ColorPoint(int number, Color pointcolor)
        {
            foreach (var q in mypoint)
            {
                if (q.num == number)
                    q.colormy = pointcolor;
            }
        }
        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }
        private void button7_Click(object sender, EventArgs e)
        {

        }
        private void number_TextChanged(object sender, EventArgs e)
        {

        }

        private void ChooseColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                //display(colorDialog1.Color.Name);
                ChooseColor.BackColor = colorDialog1.Color;
            }
        }
        private void display(string text)
        {
            MessageBox.Show(text);
        }
        private void Apply_Click(object sender, EventArgs e)
        {

            if (clickonpoint)
            {
                foreach (var q in mypoint)
                {
                    if (q.num == currentpointnumber)
                    {
                        q.radius = Convert.ToInt32(Size.Text);
                        q.colormy = ChooseColor.BackColor;

                    }
                }
                newpointblue = false;
                pictureBox1.Invalidate();
            }
            if (isclickliine)
            {
                foreach (var q in twoPoint)
                {
                    if (q.num == currentlinenumber)
                    {
                        q.weight = Convert.ToInt32(Size.Text);
                        q.colormy2 = ChooseColor.BackColor;
                    }
                }
                pictureBox1.Invalidate();
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            bool delpoint = false;
            foreach (var q in mypoint)
            {
                if (q.num == currentpointnumber)
                    delpoint = true;
            }
            bool delline = false;
            foreach (var q in twoPoint)
            {
                if (q.num == currentlinenumber)
                    delline = true;
            }
            if (clickonpoint && delpoint)
            {
                int cx1 = 0;
                int cy1 = 0;
                int minus = 0;

                foreach (var q in mypoint)
                {
                    if (q.num == currentpointnumber)
                    {
                        cx1 = q.px;
                        cy1 = q.py;
                        break;
                    }
                    minus++;
                }
                for (int i = currentpointnumber; i < mypoint.Count; i++)
                {
                    mypoint[i].num -= 1;
                }
                minus = 0;
                Point curdel = new Point(cx1, cy1);
                int twodel = 0;
                for (int z = 0; z < twoPoint.Count; z++)
                {
                    foreach (var q in twoPoint)
                    {
                        if (q.X == curdel || q.Y == curdel)
                        {
                            twoPoint.RemoveAt(twodel);
                            twodel = 0;
                            break;
                        }
                        twodel++;
                    }
                }
                mypoint.RemoveAt(currentpointnumber);
                newpointblue = false;

                for (int i = 0; i < G.Count; i++)
                {
                    for (int j = 0; j < G[i].Count; j++)
                    {
                        if (G[i][j] == currentpointnumber)
                        {
                            G[i].Remove(currentpointnumber);
                            break;
                        }
                    }
                }
                G.RemoveAt(currentpointnumber);
                for (int i = 0; i < G.Count; i++)
                {
                    for (int j = 0; j < G[i].Count; j++)
                    {
                        if (G[i][j] > currentpointnumber)
                            G[i][j] -= 1;
                    }
                }
                P.RemoveAt(currentpointnumber);
                nextpoint--;
                foreach (var q in mypoint)
                {
                    if (q.num == currentpointnumber)
                    {
                        q.ischoose = true;
                        break;
                    }
                }
                pictureBox1.Invalidate();
            }
            if (isclickliine && delline)
            {
                int x1del = 0, y1del = 0, x2del = 0, y2del = 0;
                //Point del1 = new Point(x1del, y1del);
                //Point del2 = new Point(x2del, y2del);
                int fdel = 0, sdel = 0;
                foreach (var q in twoPoint)
                {
                    if (q.num == currentlinenumber)
                    {
                        x1del = q.X.X;
                        x2del = q.Y.X;
                        y1del = q.X.Y;
                        y2del = q.Y.Y;
                        break;
                    }
                }
                foreach (var q in mypoint)
                {
                    if (q.px == x1del && q.py == y1del)
                        fdel = q.num;
                    if (q.px == x2del && q.py == y2del)
                        sdel = q.num;
                }
                for (int i = 0; i < G[fdel].Count; i++)
                {
                    if (G[fdel][i] == sdel)
                    {
                        G[fdel].RemoveAt(i);
                        break;
                    }
                }
                for (int i = 0; i < G[sdel].Count; i++)
                {
                    if (G[sdel][i] == fdel)
                    {
                        G[sdel].Remove(i);
                        break;
                    }
                }
                int linedel = 0;
                foreach (var q in twoPoint)
                {
                    if (q.num == currentlinenumber)
                    {
                        break;
                    }
                    linedel++;
                }
                twoPoint.RemoveAt(linedel);
                if (linedel != twoPoint.Count)
                {
                    for (int i = linedel; i < twoPoint.Count; i++)
                        twoPoint[i].num -= 1;
                }

                foreach (var q in twoPoint)
                {
                    if (q.num == currentlinenumber)
                    {
                        q.ischoose = true;
                        break;
                    }
                }
                pictureBox1.Invalidate();
            }
            delpoint = false;
            delline = false;

        }
        private void myevent(object sender, EventArgs e)
        {
            Process.Start(@"C:/Dop/MyTest.pdf");
        }
        private void button5_Click_1(object sender, EventArgs e)
        {
            Process p = new Process();
            p = Process.Start(@"pdflatex", "C:/Dop/MyTest.tex -output-directory C:/Dop/");
            p.EnableRaisingEvents = true;
            p.Exited += new EventHandler(myevent);
            //Process.Start("pdflatex", "C:/Dop/MyTest.tex");
            //Process.Start(@"C:/Dop/MyTest.pdf");
        }
        void F_dfs(int cur)
        {
            foreach (var q in mypoint)
            {
                if (q.num == cur)
                    q.ischoose = true;
                else
                    q.ischoose = false;
            }
            ColorPoint(cur, Color.Yellow);
            useddfs[cur] = false;
            pointtext(cur, "inf");
            for (int j = 0; j < G[cur].Count; j++)
            {
                if (useddfs[G[cur][j]])
                {
                    //if (j == G[cur].Count - 1)
                    //ColorPoint(cur, Color.Red);
                    ColorLine(cur, G[cur][j], Color.Blue);
                    ColorPoint(G[cur][j], Color.Yellow);
                    foreach (var q in mypoint)
                    {
                        if (q.num == G[cur][j])
                            q.ischoose = true;
                        else
                            q.ischoose = false;
                    }
                    open();
                    bone2();
                    close();
                    F_dfs(G[cur][j]);
                    ColorLine(cur, G[cur][j], Color.Red);
                    foreach (var q in mypoint)
                    {
                        if (q.num == cur)
                            q.ischoose = true;
                        else
                            q.ischoose = false;
                    }
                    open();
                    bone2();
                    close();
                }
            }
            foreach (var q in mypoint)
            {
                if (q.num == cur)
                    q.ischoose = true;
                else
                    q.ischoose = false;
            }
            bool isred = true;
            for (int k = 0; k < G[cur].Count; k++)
            {
                if (useddfs[G[cur][k]])
                    isred = false;
            }
            if (isred)
            {
                Color colordfs = new Color();
                foreach (var q in mypoint)
                {
                    if (cur == q.num)
                    {
                        colordfs = q.colormy;
                        break;
                    }
                }
                if (colordfs == Color.Yellow)
                {
                    ColorPoint(cur, Color.Red);
                    open();
                    bone2();
                    close();
                }
            }
        }
        private void dfs_Click(object sender, EventArgs e)
        {
            foreach (var q in mypoint)
            {
                q.colormy = Color.Green;
                q.ischoose = false;
            }

            for (int i = 0; i < 100; i++)
            {
                useddfs.Add(true);
            }
            start();
            open();
            bone2();
            close();
            foreach (var q in mypoint)
            {
                if (q.num == 0)
                {
                    q.ischoose = true;
                    break;
                }
                else
                    q.ischoose = false;
            }
            open();
            bone2();
            close();
            F_dfs(0);
            MessageBox.Show("dfs completed");
            end();

        }
        private void button1_Click_1(object sender, EventArgs e)
        { 
            start();
            open();
            bone2();
            close();
            a.Clear();
            b.Clear();
            c.Clear();
            foreach (var q in twoPoint)
            {
                a.Add(q.fnum);
                b.Add(q.snum);
                a.Add(q.snum);
                b.Add(q.fnum);
                c.Add(q.weight);
                c.Add(q.weight);
            }
            int INT_MAX = 10000000;
            int n = P.Count;
            int st = 0;
            int[,] GR;
            GR = new int[n, n];//построить матрицу смежности с помощью списков ребер, честно спизженных у Платона
            int[] distance;
            distance = new int[n];
            int count;
            int index = 0;//эту еболу не трогать, все ок
            int i;
            int j;
            int u;
            int m = st;
            bool[] visited;
            visited = new bool[n];
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    GR[i, j] = 0;
                }
            }
            for (i = 0; i < a.Count; i++)
            {
                GR[a[i], b[i]] = c[i];
            }
            for (i = 0; i < n; i++)
            {         
                distance[i] = INT_MAX;
                visited[i] = false;
            }
            foreach (var q in mypoint)
            {
                open();
                q.ischoose = true;
                ColorPoint(q.num, Color.Red);
                bone2();
                q.ischoose = false;
                close();
            }
            distance[st] = 0;
            open();
            mypoint[st].ischoose = true;
            ColorPoint(st, Color.Green);
            bone2();
            mypoint[st].ischoose = false;
            close();
            for (count = 0; count < n - 1; count++)
            {
                int min = INT_MAX;
                for (i = 0; i < n; i++)
                    if (!visited[i] && distance[i] <= min)
                    {
                        min = distance[i];
                        index = i;
                    }
                u = index;
                visited[u] = true;
                for (i = 0; i < n; i++)
                {
                    if (!visited[i] && GR[u, i] != 0 && distance[u] != INT_MAX && distance[u] + GR[u, i] < distance[i])
                        distance[i] = distance[u] + GR[u, i];
                }
            }
            for (i = 0; i < n; i++)
            {
                if (distance[i] != INT_MAX)
                    MessageBox.Show(m + ">" + i + "=" + distance[i]);
                else
                    MessageBox.Show(m + ">" + i + "=" + "недоступно");
            }
            end();
            MessageBox.Show("vse ok");
        }
    }
}
