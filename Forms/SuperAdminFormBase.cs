using System;
using System.Drawing;
using System.Windows.Forms;

namespace SkillBazaar.SuperAdminModule.Forms
{
	/// <summary>
	/// Shared chrome for every Super Admin screen: dark top bar + maroon sidebar
	/// nav + a white content area that each concrete screen fills in via
	/// BuildContent(). Colors/spacing are sampled directly from the mockups in
	/// Project Report section 6.3–6.5 so every screen matches exactly.
	/// </summary>
	public class SuperAdminFormBase : Form
	{
		protected Panel contentPanel;

		private Label lblTitle;
		private Button navOverview;
		private Button navApprovals;
		private Button navManage;
		private Button navRevenue;
		private Button navPayout;

		// Colors sampled from the report screenshots.
		protected static readonly Color ColorSidebar = Color.FromArgb(90, 30, 30);
		protected static readonly Color ColorSidebarHov = Color.FromArgb(110, 40, 40);
		protected static readonly Color ColorTopBar = Color.FromArgb(51, 51, 51);
		protected static readonly Color ColorCard = Color.FromArgb(253, 234, 234);
		protected static readonly Color ColorAccentRed = Color.FromArgb(220, 53, 69);
		protected static readonly Color ColorGreen = Color.FromArgb(40, 167, 69);
		protected static readonly Color ColorGold = Color.FromArgb(255, 202, 40);
		protected static readonly Color ColorGridHead = Color.FromArgb(238, 238, 238);
		protected static readonly Color ColorBorder = Color.FromArgb(204, 204, 204);
		protected static readonly Color ColorCaption = Color.FromArgb(85, 85, 85);

		protected SuperAdminFormBase(string screenTitle, string activeNavKey)
		{
			Text = "SkillBazaar — Super Admin";
			ClientSize = new Size(1200, 700);
			StartPosition = FormStartPosition.CenterScreen;
			BackColor = Color.White;
			Font = new Font("Arial", 10F);

			BuildChrome(screenTitle);
			SetActiveNav(activeNavKey);
			BuildContent();
		}

		/// <summary>Each concrete screen overrides this to fill contentPanel.</summary>
		protected virtual void BuildContent() { }

		private void BuildChrome(string screenTitle)
		{
			Panel topBar = new Panel { Dock = DockStyle.Top, Height = 60, BackColor = ColorTopBar };
			lblTitle = new Label
			{
				Text = screenTitle,
				ForeColor = Color.White,
				Font = new Font("Arial", 13F, FontStyle.Bold),
				AutoSize = true,
				Location = new Point(24, 18)
			};
			topBar.Controls.Add(lblTitle);

			Panel sidebar = new Panel { Dock = DockStyle.Left, Width = 250, BackColor = ColorSidebar };

			Label lblSuperAdmin = new Label
			{
				Text = "Super Admin",
				ForeColor = Color.White,
				Font = new Font("Arial", 12F, FontStyle.Bold),
				AutoSize = true,
				Location = new Point(24, 20)
			};

			navOverview = CreateNavButton("📊   Overview", 60);
			navApprovals = CreateNavButton("✅   Instructor Approvals", 114);
			navManage = CreateNavButton("👥   Manage Instructors", 168);
			navRevenue = CreateNavButton("💹   Revenue Reports", 222);
			navPayout = CreateNavButton("💰   Payout Requests", 276);

			navOverview.Click += (s, e) => Navigate(new SuperAdminDashboardForm());
			navApprovals.Click += (s, e) => Navigate(new ManageInstructorsForm());
			navManage.Click += (s, e) => Navigate(new ManageInstructorsForm());
			navRevenue.Click += (s, e) => Navigate(new SalesCommissionReportForm());
			navPayout.Click += (s, e) => Navigate(new PayoutApprovalForm());

			sidebar.Controls.Add(lblSuperAdmin);
			sidebar.Controls.AddRange(new Control[] { navOverview, navApprovals, navManage, navRevenue, navPayout });

			contentPanel = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, AutoScroll = true };

			Controls.Add(contentPanel);
			Controls.Add(sidebar);
			Controls.Add(topBar);
		}

