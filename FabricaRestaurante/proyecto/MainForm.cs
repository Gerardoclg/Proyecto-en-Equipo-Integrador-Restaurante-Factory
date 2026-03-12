using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FabricasRestaurantes
{
    public class MainForm : Form
    {
        private readonly string[]  _nombres  = { "Chino", "Japonés", "Mexicano", "Italiano", "Francés" };
        private readonly string[]  _emojis   = { "🥢",    "🍱",      "🌮",       "🍝",       "🥐"      };
        private readonly Color[]   _primarios =
        {
            Color.FromArgb(190, 30, 45),
            Color.FromArgb( 20, 60,120),
            Color.FromArgb(200, 80,  0),
            Color.FromArgb(180, 20, 20),
            Color.FromArgb( 25, 50,125),
        };
        private readonly Color[] _acentos =
        {
            Color.FromArgb(255,220,120),
            Color.FromArgb(255,182,193),
            Color.FromArgb(255,220, 50),
            Color.FromArgb(245,245,200),
            Color.FromArgb(255,235,160),
        };

        private readonly RestauranteFactory[] _fabricas =
        {
            new RestauranteChino(),
            new RestauranteJapones(),
            new RestauranteMexicano(),
            new RestauranteItaliano(),
            new RestauranteFrances(),
        };

        private int _idx = 0;

        private Panel  _sidebar   = new Panel();
        private Panel  _pnlCard   = new Panel();
        private Panel  _pnlHeader = new Panel();
        private Label  _lblTitulo    = new Label();
        private Label  _lblSubtitulo = new Label();
        private Label  _lblPlato     = new Label();
        private Label  _lblBebida    = new Label();
        private Label  _lblPostre    = new Label();
        private Button[] _botones = new Button[5];

        public MainForm()
        {
            InitializeComponent();
            MostrarMenu(0);
        }

        private void InitializeComponent()
        {
            this.Text           = "Fábrica de Restaurantes";
            this.Size           = new Size(860, 580);
            this.MinimumSize    = new Size(760, 520);
            this.StartPosition  = FormStartPosition.CenterScreen;
            this.BackColor      = Color.FromArgb(22, 22, 32);
            this.Font           = new Font("Segoe UI", 10f);
            this.DoubleBuffered = true;

            _sidebar.Dock      = DockStyle.Left;
            _sidebar.Width     = 210;
            _sidebar.BackColor = Color.FromArgb(30, 30, 42);

            var lblLogo = new Label();
            lblLogo.Text      = "🍽️  RESTAURANTES";
            lblLogo.Font      = new Font("Segoe UI", 10f, FontStyle.Bold);
            lblLogo.ForeColor = Color.FromArgb(160, 160, 200);
            lblLogo.AutoSize  = false;
            lblLogo.Bounds    = new Rectangle(0, 16, 210, 36);
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            lblLogo.BackColor = Color.Transparent;
            _sidebar.Controls.Add(lblLogo);

            var sep = new Panel();
            sep.Bounds    = new Rectangle(14, 58, 182, 1);
            sep.BackColor = Color.FromArgb(55, 55, 75);
            _sidebar.Controls.Add(sep);

            for (int i = 0; i < 5; i++)
            {
                int idx = i;
                var btn = new Button();
                btn.Text      = _emojis[i] + "  Restaurante " + _nombres[i];
                btn.TextAlign = ContentAlignment.MiddleLeft;
                btn.Font      = new Font("Segoe UI", 10f);
                btn.ForeColor = Color.FromArgb(190, 190, 220);
                btn.BackColor = Color.FromArgb(38, 38, 54);
                btn.FlatStyle = FlatStyle.Flat;
                btn.Bounds    = new Rectangle(10, 70 + i * 72, 190, 58);
                btn.Cursor    = Cursors.Hand;
                btn.Padding   = new Padding(10, 0, 0, 0);
                btn.FlatAppearance.BorderSize         = 0;
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(55, 55, 80);
                btn.Click += (s, e) => MostrarMenu(idx);
                _botones[i] = btn;
                _sidebar.Controls.Add(btn);
            }

            var lblCredito = new Label();
            lblCredito.Text      = "Abstract Factory Pattern";
            lblCredito.Font      = new Font("Segoe UI", 7.5f, FontStyle.Italic);
            lblCredito.ForeColor = Color.FromArgb(70, 70, 95);
            lblCredito.TextAlign = ContentAlignment.MiddleCenter;
            lblCredito.Dock      = DockStyle.Bottom;
            lblCredito.Height    = 28;
            lblCredito.BackColor = Color.Transparent;
            _sidebar.Controls.Add(lblCredito);

            
            var pnlMain = new Panel();
            pnlMain.Dock      = DockStyle.Fill;
            pnlMain.BackColor = Color.FromArgb(22, 22, 32);

            _pnlHeader.BackColor = Color.Transparent;
            _pnlHeader.Bounds    = new Rectangle(28, 20, 580, 90);
            _pnlHeader.Paint    += PnlHeader_Paint;

            _lblTitulo.Text      = "";
            _lblTitulo.Font      = new Font("Segoe UI", 22f, FontStyle.Bold);
            _lblTitulo.ForeColor = Color.White;
            _lblTitulo.AutoSize  = false;
            _lblTitulo.Bounds    = new Rectangle(0, 8, 580, 46);
            _lblTitulo.BackColor = Color.Transparent;

            _lblSubtitulo.Text      = "";
            _lblSubtitulo.Font      = new Font("Segoe UI", 10f);
            _lblSubtitulo.ForeColor = Color.FromArgb(140, 140, 175);
            _lblSubtitulo.AutoSize  = false;
            _lblSubtitulo.Bounds    = new Rectangle(2, 54, 580, 26);
            _lblSubtitulo.BackColor = Color.Transparent;

            _pnlHeader.Controls.Add(_lblTitulo);
            _pnlHeader.Controls.Add(_lblSubtitulo);

          
            _pnlCard.BackColor = Color.FromArgb(35, 35, 50);
            _pnlCard.Bounds    = new Rectangle(28, 126, 580, 300);
            _pnlCard.Paint    += PnlCard_Paint;

            string[] iconos = { "🍽️", "🥤", "🍮" };
            Label[] lbArr   = new Label[3];
            int[]   yPos    = { 42, 142, 242 };

            for (int i = 0; i < 3; i++)
            {
                var ic = new Label();
                ic.Text      = iconos[i];
                ic.Font      = new Font("Segoe UI Emoji", 20f);
                ic.AutoSize  = false;
                ic.Bounds    = new Rectangle(24, yPos[i] - 2, 42, 42);
                ic.TextAlign = ContentAlignment.MiddleCenter;
                ic.BackColor = Color.Transparent;
                ic.ForeColor = Color.White;

                var lbl = new Label();
                lbl.Text      = "";
                lbl.Font      = new Font("Segoe UI", 11f);
                lbl.ForeColor = Color.White;
                lbl.AutoSize  = false;
                lbl.Bounds    = new Rectangle(76, yPos[i], 460, 42);
                lbl.TextAlign = ContentAlignment.MiddleLeft;
                lbl.BackColor = Color.Transparent;

                _pnlCard.Controls.Add(ic);
                _pnlCard.Controls.Add(lbl);
                lbArr[i] = lbl;
            }

            _lblPlato  = lbArr[0];
            _lblBebida = lbArr[1];
            _lblPostre = lbArr[2];

            pnlMain.Controls.Add(_pnlHeader);
            pnlMain.Controls.Add(_pnlCard);

            this.Controls.Add(pnlMain);
            this.Controls.Add(_sidebar);

            this.Resize += (s, e) => AjustarLayout();
            AjustarLayout();
        }

        private void AjustarLayout()
        {
            int w = this.ClientSize.Width - 210 - 56;
            if (w < 200) w = 200;
            _pnlHeader.Width    = w;
            _lblTitulo.Width    = w;
            _lblSubtitulo.Width = w;
            _pnlCard.Width      = w;
        }

        private void MostrarMenu(int idx)
        {
            _idx = idx;
            var plato  = _fabricas[idx].CrearPlatoFuerte();
            var bebida = _fabricas[idx].CrearBebida();
            var postre = _fabricas[idx].CrearPostre();

            _lblTitulo.Text      = _emojis[idx] + "  Restaurante " + _nombres[idx];
            _lblTitulo.ForeColor = _acentos[idx];
            _lblSubtitulo.Text   = "Menú del día  ·  cocina " + _nombres[idx].ToLower();

            _lblPlato.Text  = plato.Servir();
            _lblBebida.Text = bebida.Servir();
            _lblPostre.Text = postre.Servir();

            _pnlCard.BackColor = MezclarColor(_primarios[idx], Color.FromArgb(35, 35, 50), 0.15f);

            for (int i = 0; i < 5; i++)
            {
                if (i == idx)
                {
                    _botones[i].BackColor = MezclarColor(_primarios[i], Color.FromArgb(38, 38, 54), 0.45f);
                    _botones[i].ForeColor = _acentos[i];
                    _botones[i].Font      = new Font("Segoe UI", 10f, FontStyle.Bold);
                }
                else
                {
                    _botones[i].BackColor = Color.FromArgb(38, 38, 54);
                    _botones[i].ForeColor = Color.FromArgb(190, 190, 220);
                    _botones[i].Font      = new Font("Segoe UI", 10f);
                }
            }

            _pnlCard.Invalidate();
            _pnlHeader.Invalidate();
        }

        private void PnlHeader_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int w = _pnlHeader.Width;
            using var brush = new LinearGradientBrush(
                new Point(0, 0), new Point(Math.Min(w, 340), 0),
                _primarios[_idx], Color.Transparent);
            g.FillRectangle(brush, 0, _pnlHeader.Height - 3, Math.Min(w, 340), 3);
        }

        private void PnlCard_Paint(object sender, PaintEventArgs e)
        {
            var g    = e.Graphics;
            var card = (Panel)sender;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using var path  = RoundedRect(new Rectangle(0, 0, card.Width - 1, card.Height - 1), 14);
            using var bgBr  = new SolidBrush(card.BackColor);
            g.FillPath(bgBr, path);

            using var penSep = new Pen(Color.FromArgb(55, 55, 75), 1);
            g.DrawLine(penSep, 20, 100, card.Width - 20, 100);
            g.DrawLine(penSep, 20, 200, card.Width - 20, 200);

            using var barBrush = new LinearGradientBrush(
                new Point(0, 16), new Point(0, card.Height - 16),
                _primarios[_idx], _acentos[_idx]);
            g.FillRectangle(barBrush, 0, 16, 5, card.Height - 32);

            using var catFont  = new Font("Segoe UI", 7.5f, FontStyle.Bold);
            using var catBrush = new SolidBrush(_acentos[_idx]);
            g.DrawString("PLATO FUERTE", catFont, catBrush, 76, 14);
            g.DrawString("BEBIDA",       catFont, catBrush, 76, 114);
            g.DrawString("POSTRE",       catFont, catBrush, 76, 214);
        }

        private static Color MezclarColor(Color a, Color b, float t) =>
            Color.FromArgb(
                (int)(a.R * t + b.R * (1 - t)),
                (int)(a.G * t + b.G * (1 - t)),
                (int)(a.B * t + b.B * (1 - t)));

        private static GraphicsPath RoundedRect(Rectangle r, int radius)
        {
            var p = new GraphicsPath();
            p.AddArc(r.X,                  r.Y,                   radius * 2, radius * 2, 180, 90);
            p.AddArc(r.Right - radius * 2, r.Y,                   radius * 2, radius * 2, 270, 90);
            p.AddArc(r.Right - radius * 2, r.Bottom - radius * 2, radius * 2, radius * 2,   0, 90);
            p.AddArc(r.X,                  r.Bottom - radius * 2, radius * 2, radius * 2,  90, 90);
            p.CloseFigure();
            return p;
        }
    }
}
