namespace FillAlgorithm
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
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_polygon = new System.Windows.Forms.Button();
            this.btn_ellipse = new System.Windows.Forms.Button();
            this.panelTools = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fillColorButton = new System.Windows.Forms.Button();
            this.strokeColorButton = new System.Windows.Forms.Button();
            this.algorithmList = new System.Windows.Forms.ComboBox();
            this.drawPanel = new System.Windows.Forms.PictureBox();
            this.panelLayers = new System.Windows.Forms.Panel();
            this.listLayers = new System.Windows.Forms.ListBox();
            this.runTestButton = new System.Windows.Forms.Button();
            this.panelTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawPanel)).BeginInit();
            this.panelLayers.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_clear
            // 
            this.btn_clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clear.Location = new System.Drawing.Point(0, 0);
            this.btn_clear.Margin = new System.Windows.Forms.Padding(0);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(114, 77);
            this.btn_clear.TabIndex = 0;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_polygon
            // 
            this.btn_polygon.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_polygon.Location = new System.Drawing.Point(114, 0);
            this.btn_polygon.Margin = new System.Windows.Forms.Padding(0);
            this.btn_polygon.Name = "btn_polygon";
            this.btn_polygon.Size = new System.Drawing.Size(114, 77);
            this.btn_polygon.TabIndex = 1;
            this.btn_polygon.Text = "Polygon";
            this.btn_polygon.UseVisualStyleBackColor = true;
            this.btn_polygon.Click += new System.EventHandler(this.btn_polygon_Click);
            // 
            // btn_ellipse
            // 
            this.btn_ellipse.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ellipse.Location = new System.Drawing.Point(228, 0);
            this.btn_ellipse.Margin = new System.Windows.Forms.Padding(0);
            this.btn_ellipse.Name = "btn_ellipse";
            this.btn_ellipse.Size = new System.Drawing.Size(114, 77);
            this.btn_ellipse.TabIndex = 2;
            this.btn_ellipse.Text = "Ellipse";
            this.btn_ellipse.UseVisualStyleBackColor = true;
            this.btn_ellipse.Click += new System.EventHandler(this.btn_ellipse_Click);
            // 
            // panelTools
            // 
            this.panelTools.Controls.Add(this.label2);
            this.panelTools.Controls.Add(this.label1);
            this.panelTools.Controls.Add(this.fillColorButton);
            this.panelTools.Controls.Add(this.strokeColorButton);
            this.panelTools.Controls.Add(this.algorithmList);
            this.panelTools.Controls.Add(this.btn_clear);
            this.panelTools.Controls.Add(this.btn_ellipse);
            this.panelTools.Controls.Add(this.btn_polygon);
            this.panelTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTools.Location = new System.Drawing.Point(0, 0);
            this.panelTools.Name = "panelTools";
            this.panelTools.Size = new System.Drawing.Size(800, 77);
            this.panelTools.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(394, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Stroke";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(460, 53);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Fill";
            // 
            // fillColorButton
            // 
            this.fillColorButton.Location = new System.Drawing.Point(454, 10);
            this.fillColorButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.fillColorButton.Name = "fillColorButton";
            this.fillColorButton.Size = new System.Drawing.Size(38, 41);
            this.fillColorButton.TabIndex = 4;
            this.fillColorButton.UseVisualStyleBackColor = true;
            this.fillColorButton.Click += new System.EventHandler(this.fillColorButton_Click);
            // 
            // strokeColorButton
            // 
            this.strokeColorButton.Location = new System.Drawing.Point(398, 10);
            this.strokeColorButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.strokeColorButton.Name = "strokeColorButton";
            this.strokeColorButton.Size = new System.Drawing.Size(38, 41);
            this.strokeColorButton.TabIndex = 4;
            this.strokeColorButton.UseVisualStyleBackColor = true;
            this.strokeColorButton.Click += new System.EventHandler(this.strokeColorButton_Click);
            // 
            // algorithmList
            // 
            this.algorithmList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.algorithmList.FormattingEnabled = true;
            this.algorithmList.Location = new System.Drawing.Point(577, 19);
            this.algorithmList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.algorithmList.Name = "algorithmList";
            this.algorithmList.Size = new System.Drawing.Size(216, 28);
            this.algorithmList.TabIndex = 3;
            this.algorithmList.SelectedIndexChanged += new System.EventHandler(this.algorithmList_SelectedIndexChanged);
            // 
            // drawPanel
            // 
            this.drawPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.drawPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawPanel.Location = new System.Drawing.Point(0, 77);
            this.drawPanel.Name = "drawPanel";
            this.drawPanel.Size = new System.Drawing.Size(622, 373);
            this.drawPanel.TabIndex = 4;
            this.drawPanel.TabStop = false;
            this.drawPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawPanel_MouseDown);
            this.drawPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawPanel_MouseMove);
            this.drawPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawPanel_MouseUp);
            // 
            // panelLayers
            // 
            this.panelLayers.Controls.Add(this.runTestButton);
            this.panelLayers.Controls.Add(this.listLayers);
            this.panelLayers.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelLayers.Location = new System.Drawing.Point(622, 77);
            this.panelLayers.Name = "panelLayers";
            this.panelLayers.Size = new System.Drawing.Size(178, 373);
            this.panelLayers.TabIndex = 5;
            // 
            // listLayers
            // 
            this.listLayers.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listLayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listLayers.FormattingEnabled = true;
            this.listLayers.ItemHeight = 20;
            this.listLayers.Location = new System.Drawing.Point(0, 49);
            this.listLayers.Name = "listLayers";
            this.listLayers.Size = new System.Drawing.Size(178, 324);
            this.listLayers.TabIndex = 0;
            this.listLayers.SelectedIndexChanged += new System.EventHandler(this.listLayers_SelectedIndexChanged);
            // 
            // runTestButton
            // 
            this.runTestButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.runTestButton.Location = new System.Drawing.Point(0, 0);
            this.runTestButton.Margin = new System.Windows.Forms.Padding(0);
            this.runTestButton.Name = "runTestButton";
            this.runTestButton.Size = new System.Drawing.Size(178, 49);
            this.runTestButton.TabIndex = 6;
            this.runTestButton.Text = "Run Tests";
            this.runTestButton.UseVisualStyleBackColor = true;
            this.runTestButton.Click += new System.EventHandler(this.runTestButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.drawPanel);
            this.Controls.Add(this.panelLayers);
            this.Controls.Add(this.panelTools);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Fill Algorithm Visualizer";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.panelTools.ResumeLayout(false);
            this.panelTools.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawPanel)).EndInit();
            this.panelLayers.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_polygon;
        private System.Windows.Forms.Button btn_ellipse;
        private System.Windows.Forms.Panel panelTools;
        private System.Windows.Forms.PictureBox drawPanel;
        private System.Windows.Forms.Panel panelLayers;
        private System.Windows.Forms.ListBox listLayers;
        private System.Windows.Forms.ComboBox algorithmList;
        private System.Windows.Forms.Button fillColorButton;
        private System.Windows.Forms.Button strokeColorButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button runTestButton;
    }
}

