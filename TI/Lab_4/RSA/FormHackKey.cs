using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.IO;

namespace RSA
{
    public partial class FormHackKey : Form
    {
        public FormHackKey()
        {
            InitializeComponent();
        }

        BigInteger gcd(BigInteger a, BigInteger b, ref BigInteger x, ref BigInteger y)
        {
            if (a == 0)
            {
                x = 0; y = 1;
                return b;
            }
            BigInteger x1 = 0;
            BigInteger y1 = 0;
            BigInteger d = gcd(b % a, a, ref x1, ref y1);
            x = y1 - (b / a) * x1;
            y = x1;
            return d;
        }
        BigInteger NOD;
        BigInteger MulInv(BigInteger a, BigInteger m)
        {
            BigInteger x = 0;
            BigInteger y = 0;
            BigInteger g = gcd(a, m, ref x, ref y);
            x = (x + m) % m;
            NOD = g;
            return x;
        }

        BigInteger p, q, k_r, k_e, k_d, phi;

        private void textBoxe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (e.KeyChar == 8))
                return;
            e.Handled = true;
        }

        private void textBoxr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (e.KeyChar == 8))
                return;
            e.Handled = true;
        }

        BigInteger GetDiv(BigInteger a)
        {
            for (BigInteger i = 2; i < a; i++)
                if (a % i == 0)
                    return i;
            return 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BigInteger.TryParse(textBoxr.Text, out k_r);
            BigInteger.TryParse(textBoxe.Text, out k_e);
            if (textBoxr.TextLength == 0)
            {
                MessageBox.Show("'r' field is empty.");
                return;
            }
            if (textBoxe.TextLength == 0)
            {
                MessageBox.Show("'e' field is empty.");
                return;
            }

            MessageBox.Show("Starting to hack RSA. It may take a while");

            p = GetDiv(k_r);
            q = k_r / p;

            phi = (p - 1) * (q - 1);
            k_d = MulInv(k_e, phi);
            if (NOD != 1)
            {
                MessageBox.Show("'d' and 'phi' are not relatively prime.");
                return;
            }

            textBoxd.Text = k_d.ToString();
            
        }
    }
}
