using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DefaultMod {
    public partial class Form1 : Form {
        Random rnd = new Random();
        List<string> words = Words.Wordlist;

        public Dictionary<string, Bitmap> images = new Dictionary<string, Bitmap>() {
            // Downloads
            {"dl_1", Properties.Resources.Download1},
            {"dl_2", Properties.Resources.Download2},
            {"dl_3", Properties.Resources.Download3},
            {"dl_4", Properties.Resources.Download4},
            {"dl_5", Properties.Resources.Download5},
            {"dl_6", Properties.Resources.Download6},
            {"dl_7", Properties.Resources.Download7},
            {"dl_8", Properties.Resources.Download8},
            {"dl_9", Properties.Resources.Download9},

            // Ads
            {"ad_1", Properties.Resources.ad1},
            {"ad_2", Properties.Resources.ad2},
            {"ad_3", Properties.Resources.ad3},
            {"ad_4", Properties.Resources.ad4},
            {"ad_5", Properties.Resources.ad5},
            {"ad_6", Properties.Resources.ad6},
            {"ad_7", Properties.Resources.ad7},
        };

        public List<string> ad = new List<string>() {
            "http://howtogobroke.com/",
            "https://thisiswhyimbroke.com/",
            "https://thatswhyimbroke.co.uk/",
        };

        public List<string> dl = new List<string>() {
            "how 2 remove a virus",
            "how to send a virus to my friend",
            "minecraft hax download no virus",
            "how to get money",
            "bonzi buddy download free",
            "how to code a virus in visual basic",
            "facebook hacking tool free download no virus working 2016",
            "how to remove trojan virus",
            "how to download memz",
            "half life 3 free download",
            "john cena midi legit not converted",
            "skrillex scay onster an nice sprites midi",
            "free antivirus&start=290&filter=0"
        };

        public Form1() {
            InitializeComponent();
        }

        public void largenUri(ref string url) {
            while(url.Length < 2000) {
                string q = words[rnd.Next(0, words.Count)];
                string a = words[rnd.Next(0, words.Count)];
                string h = "?";
                if (url.Contains("?")) h = "&";
                string prev = url;
                url += $"{h+q}={a}";
                if (url.Length > 2000) {
                    url = prev;
                    return;
                }
            }
        }
        
        public void resizeToFit(ref Bitmap image, bool ad = false) {
            try {
                double widthScale = 0, heightScale = 0;
                if (image.Width != 0)
                    widthScale = ad ? 500 : 200 / (double)image.Width;
                if (image.Height != 0)
                    heightScale = ad ? 500 : 200 / (double)image.Height;

                double scale = Math.Min(widthScale, heightScale);

                Size size = new Size((int)(image.Width * scale), (int)(image.Height * scale));
                image = new Bitmap(image, size);
            } catch {

            }
        }

        private void openUrl(string url) {
            largenUri(ref url);
            Process.Start(url);
        }

        private void Form1_Load(object sender, EventArgs e) {
            var data = images.ElementAt(rnd.Next(0, images.Count - 1));

            string name = data.Key;
            Bitmap image = data.Value;
            resizeToFit(ref image, name.StartsWith("ad_"));
            pictureBox1.Image = image;

            pictureBox1.Location = new Point(0, 0);
            Size = pictureBox1.Size;

            int mx = Screen.PrimaryScreen.Bounds.Width - Size.Width;
            int my = Screen.PrimaryScreen.Bounds.Height - Size.Height;

            Location = new Point(rnd.Next(0, mx), rnd.Next(0, my));

            pictureBox1.MouseDown += (object s, MouseEventArgs m) => {
                if (m.Button == MouseButtons.Left) {
                    if (name.StartsWith("ad_")) {
                        openUrl(ad[rnd.Next(0, ad.Count - 1)]);
                    } else {
                        openUrl("http://google.co.ck/search?q=" + dl[rnd.Next(0, dl.Count - 1)].Replace(" ", "+"));
                    }
                    Close();
                }
            };
        }
    }
}
