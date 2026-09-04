using System.Drawing;
using System.Windows.Forms;

namespace SkillBazaar.Forms
{
    internal static class Ui
    {
        public static readonly Color Primary = Color.FromArgb(83, 42, 45);
        public static readonly Color PrimaryDark = Color.FromArgb(54, 35, 36);
        public static readonly Color Accent = Color.FromArgb(218, 153, 86);
        public static readonly Color Success = Color.FromArgb(45, 139, 87);
        public static readonly Color Danger = Color.FromArgb(190, 62, 65);
        public static readonly Color Page = Color.FromArgb(246, 244, 241);

        public static Button Button(string text, int x, int y, int width, Color? color = null)
        {
            Button button = new Button
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(width, 36),
                BackColor = color ?? Primary,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            button.FlatAppearance.BorderSize = 0;
            return button;
        }

        public static DataGridView Grid(int x, int y, int width, int height)
        {
            DataGridView grid = new DataGridView
            {
                Location = new Point(x, y),
                Size = new Size(width, height),
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                MultiSelect = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                RowHeadersVisible = false,
                EnableHeadersVisualStyles = false
            };
            grid.ColumnHeadersDefaultCellStyle.BackColor = PrimaryDark;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grid.ColumnHeadersHeight = 38;
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(239, 222, 205);
            grid.DefaultCellStyle.SelectionForeColor = Color.Black;
            grid.RowTemplate.Height = 32;
            return grid;
        }

        public static Label Heading(string text, int x = 22, int y = 18)
        {
            return new Label { Text = text, Location = new Point(x, y), AutoSize = true, Font = new Font("Segoe UI", 15F, FontStyle.Bold), ForeColor = PrimaryDark };
        }

        public static Panel Header(Form owner, string role, string name, System.EventHandler logoutHandler)
        {
            Panel header = new Panel { Dock = DockStyle.Top, Height = 68, BackColor = PrimaryDark };
            header.Controls.Add(new Label { Text = "SkillBazaar", Location = new Point(22, 14), AutoSize = true, ForeColor = Color.White, Font = new Font("Segoe UI", 20F, FontStyle.Bold) });
            header.Controls.Add(new Label { Text = role + "  |  " + name, Anchor = AnchorStyles.Top | AnchorStyles.Right, Location = new Point(owner.ClientSize.Width - 340, 24), Size = new Size(220, 24), TextAlign = ContentAlignment.MiddleRight, ForeColor = Color.White, Font = new Font("Segoe UI", 9.5F) });
            Button logout = Button("Logout", owner.ClientSize.Width - 105, 16, 80, Danger);
            logout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            logout.Click += logoutHandler;
            header.Controls.Add(logout);
            return header;
        }

        public static TabControl Tabs()
        {
            return new TabControl { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 9.5F), Padding = new Point(16, 7) };
        }

        public static Label FieldLabel(string text, int x, int y)
        {
            return new Label { Text = text, Location = new Point(x, y), AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Bold) };
        }

        public static TextBox TextBox(int x, int y, int width)
        {
            return new TextBox { Location = new Point(x, y), Width = width, Font = new Font("Segoe UI", 10F) };
        }

        public static string Money(object value)
        {
            decimal amount;
            return decimal.TryParse(value == null ? "0" : value.ToString(), out amount) ? "Tk " + amount.ToString("N2") : "Tk 0.00";
        }
    }
}
