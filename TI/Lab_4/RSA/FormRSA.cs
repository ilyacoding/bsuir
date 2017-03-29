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
using System.Security.Cryptography;

namespace RSA
{
    public partial class FormRSA : Form
    {
        BigInteger p, q, k_r, k_e, k_d, phi;

        /*BigInteger phi_f(BigInteger n)
        {
            BigInteger result = n;
            for (BigInteger i = 2; i * i <= n; ++i)
                if (n % i == 0)
                {
                    while (n % i == 0)
                        n /= i;
                    result -= result / i;
                }
            if (n > 1)
                result -= result / n;
            return result;
        }*/

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

        BigInteger FastExp(BigInteger a, BigInteger z, BigInteger n)
        {
            BigInteger a1 = a;
            BigInteger z1 = z;
            BigInteger x = 1;
            while (!z1.IsZero)
            {
                while (z1.IsEven)
                {
                    z1 = z1 / 2;
                    a1 = (a1 * a1) % n;
                }
                z1 = z1 - 1;
                x = ((x * a1) + n) % n;
            }
            return x;
        }

        bool CheckFerm(BigInteger x)
        {
            if (x == 2)
                return true;
            for (int i = 0; i < 100000; i++)
            {
                BigInteger a = ((new Random().Next(0, 1000000000)) % (x - 2)) + 2;
                MulInv(a, x);
                if (NOD != 1)
                    return false;
                if (FastExp(a, x - 1, x) != 1)
                    return false;
            }
            return true;
        }

