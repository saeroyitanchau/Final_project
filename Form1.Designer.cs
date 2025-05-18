using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using _99sln;
    
namespace _99sln
{
    partial class Form1
    {
        
        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            label3.Text = "Độ dài đường đi ngắn nhất sẽ được hiển thị tại đây";
        }
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        // Biến lưu dữ liệu bản đồ
        private Dictionary<string, Dictionary<string, int>> graph;
        /// <summary>
        /// Clean up any resources being used.
        private Tuple<List<string>, Dictionary<string, int>> Dijkstra(string start, string end)
        {
            Dictionary<string, int> distances = new Dictionary<string, int>();
            Dictionary<string, string> previousNodes = new Dictionary<string, string>();
            HashSet<string> unvisited = new HashSet<string>(graph.Keys);


            foreach (var node in graph.Keys)
            {
                distances[node] = int.MaxValue;
                previousNodes[node] = null;
            }
            distances[start] = 0;

            while (unvisited.Count > 0)
            {
                string current = unvisited.OrderBy(n => distances[n]).FirstOrDefault();
                if (current == null || distances[current] == int.MaxValue) break;

                unvisited.Remove(current);

                foreach (var neighbor in graph[current])
                {
                    int tentativeDistance = distances[current] + neighbor.Value;
                    if (tentativeDistance < distances[neighbor.Key])
                    {
                        distances[neighbor.Key] = tentativeDistance;
                        previousNodes[neighbor.Key] = current;
                    }
                }
            }

            List<string> path = new List<string>();
            string currentNode = end;
            while (currentNode != null)
            {
                path.Insert(0, currentNode);
                currentNode = previousNodes[currentNode];
            }

            if (path.First() != start)
                path.Clear();

            return Tuple.Create(path, distances);
        }



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

        // Sự kiện Click cho nút Tìm đường
        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn điểm bắt đầu và kết thúc.");
                return;
            }

            string start = comboBox1.SelectedItem.ToString();
            string end = comboBox2.SelectedItem.ToString();

            Tuple<List<string>, Dictionary<string, int>> result = Dijkstra(start, end);
            List<string> path = result.Item1;
            Dictionary<string, int> distances = result.Item2;

            if (path.Count == 0)
            {
                label3.Text = "Không tìm thấy đường đi.";
            }
            else
            {
                label3.Text = "Đường đi: " + string.Join(" -> ", path) +
                              "\nTổng khoảng cách: " + distances[end] + " km";
            }

            label3.Font = new Font("Palatino Linotype", 11F, FontStyle.Bold);
            label3.ForeColor = Color.Black;
        }


        #region Windows Form Designer generated code

        private void InitializeGraph()
        {
            // Khởi tạo đồ thị với các địa điểm và khoảng cách giữa chúng
            graph = new Dictionary<string, Dictionary<string, int>>
    {
        { "Yên Phong", new Dictionary<string, int>
            {
                { "Từ Sơn", 10 },
                { "Thành phố Bắc Ninh", 12 }
            }
        },
        { "Từ Sơn", new Dictionary<string, int>
            {
                { "Yên Phong", 10 },
                { "Tiên Du", 8 }
            }
        },
        { "Thành phố Bắc Ninh", new Dictionary<string, int>
            {
                { "Yên Phong", 12 },
                { "Quế Võ", 15 },
                { "Tiên Du", 7 }
            }
        },
        { "Tiên Du", new Dictionary<string, int>
            {
                { "Từ Sơn", 8 },
                { "Thành phố Bắc Ninh", 7 },
                { "Thuận Thành", 10 }
            }
        },
        { "Quế Võ", new Dictionary<string, int>
            {
                { "Thành phố Bắc Ninh", 15 },
                { "Gia Bình", 18 }
            }
        },
        { "Thuận Thành", new Dictionary<string, int>
            {
                { "Tiên Du", 10 },
                { "Lương Tài", 14 }
            }
        },
        { "Gia Bình", new Dictionary<string, int>
            {
                { "Quế Võ", 18 },
                { "Lương Tài", 10 }
            }
        },
        { "Lương Tài", new Dictionary<string, int>
            {
                { "Thuận Thành", 14 },
                { "Gia Bình", 10 }
            }
        }
    };

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeGraph();
        }



        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(97, 422);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Điểm bắt đầu";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Yên Phong",
            "Từ Sơn",
            "Thành phố Bắc Ninh",
            "Tiên Du",
            "Quế Võ",
            "Thuận Thành",
            "Gia Bình",
            "Lương Tài"});
            this.comboBox1.Location = new System.Drawing.Point(303, 414);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(172, 28);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(97, 487);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Điểm kết thúc";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Yên Phong",
            "Từ Sơn",
            "Thành phố Bắc Ninh",
            "Tiên Du",
            "Quế Võ",
            "Thuận Thành",
            "Gia Bình",
            "Lương Tài"});
            this.comboBox2.Location = new System.Drawing.Point(303, 479);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(172, 28);
            this.comboBox2.TabIndex = 4;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(336, 553);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(124, 35);
            this.button2.TabIndex = 5;
            this.button2.Text = "Tìm đường";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);

            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(101, 553);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(130, 35);
            this.button3.TabIndex = 6;
            this.button3.Text = "Xóa";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);

            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(380, 160);
            this.label3.TabIndex = 7;
            this.label3.Text = "Độ dài đường đi ngắn nhất sẽ được hiển thị tại đây";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            

            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(77, 175);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(417, 191);
            this.panel2.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Cambria Math", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(627, 123);
            this.label4.TabIndex = 9;
            this.label4.Text = "Ứng dụng tìm đường ngắn nhất - Dijkstra";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(785, 739);
            this.panel1.TabIndex = 10;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Location = new System.Drawing.Point(792, 1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(689, 563);
            this.panel4.TabIndex = 12;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::_99sln.Properties.Resources.Screenshot_2025_03_23_121533;
            this.pictureBox1.Location = new System.Drawing.Point(0, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(683, 558);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(14, 17);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(8, 9);
            this.panel5.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(982, 578);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(203, 25);
            this.label5.TabIndex = 13;
            this.label5.Text = "Bản đồ tỉnh Bắc Ninh";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1485, 752);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label5;


    }

}

