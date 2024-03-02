using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using Microsoft.VisualBasic;
using System.Text.Encodings.Web;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text.Unicode;
using System.Text.Json;

namespace EnemyDesigner
{
    public partial class Form1 : Form
    {
        List<Enemy> enemyList;
        List<Element> elementList;
        List<string> animationNameList;
        int list1Index, list2Index, gameTime;
        bool notyet;
        Pen mypen;
        Bitmap buffer;
        public Form1()
        {
            enemyList = new List<Enemy>();
            elementList = new List<Element>();
            animationNameList = new List<string>();
            list1Index = 0;
            list2Index = 0;
            gameTime = 0;
            notyet = false;
            buffer = new Bitmap(32, 32);
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.Opaque, false);
            this.UpdateStyles();
            mypen = new Pen(Color.White, 3);
            timer1.Start();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            int idx = 0;
            string path = Application.StartupPath + @"..\data\enemy\";
            while (File.Exists(path + @"enemy_" + idx.ToString() + ".json"))
            {
                string file = @"enemy_" + idx.ToString() + ".json";
                string jsonstr = System.IO.File.ReadAllText(path + file);
                Enemy tempen = JsonSerializer.Deserialize<Enemy>(jsonstr);
                listBox1.Items.Add(idx.ToString().PadLeft(3, '0') + "：" + tempen.name);
                enemyList.Add(tempen);
                ++idx;
            }
            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("未检测到怪物数据！");
                Application.Exit();
                return;
            }
            idx = 1;
            path = Application.StartupPath + @"..\data\element\";
            while (File.Exists(path + @"element_" + idx.ToString() + ".json"))
            {
                string file = @"element_" + idx.ToString() + ".json";
                string jsonstr = System.IO.File.ReadAllText(path + file);
                Element temele = JsonSerializer.Deserialize<Element>(jsonstr);
                checkedListBox1.Items.Add(temele.name);
                elementList.Add(temele);
                ++idx;
            }
            if (checkedListBox1.Items.Count == 0)
            {
                MessageBox.Show("未检测到属性数据！");
                Application.Exit();
                return;
            }
            idx = 0;
            path = Application.StartupPath + @"..\data\animation\";
            while (File.Exists(path + @"animation_" + idx.ToString() + ".json"))
            {
                string file = @"animation_" + idx.ToString() + ".json";
                string jsonstr = System.IO.File.ReadAllText(path + file);
                Dictionary <string, object> data = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonstr);
                animationNameList.Add(data["name"].ToString());
                comboBox1.Items.Add(idx.ToString().PadLeft(3, '0') + "：" + data["name"].ToString());
                ++idx;
            }
            if (animationNameList.Count == 0)
            {
                MessageBox.Show("未检测到动画数据！");
                Application.Exit();
                return;
            }
            checkedListBox1.SelectedIndex = list2Index;
            listBox1.SelectedIndex = list1Index;
            comboBox1.SelectedIndex = enemyList[0].animationID;
            comboBox2.SelectedIndex = enemyList[0].pos;
            refreshInfo();
            setImage();
        }
        private void refreshInfo()
        {
            if (listBox1.SelectedIndex != -1)
            {
                textBox1.Text = enemyList[listBox1.SelectedIndex].name;
                textBox2.Text = enemyList[listBox1.SelectedIndex].hp.ToString();
                textBox3.Text = enemyList[listBox1.SelectedIndex].atk.ToString();
                textBox5.Text = enemyList[listBox1.SelectedIndex].def.ToString();
                textBox4.Text = enemyList[listBox1.SelectedIndex].conatk.ToString();
                textBox7.Text = enemyList[listBox1.SelectedIndex].exp.ToString();
                textBox6.Text = enemyList[listBox1.SelectedIndex].gold.ToString();
                comboBox1.SelectedIndex = enemyList[listBox1.SelectedIndex].animationID;
                comboBox2.SelectedIndex = enemyList[listBox1.SelectedIndex].pos;
                for (int i = 0; i < checkedListBox1.Items.Count; ++i)
                    checkedListBox1.SetItemChecked(i, false);
                foreach (int i in enemyList[listBox1.SelectedIndex].element)
                {
                    if (i == 0) continue;
                    checkedListBox1.SetItemChecked(i - 1, true);
                }
                setImage();
            }
            textBox8.Text = elementList[checkedListBox1.SelectedIndex].description;
        }
        private void setImage()
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox2.Image.Dispose();
                pictureBox1.Image = null;
                pictureBox2.Image = null;
            }
            if (listBox1.SelectedIndex != -1 && enemyList[listBox1.SelectedIndex].file != "")
            {
                pictureBox1.Image = Image.FromFile(Application.StartupPath + @"..\assets\character\" + enemyList[listBox1.SelectedIndex].file);
                buffer = new Bitmap(32, 32);
                Graphics g = Graphics.FromImage(buffer);
                g.DrawImage(pictureBox1.Image, new Rectangle(0, 0, 32, 32), new Rectangle(32 * (gameTime % 4), 32 * enemyList[listBox1.SelectedIndex].pos, 32, 32), GraphicsUnit.Pixel);
                pictureBox2.Image = buffer;
                g.Dispose();
            }
        }
        private void refreshList1()
        {
            listBox1.Items.Clear();
            int idx = 0;
            foreach (Enemy en in enemyList)
            {
                listBox1.Items.Add(idx.ToString().PadLeft(3, '0') + "：" + en.name);
                idx++;
            }
            listBox1.SelectedIndex = list1Index;
        }
        private void refreshList2()
        {
            notyet = true;
            checkedListBox1.Items.Clear();
            foreach (var ele in elementList)
                checkedListBox1.Items.Add(ele.name);
            checkedListBox1.SelectedIndex = list2Index;
            for (int i = 0; i < checkedListBox1.Items.Count; ++i)
                checkedListBox1.SetItemChecked(i, false);
            foreach (int i in enemyList[listBox1.SelectedIndex].element)
            {
                if (i == 0) continue;
                checkedListBox1.SetItemChecked(i - 1, true);
            }
            notyet = false;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            ++gameTime;
            setImage();
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            list1Index = listBox1.SelectedIndex;
            refreshInfo();
        }
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            list2Index = checkedListBox1.SelectedIndex;
            textBox8.Text = elementList[checkedListBox1.SelectedIndex].description;
            if (listBox1.SelectedIndex != -1 && !notyet)
            {
                enemyList[listBox1.SelectedIndex].element.Clear();
                foreach (var i in checkedListBox1.CheckedIndices)
                    enemyList[listBox1.SelectedIndex].element.Add(int.Parse(i.ToString()) + 1);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            enemyList[listBox1.SelectedIndex].name = textBox1.Text;
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            enemyList[listBox1.SelectedIndex].pos = comboBox2.SelectedIndex;
            setImage();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "") enemyList[listBox1.SelectedIndex].hp = 0;
            else enemyList[listBox1.SelectedIndex].hp = int.Parse(textBox2.Text);
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == "") enemyList[listBox1.SelectedIndex].atk = 0;
            else enemyList[listBox1.SelectedIndex].atk = int.Parse(textBox3.Text);
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text == "") enemyList[listBox1.SelectedIndex].def = 0;
            else enemyList[listBox1.SelectedIndex].def = int.Parse(textBox5.Text);
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text == "") enemyList[listBox1.SelectedIndex].conatk = 0;
            else enemyList[listBox1.SelectedIndex].conatk = int.Parse(textBox4.Text);
        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text == "") enemyList[listBox1.SelectedIndex].exp = 0;
            else enemyList[listBox1.SelectedIndex].exp = int.Parse(textBox7.Text);
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text == "") enemyList[listBox1.SelectedIndex].gold = 0;
            else enemyList[listBox1.SelectedIndex].gold = int.Parse(textBox6.Text);
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            enemyList[listBox1.SelectedIndex].animationID = comboBox1.SelectedIndex;
        }
        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            elementList[checkedListBox1.SelectedIndex].description = textBox8.Text;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //创建对象
            OpenFileDialog ofg = new OpenFileDialog();
            //设置默认打开路径
            ofg.InitialDirectory = Path.GetDirectoryName(Path.GetDirectoryName(Application.ExecutablePath)) + @"\assets\character";
            //设置打开标题、后缀
            ofg.Title = "请选择导入png文件";
            ofg.Filter = "png文件|*.png";
            string path = "";
            DialogResult s = ofg.ShowDialog();
            if (s == DialogResult.OK)
            {
                //得到打开的文件路径（包括文件名）
                string[] names = ofg.FileName.ToString().Split('\\');
                enemyList[listBox1.SelectedIndex].file = names[names.Length - 1];
                setImage();
            }
            else if (s == DialogResult.Cancel)
                MessageBox.Show("未选择打开文件！");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            enemyList.Add(new Enemy("", "", 0, 0, 0, 0, 0, 0, 0, new List<int>(), 0));
            refreshList1();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (enemyList.Count == 1)
            {
                MessageBox.Show("不允许删除最后剩余的文件");
                return;
            }
            enemyList.RemoveAt(listBox1.SelectedIndex);
            if (list1Index >= enemyList.Count) list1Index = enemyList.Count - 1;
            refreshList1();
            refreshInfo();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string eleinput = Interaction.InputBox(null, "输入内容", null, -1, -1);
            if (eleinput == "") return;
            elementList.Add(new Element(eleinput, ""));
            refreshList2();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (elementList.Count == 1)
            {
                MessageBox.Show("不允许删除最后剩余的文件");
                return;
            }
            elementList.RemoveAt(checkedListBox1.SelectedIndex);
            if (list2Index >= elementList.Count) list2Index = elementList.Count - 1;
            refreshList2();
            textBox8.Text = elementList[checkedListBox1.SelectedIndex].description;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            string eleinput = Interaction.InputBox(null, "输入内容", null, -1, -1);
            elementList[checkedListBox1.SelectedIndex].name = eleinput;
            refreshList2();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            int idx = 0;
            string file = Application.StartupPath + @"..\data\enemy\";
            foreach (Enemy en in enemyList)
            {
                var options = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                    DefaultIgnoreCondition = JsonIgnoreCondition.Never,
                    WriteIndented = false
                };
                string jsonstr = JsonSerializer.Serialize(en, options);
                System.IO.File.WriteAllText(file + @"enemy_" + idx.ToString() + ".json", jsonstr);
                idx++;
            }
            while (File.Exists(file + @"enemy_" + idx.ToString() + ".json"))
                System.IO.File.Delete(file + @"enemy_" + (idx++).ToString() + ".json");
            idx = 1;
            file = Application.StartupPath + @"..\data\element\";
            foreach (Element ele in elementList)
            {
                var options = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                    DefaultIgnoreCondition = JsonIgnoreCondition.Never,
                    WriteIndented = false
                };
                string jsonstr = JsonSerializer.Serialize(ele, options);
                System.IO.File.WriteAllText(file + @"element_" + idx.ToString() + ".json", jsonstr);
                idx++;
            }
            while (File.Exists(file + @"element_" + idx.ToString() + ".json"))
                System.IO.File.Delete(file + @"element_" + (idx++).ToString() + ".json");
            MessageBox.Show("保存成功！");
            refreshList1();
            refreshInfo();
        }
    }
}
class Enemy
{
    public string name { get; set; }
    public string file { get; set; }
    public int pos { get; set; }
    public int hp { get; set; }
    public int atk { get; set; }
    public int def { get; set; }
    public int conatk { get; set; }
    public int exp { get; set; }
    public int gold { get; set; }
    public int animationID { get; set; }
    public List<int> element { get; set; }
    public Enemy(string name, string file, int pos, int hp, int atk, int def, int conatk, int exp, int gold, List<int> element, int animationID)
    {
        this.name = name;
        this.file = file;
        this.pos = pos;
        this.hp = hp;
        this.atk = atk;
        this.def = def;
        this.conatk = conatk;
        this.exp = exp;
        this.gold = gold;
        this.element = element;
        this.animationID = animationID;
    }
}
class Element
{
    public string name { get; set; }
    public string description { get; set; }
    public Element(string name, string description)
    {
        this.name = name;
        this.description = description;
    }
}