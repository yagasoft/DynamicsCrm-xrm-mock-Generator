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
using Yagasoft.XrmMockGenerator.Model.ViewModel;

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
		private TextBox textBoxFilterEntities;
		private Button buttonClearFilter;
		private CheckBox checkBoxGenOnlineCode;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PluginControl));
			this.toolBar = new System.Windows.Forms.ToolStrip();
			this.buttonCloseTool = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonFetchData = new System.Windows.Forms.ToolStripButton();
			this.buttonGenerate = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonLoadSettings = new System.Windows.Forms.ToolStripButton();
			this.buttonSaveSettings = new System.Windows.Forms.ToolStripButton();
			this.comboBoxUsers = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.listBoxEntities = new System.Windows.Forms.ListBox();
			this.listBoxForms = new System.Windows.Forms.ListBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.buttonAdd = new System.Windows.Forms.Button();
			this.buttonRemove = new System.Windows.Forms.Button();
			this.dataGridSelectedForms = new System.Windows.Forms.DataGridView();
			this.label5 = new System.Windows.Forms.Label();
			this.textBoxFilterEntities = new System.Windows.Forms.TextBox();
			this.buttonClearFilter = new System.Windows.Forms.Button();
			this.checkBoxGenOnlineCode = new System.Windows.Forms.CheckBox();
			this.toolBar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridSelectedForms)).BeginInit();
			this.SuspendLayout();
			// 
			// toolBar
			// 
			this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonCloseTool,
            this.toolStripSeparator1,
            this.buttonFetchData,
            this.buttonGenerate,
            this.toolStripSeparator2,
            this.buttonLoadSettings,
            this.buttonSaveSettings});
			this.toolBar.Location = new System.Drawing.Point(0, 0);
			this.toolBar.Name = "toolBar";
			this.toolBar.Size = new System.Drawing.Size(943, 25);
			this.toolBar.TabIndex = 0;
			this.toolBar.Text = "toolBar";
			// 
			// buttonCloseTool
			// 
			this.buttonCloseTool.Image = ((System.Drawing.Image)(resources.GetObject("buttonCloseTool.Image")));
			this.buttonCloseTool.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonCloseTool.Name = "buttonCloseTool";
			this.buttonCloseTool.Size = new System.Drawing.Size(82, 22);
			this.buttonCloseTool.Text = "Close Tool";
			this.buttonCloseTool.Click += new System.EventHandler(this.BtnCloseClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// buttonFetchData
			// 
			this.buttonFetchData.Image = ((System.Drawing.Image)(resources.GetObject("buttonFetchData.Image")));
			this.buttonFetchData.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonFetchData.Name = "buttonFetchData";
			this.buttonFetchData.Size = new System.Drawing.Size(83, 22);
			this.buttonFetchData.Text = "Fetch Data";
			this.buttonFetchData.Click += new System.EventHandler(this.buttonFetchData_Click);
			// 
			// buttonGenerate
			// 
			this.buttonGenerate.Image = ((System.Drawing.Image)(resources.GetObject("buttonGenerate.Image")));
			this.buttonGenerate.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonGenerate.Name = "buttonGenerate";
			this.buttonGenerate.Size = new System.Drawing.Size(74, 22);
			this.buttonGenerate.Text = "Generate";
			this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// buttonLoadSettings
			// 
			this.buttonLoadSettings.Image = ((System.Drawing.Image)(resources.GetObject("buttonLoadSettings.Image")));
			this.buttonLoadSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonLoadSettings.Name = "buttonLoadSettings";
			this.buttonLoadSettings.Size = new System.Drawing.Size(98, 22);
			this.buttonLoadSettings.Text = "Load Settings";
			this.buttonLoadSettings.Click += new System.EventHandler(this.buttonLoadSettings_Click);
			// 
			// buttonSaveSettings
			// 
			this.buttonSaveSettings.Image = ((System.Drawing.Image)(resources.GetObject("buttonSaveSettings.Image")));
			this.buttonSaveSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonSaveSettings.Name = "buttonSaveSettings";
			this.buttonSaveSettings.Size = new System.Drawing.Size(96, 22);
			this.buttonSaveSettings.Text = "Save Settings";
			this.buttonSaveSettings.Click += new System.EventHandler(this.buttonSaveSettings_Click);
			// 
			// comboBoxUsers
			// 
			this.comboBoxUsers.FormattingEnabled = true;
			this.comboBoxUsers.Location = new System.Drawing.Point(81, 26);
			this.comboBoxUsers.Name = "comboBoxUsers";
			this.comboBoxUsers.Size = new System.Drawing.Size(327, 21);
			this.comboBoxUsers.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 29);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(71, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Select a User";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label2.Location = new System.Drawing.Point(1, 50);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(942, 2);
			this.label2.TabIndex = 3;
			// 
			// listBoxEntities
			// 
			this.listBoxEntities.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.listBoxEntities.FormattingEnabled = true;
			this.listBoxEntities.Location = new System.Drawing.Point(10, 98);
			this.listBoxEntities.Name = "listBoxEntities";
			this.listBoxEntities.Size = new System.Drawing.Size(196, 368);
			this.listBoxEntities.TabIndex = 4;
			this.listBoxEntities.SelectedIndexChanged += new System.EventHandler(this.listBoxEntities_SelectedIndexChanged);
			this.listBoxEntities.DoubleClick += new System.EventHandler(this.listBoxEntities_DoubleClick);
			// 
			// listBoxForms
			// 
			this.listBoxForms.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.listBoxForms.FormattingEnabled = true;
			this.listBoxForms.Location = new System.Drawing.Point(212, 72);
			this.listBoxForms.Name = "listBoxForms";
			this.listBoxForms.Size = new System.Drawing.Size(196, 394);
			this.listBoxForms.TabIndex = 5;
			this.listBoxForms.SelectedIndexChanged += new System.EventHandler(this.listBoxForms_SelectedIndexChanged);
			this.listBoxForms.DoubleClick += new System.EventHandler(this.listBoxForms_DoubleClick);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(7, 56);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(49, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Entities";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(209, 56);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "Forms";
			// 
			// buttonAdd
			// 
			this.buttonAdd.Location = new System.Drawing.Point(415, 170);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(35, 23);
			this.buttonAdd.TabIndex = 8;
			this.buttonAdd.Text = ">>";
			this.buttonAdd.UseVisualStyleBackColor = true;
			this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
			// 
			// buttonRemove
			// 
			this.buttonRemove.Location = new System.Drawing.Point(415, 200);
			this.buttonRemove.Name = "buttonRemove";
			this.buttonRemove.Size = new System.Drawing.Size(35, 23);
			this.buttonRemove.TabIndex = 9;
			this.buttonRemove.Text = "<<";
			this.buttonRemove.UseVisualStyleBackColor = true;
			this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
			// 
			// dataGridSelectedForms
			// 
			this.dataGridSelectedForms.AllowUserToAddRows = false;
			this.dataGridSelectedForms.AllowUserToDeleteRows = false;
			this.dataGridSelectedForms.AllowUserToOrderColumns = true;
			this.dataGridSelectedForms.AllowUserToResizeRows = false;
			this.dataGridSelectedForms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridSelectedForms.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dataGridSelectedForms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridSelectedForms.Location = new System.Drawing.Point(456, 72);
			this.dataGridSelectedForms.Name = "dataGridSelectedForms";
			this.dataGridSelectedForms.ReadOnly = true;
			this.dataGridSelectedForms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridSelectedForms.Size = new System.Drawing.Size(484, 394);
			this.dataGridSelectedForms.TabIndex = 10;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(453, 56);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(94, 13);
			this.label5.TabIndex = 11;
			this.label5.Text = "Selected Forms";
			// 
			// textBoxFilterEntities
			// 
			this.textBoxFilterEntities.Location = new System.Drawing.Point(10, 72);
			this.textBoxFilterEntities.Name = "textBoxFilterEntities";
			this.textBoxFilterEntities.Size = new System.Drawing.Size(154, 20);
			this.textBoxFilterEntities.TabIndex = 12;
			this.textBoxFilterEntities.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxFilterEntities_KeyUp);
			// 
			// buttonClearFilter
			// 
			this.buttonClearFilter.Location = new System.Drawing.Point(166, 70);
			this.buttonClearFilter.Name = "buttonClearFilter";
			this.buttonClearFilter.Size = new System.Drawing.Size(40, 23);
			this.buttonClearFilter.TabIndex = 13;
			this.buttonClearFilter.Text = "Clear";
			this.buttonClearFilter.UseVisualStyleBackColor = true;
			this.buttonClearFilter.Click += new System.EventHandler(this.buttonClearFilter_Click);
			// 
			// checkBoxGenOnlineCode
			// 
			this.checkBoxGenOnlineCode.AutoSize = true;
			this.checkBoxGenOnlineCode.Location = new System.Drawing.Point(456, 28);
			this.checkBoxGenOnlineCode.Name = "checkBoxGenOnlineCode";
			this.checkBoxGenOnlineCode.Size = new System.Drawing.Size(206, 17);
			this.checkBoxGenOnlineCode.TabIndex = 14;
			this.checkBoxGenOnlineCode.Text = "Generate Online Communication Code";
			this.checkBoxGenOnlineCode.UseVisualStyleBackColor = true;
			this.checkBoxGenOnlineCode.CheckedChanged += new System.EventHandler(this.checkBoxGenOnlineCode_CheckedChanged);
			// 
			// PluginControl
			// 
			this.Controls.Add(this.checkBoxGenOnlineCode);
			this.Controls.Add(this.buttonClearFilter);
			this.Controls.Add(this.textBoxFilterEntities);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.dataGridSelectedForms);
			this.Controls.Add(this.buttonRemove);
			this.Controls.Add(this.buttonAdd);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.listBoxForms);
			this.Controls.Add(this.listBoxEntities);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboBoxUsers);
			this.Controls.Add(this.toolBar);
			this.Name = "PluginControl";
			this.Size = new System.Drawing.Size(943, 477);
			this.toolBar.ResumeLayout(false);
			this.toolBar.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridSelectedForms)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public event EventHandler<StatusBarMessageEventArgs> SendMessageToStatusBar;

		#region Event handlers

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

		private void textBoxFilterEntities_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				FilterEntities(textBoxFilterEntities.Text);
			}
		}

		private void buttonClearFilter_Click(object sender, EventArgs e)
		{
			ClearEntityFilter();
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

							var templateModel =
								new T4TemplateModel
								{
									IsGenerateOnlineCode = ControlData.IsGenerateOnlineCode,
									Models = models
								};

							w.ReportProgress(95, $"Generating TypeScript code ...");
							var page = new XrmMockGeneratorTemplate(templateModel);
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
			SettingsManager.Instance.TryLoad(typeof(XrmMockGeneratorPlugin), out PluginSettings pluginSettings);

			var saveDialogue =
				new SaveFileDialog
				{
					Title = "Save models ...",
					OverwritePrompt = true,
					Filter = "JSON files (*.json)|*.json",
				};

			if (pluginSettings?.LatestPath.IsNotEmpty() == true)
			{
				saveDialogue.FileName = Path.GetFileName(pluginSettings.LatestPath);
				saveDialogue.InitialDirectory = Path.GetDirectoryName(pluginSettings.LatestPath);
			}
			else
			{
				saveDialogue.FileName = "xrm-mock-generator-settings.json";
			}

			var result = saveDialogue.ShowDialog();

			if (result == DialogResult.OK && saveDialogue.FileName.IsNotEmpty())
			{
				var settings =
					new Settings
					{
						IsGenerateOnlineCode = ControlData.IsGenerateOnlineCode,
						SelectedUserId = ((UserViewModel)comboBoxUsers.SelectedItem)?.Id ?? Guid.Empty,
						SelectedForms = ControlData.SelectedForms.Select(f => f.Id.GetValueOrDefault()).ToList()
					};

				if (!Path.HasExtension(saveDialogue.FileName))
				{
					saveDialogue.FileName += ".json";
				}

				using (var stream = (FileStream)saveDialogue.OpenFile())
				{
					var array = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(settings));
					stream.Write(array, 0, array.Length);
				}

				if (pluginSettings == null)
				{
					pluginSettings = new PluginSettings();
				}

				pluginSettings.LatestPath = saveDialogue.FileName;
				SettingsManager.Instance.Save(typeof(XrmMockGeneratorPlugin), pluginSettings);
			}
		}

		private void buttonLoadSettings_Click(object sender, EventArgs e)
		{
			SettingsManager.Instance.TryLoad(typeof(XrmMockGeneratorPlugin), out PluginSettings pluginSettings);

			var openDialogue =
				new OpenFileDialog
				{
					Title = "Load models ...",
					Filter = "JSON files (*.json)|*.json",
				};

			if (pluginSettings?.LatestPath.IsNotEmpty() == true)
			{
				openDialogue.FileName = Path.GetFileName(pluginSettings.LatestPath);
				openDialogue.InitialDirectory = Path.GetDirectoryName(pluginSettings.LatestPath);
			}

			var result = openDialogue.ShowDialog();

			if (result == DialogResult.OK && openDialogue.FileName.IsNotEmpty())
			{
				using (var reader = new StreamReader(openDialogue.FileName))
				{
					var settings = JsonConvert.DeserializeObject<Settings>(reader.ReadToEnd());
					checkBoxGenOnlineCode.Checked = settings.IsGenerateOnlineCode.GetValueOrDefault();
					ControlData.SelectedForms = ControlData.Forms
						.Where(f => settings.SelectedForms.Any(ff => f.Id == ff)).ToList();
					RefreshDataGrid();
				}

				if (pluginSettings == null)
				{
					pluginSettings = new PluginSettings();
				}

				pluginSettings.LatestPath = openDialogue.FileName;
				SettingsManager.Instance.Save(typeof(XrmMockGeneratorPlugin), pluginSettings);
			}
		}

		private void checkBoxGenOnlineCode_CheckedChanged(object sender, EventArgs e)
		{
			ControlData.IsGenerateOnlineCode = checkBoxGenOnlineCode.Checked;
		}

		#endregion

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
							w.ReportProgress(90, $"Retrieving entity names ...");
							var entityNames = DataHelpers.RetrieveEntityNames(Service);

							e.Result =
								new RetrieveResult
								{
									Users = users,
									Forms = forms,
									EntityNames = entityNames
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

							var users = result.Users.Cast<object>().ToArray();
							comboBoxUsers.Items.AddRange(users);
							comboBoxUsers.SelectedIndex =
								comboBoxUsers.SelectedIndex < 0 && users.Any() ? 0 : comboBoxUsers.SelectedIndex;

							ControlData.Forms = result.Forms.ToList();

							var formEntities = ControlData.Forms.Select(f => f.ObjectTypeCode).Distinct().ToArray();
							ControlData.EntityNames = result.EntityNames
								.Where(n => formEntities.Contains(n.LogicalName)).ToList();

							Invoke(new Action(
								() =>
								{
									ClearEntityFilter();
									buttonLoadSettings.Enabled = true;
								}));
						},
					AsyncArgument = null,
					IsCancelable = false,
					MessageWidth = 340,
					MessageHeight = 150
				});
		}

		private void ListEntityForms()
		{
			listBoxForms.SelectedIndex = -1;
			listBoxForms.Items.Clear();
			listBoxForms.Items
				.AddRange(ControlData.Forms
					.Where(f => f.ObjectTypeCode == ((EntityNameViewModel)listBoxEntities.SelectedItem)?.LogicalName)
					.OrderBy(p => p.Name).Cast<object>().ToArray());

			if (listBoxForms.Items.Count > 0)
			{
				listBoxForms.SelectedIndex = 0;
			}
		}

		private void FilterEntities(string keyword)
		{
			listBoxEntities.SelectedIndex = -1;
			listBoxEntities.Items.Clear();
			listBoxEntities.Items
				.AddRange(ControlData.EntityNames
					.Where(e => e.LogicalName.Contains(keyword) || e.DisplayName.Contains(keyword))
					.OrderBy(e => e).Cast<object>().ToArray());
		}

		private void ClearEntityFilter()
		{
			textBoxFilterEntities.Text = string.Empty;
			FilterEntities(string.Empty);
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
	}
}
