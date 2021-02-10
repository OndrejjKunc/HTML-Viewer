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
            this.newButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.viewButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.download = new System.Windows.Forms.Button();
            this.urlBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.editButton = new System.Windows.Forms.Button();
            this.editBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TreeViewer = new System.Windows.Forms.TreeView();
            this.treeIcons = new System.Windows.Forms.ImageList(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.upButton = new System.Windows.Forms.Button();
            this.downButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.addElementButton = new System.Windows.Forms.Button();
            this.addAttributeButton = new System.Windows.Forms.Button();
            this.addTextButton = new System.Windows.Forms.Button();
            this.addCommentButton = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.newButton);
            this.flowLayoutPanel2.Controls.Add(this.openButton);
            this.flowLayoutPanel2.Controls.Add(this.saveButton);
            this.flowLayoutPanel2.Controls.Add(this.viewButton);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(200, 50);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // newButton
            // 
            this.newButton.Image = global::HTML_Viewer.Properties.Resources._new;
            this.newButton.Location = new System.Drawing.Point(7, 7);
            this.newButton.Margin = new System.Windows.Forms.Padding(7);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(36, 36);
            this.newButton.TabIndex = 1;
            this.newButton.TabStop = false;
            this.toolTip.SetToolTip(this.newButton, "Nový Soubor");
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.NewFile);
            // 
            // openButton
            // 
            this.openButton.Image = global::HTML_Viewer.Properties.Resources.folderOpen;
            this.openButton.Location = new System.Drawing.Point(57, 7);
            this.openButton.Margin = new System.Windows.Forms.Padding(7);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(36, 36);
            this.openButton.TabIndex = 2;
            this.openButton.TabStop = false;
            this.toolTip.SetToolTip(this.openButton, "Otevřít Soubor");
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.OpenFile);
            // 
            // saveButton
            // 
            this.saveButton.Image = global::HTML_Viewer.Properties.Resources.save;
            this.saveButton.Location = new System.Drawing.Point(107, 7);
            this.saveButton.Margin = new System.Windows.Forms.Padding(7);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(36, 36);
            this.saveButton.TabIndex = 3;
            this.saveButton.TabStop = false;
            this.toolTip.SetToolTip(this.saveButton, "Uložit Soubor");
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveFile);
            // 
            // viewButton
            // 
            this.viewButton.Image = global::HTML_Viewer.Properties.Resources.view;
            this.viewButton.Location = new System.Drawing.Point(157, 7);
            this.viewButton.Margin = new System.Windows.Forms.Padding(7);
            this.viewButton.Name = "viewButton";
            this.viewButton.Size = new System.Drawing.Size(36, 36);
            this.viewButton.TabIndex = 4;
            this.viewButton.TabStop = false;
            this.toolTip.SetToolTip(this.viewButton, "Otevřít Náhled");
            this.viewButton.UseVisualStyleBackColor = true;
            this.viewButton.Click += new System.EventHandler(this.ShowPreview);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.download);
            this.flowLayoutPanel3.Controls.Add(this.urlBox);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(200, 0);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(584, 50);
            this.flowLayoutPanel3.TabIndex = 1;
            // 
            // download
            // 
            this.download.Image = global::HTML_Viewer.Properties.Resources.download;
            this.download.Location = new System.Drawing.Point(541, 7);
            this.download.Margin = new System.Windows.Forms.Padding(7);
            this.download.Name = "download";
            this.download.Size = new System.Drawing.Size(36, 36);
            this.download.TabIndex = 12;
            this.download.TabStop = false;
            this.toolTip.SetToolTip(this.download, "Stáhnout Zdroj Stránky");
            this.download.UseVisualStyleBackColor = true;
            this.download.Click += new System.EventHandler(this.DownloadFile);
            // 
            // urlBox
            // 
            this.urlBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.urlBox.Location = new System.Drawing.Point(227, 7);
            this.urlBox.Margin = new System.Windows.Forms.Padding(7);
            this.urlBox.Name = "urlBox";
            this.urlBox.Size = new System.Drawing.Size(300, 20);
            this.urlBox.TabIndex = 11;
            this.urlBox.TabStop = false;
            this.toolTip.SetToolTip(this.urlBox, "Adresa Stránky");
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel2.Controls.Add(this.editButton, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.editBox, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(50, 465);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(208, 42);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // editButton
            // 
            this.editButton.Image = global::HTML_Viewer.Properties.Resources.edit;
            this.editButton.Location = new System.Drawing.Point(169, 3);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(36, 36);
            this.editButton.TabIndex = 33;
            this.editButton.TabStop = false;
            this.toolTip.SetToolTip(this.editButton, "Upravit Hodnotu");
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.EditValue);
            // 
            // editBox
            // 
            this.editBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editBox.Location = new System.Drawing.Point(3, 3);
            this.editBox.Name = "editBox";
            this.editBox.Size = new System.Drawing.Size(160, 20);
            this.editBox.TabIndex = 32;
            this.editBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditEnter);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.TreeViewer, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 50);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0, 0, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(780, 507);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // TreeViewer
            // 
            this.TreeViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeViewer.HideSelection = false;
            this.TreeViewer.HotTracking = true;
            this.TreeViewer.ImageIndex = 0;
            this.TreeViewer.ImageList = this.treeIcons;
            this.TreeViewer.Location = new System.Drawing.Point(53, 3);
            this.TreeViewer.Name = "TreeViewer";
            this.TreeViewer.SelectedImageIndex = 0;
            this.TreeViewer.Size = new System.Drawing.Size(724, 459);
            this.TreeViewer.TabIndex = 31;
            this.TreeViewer.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.UpdateSelect);
            // 
            // treeIcons
            // 
            this.treeIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeIcons.ImageStream")));
            this.treeIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.treeIcons.Images.SetKeyName(0, "element.png");
            this.treeIcons.Images.SetKeyName(1, "attribute.png");
            this.treeIcons.Images.SetKeyName(2, "value.png");
            this.treeIcons.Images.SetKeyName(3, "text.png");
            this.treeIcons.Images.SetKeyName(4, "comment.png");
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.upButton);
            this.flowLayoutPanel1.Controls.Add(this.downButton);
            this.flowLayoutPanel1.Controls.Add(this.deleteButton);
            this.flowLayoutPanel1.Controls.Add(this.addElementButton);
            this.flowLayoutPanel1.Controls.Add(this.addAttributeButton);
            this.flowLayoutPanel1.Controls.Add(this.addTextButton);
            this.flowLayoutPanel1.Controls.Add(this.addCommentButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.tableLayoutPanel1.SetRowSpan(this.flowLayoutPanel1, 2);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(50, 507);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // upButton
            // 
            this.upButton.Enabled = false;
            this.upButton.Image = global::HTML_Viewer.Properties.Resources.up;
            this.upButton.Location = new System.Drawing.Point(7, 3);
            this.upButton.Margin = new System.Windows.Forms.Padding(7, 3, 7, 3);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(36, 36);
            this.upButton.TabIndex = 21;
            this.upButton.TabStop = false;
            this.toolTip.SetToolTip(this.upButton, "Posunout Nahoru");
            this.upButton.UseVisualStyleBackColor = true;
            this.upButton.Click += new System.EventHandler(this.MoveUp);
            // 
            // downButton
            // 
            this.downButton.Enabled = false;
            this.downButton.Image = global::HTML_Viewer.Properties.Resources.down;
            this.downButton.Location = new System.Drawing.Point(7, 45);
            this.downButton.Margin = new System.Windows.Forms.Padding(7, 3, 7, 3);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(36, 36);
            this.downButton.TabIndex = 22;
            this.downButton.TabStop = false;
            this.toolTip.SetToolTip(this.downButton, "Posunout Dolu");
            this.downButton.UseVisualStyleBackColor = true;
            this.downButton.Click += new System.EventHandler(this.MoveDown);
            // 
            // deleteButton
            // 
            this.deleteButton.Enabled = false;
            this.deleteButton.Image = global::HTML_Viewer.Properties.Resources.delete;
            this.deleteButton.Location = new System.Drawing.Point(7, 87);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(7, 3, 7, 7);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(36, 36);
            this.deleteButton.TabIndex = 23;
            this.deleteButton.TabStop = false;
            this.toolTip.SetToolTip(this.deleteButton, "Smazat");
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteNode);
            // 
            // addElementButton
            // 
            this.addElementButton.Image = global::HTML_Viewer.Properties.Resources.addElement;
            this.addElementButton.Location = new System.Drawing.Point(7, 137);
            this.addElementButton.Margin = new System.Windows.Forms.Padding(7, 7, 7, 3);
            this.addElementButton.Name = "addElementButton";
            this.addElementButton.Size = new System.Drawing.Size(36, 36);
            this.addElementButton.TabIndex = 24;
            this.addElementButton.TabStop = false;
            this.toolTip.SetToolTip(this.addElementButton, "Přidat Element");
            this.addElementButton.UseVisualStyleBackColor = true;
            this.addElementButton.Click += new System.EventHandler(this.AddElement);
            // 
            // addAttributeButton
            // 
            this.addAttributeButton.Image = global::HTML_Viewer.Properties.Resources.addAttribute;
            this.addAttributeButton.Location = new System.Drawing.Point(7, 179);
            this.addAttributeButton.Margin = new System.Windows.Forms.Padding(7, 3, 7, 3);
            this.addAttributeButton.Name = "addAttributeButton";
            this.addAttributeButton.Size = new System.Drawing.Size(36, 36);
            this.addAttributeButton.TabIndex = 25;
            this.addAttributeButton.TabStop = false;
            this.toolTip.SetToolTip(this.addAttributeButton, "Přidat Atribut");
            this.addAttributeButton.UseVisualStyleBackColor = true;
            this.addAttributeButton.Click += new System.EventHandler(this.AddAttribute);
            // 
            // addTextButton
            // 
            this.addTextButton.Image = global::HTML_Viewer.Properties.Resources.addText;
            this.addTextButton.Location = new System.Drawing.Point(7, 221);
            this.addTextButton.Margin = new System.Windows.Forms.Padding(7, 3, 7, 3);
            this.addTextButton.Name = "addTextButton";
            this.addTextButton.Size = new System.Drawing.Size(36, 36);
            this.addTextButton.TabIndex = 26;
            this.addTextButton.TabStop = false;
            this.toolTip.SetToolTip(this.addTextButton, "Přidat Text");
            this.addTextButton.UseVisualStyleBackColor = true;
            this.addTextButton.Click += new System.EventHandler(this.AddText);
            // 
            // addCommentButton
            // 
            this.addCommentButton.Image = global::HTML_Viewer.Properties.Resources.addComment;
            this.addCommentButton.Location = new System.Drawing.Point(7, 263);
            this.addCommentButton.Margin = new System.Windows.Forms.Padding(7, 3, 7, 3);
            this.addCommentButton.Name = "addCommentButton";
            this.addCommentButton.Size = new System.Drawing.Size(36, 36);
            this.addCommentButton.TabIndex = 27;
            this.addCommentButton.TabStop = false;
            this.toolTip.SetToolTip(this.addCommentButton, "Přidat Komentář");
            this.addCommentButton.UseVisualStyleBackColor = true;
            this.addCommentButton.Click += new System.EventHandler(this.AddComment);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(784, 561);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.flowLayoutPanel2, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.flowLayoutPanel3, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(784, 50);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "Form1";
            this.Text = "HTML Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DeleteTempFile);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button download;
        private System.Windows.Forms.TextBox urlBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.TextBox editBox;
        private System.Windows.Forms.TreeView TreeViewer;
        private System.Windows.Forms.ImageList treeIcons;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button addElementButton;
        private System.Windows.Forms.Button addAttributeButton;
        private System.Windows.Forms.Button addTextButton;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Button addCommentButton;
        private System.Windows.Forms.Button viewButton;
    }
}