        private void buttonSelectFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //System.IO.StreamReader sr = new
                //System.IO.StreamReader(openFileDialog1.FileName);
                labelFileName.Text = openFileDialog1.FileName;
                buttonDecrypt.Enabled = true;
                buttonEncrypt.Enabled = true;
                //sr.Close();
            }
        }

        bool CheckPrime(BigInteger x)
        {
            if (x == 2)
                return false;
            for (BigInteger i = 1; i < x; i++)
            {
                if (BigInteger.GreatestCommonDivisor(i, x) != 1)
                    return false;
            }
            return true;
        }

        bool IsProbablePrime(BigInteger source, int certainty)
        {
            if (source == 2 || source == 3)
                return true;
            if (source < 2 || source % 2 == 0)
                return false;

            BigInteger d = source - 1;
            int s = 0;

            while (d % 2 == 0)
            {
                d /= 2;
                s += 1;
            }
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            byte[] bytes = new byte[source.ToByteArray().LongLength];
            BigInteger a;

            for (int i = 0; i < certainty; i++)
            {
                do
                {
                    rng.GetBytes(bytes);
                    a = new BigInteger(bytes);
                }
                while (a < 2 || a >= source - 2);

                BigInteger x = BigInteger.ModPow(a, d, source);
                if (x == 1 || x == source - 1)
                    continue;

                for (int r = 1; r < s; r++)
                {
                    x = BigInteger.ModPow(x, 2, source);
                    if (x == 1)
                        return false;
                    if (x == source - 1)
                        break;
                }

                if (x != source - 1)
                    return false;
            }

            return true;
        }


        long GenPrime(long n)
        {
            bool[] prime = new bool[n + 1];
            for (long i = 0; i <= n; i++)
                prime[i] = true;
            // vector<char> prime (n + 1, true);
            prime[0] = prime[1] = false;
            for (long i = 2; i <= n; ++i)
                if (prime[i])
                    if (i * i <= n)
			            for (long j = i * i; j <= n; j += i)
                            prime[j] = false;
            // for (int i = n; i > 1; i -= 1)
            //      if (prime[i] == true)
            //     11     return i;
            long ret = n - n/4;
            while (!prime[ret])
                ret = new Random().Next(0, prime.Length);
          return ret;
        }

        private void buttonHackKey_Click(object sender, EventArgs e)
        {
            FormHackKey form = new FormHackKey();
            form.Show();
        }

        private void buttonMerc_Click(object sender, EventArgs e)
        {
            BigInteger x;
            while (true)
            {
                int select = new Random().Next(1, 2);
                if (select == 1)
                {
                    x = BigInteger.Pow(2, new Random().Next(0, 200)) - 1;
                }
                else
                {
                    int rnd = new Random().Next(0, 200);
                    x = rnd * BigInteger.Pow(2, rnd) + 1;
                }

                if (IsProbablePrime(x, 100))
                {
                    textBoxPrime.Text = x.ToString();
                    return;
                }
            }
        }

        private void textBoxp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (e.KeyChar == 8))
                return;
            e.Handled = true;
        }

        private void textBoxq_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (e.KeyChar == 8))
                return;
            e.Handled = true;
        }

        private void textBoxd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (e.KeyChar == 8))
                return;
            e.Handled = true;
        }

        private void textBoxr_TextChanged(object sender, EventArgs e)
        {
            labelrK.Text = (textBoxr.TextLength*8).ToString() + " bit";
        }

        private void textBoxe_TextChanged(object sender, EventArgs e)
        {
            labeleK.Text = (textBoxe.TextLength*8).ToString() + " bit";
        }

        private void FormRSA_Load(object sender, EventArgs e)
        {

        }

        private void textBoxd_TextChanged(object sender, EventArgs e)
        {
            labeldE.Text = (textBoxd.TextLength * 8).ToString() + " bit";
        }

        private void buttonGenSmallPrime_Click(object sender, EventArgs e)
        {
            textBoxPrime.Text = GenPrime(300).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxFd.Text = textBoxd.Text;
            textBoxFe.Text = textBoxe.Text;
            textBoxFr.Text = textBoxr.Text;
        }

        private void buttonGenPrime_Click(object sender, EventArgs e)
        {
            textBoxPrime.Text = GenPrime(20000000).ToString();
        }

        private void buttonGenKey_Click(object sender, EventArgs e)
        {
            BigInteger.TryParse(textBoxp.Text, out p);
            BigInteger.TryParse(textBoxq.Text, out q);
            BigInteger.TryParse(textBoxd.Text, out k_d);
            if (!IsProbablePrime(p, 100) || textBoxp.TextLength == 0)
            {
                MessageBox.Show("'p' is not prime or field is empty.");
                return;
            }
            if (!IsProbablePrime(q, 100) || textBoxq.TextLength == 0)
            {
                MessageBox.Show("'q' is not prime or field is empty.");
                return;
            }
            if (textBoxd.TextLength == 0)
            {
                MessageBox.Show("'d' field is empty.");
                return;
            }
            if (checkBox1.Checked)
            {
                if (!CheckPrime(p))
                {
                    MessageBox.Show("'p' is not prime or field is empty.");
                    return;
                }
                if (!CheckPrime(q))
                {
                    MessageBox.Show("'q' is not prime or field is empty.");
                    return;
                }
            }
            k_r = p * q;
            /*if (k_r <= 256)
            {
                MessageBox.Show("'r' must be 256+.");
                return;
            }*/
            phi = (p - 1) * (q - 1);
            k_e = MulInv(k_d, phi);
            if (NOD != 1)
            {
                MessageBox.Show("'d' and 'phi' are not relatively prime.");
                return;
            }

            textBoxe.Text = k_e.ToString();
            textBoxr.Text = k_r.ToString();

            textBoxKc.Text = "K(private) = (" + k_d + ", " + k_r + ")";
            textBoxKo.Text = "K(public) = (" + k_e + ", " + k_r + ")";
        }

        private void buttonDecrypt_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox2.Clear();

            BigInteger.TryParse(textBoxFd.Text, out k_d);
            BigInteger.TryParse(textBoxFe.Text, out k_e);
            BigInteger.TryParse(textBoxFr.Text, out k_r);

            if ((k_r <= 256) || (k_r >= 65535))
            {
                MessageBox.Show("'r' must be '256 < r < 65535'");
                return;
            }

            FileInfo f = new FileInfo(openFileDialog1.FileName);
            FileStream fs = f.OpenRead();
            var xE = openFileDialog1.FileName.Split('.');
            string FileExt = xE[xE.Length - 1];
            FileInfo w = new FileInfo(openFileDialog1.FileName + ".enc." + FileExt);
            FileStream fw = w.OpenWrite();
            long len = fs.Length;
            long pos = 0;
            bool dotWritten = false;
            while (fs.Position < fs.Length)
            {
                byte[] data16bit = new byte[2] { 0, 0 };
                fs.Read(data16bit, 0, 2);
                //Array.Reverse(data8bit);
                UInt16 x = BitConverter.ToUInt16(data16bit, 0);
                BigInteger C = BigInteger.Parse(x.ToString());

          
                BigInteger M = FastExp(C, k_d, k_r);

                if ((pos <= 7) || (len - pos <= 8))
                    richTextBox1.Text += M.ToString() + " ";

                if ((pos <= 7) || (len - pos <= 8))
                    richTextBox2.Text += C.ToString() + " ";

                if (pos == 8 && !dotWritten)
                {
                    richTextBox1.Text += "..";
                    richTextBox2.Text += "..";
                }

                data16bit = BitConverter.GetBytes((UInt16)M);
                fw.Write(data16bit, 0, 1);
                pos++;
            }
            fs.Close();
            fw.Close();
        }

        public FormRSA()
        {
            InitializeComponent();
        }

        private void buttonEncrypt_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox2.Clear();

            BigInteger.TryParse(textBoxFd.Text, out k_d);
            BigInteger.TryParse(textBoxFe.Text, out k_e);
            BigInteger.TryParse(textBoxFr.Text, out k_r);

            if ((k_r <= 256) || (k_r >= 65535))
            {
                MessageBox.Show("'r' must be '256 < r < 65535'");
                return;
            }

            FileInfo f = new FileInfo(openFileDialog1.FileName);
            FileStream fs = f.OpenRead();
            var xE = openFileDialog1.FileName.Split('.');
            string FileExt = xE[xE.Length - 1];
            FileInfo w = new FileInfo(openFileDialog1.FileName + ".enc." + FileExt);
            FileStream fw = w.OpenWrite();
            long len = fs.Length;
            long pos = 0;
            bool dotWritten = false;
            while (fs.Position < fs.Length)
            {
                byte[] data16bit = new byte[2] { 0, 0 };
                fs.Read(data16bit, 0, 1);
                //Array.Reverse(data8bit);
                UInt16 x = BitConverter.ToUInt16(data16bit, 0);
                BigInteger M = BigInteger.Parse(x.ToString());
                if ((pos <= 7) || (len-pos <= 8))
                    richTextBox1.Text += M.ToString() + " ";

                BigInteger C = FastExp(M, k_e, k_r);
                if ((pos <= 7) || (len - pos <= 8))
                    richTextBox2.Text += C.ToString() + " ";

                if (pos == 8 && !dotWritten)
                {
                    richTextBox1.Text += "..";
                    richTextBox2.Text += "..";
                }
                

                data16bit = BitConverter.GetBytes((UInt16)C);
                fw.Write(data16bit, 0, 2);
                pos++;
            }
            fs.Close();
            fw.Close();

            /*byte[] arr = File.ReadAllBytes(openFileDialog1.FileName);
            richTextBox1.Text = System.Text.Encoding.Default.GetString(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                UInt16 c = (UInt16)FastExp(arr[i], k_e, k_r);
                c = c << 8;
            }*/
        }
    }
}