		private Button CreateNavButton(string text, int y)
		{
			Button btn = new Button
			{
				Text = text,
				TextAlign = ContentAlignment.MiddleLeft,
				Location = new Point(0, y),
				Size = new Size(250, 54),
				FlatStyle = FlatStyle.Flat,
				BackColor = ColorSidebar,
				ForeColor = Color.White,
				Font = new Font("Arial", 10.5F),
				Cursor = Cursors.Hand
			};
			btn.FlatAppearance.BorderSize = 0;
			btn.FlatAppearance.MouseOverBackColor = ColorSidebarHov;
			return btn;
		}

		private void SetActiveNav(string key)
		{
			Button[] all = { navOverview, navApprovals, navManage, navRevenue, navPayout };
			foreach (Button b in all)
			{
				b.ForeColor = Color.White;
				b.Font = new Font("Arial", 10.5F, FontStyle.Regular);
			}

			Button active = null;
			switch (key)
			{
				case "overview":
					active = navOverview;
					break;
				case "approvals":
					active = navApprovals;
					break;
				case "manage":
					active = navManage;
					break;
				case "revenue":
					active = navRevenue;
					break;
				case "payout":
					active = navPayout;
					break;
			}

			if (active != null)
			{
				active.ForeColor = ColorGold;
				active.Font = new Font("Arial", 10.5F, FontStyle.Bold);
			}
		}

		private void Navigate(Form target)
		{
			target.StartPosition = FormStartPosition.Manual;
			target.Location = Location;

			// নতুন উইন্ডো ক্লোজ করলে যেন অ্যাপটি পুরোপুরি বন্ধ হয়
			target.FormClosed += (s, args) => this.Close();

			target.Show();
			this.Hide(); // বর্তমান উইন্ডোটি শুধু লুকিয়ে রাখবে
		}

		/// <summary>Builds one pink stat card (used on Overview, Revenue, Payout screens).</summary>
		protected Panel CreateStatCard(string name, int x, int y, string bigText, string caption)
		{
			Panel card = new Panel
			{
				Name = name,
				Location = new Point(x, y),
				Size = new Size(270, 100),
				BackColor = ColorCard
			};

			Label lblCaption = new Label
			{
				Name = "lblCaption",
				Text = caption,
				Font = new Font("Arial", 9F),
				ForeColor = ColorCaption,
				TextAlign = ContentAlignment.TopCenter,
				Dock = DockStyle.Fill
			};
			Label lblBig = new Label
			{
				Name = "lblBig",
				Text = bigText,
				Font = new Font("Arial", 18F, FontStyle.Bold),
				ForeColor = ColorAccentRed,
				TextAlign = ContentAlignment.MiddleCenter,
				Dock = DockStyle.Top,
				Height = 45
			};

			card.Controls.Add(lblCaption);
			card.Controls.Add(lblBig);
			return card;
		}

		protected void SetCardValue(Panel card, string value)
		{
			Control lbl = card.Controls["lblBig"];
			if (lbl != null) lbl.Text = value;
		}

		/// <summary>Applies the shared grid look (gray header, thin borders) used on every screen.</summary>
		protected void StyleGrid(DataGridView grid)
		{
			grid.BorderStyle = BorderStyle.FixedSingle;
			grid.GridColor = ColorBorder;
			grid.BackgroundColor = Color.White;
			grid.RowHeadersVisible = false;
			grid.AllowUserToAddRows = false;
			grid.AllowUserToResizeRows = false;
			grid.AllowUserToResizeColumns = false;
			grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grid.ColumnHeadersHeight = 42;
			grid.RowTemplate.Height = 48;
			grid.EnableHeadersVisualStyles = false;
			grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			grid.ColumnHeadersDefaultCellStyle.BackColor = ColorGridHead;
			grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
			grid.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Bold);
			grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 0, 0, 0);
			grid.DefaultCellStyle.Font = new Font("Arial", 10F);
			grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(253, 244, 244);
			grid.DefaultCellStyle.SelectionForeColor = Color.Black;
			grid.DefaultCellStyle.Padding = new Padding(10, 0, 0, 0);
			grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
		}
	}
}