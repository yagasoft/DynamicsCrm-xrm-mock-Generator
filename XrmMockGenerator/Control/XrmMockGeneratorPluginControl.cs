#region Imports

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LinkDev.Libraries.Common;
using Newtonsoft.Json;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Args;
using XrmToolBox.Extensibility.Interfaces;
using Yagasoft.XrmMockGenerator.Generator;
using Yagasoft.XrmMockGenerator.Helpers;
using Yagasoft.XrmMockGenerator.Model;
using Yagasoft.XrmMockGenerator.Model.Generator;

#endregion

namespace Yagasoft.XrmMockGenerator.Control
{
	public partial class PluginControl : PluginControlBase, IStatusBarMessenger
	{
		private ToolStripButton buttonCloseTool;
		private ToolStripSeparator toolStripSeparator1;
		private ToolStripButton buttonFetchData;
		private ToolStripSeparator toolStripSeparator2;
		private ToolStripButton buttonLoadSettings;
		private ToolStripButton buttonSaveSettings;
		private ComboBox comboBoxUsers;
		private Label label1;
		private Label label2;
		private ListBox listBoxEntities;
		private ListBox listBoxForms;
		private Label label3;
		private Label label4;
		private Button buttonAdd;
		private Button buttonRemove;
		private DataGridView dataGridSelectedForms;
		private Label label5;
		private ToolStripButton buttonGenerate;
		private ToolStrip toolBar;

		#region Base tool implementation

		public PluginControl()
		{
			InitializeComponent();

			buttonAdd.Enabled = false;
			buttonRemove.Enabled = false;
			buttonGenerate.Enabled = false;
			buttonLoadSettings.Enabled = false;
			buttonSaveSettings.Enabled = false;

			dataGridSelectedForms.Columns.Add("Id", "Form ID");
			dataGridSelectedForms.Columns["Id"].Visible = false;
			dataGridSelectedForms.Columns.Add("ObjectTypeCode", "Entity");
			dataGridSelectedForms.Columns.Add("Name", "Form Name");
		}

		private void BtnCloseClick(object sender, EventArgs e)
		{
			CloseTool(); // PluginBaseControl method that notifies the XrmToolBox that the user wants to close the plugin
			// Override the ClosingPlugin method to allow for any plugin specific closing logic to be performed (saving configs, canceling close, etc...)
		}

		//private void btnCancel_Click(object sender, EventArgs e)
		//{
		//	CancelWorker(); // PluginBaseControl method that calls the Background Workers CancelAsync method.

		//	MessageBox.Show("Cancelled");
		//}

		#endregion Base tool implementation

