using System.DirectoryServices.ActiveDirectory;
using System.Reflection.Emit;
using System.Windows.Forms;
using static PokeRaid2.Form1;
using static System.Windows.Forms.LinkLabel;
using Label = System.Windows.Forms.Label;

namespace PokeRaid2
{
    partial class Form1
    {
        public static string dir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void initializeForm()
        {

            string[] lines = global::PokeRaid2.Properties.Resources.gen9.Split('\n');
            Pokemon[] pokemon = new Pokemon[406];
            Panel[] panels = new Panel[406];
            Panel panel = new Panel();

            for (int i = 0; i < pokemon.Length; i++)
            {
                pokemon[i].assignStats(lines[i]);
            }

            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            //
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            //this.splitContainer1.Panel1.SuspendLayout();
            //this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
             
            // splitContainer1
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.None;
            this.splitContainer1.Enabled = false;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            panel.AutoScroll = true;
            //panel.VerticalScroll.Minimum = 1000;
            panel.Dock = DockStyle.None;
            //this.splitContainer1.Panel1.AutoSize = true;
            Button b = new Button();
            
            panel.Controls.Add(b);
            b.Location = new System.Drawing.Point(0, 50000);
            this.splitContainer1.Panel1.AutoSize = true;

            int posY = 0;
            for(int i = 0; i < pokemon.Length; i++)
            {
                panel.Controls.Add(panelFactory(i, pokemon[i], posY));
                posY += 118;
            }
            panel.Size = new Size(500, 800);
            this.splitContainer1.Panel1.Controls.Add(panel);
            //System.Diagnostics.Debug.WriteLine("size " + panel.Size);


            System.Diagnostics.Debug.WriteLine(this.splitContainer1.Panel1.Size);


            // splitContainer1.Panel2
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(1345, 786);
            this.splitContainer1.SplitterDistance = 497;
            this.splitContainer1.TabIndex = 1;
        
            
            // fileSystemWatcher1
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            
            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1345, 786);
            this.Controls.Add(this.splitContainer1);
            this.Icon = global::PokeRaid2.Properties.Resources.pokeball;
            this.Name = "Form1";
            this.Text = "PokeRaid";
            this.Load += new System.EventHandler(this.Form1_Load);
            //this.splitContainer1.Panel1.ResumeLayout(true);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            //this.splitContainer1.ResumeLayout(true);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(true);
            //panel.ResumeLayout(true);
            this.PerformLayout();
        }

        private Panel panelFactory(int panelNum, Pokemon pokemon, int posY)
        {
            Panel panel = new System.Windows.Forms.Panel();
            panel.Dock = DockStyle.None;
            panel.BackColor = System.Drawing.Color.SkyBlue;
            panel.Name = "Panel" + panelNum;
            panel.Location = new System.Drawing.Point( 24, posY + 8);
            panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            string[] name = { "PokeDex/ Name", "Primary Type", "Secondary Type", "Base Stats", "HP", "Attack", "Speed", "Defense", "Sp. Attack", "Sp. Defense" };
            
            for (int i = 0; i < 10; i++)
            {
                panel.Controls.Add(labelFactory(name[i], pokemon));
                if(i > 3)
                    panel.Controls.Add(statLabelFactory(name[i], pokemon));
            }

            panel.Controls.Add(pTypePictureBoxFactory(pokemon.primaryType));
            panel.Controls.Add(sTypePictureBoxFactory(pokemon.secondaryType));
            panel.Controls.Add(pokePictureBoxFactory(pokemon.pokeDexNum));
            panel.Size = new System.Drawing.Size(464, 110);
            panel.TabIndex = 0;

            return panel;
        }

