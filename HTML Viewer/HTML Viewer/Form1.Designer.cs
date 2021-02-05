namespace HTML_Viewer
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.open = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.download = new System.Windows.Forms.Button();
            this.urlBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.edit = new System.Windows.Forms.Button();
            this.editBox = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.TreeViewer = new System.Windows.Forms.TreeView();
            this.treeIcons = new System.Windows.Forms.ImageList(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.open);
            this.flowLayoutPanel2.Controls.Add(this.save);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(100, 50);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // open
            // 
            this.open.Image = global::HTML_Viewer.Properties.Resources.folderOpen;
            this.open.Location = new System.Drawing.Point(7, 7);
            this.open.Margin = new System.Windows.Forms.Padding(7);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(36, 36);
            this.open.TabIndex = 2;
            this.toolTip.SetToolTip(this.open, "Otevřít Soubor");
            this.open.UseVisualStyleBackColor = true;
            this.open.Click += new System.EventHandler(this.openFile);
            // 
            // save
            // 
            this.save.Image = global::HTML_Viewer.Properties.Resources.save;
            this.save.Location = new System.Drawing.Point(57, 7);
            this.save.Margin = new System.Windows.Forms.Padding(7);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(36, 36);
            this.save.TabIndex = 3;
            this.toolTip.SetToolTip(this.save, "Uložit Soubor");
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.saveFile);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel3.AutoSize = true;
            this.flowLayoutPanel3.Controls.Add(this.download);
            this.flowLayoutPanel3.Controls.Add(this.urlBox);
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(167, 0);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(264, 50);
            this.flowLayoutPanel3.TabIndex = 1;
            // 
            // download
            // 
            this.download.Image = global::HTML_Viewer.Properties.Resources.download;
            this.download.Location = new System.Drawing.Point(221, 7);
            this.download.Margin = new System.Windows.Forms.Padding(7);
            this.download.Name = "download";
            this.download.Size = new System.Drawing.Size(36, 36);
            this.download.TabIndex = 0;
            this.toolTip.SetToolTip(this.download, "Stáhnout Zdroj Stránky");
            this.download.UseVisualStyleBackColor = true;
            this.download.Click += new System.EventHandler(this.downloadFile);
            // 
            // urlBox
            // 
            this.urlBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.urlBox.Location = new System.Drawing.Point(7, 7);
            this.urlBox.Margin = new System.Windows.Forms.Padding(7);
            this.urlBox.Multiline = true;
            this.urlBox.Name = "urlBox";
            this.urlBox.Size = new System.Drawing.Size(200, 36);
            this.urlBox.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.Controls.Add(this.edit, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.editBox, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 461);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(430, 50);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // edit
            // 
            this.edit.Image = global::HTML_Viewer.Properties.Resources.edit;
            this.edit.Location = new System.Drawing.Point(387, 7);
            this.edit.Margin = new System.Windows.Forms.Padding(7);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(36, 36);
            this.edit.TabIndex = 3;
            this.toolTip.SetToolTip(this.edit, "Upravit Hodnotu");
            this.edit.UseVisualStyleBackColor = true;
            this.edit.Click += new System.EventHandler(this.editValue);
            // 
            // editBox
            // 
            this.editBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editBox.Location = new System.Drawing.Point(7, 7);
            this.editBox.Margin = new System.Windows.Forms.Padding(7);
            this.editBox.Multiline = true;
            this.editBox.Name = "editBox";
            this.editBox.Size = new System.Drawing.Size(366, 36);
            this.editBox.TabIndex = 4;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 50);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(424, 408);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.TreeViewer);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(416, 382);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Prohlížeč stromu";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // TreeViewer
            // 
            this.TreeViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeViewer.HideSelection = false;
            this.TreeViewer.HotTracking = true;
            this.TreeViewer.ImageIndex = 0;
            this.TreeViewer.ImageList = this.treeIcons;
            this.TreeViewer.Location = new System.Drawing.Point(3, 3);
            this.TreeViewer.Name = "TreeViewer";
            this.TreeViewer.SelectedImageIndex = 0;
            this.TreeViewer.Size = new System.Drawing.Size(410, 376);
            this.TreeViewer.TabIndex = 0;
            this.TreeViewer.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.updateTextBox);
            // 
            // treeIcons
            // 
            this.treeIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeIcons.ImageStream")));
            this.treeIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.treeIcons.Images.SetKeyName(0, "element.png");
            this.treeIcons.Images.SetKeyName(1, "attribute.png");
            this.treeIcons.Images.SetKeyName(2, "value.png");
            this.treeIcons.Images.SetKeyName(3, "text.png");
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(416, 382);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Prohlížeč pravidel";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(861, 511);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel3, 2);
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.flowLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.flowLayoutPanel5, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(861, 50);
            this.tableLayoutPanel3.TabIndex = 6;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(430, 50);
            this.flowLayoutPanel4.TabIndex = 0;
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Controls.Add(this.flowLayoutPanel3);
            this.flowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel5.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel5.Location = new System.Drawing.Point(430, 0);
            this.flowLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(431, 50);
            this.flowLayoutPanel5.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 511);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "Form1";
            this.Text = "HTML Viewer";
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button open;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button download;
        private System.Windows.Forms.TextBox urlBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.TextBox editBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TreeView TreeViewer;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.ImageList treeIcons;
        private System.Windows.Forms.ToolTip toolTip;
    }
}