		#region UI Generated

		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(PluginControl));
			toolBar = new ToolStrip();
			buttonCloseTool = new ToolStripButton();
			toolStripSeparator1 = new ToolStripSeparator();
			buttonFetchData = new ToolStripButton();
			buttonGenerate = new ToolStripButton();
			toolStripSeparator2 = new ToolStripSeparator();
			buttonLoadSettings = new ToolStripButton();
			buttonSaveSettings = new ToolStripButton();
			comboBoxUsers = new ComboBox();
			label1 = new Label();
			label2 = new Label();
			listBoxEntities = new ListBox();
			listBoxForms = new ListBox();
			label3 = new Label();
			label4 = new Label();
			buttonAdd = new Button();
			buttonRemove = new Button();
			dataGridSelectedForms = new DataGridView();
			label5 = new Label();
			toolBar.SuspendLayout();
			((ISupportInitialize)(dataGridSelectedForms)).BeginInit();
			SuspendLayout();
			// 
			// toolBar
			// 
			toolBar.Items.AddRange(new ToolStripItem[]
								   {
									   buttonCloseTool,
									   toolStripSeparator1,
									   buttonFetchData,
									   buttonGenerate,
									   toolStripSeparator2,
									   buttonLoadSettings,
									   buttonSaveSettings
								   });
			toolBar.Location = new Point(0, 0);
			toolBar.Name = "toolBar";
			toolBar.Size = new Size(943, 25);
			toolBar.TabIndex = 0;
			toolBar.Text = "toolBar";
			// 
			// buttonCloseTool
			// 
			buttonCloseTool.Image = ((Image)(resources.GetObject("buttonCloseTool.Image")));
			buttonCloseTool.ImageTransparentColor = Color.Magenta;
			buttonCloseTool.Name = "buttonCloseTool";
			buttonCloseTool.Size = new Size(82, 22);
			buttonCloseTool.Text = "Close Tool";
			buttonCloseTool.Click += new EventHandler(BtnCloseClick);
			// 
			// toolStripSeparator1
			// 
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new Size(6, 25);
			// 
			// buttonFetchData
			// 
			buttonFetchData.Image = ((Image)(resources.GetObject("buttonFetchData.Image")));
			buttonFetchData.ImageTransparentColor = Color.Magenta;
			buttonFetchData.Name = "buttonFetchData";
			buttonFetchData.Size = new Size(83, 22);
			buttonFetchData.Text = "Fetch Data";
			buttonFetchData.Click += new EventHandler(buttonFetchData_Click);
			// 
			// buttonGenerate
			// 
			buttonGenerate.Image = ((Image)(resources.GetObject("buttonGenerate.Image")));
			buttonGenerate.ImageTransparentColor = Color.Magenta;
			buttonGenerate.Name = "buttonGenerate";
			buttonGenerate.Size = new Size(74, 22);
			buttonGenerate.Text = "Generate";
			buttonGenerate.Click += new EventHandler(buttonGenerate_Click);
			// 
			// toolStripSeparator2
			// 
			toolStripSeparator2.Name = "toolStripSeparator2";
			toolStripSeparator2.Size = new Size(6, 25);
			// 
			// buttonLoadSettings
			// 
			buttonLoadSettings.Image = ((Image)(resources.GetObject("buttonLoadSettings.Image")));
			buttonLoadSettings.ImageTransparentColor = Color.Magenta;
			buttonLoadSettings.Name = "buttonLoadSettings";
			buttonLoadSettings.Size = new Size(98, 22);
			buttonLoadSettings.Text = "Load Settings";
			buttonLoadSettings.Click += new EventHandler(buttonLoadSettings_Click);
			// 
			// buttonSaveSettings
			// 
			buttonSaveSettings.Image = ((Image)(resources.GetObject("buttonSaveSettings.Image")));
			buttonSaveSettings.ImageTransparentColor = Color.Magenta;
			buttonSaveSettings.Name = "buttonSaveSettings";
			buttonSaveSettings.Size = new Size(96, 22);
			buttonSaveSettings.Text = "Save Settings";
			buttonSaveSettings.Click += new EventHandler(buttonSaveSettings_Click);
			// 
			// comboBoxUsers
			// 
			comboBoxUsers.FormattingEnabled = true;
			comboBoxUsers.Location = new Point(81, 26);
			comboBoxUsers.Name = "comboBoxUsers";
			comboBoxUsers.Size = new Size(297, 21);
			comboBoxUsers.TabIndex = 1;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(4, 29);
			label1.Name = "label1";
			label1.Size = new Size(71, 13);
			label1.TabIndex = 2;
			label1.Text = "Select a User";
			// 
			// label2
			// 
			label2.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left)
				| AnchorStyles.Right)));
			label2.BorderStyle = BorderStyle.Fixed3D;
			label2.Location = new Point(1, 50);
			label2.Name = "label2";
			label2.Size = new Size(942, 2);
			label2.TabIndex = 3;
			// 
			// listBoxEntities
			// 
			listBoxEntities.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom)
				| AnchorStyles.Left)));
			listBoxEntities.FormattingEnabled = true;
			listBoxEntities.Location = new Point(10, 72);
			listBoxEntities.Name = "listBoxEntities";
			listBoxEntities.Size = new Size(196, 394);
			listBoxEntities.TabIndex = 4;
			listBoxEntities.SelectedIndexChanged += new EventHandler(listBoxEntities_SelectedIndexChanged);
			listBoxEntities.DoubleClick += new EventHandler(listBoxEntities_DoubleClick);
			// 
			// listBoxForms
			// 
			listBoxForms.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom)
				| AnchorStyles.Left)));
			listBoxForms.FormattingEnabled = true;
			listBoxForms.Location = new Point(212, 72);
			listBoxForms.Name = "listBoxForms";
			listBoxForms.Size = new Size(196, 394);
			listBoxForms.TabIndex = 5;
			listBoxForms.SelectedIndexChanged += new EventHandler(listBoxForms_SelectedIndexChanged);
			listBoxForms.DoubleClick += new EventHandler(listBoxForms_DoubleClick);
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
			label3.Location = new Point(7, 56);
			label3.Name = "label3";
			label3.Size = new Size(49, 13);
			label3.TabIndex = 6;
			label3.Text = "Entities";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
			label4.Location = new Point(209, 56);
			label4.Name = "label4";
			label4.Size = new Size(40, 13);
			label4.TabIndex = 7;
			label4.Text = "Forms";
			// 
			// buttonAdd
			// 
			buttonAdd.Location = new Point(415, 170);
			buttonAdd.Name = "buttonAdd";
			buttonAdd.Size = new Size(35, 23);
			buttonAdd.TabIndex = 8;
			buttonAdd.Text = ">>";
			buttonAdd.UseVisualStyleBackColor = true;
			buttonAdd.Click += new EventHandler(buttonAdd_Click);
			// 
			// buttonRemove
			// 
			buttonRemove.Location = new Point(415, 200);
			buttonRemove.Name = "buttonRemove";
			buttonRemove.Size = new Size(35, 23);
			buttonRemove.TabIndex = 9;
			buttonRemove.Text = "<<";
			buttonRemove.UseVisualStyleBackColor = true;
			buttonRemove.Click += new EventHandler(buttonRemove_Click);
			// 
			// dataGridSelectedForms
			// 
			dataGridSelectedForms.AllowUserToAddRows = false;
			dataGridSelectedForms.AllowUserToDeleteRows = false;
			dataGridSelectedForms.AllowUserToOrderColumns = true;
			dataGridSelectedForms.AllowUserToResizeRows = false;
			dataGridSelectedForms.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom)
				| AnchorStyles.Left)
				| AnchorStyles.Right)));
			dataGridSelectedForms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			dataGridSelectedForms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridSelectedForms.Location = new Point(456, 72);
			dataGridSelectedForms.Name = "dataGridSelectedForms";
			dataGridSelectedForms.ReadOnly = true;
			dataGridSelectedForms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridSelectedForms.Size = new Size(484, 394);
			dataGridSelectedForms.TabIndex = 10;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
			label5.Location = new Point(453, 56);
			label5.Name = "label5";
			label5.Size = new Size(94, 13);
			label5.TabIndex = 11;
			label5.Text = "Selected Forms";
			// 
			// PluginControl
			// 
			Controls.Add(label5);
			Controls.Add(dataGridSelectedForms);
			Controls.Add(buttonRemove);
			Controls.Add(buttonAdd);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(listBoxForms);
			Controls.Add(listBoxEntities);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(comboBoxUsers);
			Controls.Add(toolBar);
			Name = "PluginControl";
			Size = new Size(943, 477);
			toolBar.ResumeLayout(false);
			toolBar.PerformLayout();
			((ISupportInitialize)(dataGridSelectedForms)).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		public event EventHandler<StatusBarMessageEventArgs> SendMessageToStatusBar;

		private void buttonFetchData_Click(object sender, EventArgs e)
		{
			ExecuteMethod(FetchData);
		}

		private void listBoxEntities_SelectedIndexChanged(object sender, EventArgs e)
		{
			ListEntityForms();
			buttonAdd.Enabled = listBoxForms.SelectedIndex >= 0;
		}

		private void listBoxEntities_DoubleClick(object sender, EventArgs e)
		{
			ListEntityForms();
			AddSelectedForm();
		}

		private void ListEntityForms()
		{
			listBoxForms.SelectedIndex = -1;
			listBoxForms.Items.Clear();
			listBoxForms.Items
				.AddRange(ControlData.Forms
					.Where(f => f.ObjectTypeCode == (string)listBoxEntities.SelectedItem)
					.OrderBy(p => p.Name).ToArray());

			if (listBoxForms.Items.Count > 0)
			{
				listBoxForms.SelectedIndex = 0;
			}
		}

		private void listBoxForms_SelectedIndexChanged(object sender, EventArgs e)
		{
			buttonAdd.Enabled = listBoxForms.SelectedIndex >= 0;
		}

		private void listBoxForms_DoubleClick(object sender, EventArgs e)
		{
			AddSelectedForm();
		}

		private void buttonAdd_Click(object sender, EventArgs e)
		{
			AddSelectedForm();
		}

		private void buttonRemove_Click(object sender, EventArgs e)
		{
			foreach (DataGridViewRow selectedRow in dataGridSelectedForms.SelectedRows)
			{
				ControlData.SelectedForms.RemoveAll(f => f.Id == (Guid)selectedRow.Cells["Id"].Value);
			}

			RefreshDataGrid();
		}

		private void AddSelectedForm()
		{
			var selectedForm = (SystemFormViewModel)listBoxForms.SelectedItem;

			if (ControlData.SelectedForms.Any(f => f.Id == selectedForm.Id))
			{
				return;
			}

			ControlData.SelectedForms.Add(selectedForm);
			RefreshDataGrid();
		}

		private void RefreshDataGrid()
		{
			dataGridSelectedForms.Rows.Clear();

			foreach (var form in ControlData.SelectedForms.OrderBy(f => f.ObjectTypeCode).ThenBy(f => f.Name))
			{
				dataGridSelectedForms.Rows.Add(form.Id, form.ObjectTypeCode, form.Name);
			}

			Invoke(new Action(
				() =>
				{
					var isEnabled = ControlData.SelectedForms.Any();
					buttonRemove.Enabled = isEnabled;
					buttonGenerate.Enabled = isEnabled;
					buttonSaveSettings.Enabled = isEnabled;
				}));
		}

		private void buttonGenerate_Click(object sender, EventArgs eArgs)
		{
			var selectedUser = (UserViewModel)comboBoxUsers.SelectedItem;

			if (selectedUser == null)
			{
				MessageBox.Show($"Must select a user before generating the model.", "Error Generating XRM Model",
					MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return;
			}

			toolBar.Enabled = false;

			WorkAsync(
				new WorkAsyncInfo
				{
					Message = "Retrieving data ...",
					Work =
						(w, e) =>
						{
							w.ReportProgress(0, $"Generating XRM Model ...");

							var groupedForms = ControlData.SelectedForms
								.GroupBy(f => f.ObjectTypeCode).ToList();
							var modelGenerator = new ModelGenerator();
							var models = new List<XrmModel>();

							for (var i = 0; i < groupedForms.Count; i++)
							{
								var group = groupedForms[i];
								w.ReportProgress((i + 1) / groupedForms.Count * 90, $"Generating model for {group.Key} ...");

								models.Add(
									modelGenerator.Generate(
										Service,
										new ModelGeneratorParams
										{
											SelectedUserId = selectedUser.Id.GetValueOrDefault(),
											EntityName = group.Key,
											SelectedForms = group.Select(g => g.Id.GetValueOrDefault()).ToList()
										}));
							}

							w.ReportProgress(95, $"Generating TypeScript code ...");
							var page = new XrmMockGeneratorTemplate(models);
							var pageContent = page.TransformText();

							e.Result = pageContent;
						},
					ProgressChanged =
						e =>
						{
							// If progress has to be notified to user, use the following method:
							SetWorkingMessage(e.UserState.ToString());

							// If progress has to be notified to user, through the
							// status bar, use the following method
							SendMessageToStatusBar?.Invoke(this,
								new StatusBarMessageEventArgs(e.ProgressPercentage, e.UserState.ToString()));
						},
					PostWorkCallBack =
						e =>
						{
							SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(""));

							var result = (string)e.Result;
							var saveDialogue =
								new SaveFileDialog
								{
									Title = "Save XRM Model ...",
									OverwritePrompt = true,
									Filter = "TypeScript files (*.ts)|*.ts",
									FileName = "xrm.model.ts"
								};
							saveDialogue.ShowDialog();

							if (saveDialogue.FileName.IsNotEmpty())
							{
								using (var stream = (FileStream)saveDialogue.OpenFile())
								{
									var array = Encoding.UTF8.GetBytes(result);
									stream.Write(array, 0, array.Length);
								}
							}

							toolBar.Enabled = true;
						},
					AsyncArgument = null,
					IsCancelable = false,
					MessageWidth = 340,
					MessageHeight = 150
				});
		}

		private void buttonSaveSettings_Click(object sender, EventArgs e)
		{
			var saveDialogue =
				new SaveFileDialog
				{
					Title = "Save models ...",
					OverwritePrompt = true,
					Filter = "JSON files (*.json)|*.json",
					FileName = "xrm-mock-generator-settings.json"
				};
			saveDialogue.ShowDialog();

			if (saveDialogue.FileName.IsNotEmpty())
			{
				var settings =
					new Settings
					{
						SelectedUserId = ((UserViewModel)comboBoxUsers.SelectedItem)?.Id ?? Guid.Empty,
						SelectedForms = ControlData.SelectedForms.Select(f => f.Id.GetValueOrDefault()).ToList()
					};

				using (var stream = (FileStream)saveDialogue.OpenFile())
				{
					var array = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(settings));
					stream.Write(array, 0, array.Length);
				}
			}
		}

		private void buttonLoadSettings_Click(object sender, EventArgs e)
		{
			var openDialogue =
				new OpenFileDialog
				{
					Title = "Load models ...",
					Filter = "JSON files (*.json)|*.json",
					FileName = "xrm-mock-generator-settings.json"
				};
			var result = openDialogue.ShowDialog();

			if (result == DialogResult.OK)
			{
				using (var reader = new StreamReader(openDialogue.FileName))
				{
					var settings = JsonConvert.DeserializeObject<Settings>(reader.ReadToEnd());
					ControlData.SelectedForms = ControlData.Forms
						.Where(f => settings.SelectedForms.Any(ff => f.Id == ff)).ToList();
					RefreshDataGrid();
				}
			}
		}

		private void FetchData()
		{
			comboBoxUsers.SelectedIndex = -1;
			comboBoxUsers.Text = "";
			comboBoxUsers.Items.Clear();
			listBoxEntities.SelectedIndex = -1;
			listBoxEntities.Items.Clear();
			listBoxForms.SelectedIndex = -1;
			listBoxForms.Items.Clear();

			buttonAdd.Enabled = false;
			buttonRemove.Enabled = false;

			WorkAsync(
				new WorkAsyncInfo
				{
					Message = "Retrieving data ...",
					Work =
						(w, e) =>
						{
							w.ReportProgress(0, $"Retrieving users ...");
							var users = DataHelpers.RetrieveUsers(Service);
							w.ReportProgress(50, $"Retrieving forms ...");
							var forms = DataHelpers.RetrieveForms(Service);

							e.Result =
								new RetrieveResult
								{
									Users = users,
									Forms = forms
								};
						},
					ProgressChanged =
						e =>
						{
							// If progress has to be notified to user, use the following method:
							SetWorkingMessage(e.UserState.ToString());

							// If progress has to be notified to user, through the
							// status bar, use the following method
							SendMessageToStatusBar?.Invoke(this,
								new StatusBarMessageEventArgs(e.ProgressPercentage, e.UserState.ToString()));
						},
					PostWorkCallBack =
						e =>
						{
							SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(""));
							var result = (RetrieveResult)e.Result;

							comboBoxUsers.Items.AddRange(result.Users.ToArray());

							ControlData.Forms = result.Forms;
							listBoxEntities.Items.AddRange(result.Forms.Select(f => f.ObjectTypeCode).Distinct().OrderBy(p => p).ToArray());

							Invoke(new Action(
								() => { buttonLoadSettings.Enabled = true; }));
						},
					AsyncArgument = null,
					IsCancelable = false,
					MessageWidth = 340,
					MessageHeight = 150
				});
		}
	}
}
