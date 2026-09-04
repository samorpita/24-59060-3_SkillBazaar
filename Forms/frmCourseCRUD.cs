using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SkillBazaar.Classes;
using System.Linq;

namespace SkillBazaar.Forms
{
    public partial class frmCourseCRUD : Form
    {
        private InstructorManager instructorManager;
        private CourseManager courseManager;
        private DataTable courseTable;
        private bool isEditing = false;
        private int editingCourseID = 0;

        public frmCourseCRUD(InstructorManager manager)
        {
            InitializeComponent();
            instructorManager = manager;
            courseManager = new CourseManager(manager.InstructorID);
            SetupDataGridView();
            LoadCategories();
            LoadCourses();
            UpdateStatus("Ready", 0);
        }

        private void frmCourseCRUD_Load(object sender, EventArgs e)
        {
            // Set default search text
            txtSearch.Text = "Search courses...";
            txtSearch.ForeColor = Color.Gray;
        }

        private void SetupDataGridView()
        {
            // Configure DataGridView appearance
            dgvCourses.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvCourses.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvCourses.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
            dgvCourses.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCourses.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);
            dgvCourses.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dgvCourses.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvCourses.RowTemplate.Height = 35;
        }

        private void LoadCategories()
        {
            try
            {
                DataTable categories = courseManager.GetCategories();
                cmbCategory.DataSource = categories;
                cmbCategory.DisplayMember = "CategoryName";
                cmbCategory.ValueMember = "CategoryID";

                cmbCategoryForm.DataSource = categories.Copy();
                cmbCategoryForm.DisplayMember = "CategoryName";
                cmbCategoryForm.ValueMember = "CategoryID";

                // Add "All Categories" option for filter
                DataRow row = categories.NewRow();
                row["CategoryID"] = 0;
                row["CategoryName"] = "All Categories";
                categories.Rows.InsertAt(row, 0);
                cmbCategory.DataSource = categories;
                cmbCategory.DisplayMember = "CategoryName";
                cmbCategory.ValueMember = "CategoryID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCourses(string search = null, int? categoryID = null)
        {
            try
            {
                // Show loading status
                lblStatus.Text = "⏳ Loading courses...";

                courseTable = courseManager.GetCourses(search, categoryID);
                dgvCourses.DataSource = courseTable;

                if (courseTable != null && courseTable.Rows.Count > 0)
                {
                    // Format columns
                    if (dgvCourses.Columns["CourseID"] != null)
                        dgvCourses.Columns["CourseID"].Visible = false;

                    if (dgvCourses.Columns["Title"] != null)
                    {
                        dgvCourses.Columns["Title"].HeaderText = "Course Title";
                        dgvCourses.Columns["Title"].DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                    }

                    if (dgvCourses.Columns["CategoryName"] != null)
                        dgvCourses.Columns["CategoryName"].HeaderText = "Category";

                    if (dgvCourses.Columns["Price"] != null)
                    {
                        dgvCourses.Columns["Price"].HeaderText = "Price (₮)";
                        dgvCourses.Columns["Price"].DefaultCellStyle.Format = "N0";
                        dgvCourses.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }

                    if (dgvCourses.Columns["TotalSeats"] != null)
                    {
                        dgvCourses.Columns["TotalSeats"].HeaderText = "Total Seats";
                        dgvCourses.Columns["TotalSeats"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }

                    if (dgvCourses.Columns["AvailableSeats"] != null)
                    {
                        dgvCourses.Columns["AvailableSeats"].HeaderText = "Available";
                        dgvCourses.Columns["AvailableSeats"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        // Color code available seats
                        dgvCourses.CellFormatting += (sender, e) =>
                        {
                            if (e.ColumnIndex == dgvCourses.Columns["AvailableSeats"].Index && e.RowIndex >= 0)
                            {
                                int available = Convert.ToInt32(dgvCourses.Rows[e.RowIndex].Cells["AvailableSeats"].Value);
                                if (available <= 0)
                                    e.CellStyle.ForeColor = Color.Red;
                                else if (available <= 5)
                                    e.CellStyle.ForeColor = Color.Orange;
                                else
                                    e.CellStyle.ForeColor = Color.Green;
                            }
                        };
                    }

                    if (dgvCourses.Columns["EnrolledSeats"] != null)
                    {
                        dgvCourses.Columns["EnrolledSeats"].HeaderText = "Enrolled";
                        dgvCourses.Columns["EnrolledSeats"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }

                    // Add action buttons
                    if (!dgvCourses.Columns.Contains("Edit"))
                    {
                        DataGridViewButtonColumn editColumn = new DataGridViewButtonColumn();
                        editColumn.Name = "Edit";
                        editColumn.HeaderText = "Actions";
                        editColumn.Text = "✏️ Edit";
                        editColumn.UseColumnTextForButtonValue = true;
                        editColumn.Width = 80;
                        dgvCourses.Columns.Add(editColumn);

                        DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn();
                        deleteColumn.Name = "Delete";
                        deleteColumn.HeaderText = "";
                        deleteColumn.Text = "🗑️ Delete";
                        deleteColumn.UseColumnTextForButtonValue = true;
                        deleteColumn.Width = 80;
                        dgvCourses.Columns.Add(deleteColumn);
                    }

                    UpdateStatus($"✅ Loaded {courseTable.Rows.Count} courses", courseTable.Rows.Count);
                }
                else
                {
                    dgvCourses.DataSource = null;
                    UpdateStatus("ℹ️ No courses found. Add your first course!", 0);
                }
            }
            catch (Exception ex)
            {
                UpdateStatus($"❌ Error: {ex.Message}", 0);
                MessageBox.Show("Error loading courses: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStatus(string message, int count)
        {
            lblStatus.Text = message;
            lblRecordCount.Text = $"Total: {count} courses";
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            isEditing = false;
            editingCourseID = 0;
            ClearForm();
            pnlForm.Visible = true;
            lblFormTitle.Text = "📝 Add New Course";
            btnSave.Text = "💾 Add Course";
            txtTitle.Focus();
            UpdateStatus("✏️ Adding new course...", courseTable?.Rows?.Count ?? 0);
        }

        private void dgvCourses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvCourses.Rows.Count)
            {
                try
                {
                    int courseID = Convert.ToInt32(dgvCourses.Rows[e.RowIndex].Cells["CourseID"].Value);

                    if (e.ColumnIndex == dgvCourses.Columns["Edit"].Index)
                    {
                        // Edit course
                        isEditing = true;
                        editingCourseID = courseID;
                        LoadCourseForEdit(courseID);
                        pnlForm.Visible = true;
                        lblFormTitle.Text = "✏️ Edit Course";
                        btnSave.Text = "💾 Update Course";
                        UpdateStatus($"✏️ Editing: {dgvCourses.Rows[e.RowIndex].Cells["Title"].Value}",
                            courseTable?.Rows?.Count ?? 0);
                    }
                    else if (e.ColumnIndex == dgvCourses.Columns["Delete"].Index)
                    {
                        // Delete course
                        string courseName = dgvCourses.Rows[e.RowIndex].Cells["Title"].Value.ToString();
                        DialogResult result = MessageBox.Show(
                            $"Are you sure you want to delete the course:\n\n\"{courseName}\"?\n\nThis action cannot be undone!",
                            "Confirm Delete",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            DeleteCourse(courseID);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvCourses_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvCourses.Rows.Count)
            {
                // Double-click to edit
                int courseID = Convert.ToInt32(dgvCourses.Rows[e.RowIndex].Cells["CourseID"].Value);
                isEditing = true;
                editingCourseID = courseID;
                LoadCourseForEdit(courseID);
                pnlForm.Visible = true;
                lblFormTitle.Text = "✏️ Edit Course";
                btnSave.Text = "💾 Update Course";
            }
        }

        private void LoadCourseForEdit(int courseID)
        {
            try
            {
                DataTable dt = courseManager.GetCourseDetails(courseID);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    txtTitle.Text = row["Title"].ToString();
                    txtPrice.Text = row["Price"].ToString();
                    txtSeats.Text = row["TotalSeats"].ToString();
                    txtDescription.Text = row["Description"].ToString();
                    cmbCategoryForm.SelectedValue = Convert.ToInt32(row["CategoryID"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading course details: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtTitle.Clear();
            txtPrice.Clear();
            txtSeats.Clear();
            txtDescription.Clear();
            if (cmbCategoryForm.Items.Count > 0)
                cmbCategoryForm.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate inputs
                if (string.IsNullOrWhiteSpace(txtTitle.Text))
                {
                    MessageBox.Show("Please enter a course title.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTitle.Focus();
                    return;
                }

                if (!decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
                {
                    MessageBox.Show("Please enter a valid price (greater than 0).", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPrice.Focus();
                    return;
                }

                if (!int.TryParse(txtSeats.Text, out int seats) || seats <= 0)
                {
                    MessageBox.Show("Please enter a valid number of seats (greater than 0).", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSeats.Focus();
                    return;
                }

                if (cmbCategoryForm.SelectedValue == null || Convert.ToInt32(cmbCategoryForm.SelectedValue) == 0)
                {
                    MessageBox.Show("Please select a category.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbCategoryForm.Focus();
                    return;
                }

                int categoryID = Convert.ToInt32(cmbCategoryForm.SelectedValue);
                bool success;

                lblStatus.Text = "⏳ Saving course...";

                if (isEditing)
                {
                    success = courseManager.UpdateCourse(editingCourseID, txtTitle.Text.Trim(), price, seats, categoryID);
                    if (success)
                    {
                        MessageBox.Show("Course updated successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UpdateStatus("✅ Course updated successfully", courseTable?.Rows?.Count ?? 0);
                    }
                }
                else
                {
                    success = courseManager.AddCourse(txtTitle.Text.Trim(), price, seats, categoryID, txtDescription.Text.Trim());
                    if (success)
                    {
                        MessageBox.Show("Course added successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UpdateStatus("✅ Course added successfully", courseTable?.Rows?.Count + 1 ?? 1);
                    }
                }

                if (success)
                {
                    pnlForm.Visible = false;
                    ClearForm();
                    LoadCourses(txtSearch.Text == "Search courses..." ? null : txtSearch.Text,
                        Convert.ToInt32(cmbCategory.SelectedValue) > 0 ? Convert.ToInt32(cmbCategory.SelectedValue) : (int?)null);
                }
                else
                {
                    MessageBox.Show("Failed to save course. Please try again.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    UpdateStatus("❌ Failed to save course", courseTable?.Rows?.Count ?? 0);
                }
            }
            catch (Exception ex)
            {
                UpdateStatus("❌ Error: " + ex.Message, courseTable?.Rows?.Count ?? 0);
                MessageBox.Show("Error saving course: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteCourse(int courseID)
        {
            try
            {
                if (courseManager.DeleteCourse(courseID))
                {
                    MessageBox.Show("Course deleted successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCourses(txtSearch.Text == "Search courses..." ? null : txtSearch.Text,
                        Convert.ToInt32(cmbCategory.SelectedValue) > 0 ? Convert.ToInt32(cmbCategory.SelectedValue) : (int?)null);
                    UpdateStatus("🗑️ Course deleted successfully", courseTable?.Rows?.Count ?? 0);
                }
                else
                {
                    MessageBox.Show("Failed to delete course. It may have enrolled students.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting course: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            pnlForm.Visible = false;
            ClearForm();
            UpdateStatus("ℹ️ Operation cancelled", courseTable?.Rows?.Count ?? 0);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();
            if (searchTerm == "Search courses...")
                searchTerm = "";

            int? categoryID = Convert.ToInt32(cmbCategory.SelectedValue) > 0 ?
                Convert.ToInt32(cmbCategory.SelectedValue) : (int?)null;

            LoadCourses(searchTerm, categoryID);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "Search courses...";
            txtSearch.ForeColor = Color.Gray;
            cmbCategory.SelectedValue = 0;
            LoadCourses();
            UpdateStatus("🔄 Refreshed data", courseTable?.Rows?.Count ?? 0);
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Auto-filter when category changes
            if (cmbCategory.SelectedValue != null && Convert.ToInt32(cmbCategory.SelectedValue) >= 0)
            {
                string searchTerm = txtSearch.Text.Trim();
                if (searchTerm == "Search courses...")
                    searchTerm = "";

                int? categoryID = Convert.ToInt32(cmbCategory.SelectedValue) > 0 ?
                    Convert.ToInt32(cmbCategory.SelectedValue) : (int?)null;

                LoadCourses(searchTerm, categoryID);
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search courses...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Search courses...";
                txtSearch.ForeColor = Color.Gray;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "Search courses..." && !string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                string searchTerm = txtSearch.Text.Trim();
                int? categoryID = Convert.ToInt32(cmbCategory.SelectedValue) > 0 ?
                    Convert.ToInt32(cmbCategory.SelectedValue) : (int?)null;
                LoadCourses(searchTerm, categoryID);
            }
            else if (string.IsNullOrWhiteSpace(txtSearch.Text) || txtSearch.Text == "Search courses...")
            {
                int? categoryID = Convert.ToInt32(cmbCategory.SelectedValue) > 0 ?
                    Convert.ToInt32(cmbCategory.SelectedValue) : (int?)null;
                LoadCourses(null, categoryID);
            }
        }

        private void cmbCategory_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}