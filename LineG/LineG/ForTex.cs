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
    public class ForTex
    {
        public void start()
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
                fs.Write("\\begin{document}\n");
                fs.Close();
            }
        }
    }
}
