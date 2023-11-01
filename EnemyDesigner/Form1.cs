using System.Windows.Forms;

namespace EnemyDesigner
{
    public partial class Form1 : Form
    {
        List<Enemy> enemyList;
        List<Element> elementList;
        List<string> animationNameList;
        int list1Index, list2Index;
        Pen mypen;
        public Form1()
        {
            enemyList = new List<Enemy>();
            elementList = new List<Element>();
            animationNameList = new List<string>();
            list1Index = 0;
            list2Index = 0;
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.Opaque, false);
            this.UpdateStyles();
            mypen = new Pen(Color.White, 3);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            int idx = 0;
            string path = Application.StartupPath + @"..\data\enemy\";
            while (File.Exists(path + @"enemy_" + idx.ToString() + ".dat"))
            {
                string file = @"enemy_" + idx.ToString() + ".dat";
                string datatext = System.IO.File.ReadAllText(path + file);
                string[] data = datatext.Split(Environment.NewLine.ToCharArray());
                data = data.Where(s => !string.IsNullOrEmpty(s)).ToArray();
                var datamap = data.Select(line => line.Split(':')).Where(parts => parts.Length == 2).ToDictionary(parts => parts[0].Trim(), parts => parts[1].Trim());
                listBox1.Items.Add(idx.ToString().PadLeft(3, '0') + "：" + datamap["name"]);
                enemyList.Add(new Enemy(datamap["name"], datamap["file"] == "none" ? "" : datamap["file"], int.Parse(datamap["pos"]), int.Parse(datamap["hp"]), int.Parse(datamap["atk"]), int.Parse(datamap["def"]), int.Parse(datamap["conatk"]), int.Parse(datamap["exp"]), int.Parse(datamap["gold"]), datamap["element"].Split(',').Select(s => int.Parse(s)).ToList(), int.Parse(datamap["animationID"])));
                ++idx;
            }
            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("未检测到怪物数据！");
                Application.Exit();
                return;
            }
            idx = 0;
            path = Application.StartupPath + @"..\data\element\";
            while (File.Exists(path + @"element_" + idx.ToString() + ".dat"))
            {
                if (idx == 0)
                {
                    ++idx;
                    continue;
                }
                string file = @"element_" + idx.ToString() + ".dat";
                string datatext = System.IO.File.ReadAllText(path + file);
                string[] data = datatext.Split(Environment.NewLine.ToCharArray());
                data = data.Where(s => !string.IsNullOrEmpty(s)).ToArray();
                var datamap = data.Select(line => line.Split(':')).Where(parts => parts.Length == 2).ToDictionary(parts => parts[0].Trim(), parts => parts[1].Trim());
                checkedListBox1.Items.Add(datamap["name"]);
                elementList.Add(new Element(datamap["name"], datamap["description"]));
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
            while (File.Exists(path + @"animation_" + idx.ToString() + ".dat"))
            {
                string file = @"animation_" + idx.ToString() + ".dat";
                string datatext = System.IO.File.ReadAllText(path + file);
                string[] data = datatext.Split(Environment.NewLine.ToCharArray());
                data = data.Where(s => !string.IsNullOrEmpty(s)).ToArray();
                var datamap = data.Select(line => line.Split(':')).Where(parts => parts.Length == 2).ToDictionary(parts => parts[0].Trim(), parts => parts[1].Trim());
                animationNameList.Add(datamap["name"]);
                comboBox1.Items.Add(idx.ToString().PadLeft(3, '0') + "：" + datamap["name"]);
                ++idx;
            }
            if (animationNameList.Count == 0)
            {
                MessageBox.Show("未检测到动画数据！");
                Application.Exit();
                return;
            }
            listBox1.SelectedIndex = list1Index;
            checkedListBox1.SelectedIndex = list2Index;
            comboBox1.SelectedIndex = enemyList[0].animationID;
            refreshInfo();
            setImage();
        }
        private void refreshInfo()
        {
            textBox1.Text = enemyList[listBox1.SelectedIndex].name;
            textBox2.Text = enemyList[listBox1.SelectedIndex].hp.ToString();
            textBox3.Text = enemyList[listBox1.SelectedIndex].atk.ToString();
            textBox5.Text = enemyList[listBox1.SelectedIndex].def.ToString();
            textBox4.Text = enemyList[listBox1.SelectedIndex].conatk.ToString();
            textBox7.Text = enemyList[listBox1.SelectedIndex].exp.ToString();
            textBox6.Text = enemyList[listBox1.SelectedIndex].gold.ToString();
            comboBox1.SelectedIndex = enemyList[listBox1.SelectedIndex].animationID;
            for (int i = 0; i < checkedListBox1.Items.Count; ++i)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
            foreach (int i in enemyList[listBox1.SelectedIndex].element)
            {
                if (i == 0) continue;
                checkedListBox1.SetItemChecked(i - 1, true);
            }
            textBox8.Text = elementList[checkedListBox1.SelectedIndex].description;
        }
        private void setImage()
        {
            Graphics g1 = pictureBox1.CreateGraphics();
            if (enemyList[listBox1.SelectedIndex].file != "")
            {
                pictureBox1.Image = Image.FromFile(Application.StartupPath + @"..\graphics\character\" + enemyList[listBox1.SelectedIndex].file);
                g1.DrawRectangle(mypen, new Rectangle(0, enemyList[listBox1.SelectedIndex].pos * 32, 128, 32));
            }
            g1.Dispose();
        }
    }
}
class Enemy
{
    public string name, file;
    public int pos, hp, atk, def, conatk, exp, gold, animationID;
    public List<int> element;
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
    public string name, description;
    public Element(string name, string description)
    {
        this.name = name;
        this.description = description;
    }
}