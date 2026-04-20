namespace Group_Project
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tableLayoutPanel_MainWindow = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel_Grid = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel_Sidebar = new System.Windows.Forms.TableLayoutPanel();
            this.labelSectionTitle = new System.Windows.Forms.Label();
            this.labelSectionValue = new System.Windows.Forms.Label();
            this.labelPlayerStats = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelAllyOne = new System.Windows.Forms.Label();
            this.labelAllyTwo = new System.Windows.Forms.Label();
            this.tableLayoutPanel_MainWindow.SuspendLayout();
            this.tableLayoutPanel_Sidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_MainWindow
            // 
            this.tableLayoutPanel_MainWindow.ColumnCount = 2;
            this.tableLayoutPanel_MainWindow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel_MainWindow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel_MainWindow.Controls.Add(this.tableLayoutPanel_Grid, 0, 0);
            this.tableLayoutPanel_MainWindow.Controls.Add(this.tableLayoutPanel_Sidebar, 1, 0);
            this.tableLayoutPanel_MainWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_MainWindow.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_MainWindow.Name = "tableLayoutPanel_MainWindow";
            this.tableLayoutPanel_MainWindow.RowCount = 1;
            this.tableLayoutPanel_MainWindow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_MainWindow.Size = new System.Drawing.Size(850, 487);
            this.tableLayoutPanel_MainWindow.TabIndex = 0;
            // 
            // tableLayoutPanel_Grid
            // 
            this.tableLayoutPanel_Grid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tableLayoutPanel_Grid.ColumnCount = 7;
            this.tableLayoutPanel_Grid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel_Grid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel_Grid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel_Grid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel_Grid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel_Grid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel_Grid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Grid.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel_Grid.Name = "tableLayoutPanel_Grid";
            this.tableLayoutPanel_Grid.RowCount = 7;
            this.tableLayoutPanel_Grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel_Grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel_Grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel_Grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel_Grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel_Grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel_Grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel_Grid.Size = new System.Drawing.Size(631, 481);
            this.tableLayoutPanel_Grid.TabIndex = 0;
            // 
            // tableLayoutPanel_Sidebar
            // 
            this.tableLayoutPanel_Sidebar.BackColor = System.Drawing.Color.SlateGray;
            this.tableLayoutPanel_Sidebar.ColumnCount = 1;
            this.tableLayoutPanel_Sidebar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Sidebar.Controls.Add(this.labelSectionTitle, 0, 0);
            this.tableLayoutPanel_Sidebar.Controls.Add(this.labelSectionValue, 0, 1);
            this.tableLayoutPanel_Sidebar.Controls.Add(this.labelPlayerStats, 0, 2);
            this.tableLayoutPanel_Sidebar.Controls.Add(this.labelStatus, 0, 3);
            this.tableLayoutPanel_Sidebar.Controls.Add(this.labelAllyOne, 0, 4);
            this.tableLayoutPanel_Sidebar.Controls.Add(this.labelAllyTwo, 0, 5);
            this.tableLayoutPanel_Sidebar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Sidebar.Location = new System.Drawing.Point(640, 3);
            this.tableLayoutPanel_Sidebar.Name = "tableLayoutPanel_Sidebar";
            this.tableLayoutPanel_Sidebar.RowCount = 8;
            this.tableLayoutPanel_Sidebar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_Sidebar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_Sidebar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel_Sidebar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel_Sidebar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_Sidebar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_Sidebar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Sidebar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_Sidebar.Size = new System.Drawing.Size(207, 481);
            this.tableLayoutPanel_Sidebar.TabIndex = 1;
            // 
            // labelSectionTitle
            // 
            this.labelSectionTitle.AutoSize = true;
            this.labelSectionTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSectionTitle.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSectionTitle.Location = new System.Drawing.Point(3, 0);
            this.labelSectionTitle.Name = "labelSectionTitle";
            this.labelSectionTitle.Size = new System.Drawing.Size(201, 30);
            this.labelSectionTitle.TabIndex = 0;
            this.labelSectionTitle.Text = "Section";
            // 
            // labelSectionValue
            // 
            this.labelSectionValue.AutoSize = true;
            this.labelSectionValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSectionValue.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSectionValue.Location = new System.Drawing.Point(3, 30);
            this.labelSectionValue.Name = "labelSectionValue";
            this.labelSectionValue.Size = new System.Drawing.Size(201, 30);
            this.labelSectionValue.TabIndex = 1;
            this.labelSectionValue.Text = "Map 1 - Section 1";
            // 
            // labelPlayerStats
            // 
            this.labelPlayerStats.AutoSize = true;
            this.labelPlayerStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPlayerStats.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayerStats.ForeColor = System.Drawing.Color.Maroon;
            this.labelPlayerStats.Location = new System.Drawing.Point(3, 60);
            this.labelPlayerStats.Name = "labelPlayerStats";
            this.labelPlayerStats.Size = new System.Drawing.Size(201, 50);
            this.labelPlayerStats.TabIndex = 2;
            this.labelPlayerStats.Text = "HP: 100/100 | DMG: 15 | LVL: 1";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelStatus.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.ForeColor = System.Drawing.Color.LimeGreen;
            this.labelStatus.Location = new System.Drawing.Point(3, 110);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(201, 50);
            this.labelStatus.TabIndex = 3;
            this.labelStatus.Text = "Ready";
            // 
            // labelAllyOne
            // 
            this.labelAllyOne.AutoSize = true;
            this.labelAllyOne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelAllyOne.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAllyOne.Location = new System.Drawing.Point(3, 160);
            this.labelAllyOne.Name = "labelAllyOne";
            this.labelAllyOne.Size = new System.Drawing.Size(201, 30);
            this.labelAllyOne.TabIndex = 4;
            this.labelAllyOne.Text = "Ally 1: None";
            // 
            // labelAllyTwo
            // 
            this.labelAllyTwo.AutoSize = true;
            this.labelAllyTwo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelAllyTwo.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAllyTwo.Location = new System.Drawing.Point(3, 190);
            this.labelAllyTwo.Name = "labelAllyTwo";
            this.labelAllyTwo.Size = new System.Drawing.Size(201, 30);
            this.labelAllyTwo.TabIndex = 5;
            this.labelAllyTwo.Text = "Ally 2: None";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(850, 487);
            this.Controls.Add(this.tableLayoutPanel_MainWindow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "COSC2200 - Reggie Brown";
            this.tableLayoutPanel_MainWindow.ResumeLayout(false);
            this.tableLayoutPanel_Sidebar.ResumeLayout(false);
            this.tableLayoutPanel_Sidebar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_MainWindow;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Grid;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Sidebar;
        private System.Windows.Forms.Label labelSectionTitle;
        private System.Windows.Forms.Label labelSectionValue;
        private System.Windows.Forms.Label labelPlayerStats;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelAllyOne;
        private System.Windows.Forms.Label labelAllyTwo;
    }
}

