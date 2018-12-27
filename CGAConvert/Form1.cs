using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CGAConvert
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;//该值确定是否可以选择多个文件
            dialog.Title = "请选择BrainFuck源码";
            dialog.Filter = "*.*|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string path = dialog.FileName;
                textBox1.Text = File.ReadAllText(path);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string strCGA = null;
            string str = textBox1.Text;

            str = str.Replace("[", "富强");
            str = str.Replace("]", "民主");
            str = str.Replace(">", "文明");
            str = str.Replace("<", "和谐");
            str = str.Replace("+++++", "敬业");
            str = str.Replace("+", "爱国");
            str = str.Replace(".", "诚信");
            str = str.Replace(",", "友善");
            str = str.Replace("-----", "平等");
            str = str.Replace("-", "自由");

            strCGA = str;
            textBox2.Text = strCGA;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sav = new SaveFileDialog();
            sav.Title = "请选择要保存的位置";
            sav.Filter = "CGA|*.cga";
            sav.ShowDialog();
            string stt = sav.FileName;
            if (stt == "")
            {
                MessageBox.Show("请输入文件名", "警告");
                return;
            }
            using (FileStream fil = new FileStream(stt, FileMode.OpenOrCreate, FileAccess.Write))
            {
                byte[] byt = new byte[1024];
                string str = textBox2.Text;
                byt = Encoding.Default.GetBytes(str);
                fil.Write(byt, 0, byt.Length);
                fil.Flush();
                fil.Close();
            }
            MessageBox.Show("保存完毕");
        }
    }
}