        private Label labelFactory(string name, Pokemon pokemon)
        {
            Label label = new System.Windows.Forms.Label();
            label.Dock = DockStyle.None;
            label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label.BackColor = System.Drawing.Color.LightCoral;
            label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label.AutoSize = false;
            label.Name = name;
            label.TabIndex = 1;

            switch (name)
            {
                case "PokeDex/ Name":
                    label.Size = new System.Drawing.Size(122, 18);
                    label.Text = "#" + pokemon.pokeDexNum + ": " + pokemon.name;
                    label.Location = new System.Drawing.Point(-1,  -1);
                    break;
                case "Primary Type": 
                    label.Size = new System.Drawing.Size(120, 18);
                    label.Text = "Primary Type";
                    label.Location= new System.Drawing.Point(120,  -1);
                    break;
                case "Secondary Type":
                    label.Size = new System.Drawing.Size(120, 18);
                    label.Text = "Secondary Type";
                    label.Location = new System.Drawing.Point(120,  61);
                    break;
                case "Base Stats":
                    label.Size = new System.Drawing.Size(224, 18);
                    label.Text = "Base Stats";
                    label.Location = new System.Drawing.Point(239,  -1);
                    break;
                case "Attack":
                    label.Size = new System.Drawing.Size(76, 18);
                    label.Text = "Attack";
                    label.Location = new System.Drawing.Point(312,  16);
                    break;
                case "HP":
                    label.Size = new System.Drawing.Size(74, 18);
                    label.Text = "HP";
                    label.Location = new System.Drawing.Point(239, 16);
                    break;
                case "Speed":
                    label.Size = new System.Drawing.Size(74, 18);
                    label.Text = "Speed";
                    label.Location = new System.Drawing.Point(239,  61);
                    break;
                case "Defense":
                    label.Size = new System.Drawing.Size(76, 18);
                    label.Text = "Defense";
                    label.Location = new System.Drawing.Point(387,  16);
                    break;
                case "Sp. Attack":
                    label.Size = new System.Drawing.Size(76, 18);
                    label.Text = "Sp. Attack";
                    label.Location = new System.Drawing.Point(312,  61);
                    break;
                case "Sp. Defense":
                    label.Size = new System.Drawing.Size(76, 18);
                    label.Text = "Sp. Defense";
                    label.Location = new System.Drawing.Point(387,  61);
                    break;
            }

            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            return label;
        }

        private System.Windows.Forms.Label statLabelFactory(string name, Pokemon pokemon)
        {
            Label statLabel = new System.Windows.Forms.Label();
            statLabel.Dock = DockStyle.None;
            statLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            statLabel.BackColor = System.Drawing.Color.SkyBlue;
            statLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            statLabel.AutoSize = false;
            statLabel.Name = name;
            statLabel.TabIndex = 1;

            //System.Diagnostics.Debug.WriteLine(name);

            switch (name)
            {
                case "Attack":
                    statLabel.Size = new System.Drawing.Size(76, 29);
                    statLabel.Text = pokemon.attack;
                    statLabel.Location = new System.Drawing.Point(312, 33);
                    break;
                case "HP":
                    statLabel.Size = new System.Drawing.Size(74, 29);
                    statLabel.Text = pokemon.hp;
                    statLabel.Location = new System.Drawing.Point(239, 33);
                    break;
                case "Speed":
                    statLabel.Size = new System.Drawing.Size(74, 31);
                    statLabel.Text = pokemon.speed;
                    statLabel.Location = new System.Drawing.Point(239, 78);
                    break;
                case "Defense":
                    statLabel.Size = new System.Drawing.Size(76, 29);
                    statLabel.Text = pokemon.defense;
                    statLabel.Location = new System.Drawing.Point(387, 33);
                    break;
                case "Sp. Attack":
                    statLabel.Size = new System.Drawing.Size(76, 31);
                    statLabel.Text = pokemon.spAttack;
                    statLabel.Location = new System.Drawing.Point(312, 78);
                    break;
                case "Sp. Defense":
                    statLabel.Size = new System.Drawing.Size(76, 31);
                    statLabel.Text = pokemon.spDefense;
                    statLabel.Location = new System.Drawing.Point(387, 78);
                    break;
            }

            statLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            return statLabel;
        }

        private PictureBox pokePictureBoxFactory(string dexNum)
        {
            PictureBox pictureBox = new System.Windows.Forms.PictureBox();
            pictureBox.Dock = DockStyle.None;
            pictureBox.BackColor = System.Drawing.Color.Azure;
            pictureBox.Image = (System.Drawing.Image)(global::PokeRaid2.Properties.Resources.ResourceManager.GetObject("_" + dexNum.ToLower().Trim(), global::PokeRaid2.Properties.Resources.Culture));
            pictureBox.Location = new System.Drawing.Point(-1, -1);
            pictureBox.Size = new System.Drawing.Size(120, 120);
            pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            

            return pictureBox;
        }

