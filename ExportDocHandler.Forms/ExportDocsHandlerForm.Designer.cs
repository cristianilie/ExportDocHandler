namespace ExportDocHandles
{
    partial class ExportDocsHandlerForm
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
            this.GetDirectoryPathButton = new System.Windows.Forms.Button();
            this.SearchDirectoryLabel = new System.Windows.Forms.Label();
            this.SalesInvoiceLabel = new System.Windows.Forms.Label();
            this.PurchaseReportLabel = new System.Windows.Forms.Label();
            this.LoadSalesInvoiceButton = new System.Windows.Forms.Button();
            this.LoadPurchaseReportButton = new System.Windows.Forms.Button();
            this.AppTitleLabel = new System.Windows.Forms.Label();
            this.InvoiceContentDataGridView = new System.Windows.Forms.DataGridView();
            this.InvoiceContentLabel = new System.Windows.Forms.Label();
            this.PurchaseReportTabel = new System.Windows.Forms.Label();
            this.PurchaseReportDataGridView = new System.Windows.Forms.DataGridView();
            this.FolderToMoveFilesPathTextBox = new System.Windows.Forms.TextBox();
            this.MoveFilesToLabel = new System.Windows.Forms.Label();
            this.GetPathToMoveFilesButton = new System.Windows.Forms.Button();
            this.FileLoadersGroupBox = new System.Windows.Forms.GroupBox();
            this.GetPurchaseInvoicesButton = new System.Windows.Forms.Button();
            this.FilterReportButton = new System.Windows.Forms.Button();
            this.FilesMovingGroupBox = new System.Windows.Forms.GroupBox();
            this.DisplayMissingDocsButton = new System.Windows.Forms.Button();
            this.MovePurchasingInvoicesButton = new System.Windows.Forms.Button();
            this.CreateExportDocsButton = new System.Windows.Forms.Button();
            this.CreateDocumentsGroupBox = new System.Windows.Forms.GroupBox();
            this.CloseFormButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceContentDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseReportDataGridView)).BeginInit();
            this.FileLoadersGroupBox.SuspendLayout();
            this.FilesMovingGroupBox.SuspendLayout();
            this.CreateDocumentsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // GetDirectoryPathButton
            // 
            this.GetDirectoryPathButton.BackColor = System.Drawing.Color.DarkSlateGray;
            this.GetDirectoryPathButton.FlatAppearance.BorderColor = System.Drawing.Color.Aqua;
            this.GetDirectoryPathButton.FlatAppearance.BorderSize = 0;
            this.GetDirectoryPathButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RosyBrown;
            this.GetDirectoryPathButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkCyan;
            this.GetDirectoryPathButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GetDirectoryPathButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.GetDirectoryPathButton.Location = new System.Drawing.Point(134, 26);
            this.GetDirectoryPathButton.Name = "GetDirectoryPathButton";
            this.GetDirectoryPathButton.Size = new System.Drawing.Size(75, 23);
            this.GetDirectoryPathButton.TabIndex = 0;
            this.GetDirectoryPathButton.Text = "Get Path";
            this.GetDirectoryPathButton.UseVisualStyleBackColor = false;
            this.GetDirectoryPathButton.Click += new System.EventHandler(this.GetDirectoryPathButton_Click);
            // 
            // SearchDirectoryLabel
            // 
            this.SearchDirectoryLabel.AutoSize = true;
            this.SearchDirectoryLabel.Location = new System.Drawing.Point(18, 26);
            this.SearchDirectoryLabel.Name = "SearchDirectoryLabel";
            this.SearchDirectoryLabel.Size = new System.Drawing.Size(112, 19);
            this.SearchDirectoryLabel.TabIndex = 1;
            this.SearchDirectoryLabel.Text = "Search Directory";
            // 
            // SalesInvoiceLabel
            // 
            this.SalesInvoiceLabel.AutoSize = true;
            this.SalesInvoiceLabel.Location = new System.Drawing.Point(18, 53);
            this.SalesInvoiceLabel.Name = "SalesInvoiceLabel";
            this.SalesInvoiceLabel.Size = new System.Drawing.Size(88, 19);
            this.SalesInvoiceLabel.TabIndex = 3;
            this.SalesInvoiceLabel.Text = "Sales Invoice";
            // 
            // PurchaseReportLabel
            // 
            this.PurchaseReportLabel.AutoSize = true;
            this.PurchaseReportLabel.Location = new System.Drawing.Point(18, 81);
            this.PurchaseReportLabel.Name = "PurchaseReportLabel";
            this.PurchaseReportLabel.Size = new System.Drawing.Size(110, 19);
            this.PurchaseReportLabel.TabIndex = 5;
            this.PurchaseReportLabel.Text = "Purchase Report";
            // 
            // LoadSalesInvoiceButton
            // 
            this.LoadSalesInvoiceButton.BackColor = System.Drawing.Color.DarkSlateGray;
            this.LoadSalesInvoiceButton.FlatAppearance.BorderSize = 0;
            this.LoadSalesInvoiceButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RosyBrown;
            this.LoadSalesInvoiceButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkCyan;
            this.LoadSalesInvoiceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadSalesInvoiceButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.LoadSalesInvoiceButton.Location = new System.Drawing.Point(134, 53);
            this.LoadSalesInvoiceButton.Name = "LoadSalesInvoiceButton";
            this.LoadSalesInvoiceButton.Size = new System.Drawing.Size(75, 23);
            this.LoadSalesInvoiceButton.TabIndex = 7;
            this.LoadSalesInvoiceButton.Text = "Load File";
            this.LoadSalesInvoiceButton.UseVisualStyleBackColor = false;
            this.LoadSalesInvoiceButton.Click += new System.EventHandler(this.LoadSalesInvoiceButton_Click);
            // 
            // LoadPurchaseReportButton
            // 
            this.LoadPurchaseReportButton.BackColor = System.Drawing.Color.DarkSlateGray;
            this.LoadPurchaseReportButton.FlatAppearance.BorderSize = 0;
            this.LoadPurchaseReportButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RosyBrown;
            this.LoadPurchaseReportButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkCyan;
            this.LoadPurchaseReportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadPurchaseReportButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.LoadPurchaseReportButton.Location = new System.Drawing.Point(134, 81);
            this.LoadPurchaseReportButton.Name = "LoadPurchaseReportButton";
            this.LoadPurchaseReportButton.Size = new System.Drawing.Size(75, 23);
            this.LoadPurchaseReportButton.TabIndex = 8;
            this.LoadPurchaseReportButton.Text = "Load File";
            this.LoadPurchaseReportButton.UseVisualStyleBackColor = false;
            this.LoadPurchaseReportButton.Click += new System.EventHandler(this.LoadPurchaseReportButton_Click);
            // 
            // AppTitleLabel
            // 
            this.AppTitleLabel.AutoSize = true;
            this.AppTitleLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppTitleLabel.Location = new System.Drawing.Point(10, 9);
            this.AppTitleLabel.Name = "AppTitleLabel";
            this.AppTitleLabel.Size = new System.Drawing.Size(206, 20);
            this.AppTitleLabel.TabIndex = 9;
            this.AppTitleLabel.Text = "Export Documents Handler";
            // 
            // InvoiceContentDataGridView
            // 
            this.InvoiceContentDataGridView.AllowUserToAddRows = false;
            this.InvoiceContentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InvoiceContentDataGridView.Location = new System.Drawing.Point(16, 201);
            this.InvoiceContentDataGridView.Name = "InvoiceContentDataGridView";
            this.InvoiceContentDataGridView.Size = new System.Drawing.Size(310, 351);
            this.InvoiceContentDataGridView.TabIndex = 10;
            // 
            // InvoiceContentLabel
            // 
            this.InvoiceContentLabel.AutoSize = true;
            this.InvoiceContentLabel.Location = new System.Drawing.Point(14, 179);
            this.InvoiceContentLabel.Name = "InvoiceContentLabel";
            this.InvoiceContentLabel.Size = new System.Drawing.Size(107, 19);
            this.InvoiceContentLabel.TabIndex = 11;
            this.InvoiceContentLabel.Text = "Invoice Content";
            // 
            // PurchaseReportTabel
            // 
            this.PurchaseReportTabel.AutoSize = true;
            this.PurchaseReportTabel.Location = new System.Drawing.Point(343, 179);
            this.PurchaseReportTabel.Name = "PurchaseReportTabel";
            this.PurchaseReportTabel.Size = new System.Drawing.Size(110, 19);
            this.PurchaseReportTabel.TabIndex = 13;
            this.PurchaseReportTabel.Text = "Purchase Report";
            // 
            // PurchaseReportDataGridView
            // 
            this.PurchaseReportDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PurchaseReportDataGridView.Location = new System.Drawing.Point(345, 201);
            this.PurchaseReportDataGridView.Name = "PurchaseReportDataGridView";
            this.PurchaseReportDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.PurchaseReportDataGridView.Size = new System.Drawing.Size(556, 351);
            this.PurchaseReportDataGridView.TabIndex = 12;
            // 
            // FolderToMoveFilesPathTextBox
            // 
            this.FolderToMoveFilesPathTextBox.Location = new System.Drawing.Point(105, 17);
            this.FolderToMoveFilesPathTextBox.Name = "FolderToMoveFilesPathTextBox";
            this.FolderToMoveFilesPathTextBox.Size = new System.Drawing.Size(114, 24);
            this.FolderToMoveFilesPathTextBox.TabIndex = 16;
            // 
            // MoveFilesToLabel
            // 
            this.MoveFilesToLabel.AutoSize = true;
            this.MoveFilesToLabel.Location = new System.Drawing.Point(6, 20);
            this.MoveFilesToLabel.Name = "MoveFilesToLabel";
            this.MoveFilesToLabel.Size = new System.Drawing.Size(93, 19);
            this.MoveFilesToLabel.TabIndex = 15;
            this.MoveFilesToLabel.Text = "Move Files To";
            // 
            // GetPathToMoveFilesButton
            // 
            this.GetPathToMoveFilesButton.BackColor = System.Drawing.Color.DarkSlateGray;
            this.GetPathToMoveFilesButton.FlatAppearance.BorderColor = System.Drawing.Color.Aqua;
            this.GetPathToMoveFilesButton.FlatAppearance.BorderSize = 0;
            this.GetPathToMoveFilesButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RosyBrown;
            this.GetPathToMoveFilesButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkCyan;
            this.GetPathToMoveFilesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GetPathToMoveFilesButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.GetPathToMoveFilesButton.Location = new System.Drawing.Point(225, 18);
            this.GetPathToMoveFilesButton.Name = "GetPathToMoveFilesButton";
            this.GetPathToMoveFilesButton.Size = new System.Drawing.Size(75, 23);
            this.GetPathToMoveFilesButton.TabIndex = 14;
            this.GetPathToMoveFilesButton.Text = "Get Path";
            this.GetPathToMoveFilesButton.UseVisualStyleBackColor = false;
            this.GetPathToMoveFilesButton.Click += new System.EventHandler(this.GetPathToMoveFilesButton_Click);
            // 
            // FileLoadersGroupBox
            // 
            this.FileLoadersGroupBox.Controls.Add(this.GetPurchaseInvoicesButton);
            this.FileLoadersGroupBox.Controls.Add(this.FilterReportButton);
            this.FileLoadersGroupBox.Controls.Add(this.SearchDirectoryLabel);
            this.FileLoadersGroupBox.Controls.Add(this.GetDirectoryPathButton);
            this.FileLoadersGroupBox.Controls.Add(this.SalesInvoiceLabel);
            this.FileLoadersGroupBox.Controls.Add(this.PurchaseReportLabel);
            this.FileLoadersGroupBox.Controls.Add(this.LoadSalesInvoiceButton);
            this.FileLoadersGroupBox.Controls.Add(this.LoadPurchaseReportButton);
            this.FileLoadersGroupBox.Location = new System.Drawing.Point(16, 41);
            this.FileLoadersGroupBox.Name = "FileLoadersGroupBox";
            this.FileLoadersGroupBox.Size = new System.Drawing.Size(351, 116);
            this.FileLoadersGroupBox.TabIndex = 20;
            this.FileLoadersGroupBox.TabStop = false;
            this.FileLoadersGroupBox.Text = "File Loaders/Getters";
            // 
            // GetPurchaseInvoicesButton
            // 
            this.GetPurchaseInvoicesButton.BackColor = System.Drawing.Color.DarkSlateGray;
            this.GetPurchaseInvoicesButton.FlatAppearance.BorderColor = System.Drawing.Color.Aqua;
            this.GetPurchaseInvoicesButton.FlatAppearance.BorderSize = 0;
            this.GetPurchaseInvoicesButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RosyBrown;
            this.GetPurchaseInvoicesButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkCyan;
            this.GetPurchaseInvoicesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GetPurchaseInvoicesButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.GetPurchaseInvoicesButton.Location = new System.Drawing.Point(215, 55);
            this.GetPurchaseInvoicesButton.Name = "GetPurchaseInvoicesButton";
            this.GetPurchaseInvoicesButton.Size = new System.Drawing.Size(130, 49);
            this.GetPurchaseInvoicesButton.TabIndex = 10;
            this.GetPurchaseInvoicesButton.Text = "Get Purchase Invoices";
            this.GetPurchaseInvoicesButton.UseVisualStyleBackColor = false;
            this.GetPurchaseInvoicesButton.Click += new System.EventHandler(this.GetPurchaseInvoicesButton_Click);
            // 
            // FilterReportButton
            // 
            this.FilterReportButton.BackColor = System.Drawing.Color.DarkSlateGray;
            this.FilterReportButton.FlatAppearance.BorderColor = System.Drawing.Color.Aqua;
            this.FilterReportButton.FlatAppearance.BorderSize = 0;
            this.FilterReportButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RosyBrown;
            this.FilterReportButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkCyan;
            this.FilterReportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FilterReportButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.FilterReportButton.Location = new System.Drawing.Point(215, 26);
            this.FilterReportButton.Name = "FilterReportButton";
            this.FilterReportButton.Size = new System.Drawing.Size(130, 23);
            this.FilterReportButton.TabIndex = 9;
            this.FilterReportButton.Text = "Report word filter";
            this.FilterReportButton.UseVisualStyleBackColor = false;
            this.FilterReportButton.Click += new System.EventHandler(this.SortFilterReportButton_Click);
            // 
            // FilesMovingGroupBox
            // 
            this.FilesMovingGroupBox.Controls.Add(this.DisplayMissingDocsButton);
            this.FilesMovingGroupBox.Controls.Add(this.MovePurchasingInvoicesButton);
            this.FilesMovingGroupBox.Controls.Add(this.MoveFilesToLabel);
            this.FilesMovingGroupBox.Controls.Add(this.GetPathToMoveFilesButton);
            this.FilesMovingGroupBox.Controls.Add(this.FolderToMoveFilesPathTextBox);
            this.FilesMovingGroupBox.Location = new System.Drawing.Point(387, 41);
            this.FilesMovingGroupBox.Name = "FilesMovingGroupBox";
            this.FilesMovingGroupBox.Size = new System.Drawing.Size(331, 116);
            this.FilesMovingGroupBox.TabIndex = 21;
            this.FilesMovingGroupBox.TabStop = false;
            this.FilesMovingGroupBox.Text = "Files Moving";
            // 
            // DisplayMissingDocsButton
            // 
            this.DisplayMissingDocsButton.BackColor = System.Drawing.Color.DarkSlateGray;
            this.DisplayMissingDocsButton.FlatAppearance.BorderColor = System.Drawing.Color.Aqua;
            this.DisplayMissingDocsButton.FlatAppearance.BorderSize = 0;
            this.DisplayMissingDocsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RosyBrown;
            this.DisplayMissingDocsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkCyan;
            this.DisplayMissingDocsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DisplayMissingDocsButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.DisplayMissingDocsButton.Location = new System.Drawing.Point(117, 81);
            this.DisplayMissingDocsButton.Name = "DisplayMissingDocsButton";
            this.DisplayMissingDocsButton.Size = new System.Drawing.Size(183, 23);
            this.DisplayMissingDocsButton.TabIndex = 27;
            this.DisplayMissingDocsButton.Text = "Show Missing Documents";
            this.DisplayMissingDocsButton.UseVisualStyleBackColor = false;
            this.DisplayMissingDocsButton.Click += new System.EventHandler(this.DisplayMissingDocsButton_Click);
            // 
            // MovePurchasingInvoicesButton
            // 
            this.MovePurchasingInvoicesButton.BackColor = System.Drawing.Color.DarkSlateGray;
            this.MovePurchasingInvoicesButton.FlatAppearance.BorderColor = System.Drawing.Color.Aqua;
            this.MovePurchasingInvoicesButton.FlatAppearance.BorderSize = 0;
            this.MovePurchasingInvoicesButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RosyBrown;
            this.MovePurchasingInvoicesButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkCyan;
            this.MovePurchasingInvoicesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MovePurchasingInvoicesButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.MovePurchasingInvoicesButton.Location = new System.Drawing.Point(163, 50);
            this.MovePurchasingInvoicesButton.Name = "MovePurchasingInvoicesButton";
            this.MovePurchasingInvoicesButton.Size = new System.Drawing.Size(137, 23);
            this.MovePurchasingInvoicesButton.TabIndex = 26;
            this.MovePurchasingInvoicesButton.Text = "Move Invoices";
            this.MovePurchasingInvoicesButton.UseVisualStyleBackColor = false;
            this.MovePurchasingInvoicesButton.Click += new System.EventHandler(this.MovePurchasingInvoicesButton_Click);
            // 
            // CreateExportDocsButton
            // 
            this.CreateExportDocsButton.BackColor = System.Drawing.Color.DarkSlateGray;
            this.CreateExportDocsButton.FlatAppearance.BorderColor = System.Drawing.Color.Aqua;
            this.CreateExportDocsButton.FlatAppearance.BorderSize = 0;
            this.CreateExportDocsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RosyBrown;
            this.CreateExportDocsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkCyan;
            this.CreateExportDocsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateExportDocsButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.CreateExportDocsButton.Location = new System.Drawing.Point(6, 31);
            this.CreateExportDocsButton.Name = "CreateExportDocsButton";
            this.CreateExportDocsButton.Size = new System.Drawing.Size(165, 67);
            this.CreateExportDocsButton.TabIndex = 22;
            this.CreateExportDocsButton.Text = "Create Export Documents";
            this.CreateExportDocsButton.UseVisualStyleBackColor = false;
            this.CreateExportDocsButton.Click += new System.EventHandler(this.CreateExportDocsButton_Click);
            // 
            // CreateDocumentsGroupBox
            // 
            this.CreateDocumentsGroupBox.Controls.Add(this.CreateExportDocsButton);
            this.CreateDocumentsGroupBox.Location = new System.Drawing.Point(724, 41);
            this.CreateDocumentsGroupBox.Name = "CreateDocumentsGroupBox";
            this.CreateDocumentsGroupBox.Size = new System.Drawing.Size(177, 116);
            this.CreateDocumentsGroupBox.TabIndex = 25;
            this.CreateDocumentsGroupBox.TabStop = false;
            this.CreateDocumentsGroupBox.Text = "Create Documents";
            // 
            // CloseFormButton
            // 
            this.CloseFormButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseFormButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CloseFormButton.FlatAppearance.BorderColor = System.Drawing.Color.Aqua;
            this.CloseFormButton.FlatAppearance.BorderSize = 0;
            this.CloseFormButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RosyBrown;
            this.CloseFormButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Crimson;
            this.CloseFormButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseFormButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.CloseFormButton.Location = new System.Drawing.Point(890, 2);
            this.CloseFormButton.Name = "CloseFormButton";
            this.CloseFormButton.Size = new System.Drawing.Size(23, 23);
            this.CloseFormButton.TabIndex = 26;
            this.CloseFormButton.Text = "X";
            this.CloseFormButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.CloseFormButton.UseCompatibleTextRendering = true;
            this.CloseFormButton.UseVisualStyleBackColor = false;
            this.CloseFormButton.Click += new System.EventHandler(this.CloseFormButton_Click);
            // 
            // ExportDocsHandlerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(914, 564);
            this.Controls.Add(this.CloseFormButton);
            this.Controls.Add(this.CreateDocumentsGroupBox);
            this.Controls.Add(this.FilesMovingGroupBox);
            this.Controls.Add(this.FileLoadersGroupBox);
            this.Controls.Add(this.PurchaseReportTabel);
            this.Controls.Add(this.PurchaseReportDataGridView);
            this.Controls.Add(this.InvoiceContentLabel);
            this.Controls.Add(this.InvoiceContentDataGridView);
            this.Controls.Add(this.AppTitleLabel);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "ExportDocsHandlerForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export Documents Handler";
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceContentDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseReportDataGridView)).EndInit();
            this.FileLoadersGroupBox.ResumeLayout(false);
            this.FileLoadersGroupBox.PerformLayout();
            this.FilesMovingGroupBox.ResumeLayout(false);
            this.FilesMovingGroupBox.PerformLayout();
            this.CreateDocumentsGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GetDirectoryPathButton;
        private System.Windows.Forms.Label SearchDirectoryLabel;
        private System.Windows.Forms.Label SalesInvoiceLabel;
        private System.Windows.Forms.Label PurchaseReportLabel;
        private System.Windows.Forms.Button LoadSalesInvoiceButton;
        private System.Windows.Forms.Button LoadPurchaseReportButton;
        private System.Windows.Forms.Label AppTitleLabel;
        private System.Windows.Forms.DataGridView InvoiceContentDataGridView;
        private System.Windows.Forms.Label InvoiceContentLabel;
        private System.Windows.Forms.Label PurchaseReportTabel;
        private System.Windows.Forms.DataGridView PurchaseReportDataGridView;
        private System.Windows.Forms.TextBox FolderToMoveFilesPathTextBox;
        private System.Windows.Forms.Label MoveFilesToLabel;
        private System.Windows.Forms.Button GetPathToMoveFilesButton;
        private System.Windows.Forms.GroupBox FileLoadersGroupBox;
        private System.Windows.Forms.GroupBox FilesMovingGroupBox;
        private System.Windows.Forms.Button CreateExportDocsButton;
        private System.Windows.Forms.GroupBox CreateDocumentsGroupBox;
        private System.Windows.Forms.Button CloseFormButton;
        private System.Windows.Forms.Button MovePurchasingInvoicesButton;
        private System.Windows.Forms.Button FilterReportButton;
        private System.Windows.Forms.Button GetPurchaseInvoicesButton;
        private System.Windows.Forms.Button DisplayMissingDocsButton;
    }
}