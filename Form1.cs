using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;

namespace CardMarker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ArrayList list = new();
            list.Add(new DictionaryEntry(CardKind.Monster, "怪兽"));
            list.Add(new DictionaryEntry(CardKind.Consume, "消耗品"));
            list.Add(new DictionaryEntry(CardKind.Equip, "装备"));
            list.Add(new DictionaryEntry(CardKind.Weapon, "武器"));
            comboBox1.DataSource = list;
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";

            ArrayList list2 = new();
            list2.Add(new DictionaryEntry(CardColor.All, "白"));
            list2.Add(new DictionaryEntry(CardColor.Balance, "蓝"));
            list2.Add(new DictionaryEntry(CardColor.Chaos, "紫"));
            list2.Add(new DictionaryEntry(CardColor.Fortune, "黄"));
            list2.Add(new DictionaryEntry(CardColor.Nature, "绿"));
            list2.Add(new DictionaryEntry(CardColor.War, "红"));
            comboBox2.DataSource = list2;
            comboBox2.DisplayMember = "Value";
            comboBox2.ValueMember = "Key";

            ArrayList list3 = new();
            list3.Add(new DictionaryEntry(CardColor.None, "无"));
            list3.Add(new DictionaryEntry(CardColor.All, "白"));
            list3.Add(new DictionaryEntry(CardColor.Balance, "蓝"));
            list3.Add(new DictionaryEntry(CardColor.Chaos, "紫"));
            list3.Add(new DictionaryEntry(CardColor.Fortune, "黄"));
            list3.Add(new DictionaryEntry(CardColor.Nature, "绿"));
            list3.Add(new DictionaryEntry(CardColor.War, "红"));
            comboBox3.DataSource = list3;
            comboBox3.DisplayMember = "Value";
            comboBox3.ValueMember = "Key";

            ArrayList list4 = new();
            list4.Add(new DictionaryEntry(Quality.Elite, "精英"));
            list4.Add(new DictionaryEntry(Quality.Epic, "彩钻"));
            list4.Add(new DictionaryEntry(Quality.Rarity, "黄金"));
            list4.Add(new DictionaryEntry(Quality.Rare, "白银"));
            list4.Add(new DictionaryEntry(Quality.Normal, "黑铁"));
            list4.Add(new DictionaryEntry(Quality.Friend, "其他"));
            comboBox4.DataSource = list4;
            comboBox4.DisplayMember = "Value";
            comboBox4.ValueMember = "Key";

            ArrayList list5 = new();
            list5.Add(new DictionaryEntry(CardTag.None, "无"));
            list5.Add(new DictionaryEntry(CardTag.PrCard, "限定"));
            list5.Add(new DictionaryEntry(CardTag.YearCard, "年兽"));
            list5.Add(new DictionaryEntry(CardTag.SpecialLegend, "金标"));
            list5.Add(new DictionaryEntry(CardTag.SpecialEpic, "银标"));
            list5.Add(new DictionaryEntry(CardTag.SpecialRare, "铁标"));
            comboBox5.DataSource = list5;
            comboBox5.DisplayMember = "Value";
            comboBox5.ValueMember = "Key";

            textBox1.Text = @"ui/bighunter.jpg";
            textBox2.Text = "0";
            textBox3.Text = "35";
            textBox4.Text = "0";
            textBox15.Text = "0.52";
            textBox25.Text = " ★";
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            radioButton1.Checked = true;
            radioButton3.Checked = true;
            radioButton5.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Multiselect = false,
                Title = "选择图像",
                Filter = "所有文件(*.*)|*.*"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dialog.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CardKind cardKind = (CardKind)comboBox1.SelectedValue;
            CardColor cardColor1 = (CardColor)comboBox2.SelectedValue;
            CardColor cardColor2 = (CardColor)comboBox3.SelectedValue;
            Quality cardQuality = (Quality)comboBox4.SelectedValue;
            CardTag cardTag = (CardTag)comboBox5.SelectedValue;

            pictureBox1.Image = null;
            Bitmap bitmap = new(pictureBox1.Size.Width, pictureBox1.Size.Height);
            bitmap.SetResolution(0x60f, 0x60f);
            Graphics graphics = Graphics.FromImage(bitmap);

            //背景
            if (cardKind == CardKind.Consume)
            {
                if (cardQuality == Quality.Elite)
                {
                    graphics.DrawImage(Image.FromFile("ui/background/consumebg_elite.png"), 0x12, 40, 0x16a, 470);
                }
                else
                {
                    graphics.DrawImage(Image.FromFile("ui/background/consumebg.png"), 0x12, 40, 0x16a, 470);
                }
            }
            else
            {
                Image bgImage1 = null;
                switch (cardColor1)
                {
                    case CardColor.All:
                        bgImage1 = Image.FromFile("ui/background/equipbg_all_l.png");
                        break;
                    case CardColor.Balance:
                        bgImage1 = Image.FromFile("ui/background/equipbg_balance_l.png");
                        break;
                    case CardColor.Chaos:
                        bgImage1 = Image.FromFile("ui/background/equipbg_chaos_l.png");
                        break;
                    case CardColor.Fortune:
                        bgImage1 = Image.FromFile("ui/background/equipbg_fortune_l.png");
                        break;
                    case CardColor.Nature:
                        bgImage1 = Image.FromFile("ui/background/equipbg_nature_l.png");
                        break;
                    case CardColor.War:
                        bgImage1 = Image.FromFile("ui/background/equipbg_war_l.png");
                        break;
                }

                Image bgImage2 = null;
                switch (cardColor2 == CardColor.None ? cardColor1 : cardColor2)
                {
                    case CardColor.All:
                        bgImage2 = Image.FromFile("ui/background/equipbg_all_r.png");
                        break;
                    case CardColor.Balance:
                        bgImage2 = Image.FromFile("ui/background/equipbg_balance_r.png");
                        break;
                    case CardColor.Chaos:
                        bgImage2 = Image.FromFile("ui/background/equipbg_chaos_r.png");
                        break;
                    case CardColor.Fortune:
                        bgImage2 = Image.FromFile("ui/background/equipbg_fortune_r.png");
                        break;
                    case CardColor.Nature:
                        bgImage2 = Image.FromFile("ui/background/equipbg_nature_r.png");
                        break;
                    case CardColor.War:
                        bgImage2 = Image.FromFile("ui/background/equipbg_war_r.png");
                        break;
                }

                graphics.DrawImage(bgImage1, 40, 0x40, 0xa6, 400);
                graphics.DrawImage(bgImage2, 0xc7, 0x40, 0xa6, 400);
            }

            //皮肤
            int skinImageWidth;
            int skinImageHeight;
            Image original = Image.FromFile(textBox1.Text);
            if (!radioButton1.Checked)
            {
                skinImageWidth = (int)(original.Width * Convert.ToDecimal(textBox15.Text));
                skinImageHeight = (int)(original.Height * Convert.ToDecimal(textBox15.Text));
            }
            else if ((((float)original.Width) / original.Height) > 0.8097561f)
            {
                skinImageWidth = (original.Width * 410) / original.Height;
                skinImageHeight = 410;
            }
            else
            {
                skinImageWidth = 0x14c;
                skinImageHeight = (original.Height * 0x14c) / original.Width;
            }

            Bitmap skinBitmap = new(original, skinImageWidth, skinImageHeight);
            skinBitmap.SetResolution(0x60f, 0x60f);

            Bitmap skinBgBitmap = new(0x14c, 410, PixelFormat.Format32bppArgb);
            skinBgBitmap.SetResolution(0x60f, 0x60f);

            Graphics skinBgGraphics = Graphics.FromImage(skinBgBitmap);
            skinBgGraphics.Clear(Color.Empty);
            skinBgGraphics.DrawImage(skinBitmap, new Rectangle(0, 0, 0x14c, 410), new Rectangle(Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), 0x14c, 410), GraphicsUnit.Pixel);
            skinBgGraphics.Dispose();

            if (cardKind == CardKind.Consume)
            {
                Color color = Color.FromArgb(0, 0, 0, 0);
                int num3 = 0;
                while (true)
                {
                    if (num3 >= 0x22)
                    {
                        int x = 0;
                        while (true)
                        {
                            if (x >= 140)
                            {
                                break;
                            }
                            int num7 = 0x22 - ((int)(0.19 * x));
                            int num8 = 410 - num7;
                            while (true)
                            {
                                if (num8 >= 410)
                                {
                                    x++;
                                    break;
                                }
                                skinBgBitmap.SetPixel(x, num8, color);
                                skinBgBitmap.SetPixel(0x14b - x, num8, color);
                                num8++;
                            }
                        }
                        break;
                    }
                    int num4 = 0x23 - ((int)(0.6 * num3));
                    int y = 400 - num4;
                    while (true)
                    {
                        if (y >= 410)
                        {
                            num3++;
                            break;
                        }
                        skinBgBitmap.SetPixel(0xa5 - num3, y, color);
                        skinBgBitmap.SetPixel(0xa5 + num3, y, color);
                        y++;
                    }
                }
            }

            graphics.DrawImage(skinBgBitmap, 0x22, 0x40);

            //种类图标
            graphics.DrawImage(Image.FromFile("ui/kindicon_bg.png"), 0x87, 0x41, 128, 37);
            switch (cardKind)
            {
                case CardKind.Monster:
                    graphics.DrawImage(Image.FromFile("ui/kindicon_monster.png"), 190, 0x49, 19, 20);
                    break;
                case CardKind.Consume:
                    graphics.DrawImage(Image.FromFile("ui/kindicon_consume.png"), 190, 0x49, 19, 20);
                    break;
                case CardKind.Equip:
                    graphics.DrawImage(Image.FromFile("ui/kindicon_equip.png"), 190, 0x49, 19, 20);
                    break;
                case CardKind.Weapon:
                    graphics.DrawImage(Image.FromFile("ui/kindicon_weapon.png"), 190, 0x49, 19, 20);
                    break;
            }

            //边框
            if (cardKind != CardKind.Consume)
            {
                Bitmap borderBitmap = new(Image.FromFile("ui/card_border.png"));

                Image borderImage1 = null;
                if (radioButton3.Checked)
                {
                    if (cardKind == CardKind.Consume)
                    {
                        borderImage1 = borderBitmap;
                    }
                    else
                    {
                        switch (cardColor1)
                        {
                            case CardColor.Balance:
                                borderImage1 = ConvertColor(borderBitmap, DefaultColor.balance);
                                break;
                            case CardColor.Chaos:
                                borderImage1 = ConvertColor(borderBitmap, DefaultColor.chaos);
                                break;
                            case CardColor.Fortune:
                                borderImage1 = ConvertColor(borderBitmap, DefaultColor.fortune);
                                break;
                            case CardColor.Nature:
                                borderImage1 = ConvertColor(borderBitmap, DefaultColor.nature);
                                break;
                            case CardColor.War:
                                borderImage1 = ConvertColor(borderBitmap, DefaultColor.war);
                                break;
                            default:
                                borderImage1 = borderBitmap;
                                break;
                        }
                    }
                }
                if (radioButton4.Checked)
                {
                    borderImage1 = ConvertColor(borderBitmap, Color.FromArgb(Convert.ToInt32(textBox8.Text.Replace("#", ""), 16)));
                }

                graphics.DrawImage(borderImage1, 0x10, 6, 183, 504);

                Bitmap borderBitmap2 = new(borderBitmap.Width, borderBitmap.Height);
                for (int i = 0; i < borderBitmap.Width; i++)
                {
                    for (int j = 0; j < borderBitmap.Height; j++)
                    {
                        borderBitmap2.SetPixel(borderBitmap.Width - 1 - i, j, borderBitmap.GetPixel(i, j));
                    }
                }

                Image borderImage2 = null;
                if (radioButton5.Checked)
                {
                    if (cardKind == CardKind.Consume)
                    {
                        borderImage2 = borderBitmap2;
                    }
                    else
                    {
                        switch (cardColor2 == CardColor.None ? cardColor1 : cardColor2)
                        {
                            case CardColor.Balance:
                                borderImage2 = ConvertColor(borderBitmap2, DefaultColor.balance);
                                break;
                            case CardColor.Chaos:
                                borderImage2 = ConvertColor(borderBitmap2, DefaultColor.chaos);
                                break;
                            case CardColor.Fortune:
                                borderImage2 = ConvertColor(borderBitmap2, DefaultColor.fortune);
                                break;
                            case CardColor.Nature:
                                borderImage2 = ConvertColor(borderBitmap2, DefaultColor.nature);
                                break;
                            case CardColor.War:
                                borderImage2 = ConvertColor(borderBitmap2, DefaultColor.war);
                                break;
                            default:
                                borderImage2 = borderBitmap2;
                                break;
                        }
                    }
                }
                if (radioButton6.Checked)
                {
                    borderImage2 = ConvertColor(borderBitmap2, Color.FromArgb(Convert.ToInt32(textBox16.Text.Replace("#", ""), 16)));
                }
                graphics.DrawImage(borderImage2, 0xc7, 6, 183, 504);
            }

            //阵营图标
            Bitmap iconBgBitmap = new(Image.FromFile("ui/coloricon/coloricon_bg.png"));

            Image iconBgImage1 = null;
            Image iconImage1 = null;
            if (radioButton3.Checked)
            {
                switch (cardColor1)
                {
                    case CardColor.Balance:
                        iconBgImage1 = ConvertColor(iconBgBitmap, DefaultColor.balance);
                        iconImage1 = Image.FromFile("ui/coloricon/coloricon_balance.png");
                        break;
                    case CardColor.Chaos:
                        iconBgImage1 = ConvertColor(iconBgBitmap, DefaultColor.chaos);
                        iconImage1 = Image.FromFile("ui/coloricon/coloricon_chaos.png");
                        break;
                    case CardColor.Fortune:
                        iconBgImage1 = ConvertColor(iconBgBitmap, DefaultColor.fortune);
                        iconImage1 = Image.FromFile("ui/coloricon/coloricon_fortune.png");
                        break;
                    case CardColor.Nature:
                        iconBgImage1 = ConvertColor(iconBgBitmap, DefaultColor.nature);
                        iconImage1 = Image.FromFile("ui/coloricon/coloricon_nature.png");
                        break;
                    case CardColor.War:
                        iconBgImage1 = ConvertColor(iconBgBitmap, DefaultColor.war);
                        iconImage1 = Image.FromFile("ui/coloricon/coloricon_war.png");
                        break;
                    default:
                        iconBgImage1 = iconBgBitmap;
                        iconImage1 = Image.FromFile("ui/coloricon/coloricon_all.png");
                        break;
                }
                if (cardKind == CardKind.Consume)
                {
                    iconBgImage1 = iconBgBitmap;
                }
            }
            if (radioButton4.Checked)
            {
                iconBgImage1 = ConvertColor(iconBgBitmap, Color.FromArgb(Convert.ToInt32(textBox8.Text.Replace("#", ""), 16)));
                iconImage1 = Image.FromFile(textBox17.Text);
            }
            graphics.DrawImage(iconBgImage1, 0x12, 0x5d, 0x42, 82);
            graphics.DrawImage(iconImage1, 0x23, 107, 30, 32);

            if (cardColor2 != CardColor.None || radioButton6.Checked)
            {
                Bitmap iconBgBitmap2 = new(iconBgBitmap.Width, iconBgBitmap.Height);
                for (int i = 0; i < iconBgBitmap.Width; i++)
                {
                    for (int j = 0; j < iconBgBitmap.Height; j++)
                    {
                        iconBgBitmap2.SetPixel(iconBgBitmap.Width - 1 - i, j, iconBgBitmap.GetPixel(i, j));
                    }
                }

                Image iconBgImage2 = null;
                Image iconImage2 = null;
                if (radioButton5.Checked)
                {
                    switch (cardColor2)
                    {
                        case CardColor.Balance:
                            iconBgImage2 = ConvertColor(iconBgBitmap2, DefaultColor.balance);
                            iconImage2 = Image.FromFile("ui/coloricon/coloricon_balance.png");
                            break;
                        case CardColor.Chaos:
                            iconBgImage2 = ConvertColor(iconBgBitmap2, DefaultColor.chaos);
                            iconImage2 = Image.FromFile("ui/coloricon/coloricon_chaos.png");
                            break;
                        case CardColor.Fortune:
                            iconBgImage2 = ConvertColor(iconBgBitmap2, DefaultColor.fortune);
                            iconImage2 = Image.FromFile("ui/coloricon/coloricon_fortune.png");
                            break;
                        case CardColor.Nature:
                            iconBgImage2 = ConvertColor(iconBgBitmap2, DefaultColor.nature);
                            iconImage2 = Image.FromFile("ui/coloricon/coloricon_nature.png");
                            break;
                        case CardColor.War:
                            iconBgImage2 = ConvertColor(iconBgBitmap2, DefaultColor.war);
                            iconImage2 = Image.FromFile("ui/coloricon/coloricon_war.png");
                            break;
                        default:
                            iconBgImage2 = iconBgBitmap2;
                            iconImage2 = Image.FromFile("ui/coloricon/coloricon_all.png");
                            break;
                    }
                    if (cardKind == CardKind.Consume)
                    {
                        iconBgImage2 = iconBgBitmap2;
                    }
                }
                if (radioButton6.Checked)
                {
                    iconBgImage2 = ConvertColor(iconBgBitmap2, Color.FromArgb(Convert.ToInt32(textBox16.Text.Replace("#", ""), 16)));
                    iconImage2 = Image.FromFile(textBox18.Text);
                }
                graphics.DrawImage(iconBgImage2, 0x13a, 0x5c, 0x42, 82);
                graphics.DrawImage(iconImage2, 0x14d, 107, 30, 32);
            }

            //卡牌名称背景
            Bitmap titleBitmap = new(Image.FromFile("ui/title1.png"));

            Image titleImage1 = null;
            if (cardKind == CardKind.Consume)
            {
                titleImage1 = titleBitmap;
            }
            else
            {
                if (radioButton3.Checked)
                {
                    switch (cardColor1)
                    {
                        case CardColor.Balance:
                            titleImage1 = ConvertColor(titleBitmap, DefaultColor.balance);
                            break;
                        case CardColor.Chaos:
                            titleImage1 = ConvertColor(titleBitmap, DefaultColor.chaos);
                            break;
                        case CardColor.Fortune:
                            titleImage1 = ConvertColor(titleBitmap, DefaultColor.fortune);
                            break;
                        case CardColor.Nature:
                            titleImage1 = ConvertColor(titleBitmap, DefaultColor.nature);
                            break;
                        case CardColor.War:
                            titleImage1 = ConvertColor(titleBitmap, DefaultColor.war);
                            break;
                        default:
                            titleImage1 = titleBitmap;
                            break;
                    }
                }
                if (radioButton4.Checked)
                {
                    titleImage1 = ConvertColor(titleBitmap, Color.FromArgb(Convert.ToInt32(textBox8.Text.Replace("#", ""), 16)));
                }
            }
            graphics.DrawImage(titleImage1, 0, 0, 199, 113);

            Bitmap titleBitmap2 = new(Image.FromFile("ui/title2.png"));

            Image titleImage2 = null;
            if (cardKind == CardKind.Consume)
            {
                titleImage2 = titleBitmap2;
            }
            else
            {
                if (radioButton5.Checked)
                {
                    switch (cardColor2 == CardColor.None ? cardColor1 : cardColor2)
                    {
                        case CardColor.Balance:
                            titleImage2 = ConvertColor(titleBitmap2, DefaultColor.balance);
                            break;
                        case CardColor.Chaos:
                            titleImage2 = ConvertColor(titleBitmap2, DefaultColor.chaos);
                            break;
                        case CardColor.Fortune:
                            titleImage2 = ConvertColor(titleBitmap2, DefaultColor.fortune);
                            break;
                        case CardColor.Nature:
                            titleImage2 = ConvertColor(titleBitmap2, DefaultColor.nature);
                            break;
                        case CardColor.War:
                            titleImage2 = ConvertColor(titleBitmap2, DefaultColor.war);
                            break;
                        default:
                            titleImage2 = titleBitmap2;
                            break;
                    }
                }
                if (radioButton6.Checked)
                {
                    titleImage2 = ConvertColor(titleBitmap2, Color.FromArgb(Convert.ToInt32(textBox16.Text.Replace("#", ""), 16)));
                }
            }
            graphics.DrawImage(titleImage2, 199, 0, 206, 113);

            graphics.DrawImage(Image.FromFile("ui/title_goldborder.png"), 0x20, 12, 0x165, 0x54);

            //标签
            switch (cardTag)
            {
                case CardTag.PrCard:
                    graphics.DrawImage(Image.FromFile("ui/tag/pr_card.png"), 65, 0, 135, 119);
                    break;
                case CardTag.YearCard:
                    graphics.DrawImage(Image.FromFile("ui/tag/year_card.png"), 65, 0, 135, 119);
                    break;
                case CardTag.SpecialLegend:
                    graphics.DrawImage(Image.FromFile("ui/tag/special_legend.png"), 65, -3, 135, 119);
                    break;
                case CardTag.SpecialEpic:
                    graphics.DrawImage(Image.FromFile("ui/tag/special_epic.png"), 65, -3, 135, 119);
                    break;
                case CardTag.SpecialRare:
                    graphics.DrawImage(Image.FromFile("ui/tag/special_rare.png"), 65, -40, 178, 157);
                    break;
            }

            //卡牌名
            string str = textBox25.Text;
            Bitmap nameBitmap = TextToBitmap(str);
            graphics.DrawImage(nameBitmap, 0xc7 - (nameBitmap.Width * 20 / nameBitmap.Height), 0x17, (nameBitmap.Width * 40) / nameBitmap.Height, 40);


            //费用
            graphics.DrawImage(Image.FromFile("ui/crystal.png"), 3, -1, 98, 112);
            Bitmap crystalAmountBitmap = NumToBitmap(textBox4.Text);

            graphics.DrawImage(crystalAmountBitmap, 0x2f - (crystalAmountBitmap.Width * 0x21 / crystalAmountBitmap.Height), 0x19, (crystalAmountBitmap.Width * 0x42) / crystalAmountBitmap.Height, 0x42);

            //高级技能
            if (!string.IsNullOrEmpty(textBox20.Text))
            {
                graphics.DrawImage(Image.FromFile("ui/skill2_shadow.png"), 0x37, 0x163, 0x120, 0x58);
                graphics.DrawImage(Image.FromFile("ui/skill2_bg.png"), 0x9d, 310, 89, 129);
                graphics.DrawImage(Image.FromFile("ui/skill/" + textBox20.Text + ".png"), 0xad, 0x149, 0x34, 0x34);
                if (!string.IsNullOrEmpty(textBox9.Text))
                {
                    Bitmap bitmap4 = NumToBitmap(textBox9.Text);
                    graphics.DrawImage(bitmap4, 0xc7 - ((bitmap4.Width * 0x15) / bitmap4.Height), 0x175, (bitmap4.Width * 0x2a) / bitmap4.Height, 0x2a);
                }
            }
            if (!string.IsNullOrEmpty(textBox21.Text))
            {
                graphics.DrawImage(Image.FromFile("ui/skill2_bg.png"), 0x43, 310, 89, 129);
                graphics.DrawImage(Image.FromFile("ui/skill/" + textBox21.Text + ".png"), 0x53, 0x149, 0x34, 0x34);
                if (!string.IsNullOrEmpty(textBox10.Text))
                {
                    Bitmap bitmap5 = NumToBitmap(textBox10.Text);
                    graphics.DrawImage(bitmap5, 0x6d - ((bitmap5.Width * 0x15) / bitmap5.Height), 0x175, (bitmap5.Width * 0x2a) / bitmap5.Height, 0x2a);
                }
            }
            if (!string.IsNullOrEmpty(textBox22.Text))
            {
                graphics.DrawImage(Image.FromFile("ui/skill2_bg.png"), 0xf7, 310, 89, 129);
                graphics.DrawImage(Image.FromFile("ui/skill/" + textBox22.Text + ".png"), 0x107, 0x149, 0x34, 0x34);
                if (!string.IsNullOrEmpty(textBox11.Text))
                {
                    Bitmap bitmap6 = NumToBitmap(textBox11.Text);
                    graphics.DrawImage(bitmap6, 0x121 - ((bitmap6.Width * 0x15) / bitmap6.Height), 0x175, (bitmap6.Width * 0x2a) / bitmap6.Height, 0x2a);
                }
            }

            //精英技能
            if (!string.IsNullOrEmpty(textBox23.Text))
            {
                graphics.DrawImage(Image.FromFile("ui/skill2_bg.png"), 0x11, 0x86, 0x43, 0x61);
                graphics.DrawImage(Image.FromFile("ui/skill/" + textBox23.Text + ".png"), 0x1d, 0x94, 0x2a, 0x2a);
                if (!string.IsNullOrEmpty(textBox12.Text))
                {
                    Bitmap bitmap7 = NumToBitmap(textBox12.Text);
                    graphics.DrawImage(bitmap7, 0x31 - ((bitmap7.Width * 0x11) / bitmap7.Height), 0xb7, (bitmap7.Width * 0x22) / bitmap7.Height, 0x22);
                }
            }
            if (!string.IsNullOrEmpty(textBox24.Text))
            {
                graphics.DrawImage(Image.FromFile("ui/skill2_bg.png"), 0x13a, 0x86, 0x43, 0x61);
                graphics.DrawImage(Image.FromFile("ui/skill/" + textBox24.Text + ".png"), 0x147, 0x94, 0x2a, 0x2a);
                if (!string.IsNullOrEmpty(textBox13.Text))
                {
                    Bitmap bitmap8 = NumToBitmap(textBox13.Text);
                    graphics.DrawImage(bitmap8, 0x15b - ((bitmap8.Width * 0x11) / bitmap8.Height), 0xb7, (bitmap8.Width * 0x22) / bitmap8.Height, 0x22);
                }
            }

            //基础技能
            if (!string.IsNullOrEmpty(comboBox7.Text) && !string.IsNullOrEmpty(textBox6.Text))
            {
                graphics.DrawImage(Image.FromFile("ui/skill1_bg.png"), 6, 0x18d, 97, 100);

                graphics.DrawImage(Image.FromFile("ui/skill/" + comboBox7.Text + ".png"), 1, 0x183, 0x34, 0x34);
                Bitmap bitmap9 = NumToBitmap(textBox6.Text);
                graphics.DrawImage(bitmap9, 0x33 - ((bitmap9.Width * 0x21) / bitmap9.Height), 0x199, (bitmap9.Width * 0x42) / bitmap9.Height, 0x42);
            }
            if (!comboBox8.Text.Equals(string.Empty) & !textBox14.Text.Equals(string.Empty))
            {
                graphics.DrawImage(Image.FromFile("ui/skill1_bg.png"), 6, 0x11f, 97, 100);

                graphics.DrawImage(Image.FromFile("ui/skill/" + comboBox8.Text + ".png"), 1, 0x115, 0x34, 0x34);
                Bitmap bitmap10 = NumToBitmap(textBox14.Text);
                graphics.DrawImage(bitmap10, 0x33 - ((bitmap10.Width * 0x21) / bitmap10.Height), 0x12b, (bitmap10.Width * 0x42) / bitmap10.Height, 0x42);
            }
            if (!comboBox9.Text.Equals(string.Empty) & !textBox7.Text.Equals(string.Empty))
            {
                graphics.DrawImage(Image.FromFile("ui/skill1_bg.png"), 6, 0xb1, 97, 100);

                graphics.DrawImage(Image.FromFile("ui/skill/" + comboBox9.Text + ".png"), 1, 0xa7, 0x34, 0x34);
                Bitmap bitmap11 = NumToBitmap(textBox7.Text);
                graphics.DrawImage(bitmap11, 0x33 - ((bitmap11.Width * 0x21) / bitmap11.Height), 0xbd, (bitmap11.Width * 0x42) / bitmap11.Height, 0x42);
            }


            //血量护甲
            if (cardKind == CardKind.Monster)
            {
                graphics.DrawImage(Image.FromFile("ui/hp_bg.png"), 0x12a, 388, 97, 100);

                if (!string.IsNullOrEmpty(textBox5.Text))
                {
                    Bitmap hpBitmap = NumToBitmap(textBox5.Text);
                    graphics.DrawImage(hpBitmap, 0x15b - (hpBitmap.Width * 0x1f / hpBitmap.Height), 0x199, (hpBitmap.Width * 0x3e) / hpBitmap.Height, 0x3e);
                }
            }
            if ((cardKind == CardKind.Equip || cardKind == CardKind.Weapon) && !string.IsNullOrEmpty(textBox5.Text))
            {
                graphics.DrawImage(Image.FromFile("ui/armor_bg.png"), 0x132, 400, 97, 100);
                Bitmap hpBitmap = NumToBitmap(textBox5.Text);
                graphics.DrawImage(hpBitmap, 0x15b - (hpBitmap.Width * 0x1f / hpBitmap.Height), 0x199, (hpBitmap.Width * 0x3e) / hpBitmap.Height, 0x3e);
            }

            //稀有度
            switch (cardQuality)
            {
                case Quality.Elite:
                    graphics.DrawImage(Image.FromFile("ui/qualityicon/quality_elite.png"), 0x8b, 0x1a9, 0x76, 0x59);
                    break;
                case Quality.Epic:
                    graphics.DrawImage(Image.FromFile("ui/qualityicon/quality_epic.png"), 0xad, 0x1b5, 0x34, 60);
                    break;
                case Quality.Rarity:
                    graphics.DrawImage(Image.FromFile("ui/qualityicon/quality_rarity.png"), 0xad, 0x1b6, 0x34, 60);
                    break;
                case Quality.Rare:
                    graphics.DrawImage(Image.FromFile("ui/qualityicon/quality_rare.png"), 0xad, 0x1b6, 0x34, 60);
                    break;
                case Quality.Normal:
                    graphics.DrawImage(Image.FromFile("ui/qualityicon/quality_normal.png"), 0xad, 0x1b5, 0x34, 60);
                    break;
                case Quality.Friend:
                    graphics.DrawImage(Image.FromFile("ui/qualityicon/quality_friend.png"), 0xad, 0x1b5, 0x34, 60);
                    break;
            }

            pictureBox1.Image = bitmap;
            return;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "Image Files (*.png)|*.png",
                Title = "保存图像",
                FileName = textBox25.Text
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(dialog.FileName);
            }
        }

        private void 帮助文档ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("notepad.exe", "帮助文档.txt");
        }

        private void 程序位置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Environment.CurrentDirectory);
        }

        private void 打开allcardskinconfigcsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("notepad.exe", "ui/all_card_skin_config.csv");
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("v2.0\n作者：红色的哥\n邮箱：2451983550@qq.com\nqq:2451983550", "关于");
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }

        private Bitmap Paiamian()
        {
            CardKind cardKind = (CardKind)comboBox1.SelectedValue;

            int num;
            int num2;
            Image original = Image.FromFile(textBox1.Text);
            if (!radioButton1.Checked)
            {
                num = (int)(original.Width * Convert.ToDecimal(textBox15.Text));
                num2 = (int)(original.Height * Convert.ToDecimal(textBox15.Text));
            }
            else if ((((float)original.Width) / ((float)original.Height)) > 0.8097561f)
            {
                num = (original.Width * 410) / original.Height;
                num2 = 410;
            }
            else
            {
                num = 0x14c;
                num2 = (original.Height * 0x14c) / original.Width;
            }
            Bitmap image = new Bitmap(original, num, num2);
            image.SetResolution(0x60f, 0x60f);
            Bitmap bitmap2 = new Bitmap(0x14c, 410, PixelFormat.Format32bppArgb);
            bitmap2.SetResolution(0x60f, 0x60f);
            Graphics graphics = Graphics.FromImage(bitmap2);
            graphics.Clear(Color.Empty);
            graphics.DrawImage(image, new Rectangle(0, 0, 0x14c, 410), new Rectangle(Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), 0x14c, 410), GraphicsUnit.Pixel);
            graphics.Dispose();

            if (cardKind == CardKind.Consume)
            {
                Color color = Color.FromArgb(0, 0, 0, 0);
                int num3 = 0;
                while (true)
                {
                    if (num3 >= 0x22)
                    {
                        int x = 0;
                        while (true)
                        {
                            if (x >= 140)
                            {
                                break;
                            }
                            int num7 = 0x22 - ((int)(0.19 * x));
                            int num8 = 410 - num7;
                            while (true)
                            {
                                if (num8 >= 410)
                                {
                                    x++;
                                    break;
                                }
                                bitmap2.SetPixel(x, num8, color);
                                bitmap2.SetPixel(0x14b - x, num8, color);
                                num8++;
                            }
                        }
                        break;
                    }
                    int num4 = 0x23 - ((int)(0.6 * num3));
                    int y = 400 - num4;
                    while (true)
                    {
                        if (y >= 410)
                        {
                            num3++;
                            break;
                        }
                        bitmap2.SetPixel(0xa5 - num3, y, color);
                        bitmap2.SetPixel(0xa5 + num3, y, color);
                        y++;
                    }
                }
            }
            return bitmap2;
        }

        private Bitmap shuzipinjie(Bitmap map1, Bitmap map2)
        {
            Bitmap image = new Bitmap(map1.Width + map2.Width, Math.Max(map1.Height, map2.Height));
            Graphics graphics = Graphics.FromImage(image);
            graphics.DrawImage(map1, 0, 0, map1.Width, map2.Height);
            graphics.DrawImage(map2, map1.Width, 0, map2.Width, map2.Height);
            map1.Dispose();
            map2.Dispose();
            return image;
        }

        private Bitmap NumToBitmap(string numText)
        {
            Bitmap bitmap = new(54 * numText.Length, 73);
            Graphics graphics = Graphics.FromImage(bitmap);

            for (int i = 0; i < numText.Length; i++)
            {
                Bitmap numBitmap = new(Image.FromFile("ui/num_img/" + numText[i].ToString() + ".png"));
                graphics.DrawImage(numBitmap, 54 * i, 0);
            }

            return bitmap;
        }

        private Bitmap TextToBitmap(string text)
        {
            if (text.Length < 3)
            {
                text = "充                                        " + text + "                                        充";
            }
            PrivateFontCollection fonts = new PrivateFontCollection();
            fonts.AddFontFile("ui/font.ttf");
            Font font = new Font(fonts.Families[0], 80f);
            StringFormat stringFormat = new StringFormat(StringFormatFlags.NoClip);
            Bitmap image = new Bitmap(1, 1);
            SizeF ef = Graphics.FromImage(image).MeasureString(text, font, PointF.Empty, stringFormat);
            int width = (int)(ef.Width + 1f);
            int height = (int)(ef.Height + 1f);
            image.Dispose();
            image = new Bitmap(width, height);
            Graphics graphics = Graphics.FromImage(image);
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            graphics.DrawString(text, font, Brushes.White, new Rectangle(5, 12, width, height), stringFormat);
            int x = 4;
            while (true)
            {
                if (x >= (image.Width - 4))
                {
                    Bitmap bitmap2 = new Bitmap(width, height);
                    Graphics graphics2 = Graphics.FromImage(bitmap2);
                    graphics2.DrawImage(image, 0, 0);
                    graphics2.DrawImage(bitmap2, 0, -1);
                    graphics2.DrawImage(bitmap2, 0, -2);
                    graphics2.DrawImage(bitmap2, 0, -4);
                    graphics2.DrawImage(image, 0, -8);
                    graphics2.DrawImage(image, 0, -9);
                    graphics2.DrawImage(image, 0, -10);
                    return bitmap2;
                }
                int y = 4;
                while (true)
                {
                    if (y >= (image.Height - 4))
                    {
                        x++;
                        break;
                    }
                    Color pixel = image.GetPixel(x, y);
                    Color color = Color.FromArgb(0xff, 0, 0, 0);
                    Color color3 = Color.FromArgb(0xff, 0xff, 0xff, 0xff);
                    if (pixel.Equals(color3))
                    {
                        int num5 = -4;
                        while (true)
                        {
                            if (num5 >= 5)
                            {
                                break;
                            }
                            int num6 = -4;
                            while (true)
                            {
                                if (num6 >= 5)
                                {
                                    num5++;
                                    break;
                                }
                                Color color4 = image.GetPixel(x + num5, y + num6);
                                if (!color4.Equals(color3))
                                {
                                    image.SetPixel(x + num5, y + num6, color);
                                }
                                num6++;
                            }
                        }
                    }
                    y++;
                }
            }
        }

        private Bitmap ConvertColor(Bitmap bitmap, Color color)
        {
            Bitmap result = new(bitmap.Width, bitmap.Height);
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color color1 = bitmap.GetPixel(i, j);
                    Color color2 = Color.FromArgb(color1.A, color1.R * color.R / 255, color1.G * color.G / 255, color1.B * color.B / 255);

                    result.SetPixel(i, j, color2);
                }
            }
            return result;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Multiselect = false,
                Title = "选择图像",
                Filter = "所有文件(*.*)|*.*"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox17.Text = dialog.FileName;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Multiselect = false,
                Title = "选择图像",
                Filter = "所有文件(*.*)|*.*"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox18.Text = dialog.FileName;
            }
        }
    }

    enum CardKind
    {
        Monster,
        Consume,
        Equip,
        Weapon
    }

    enum Quality
    {
        Elite,
        Epic,
        Rarity,
        Rare,
        Normal,
        Friend
    }

    enum CardTag
    {
        None,
        PrCard,
        YearCard,
        SpecialLegend,
        SpecialEpic,
        SpecialRare
    }

    enum CardColor
    {
        None,
        All,
        Balance,
        Chaos,
        Fortune,
        Nature,
        War
    }

    class DefaultColor
    {
        public static Color balance = Color.FromArgb(Convert.ToInt32("4faaf8", 16));
        public static Color chaos = Color.FromArgb(Convert.ToInt32("9456ce", 16));
        public static Color fortune = Color.FromArgb(Convert.ToInt32("eec401", 16));
        public static Color nature = Color.FromArgb(Convert.ToInt32("74bb03", 16));
        public static Color war = Color.FromArgb(Convert.ToInt32("df583d", 16));
    }
}