        private PictureBox pTypePictureBoxFactory(string pType)
        {
            PictureBox pictureBox = new System.Windows.Forms.PictureBox();
            pictureBox.Dock = DockStyle.None;
            pictureBox.BackColor = System.Drawing.Color.SkyBlue;
            pictureBox.Image = (System.Drawing.Image)(global::PokeRaid2.Properties.Resources.ResourceManager.GetObject(pType.ToLower().Trim(), global::PokeRaid2.Properties.Resources.Culture));
            pictureBox.Location = new System.Drawing.Point(120, 16);
            pictureBox.Size = new System.Drawing.Size(120, 51);
            pictureBox.TabIndex = 1;
            pictureBox.TabStop = false;
            pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;

            return pictureBox;
        }

        private PictureBox sTypePictureBoxFactory(string sType)
        {
            PictureBox pictureBox = new System.Windows.Forms.PictureBox();
            pictureBox.Dock = DockStyle.None;
            if (sType == "N/A")
                sType = "na";

            pictureBox.BackColor = System.Drawing.Color.SkyBlue;
            pictureBox.Image = (System.Drawing.Image)(global::PokeRaid2.Properties.Resources.ResourceManager.GetObject(sType.ToLower().Trim(), global::PokeRaid2.Properties.Resources.Culture));
            pictureBox.Location = new System.Drawing.Point(120, 78);
            pictureBox.Size = new System.Drawing.Size(120, 31);
            pictureBox.TabIndex = 1;
            pictureBox.TabStop = false;
            pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;

            return pictureBox;
        }

        public struct Pokemon
        {
            public string pokeDexNum;

            public string name;

            public string hp;
            public string attack;
            public string defense;
            public string spAttack;
            public string spDefense;
            public string speed;

            public string primaryType;
            public string secondaryType;

            public Pokemon()
            {
                pokeDexNum = "N/A";

                name = "N/A";

                hp = "N/A";
                attack = "N/A";
                defense = "N/A";
                spAttack = "N/A";
                spDefense = "N/A";
                speed = "N/A";

                primaryType = "N/A";
                secondaryType = "N/A";
            }
            public void assignStats(string line)
            {
                string[] info = line.Split('\t');
                string[] baseStats;
                string[] types;

                pokeDexNum = info[0];

                name = info[1];

                if (info[1].Length < 8)
                {
                    baseStats = info[3].Split(" ");
                    types = info[4].Split(" / ");
                }
                else
                {
                    baseStats = info[2].Split(" ");
                    types = info[3].Split(" / ");
                }

                hp = baseStats[0];
                attack = baseStats[1];
                defense = baseStats[2];
                spAttack = baseStats[3];
                spDefense = baseStats[4];
                speed = baseStats[5];

                if (types.Length > 1)
                {
                    primaryType = types[0];
                    secondaryType = types[1];
                }
                else
                {
                    primaryType = types[0];
                    secondaryType = "N/A";
                }

                /*System.Diagnostics.Debug.WriteLine("PokeDex: " + pokeDexNum + "\n" 
                    + "Name: " + name + "\n" 
                    + "HP: " + hp + "\n"
                    + "Attack: " + attack + "\n"
                    + "Defense: " + defense + "\n"
                    + "Sp. Attack: " + spAttack + "\n" 
                    + "Sp. Defense: " + spDefense + "\n" 
                    + "Speed: " + speed + "\n" 
                    + "Primary Typing: " + primaryType + "\n" 
                    + "Secondary Typing: " + secondaryType 
                    + "\n--------------------\n");*/

            }
        }

        private SplitContainer splitContainer1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private VScrollBar vScrollBar1;
        private BindingSource bindingSource1;
        private FileSystemWatcher fileSystemWatcher1;

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "PokeRaid";
            this.Icon = global::PokeRaid2.Properties.Resources.pokeball;
        }

        #endregion
    }
}