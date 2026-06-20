using System;
using System.Drawing;
using System.Windows.Forms;

namespace AStar_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            gr = Tual.CreateGraphics();
            harita = new int[(int)Nud_Size.Value, (int)Nud_Size.Value];
            harita_yol = new int[(int)Nud_Size.Value, (int)Nud_Size.Value];
            bitis = new Point(size-1, size-1);
        }
        Point baslangic;
        Point bitis;
        int[,] harita;
        int[,] harita_yol;
        TreeNode sira;
        TreeNode yol;
        int blueValue = 30;

        Graphics gr;
   
        private void Nud_Size_ValueChanged(object sender, EventArgs e)
        {
            harita = new int[(int)Nud_Size.Value, (int)Nud_Size.Value];
            harita_yol = new int[(int)Nud_Size.Value, (int)Nud_Size.Value];
            bitis = new Point(size - 1, size - 1);
            while (500 % (int)Nud_Size.Value != 0)
            {
                Nud_Size.Value++;
            }
        }

        public void A_Star()
        {
            sirayaEkle(new TreeNode(baslangic.X, baslangic.Y, null, hHesapla(baslangic), 0, null, null, null, null));
            while (sira != null)
            {
                TreeNode x = sira;
                if ((x.X == bitis.X) && (x.Y == bitis.Y))
                {
                    yolOlustur();
                    yenidenCiz();
                    break;
                }
                
                yolaEkle(x);

                if (sira.alt != null)
                {
                    sira = sira.alt;
                    sira.ust = null;
                }
                else
                    sira = null;

                foreach (Point p in komsuDugumler(x))
                {
                    if ((p.X < size) && (p.Y < size) && (p.X >= 0) && (p.Y >= 0))
                    {
                        if (kapaliListedeVarMi(p) != true)
                        {
                            if (harita[p.X, p.Y] == 0)
                            {
                                TreeNode t = new TreeNode(p.X, p.Y, x, hHesapla(p), 0, null, null, null, null);
                                t.g = gHesapla(t);
                                t.f = t.h + t.g;
                                sirayaEkle(t);
                            }
                        }
                    }
                }

            }
        }

        public int hHesapla(Point p)
        {
            int x = Math.Abs(p.X - bitis.X);
            int y = Math.Abs(p.Y - bitis.Y);
            return x + y;
        }

        public int gHesapla(TreeNode p)
        {
            int g = 0;
            TreeNode scout = p; 
            while (scout.geldigiYer != null)
            {
                scout = scout.geldigiYer;
                g++;
            }
            return g;
        }

        public bool kapaliListedeVarMi(Point x)
        {
            TreeNode scout = yol;
            while (scout.sag != null)
            {
                if ((scout.X == x.X) && (scout.Y == x.Y))
                    return true;
                scout = scout.sag;
            }
            if ((scout.X == x.X) && (scout.Y == x.Y))
                return true;
            else
                return false;
        }

        public void yolOlustur()
        {
            TreeNode scout = yol;
            while (scout.geldigiYer != null)
            {
                harita_yol[scout.X, scout.Y] = 2;
                scout = scout.geldigiYer;
            }
        }

        public void yolaEkle(TreeNode x)
        {
            TreeNode aranan = x.geldigiYer;
            if (aranan == null)
            {
                yol = x;
            }
            else
            {
                yol.sol = x;
                x.sag = yol;
                yol = x;
            }
        }

        public Point[] komsuDugumler(TreeNode x)
        {
            Point[] komsular = new Point[4];
            komsular[0] = new Point(x.X, x.Y - 1);
            komsular[1] = new Point(x.X - 1, x.Y);
            komsular[2] = new Point(x.X, x.Y + 1);
            komsular[3] = new Point(x.X + 1, x.Y);
            return komsular;

        }
        //Öncelik sırasına ekleme
        public void sirayaEkle(TreeNode eklenecek)
        {
            //Sıra boşsa gelen elemanı direk sıraya ekle
            if (sira == null)
            {
                sira = eklenecek;
                return;
            }

            // scout sıra üzerinde gezecek pointer
            TreeNode scout = sira;

            while (true)
            {
                // eklenecek olan düğümün f(x) değeri o anki düğümden daha küçükse önüne eklenecek
                if (eklenecek.f <= scout.f)
                {
                    if ((eklenecek.X == scout.X) && (eklenecek.Y == scout.Y))
                    {
                        break;
                    }
                    eklenecek.alt = scout;
                    if (scout.ust != null)
                    {
                        eklenecek.ust = scout.ust;
                        scout.ust = eklenecek;
                    }
                    else
                    {                        
                        scout.ust = eklenecek;
                        sira = eklenecek;
                    }
                    break;
                }
                // daha küçük değilse bir sonraki düğüme bakılacak
                else
                {
                    // eğer birsonraki düğüm yoksa o zaman eklenecek değer son düğüm olacak
                    if (scout.alt == null)
                    {
                        scout.alt = eklenecek;
                        eklenecek.ust = scout;
                        break;
                    }
                    scout = scout.alt; 
                }
            }

        }
        int birBirim;
        int size;

        private void Tual_MouseDown(object sender, MouseEventArgs e)
        {
            size = (int)Nud_Size.Value;
            birBirim = 500 / size;

            int currentX = e.X / birBirim;
            int currentY = e.Y / birBirim;

            if (e.Button == MouseButtons.Left)
            {
                if (harita[currentX, currentY] != 1)
                {
                    harita[currentX, currentY] = 1;
                    yenidenCiz();
                }
            }
            else if (e.Button == MouseButtons.Middle)
            {
                baslangic = new Point(currentX, currentY);
                yenidenCiz();
            }
            else if (e.Button == MouseButtons.Right)
            {
                bitis = new Point(currentX, currentY);
                yenidenCiz();
            }
            

        }

        public void yenidenCiz()
        {
            gr.Clear(Color.FromKnownColor(KnownColor.Control));
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (harita[i,j] == 1)
                    {
                        gr.FillRectangle(Brushes.Black, i * birBirim, j * birBirim, birBirim, birBirim);
                        gr.DrawRectangle(new Pen(Brushes.Silver), i * birBirim, j * birBirim, birBirim, birBirim);
                    }
                    if (harita_yol[i, j] == 2)
                    {
                        if(blueValue<253)
                            blueValue += 2;
                        Brush b = new SolidBrush(Color.FromArgb(5,5,blueValue));
                        gr.FillRectangle(b, i * birBirim, j * birBirim, birBirim, birBirim);
                    }
                }
            }
            gr.FillRectangle(Brushes.Green, baslangic.X* birBirim, baslangic.Y * birBirim, birBirim, birBirim);
            gr.FillRectangle(Brushes.Red, bitis.X * birBirim, bitis.Y * birBirim, birBirim, birBirim);
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            yenidenCiz();
        }

        private void Btn_AStar_Click(object sender, EventArgs e)
        {
            blueValue = 30;
            harita_yol = new int[(int)Nud_Size.Value, (int)Nud_Size.Value];
            yol = null;
            sira = null;
            A_Star();
            yolOlustur();
            yenidenCiz();
        }

        private void Btn_Yenile_Click(object sender, EventArgs e)
        {
            harita_yol = new int[(int)Nud_Size.Value, (int)Nud_Size.Value];
            harita = new int[(int)Nud_Size.Value, (int)Nud_Size.Value];
            yol = null;
            sira = null;
            blueValue = 30;
            baslangic = new Point();
            bitis = new Point(size - 1, size - 1);
            yenidenCiz();
        }

    }

}
