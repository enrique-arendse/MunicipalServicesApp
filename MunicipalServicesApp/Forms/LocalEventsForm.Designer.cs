namespace MunicipalServicesApp.Forms
{
	partial class LocalEventsForm
	{
		private System.ComponentModel.IContainer components = null;

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		private System.Windows.Forms.Panel pnlHeader;
		private System.Windows.Forms.Label lblHeading;
		private System.Windows.Forms.Label lblTicker;

		private System.Windows.Forms.Label lblKeyword;
		private System.Windows.Forms.TextBox txtKeyword;
		private System.Windows.Forms.Label lblCategoryFilter;
		private System.Windows.Forms.ComboBox cmbCategoryFilter;
		private System.Windows.Forms.CheckBox chkFrom;
		private System.Windows.Forms.DateTimePicker dtpFrom;
		private System.Windows.Forms.CheckBox chkTo;
		private System.Windows.Forms.DateTimePicker dtpTo;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.Button btnClearSearch;

		private System.Windows.Forms.Label lblResultsHeading;
		private System.Windows.Forms.Label lblNextUp;

		private System.Windows.Forms.Panel pnlEvents;
		private System.Windows.Forms.FlowLayoutPanel flpEvents;

		private System.Windows.Forms.Panel pnlSide;
		private System.Windows.Forms.Label lblRecommendedHeading;
		private System.Windows.Forms.ListBox lstRecommended;
		private System.Windows.Forms.Label lblRecentHeading;
		private System.Windows.Forms.ListBox lstRecentlyViewed;

		private System.Windows.Forms.Label lblResultCount;
		private System.Windows.Forms.Button btnBackToMenu;

		private void InitializeComponent()
		{
			this.pnlHeader = new System.Windows.Forms.Panel();
			this.lblHeading = new System.Windows.Forms.Label();
			this.lblTicker = new System.Windows.Forms.Label();
			this.lblKeyword = new System.Windows.Forms.Label();
			this.txtKeyword = new System.Windows.Forms.TextBox();
			this.lblCategoryFilter = new System.Windows.Forms.Label();
			this.cmbCategoryFilter = new System.Windows.Forms.ComboBox();
			this.chkFrom = new System.Windows.Forms.CheckBox();
			this.dtpFrom = new System.Windows.Forms.DateTimePicker();
			this.chkTo = new System.Windows.Forms.CheckBox();
			this.dtpTo = new System.Windows.Forms.DateTimePicker();
			this.btnSearch = new System.Windows.Forms.Button();
			this.btnClearSearch = new System.Windows.Forms.Button();
			this.lblResultsHeading = new System.Windows.Forms.Label();
			this.lblNextUp = new System.Windows.Forms.Label();
			this.pnlEvents = new System.Windows.Forms.Panel();
			this.flpEvents = new System.Windows.Forms.FlowLayoutPanel();
			this.pnlSide = new System.Windows.Forms.Panel();
			this.lstRecentlyViewed = new System.Windows.Forms.ListBox();
			this.lblRecentHeading = new System.Windows.Forms.Label();
			this.lstRecommended = new System.Windows.Forms.ListBox();
			this.lblRecommendedHeading = new System.Windows.Forms.Label();
			this.lblResultCount = new System.Windows.Forms.Label();
			this.btnBackToMenu = new System.Windows.Forms.Button();
			this.pnlHeader.SuspendLayout();
			this.pnlEvents.SuspendLayout();
			this.pnlSide.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlHeader
			// 
			this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(82)))), ((int)(((byte)(120)))));
			this.pnlHeader.Controls.Add(this.lblHeading);
			this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlHeader.Location = new System.Drawing.Point(0, 0);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Size = new System.Drawing.Size(1120, 64);
			this.pnlHeader.TabIndex = 0;
			// 
			// lblHeading
			// 
			this.lblHeading.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
			this.lblHeading.ForeColor = System.Drawing.Color.White;
			this.lblHeading.Location = new System.Drawing.Point(23, 16);
			this.lblHeading.Name = "lblHeading";
			this.lblHeading.Size = new System.Drawing.Size(686, 32);
			this.lblHeading.TabIndex = 0;
			this.lblHeading.Text = "Local Events and Announcements";
			// 
			// lblTicker
			// 
			this.lblTicker.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
			this.lblTicker.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(82)))), ((int)(((byte)(120)))));
			this.lblTicker.Location = new System.Drawing.Point(23, 73);
			this.lblTicker.Name = "lblTicker";
			this.lblTicker.Size = new System.Drawing.Size(1074, 21);
			this.lblTicker.TabIndex = 1;
			this.lblTicker.Text = "Latest announcements loading...";
			// 
			// lblKeyword
			// 
			this.lblKeyword.AutoSize = true;
			this.lblKeyword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			this.lblKeyword.Location = new System.Drawing.Point(23, 102);
			this.lblKeyword.Name = "lblKeyword";
			this.lblKeyword.Size = new System.Drawing.Size(71, 20);
			this.lblKeyword.TabIndex = 2;
			this.lblKeyword.Text = "Keyword";
			// 
			// txtKeyword
			// 
			this.txtKeyword.Font = new System.Drawing.Font("Segoe UI", 9.5F);
			this.txtKeyword.Location = new System.Drawing.Point(23, 123);
			this.txtKeyword.Name = "txtKeyword";
			this.txtKeyword.Size = new System.Drawing.Size(239, 29);
			this.txtKeyword.TabIndex = 3;
			// 
			// lblCategoryFilter
			// 
			this.lblCategoryFilter.AutoSize = true;
			this.lblCategoryFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			this.lblCategoryFilter.Location = new System.Drawing.Point(280, 102);
			this.lblCategoryFilter.Name = "lblCategoryFilter";
			this.lblCategoryFilter.Size = new System.Drawing.Size(73, 20);
			this.lblCategoryFilter.TabIndex = 4;
			this.lblCategoryFilter.Text = "Category";
			// 
			// cmbCategoryFilter
			// 
			this.cmbCategoryFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCategoryFilter.Font = new System.Drawing.Font("Segoe UI", 9.5F);
			this.cmbCategoryFilter.FormattingEnabled = true;
			this.cmbCategoryFilter.Location = new System.Drawing.Point(280, 123);
			this.cmbCategoryFilter.Name = "cmbCategoryFilter";
			this.cmbCategoryFilter.Size = new System.Drawing.Size(188, 29);
			this.cmbCategoryFilter.TabIndex = 5;
			// 
			// chkFrom
			// 
			this.chkFrom.AutoSize = true;
			this.chkFrom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			this.chkFrom.Location = new System.Drawing.Point(486, 103);
			this.chkFrom.Name = "chkFrom";
			this.chkFrom.Size = new System.Drawing.Size(68, 24);
			this.chkFrom.TabIndex = 6;
			this.chkFrom.Text = "From";
			this.chkFrom.UseVisualStyleBackColor = true;
			this.chkFrom.CheckedChanged += new System.EventHandler(this.chkFrom_CheckedChanged);
			// 
			// dtpFrom
			// 
			this.dtpFrom.Enabled = false;
			this.dtpFrom.Font = new System.Drawing.Font("Segoe UI", 9.5F);
			this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFrom.Location = new System.Drawing.Point(486, 123);
			this.dtpFrom.Name = "dtpFrom";
			this.dtpFrom.Size = new System.Drawing.Size(137, 29);
			this.dtpFrom.TabIndex = 7;
			// 
			// chkTo
			// 
			this.chkTo.AutoSize = true;
			this.chkTo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			this.chkTo.Location = new System.Drawing.Point(640, 103);
			this.chkTo.Name = "chkTo";
			this.chkTo.Size = new System.Drawing.Size(48, 24);
			this.chkTo.TabIndex = 8;
			this.chkTo.Text = "To";
			this.chkTo.UseVisualStyleBackColor = true;
			this.chkTo.CheckedChanged += new System.EventHandler(this.chkTo_CheckedChanged);
			// 
			// dtpTo
			// 
			this.dtpTo.Enabled = false;
			this.dtpTo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
			this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpTo.Location = new System.Drawing.Point(640, 123);
			this.dtpTo.Name = "dtpTo";
			this.dtpTo.Size = new System.Drawing.Size(137, 29);
			this.dtpTo.TabIndex = 9;
			// 
			// btnSearch
			// 
			this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(82)))), ((int)(((byte)(120)))));
			this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
			this.btnSearch.ForeColor = System.Drawing.Color.White;
			this.btnSearch.Location = new System.Drawing.Point(789, 117);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(143, 39);
			this.btnSearch.TabIndex = 10;
			this.btnSearch.Text = "Search";
			this.btnSearch.UseVisualStyleBackColor = false;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// btnClearSearch
			// 
			this.btnClearSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnClearSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F);
			this.btnClearSearch.Location = new System.Drawing.Point(949, 117);
			this.btnClearSearch.Name = "btnClearSearch";
			this.btnClearSearch.Size = new System.Drawing.Size(149, 39);
			this.btnClearSearch.TabIndex = 11;
			this.btnClearSearch.Text = "Clear Filters";
			this.btnClearSearch.UseVisualStyleBackColor = true;
			this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
			// 
			// lblResultsHeading
			// 
			this.lblResultsHeading.AutoSize = true;
			this.lblResultsHeading.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
			this.lblResultsHeading.Location = new System.Drawing.Point(23, 165);
			this.lblResultsHeading.Name = "lblResultsHeading";
			this.lblResultsHeading.Size = new System.Drawing.Size(167, 25);
			this.lblResultsHeading.TabIndex = 12;
			this.lblResultsHeading.Text = "Upcoming Events";
			// 
			// lblNextUp
			// 
			this.lblNextUp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
			this.lblNextUp.ForeColor = System.Drawing.Color.DimGray;
			this.lblNextUp.Location = new System.Drawing.Point(23, 190);
			this.lblNextUp.Name = "lblNextUp";
			this.lblNextUp.Size = new System.Drawing.Size(743, 21);
			this.lblNextUp.TabIndex = 13;
			this.lblNextUp.Text = "Next up: ...";
			// 
			// pnlEvents
			// 
			this.pnlEvents.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlEvents.Controls.Add(this.flpEvents);
			this.pnlEvents.Location = new System.Drawing.Point(23, 215);
			this.pnlEvents.Name = "pnlEvents";
			this.pnlEvents.Size = new System.Drawing.Size(743, 411);
			this.pnlEvents.TabIndex = 14;
			// 
			// flpEvents
			// 
			this.flpEvents.AutoScroll = true;
			this.flpEvents.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flpEvents.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flpEvents.Location = new System.Drawing.Point(0, 0);
			this.flpEvents.Name = "flpEvents";
			this.flpEvents.Padding = new System.Windows.Forms.Padding(9, 9, 9, 9);
			this.flpEvents.Size = new System.Drawing.Size(741, 409);
			this.flpEvents.TabIndex = 0;
			this.flpEvents.WrapContents = false;
			// 
			// pnlSide
			// 
			this.pnlSide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlSide.Controls.Add(this.lstRecentlyViewed);
			this.pnlSide.Controls.Add(this.lblRecentHeading);
			this.pnlSide.Controls.Add(this.lstRecommended);
			this.pnlSide.Controls.Add(this.lblRecommendedHeading);
			this.pnlSide.Location = new System.Drawing.Point(789, 215);
			this.pnlSide.Name = "pnlSide";
			this.pnlSide.Size = new System.Drawing.Size(308, 411);
			this.pnlSide.TabIndex = 15;
			// 
			// lstRecentlyViewed
			// 
			this.lstRecentlyViewed.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.lstRecentlyViewed.FormattingEnabled = true;
			this.lstRecentlyViewed.ItemHeight = 20;
			this.lstRecentlyViewed.Location = new System.Drawing.Point(11, 238);
			this.lstRecentlyViewed.Name = "lstRecentlyViewed";
			this.lstRecentlyViewed.Size = new System.Drawing.Size(283, 164);
			this.lstRecentlyViewed.TabIndex = 3;
			// 
			// lblRecentHeading
			// 
			this.lblRecentHeading.AutoSize = true;
			this.lblRecentHeading.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.lblRecentHeading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(82)))), ((int)(((byte)(120)))));
			this.lblRecentHeading.Location = new System.Drawing.Point(11, 213);
			this.lblRecentHeading.Name = "lblRecentHeading";
			this.lblRecentHeading.Size = new System.Drawing.Size(142, 23);
			this.lblRecentHeading.TabIndex = 2;
			this.lblRecentHeading.Text = "Recently Viewed";
			// 
			// lstRecommended
			// 
			this.lstRecommended.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.lstRecommended.FormattingEnabled = true;
			this.lstRecommended.ItemHeight = 20;
			this.lstRecommended.Location = new System.Drawing.Point(11, 35);
			this.lstRecommended.Name = "lstRecommended";
			this.lstRecommended.Size = new System.Drawing.Size(283, 164);
			this.lstRecommended.TabIndex = 1;
			this.lstRecommended.DoubleClick += new System.EventHandler(this.lstRecommended_DoubleClick);
			// 
			// lblRecommendedHeading
			// 
			this.lblRecommendedHeading.AutoSize = true;
			this.lblRecommendedHeading.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			this.lblRecommendedHeading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(82)))), ((int)(((byte)(120)))));
			this.lblRecommendedHeading.Location = new System.Drawing.Point(11, 11);
			this.lblRecommendedHeading.Name = "lblRecommendedHeading";
			this.lblRecommendedHeading.Size = new System.Drawing.Size(192, 23);
			this.lblRecommendedHeading.TabIndex = 0;
			this.lblRecommendedHeading.Text = "Recommended for You";
			// 
			// lblResultCount
			// 
			this.lblResultCount.AutoSize = true;
			this.lblResultCount.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
			this.lblResultCount.ForeColor = System.Drawing.Color.DimGray;
			this.lblResultCount.Location = new System.Drawing.Point(23, 638);
			this.lblResultCount.Name = "lblResultCount";
			this.lblResultCount.Size = new System.Drawing.Size(119, 20);
			this.lblResultCount.TabIndex = 16;
			this.lblResultCount.Text = "Showing 0 events";
			// 
			// btnBackToMenu
			// 
			this.btnBackToMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBackToMenu.Font = new System.Drawing.Font("Segoe UI", 9.5F);
			this.btnBackToMenu.Location = new System.Drawing.Point(949, 631);
			this.btnBackToMenu.Name = "btnBackToMenu";
			this.btnBackToMenu.Size = new System.Drawing.Size(149, 34);
			this.btnBackToMenu.TabIndex = 17;
			this.btnBackToMenu.Text = "Back to Main Menu";
			this.btnBackToMenu.UseVisualStyleBackColor = true;
			this.btnBackToMenu.Click += new System.EventHandler(this.btnBackToMenu_Click);
			// 
			// LocalEventsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(1120, 683);
			this.Controls.Add(this.btnBackToMenu);
			this.Controls.Add(this.lblResultCount);
			this.Controls.Add(this.pnlSide);
			this.Controls.Add(this.pnlEvents);
			this.Controls.Add(this.lblNextUp);
			this.Controls.Add(this.lblResultsHeading);
			this.Controls.Add(this.btnClearSearch);
			this.Controls.Add(this.btnSearch);
			this.Controls.Add(this.dtpTo);
			this.Controls.Add(this.chkTo);
			this.Controls.Add(this.dtpFrom);
			this.Controls.Add(this.chkFrom);
			this.Controls.Add(this.cmbCategoryFilter);
			this.Controls.Add(this.lblCategoryFilter);
			this.Controls.Add(this.txtKeyword);
			this.Controls.Add(this.lblKeyword);
			this.Controls.Add(this.lblTicker);
			this.Controls.Add(this.pnlHeader);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "LocalEventsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Local Events and Announcements - Municipal Services Application";
			this.pnlHeader.ResumeLayout(false);
			this.pnlEvents.ResumeLayout(false);
			this.pnlSide.ResumeLayout(false);
			this.pnlSide.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
	}
}