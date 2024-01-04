using System.Windows.Forms;

namespace XsdToCsharp
{
    public partial class MainForm : Form, ILogListener
    {

        string[] NamingSchemeList = Enum.GetNames(typeof(NamingScheme));
        string[] DataAnnotationModeList = Enum.GetNames(typeof(DataAnnotationMode)); 
        string[] CollectionSettersModeList = Enum.GetNames (typeof(CollectionSettersMode));
        string[] ListTypes = [typeof(List<>).FullName ];
        string[] IntegerTypes = [typeof(int).FullName, typeof(long).FullName];

        DataTable tblFiles;
        DataTable tblNamespaces;

        BindingSource bsFiles;
        BindingSource bsNamespaces;
 

        /* private */
        ProjectSettings Project;

        /* events */
        void AnyClick(object sender, EventArgs e)
        {
            if (btnExit == sender)
            {
                Close();
            }
            else if (btnAbout == sender)
            {
                ShowAboutDialog();
            }
            else if (btnOpenProject == sender)
            {
                OpenProject();
            }
            else if (btnNewProject == sender)
            {
                NewProject();
            }
            else if (btnSaveProject == sender)
            {
                SaveProject();
            }
            else if (btnSaveProjectAs == sender)
            {
                SaveProjectAs();
            }
            else if (btnExecuteProject == sender)
            {
                ExecuteProject();
            }
 
            else if (btnAddFile == sender)
            {
                AddFile();
            }
            else if (btnDeleteFile == sender)
            {
                DeleteFile();
            }

            else if (btnAddNs == sender)
            {
                AddNamespace();
            }
            else if (btnEditNs == sender)
            {
                EditNamespace();
            }
            else if (btnDeleteNs == sender)
            {
                DeleteNamespace();
            }

        }
        void gridNamespaces_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EditNamespace();
        }

        void FormInitialize()
        {
            this.KeyPreview = true;

            btnOpenProject.Click += AnyClick;
            btnNewProject.Click += AnyClick;
            btnSaveProject.Click += AnyClick;
            btnSaveProjectAs.Click += AnyClick;
            btnExecuteProject.Click += AnyClick;
            btnAbout.Click += AnyClick;
            btnExit.Click += AnyClick;

            btnAddFile.Click += AnyClick;
            btnDeleteFile.Click += AnyClick;    

            btnAddNs.Click += AnyClick;
            btnDeleteNs.Click += AnyClick;
            btnEditNs.Click += AnyClick;

            gridNamespaces.MouseDoubleClick += gridNamespaces_MouseDoubleClick;

            cboNamingScheme.Items.AddRange(NamingSchemeList);
            cboDataAnnotationMode.Items.AddRange(DataAnnotationModeList);
            cboCollectionSettersMode.Items.AddRange(CollectionSettersModeList);
            cboCollectionType.Items.AddRange(ListTypes);
            cboIntegerDataType.Items.AddRange(IntegerTypes);

            tblFiles = new DataTable();
            tblFiles.Columns.Add("FilePath");

            tblNamespaces = new DataTable();
            tblNamespaces.Columns.Add("Xsd");
            tblNamespaces.Columns.Add("CSharp");

            bsFiles = new BindingSource();
            bsFiles.DataSource = tblFiles;

            bsNamespaces = new BindingSource();
            bsNamespaces.DataSource = tblNamespaces;

            InitializeGrid(bsFiles, gridFiles);
            InitializeGrid(bsNamespaces, gridNamespaces);

            if (File.Exists(App.Settings.LastProjectPath))
            {
                Project = new ProjectSettings(App.Settings.LastProjectPath);
                ItemToContrls();
            }

            ProjectChanged();
        }
 
        void ProjectChanged()
        {            
            Pager.Visible = Project != null;
            lblProjectName.Text = Project != null ? Project.Name : "";
            lblProjectPath.Text = Project != null ? App.Settings.LastProjectPath : "";
        }
        void LoadProject(string FilePath)
        {
            Project = new ProjectSettings(FilePath);
            ItemToContrls();
            ProjectChanged(); 
        }

        void ItemToContrls()
        {
            // tabGeneral
            edtName.Text = Project.Name;
            edtOutputFolder.Text = Project.OutputFolder;
            edtGlobalNamespace.Text = Project.GlobalNamespace;
            edtNamespacePrefix.Text = Project.NamespacePrefix;
            edtPrivateMemberPrefix.Text = Project.PrivateMemberPrefix;
            edtTextValuePropertyName.Text = Project.TextValuePropertyName;

            SetComboBoxValue(Project.CollectionType, cboCollectionType);
            SetComboBoxValue(Project.IntegerDataType, cboIntegerDataType);
            SetComboBoxValue(Project.CollectionSettersMode.ToString(), cboCollectionSettersMode);
            SetComboBoxValue(Project.NamingScheme.ToString(), cboNamingScheme);
            SetComboBoxValue(Project.DataAnnotationMode.ToString(), cboDataAnnotationMode);

            // tabFlags
            chSeparateClasses.Checked = Project.SeparateClasses;
            chGenerateDescriptionAttribute.Checked = Project.GenerateDescriptionAttribute;
            chDisableComments.Checked = Project.DisableComments;
            chGenerateDebuggerStepThroughAttribute.Checked = Project.GenerateDebuggerStepThroughAttribute;
            chEnableNullableReferenceAttributes.Checked = Project.EnableNullableReferenceAttributes;
            chGenerateNullables.Checked = Project.GenerateNullables;
            chDoNotForceIsNullable.Checked = Project.DoNotForceIsNullable;
            chUseXElementForAny.Checked = Project.UseXElementForAny;
            chEnableDataBinding.Checked = Project.EnableDataBinding;
            chGenerateSerializableAttribute.Checked = Project.GenerateSerializableAttribute;
            chUseShouldSerializePattern.Checked = Project.UseShouldSerializePattern;
            chEnumAsString.Checked = Project.EnumAsString;
            chUseIntegerDataTypeAsFallback.Checked = Project.UseIntegerDataTypeAsFallback;
            chDateTimeWithTimeZone.Checked = Project.DateTimeWithTimeZone;
            chEmitOrder.Checked = Project.EmitOrder;
            chGenerateDesignerCategoryAttribute.Checked = Project.GenerateDesignerCategoryAttribute;
            chEntityFramework.Checked = Project.EntityFramework;
            chGenerateInterfaces.Checked = Project.GenerateInterfaces;
            chAssemblyVisible.Checked = Project.AssemblyVisible;
            chEnableUpaCheck.Checked = Project.EnableUpaCheck;
            chGenerateComplexTypesForCollections.Checked = Project.GenerateComplexTypesForCollections;
            chCompactTypeNames.Checked = Project.CompactTypeNames;
            chSeparateSubstitutes.Checked = Project.SeparateSubstitutes;
            chUniqueTypeNamesAcrossNamespaces.Checked = Project.UniqueTypeNamesAcrossNamespaces;
            chCreateGeneratedCodeAttributeVersion.Checked = Project.CreateGeneratedCodeAttributeVersion;
            chNetCoreSpecificCode.Checked = Project.NetCoreSpecificCode;
            chGenerateCommandLineArgumentsComment.Checked = Project.GenerateCommandLineArgumentsComment;
            chUseArrayItemAttribute.Checked = Project.UseArrayItemAttribute;
            chMapUnionToWidestCommonType.Checked = Project.MapUnionToWidestCommonType;
            chSeparateNamespaceHierarchy.Checked = Project.SeparateNamespaceHierarchy;
                  
            // tabFiles
            tblFiles.DeleteRows();
            tblFiles.AcceptChanges();
            foreach (var FileName in Project.Files)
                tblFiles.Rows.Add(FileName);
            tblFiles.AcceptChanges();

            // tabNamespaces
            tblNamespaces.DeleteRows();
            tblNamespaces.AcceptChanges();
            foreach (var NsPair in Project.Namespaces)
                tblNamespaces.Rows.Add(NsPair.Xsd, NsPair.CSharp);
            tblNamespaces.AcceptChanges();

        }
        void ControlsToItem()
        {
            // tabGeneral
            Project.Name = edtName.Text;
            Project.OutputFolder = edtOutputFolder.Text.Trim();
            Project.GlobalNamespace = edtGlobalNamespace.Text.Trim();
            Project.NamespacePrefix = edtNamespacePrefix.Text.Trim();
            Project.PrivateMemberPrefix = edtPrivateMemberPrefix.Text.Trim();
            Project.TextValuePropertyName = edtTextValuePropertyName.Text.Trim();

            Project.CollectionType = cboCollectionType.Text;
            Project.IntegerDataType = cboIntegerDataType.Text;
            Project.CollectionSettersMode = ToEnum<CollectionSettersMode>(cboCollectionSettersMode.Text);
            Project.NamingScheme = ToEnum<NamingScheme>(cboNamingScheme.Text);
            Project.DataAnnotationMode = ToEnum<DataAnnotationMode>(cboDataAnnotationMode.Text);

            // tabFlags
            Project.SeparateClasses = chSeparateClasses.Checked;
            Project.GenerateDescriptionAttribute = chGenerateDescriptionAttribute.Checked;
            Project.DisableComments = chDisableComments.Checked;
            Project.GenerateDebuggerStepThroughAttribute = chGenerateDebuggerStepThroughAttribute.Checked;
            Project.EnableNullableReferenceAttributes = chEnableNullableReferenceAttributes.Checked;
            Project.GenerateNullables = chGenerateNullables.Checked;
            Project.DoNotForceIsNullable = chDoNotForceIsNullable.Checked;
            Project.UseXElementForAny = chUseXElementForAny.Checked;
            Project.EnableDataBinding = chEnableDataBinding.Checked;
            Project.GenerateSerializableAttribute = chGenerateSerializableAttribute.Checked;
            Project.UseShouldSerializePattern = chUseShouldSerializePattern.Checked;
            Project.EnumAsString = chEnumAsString.Checked;
            Project.UseIntegerDataTypeAsFallback = chUseIntegerDataTypeAsFallback.Checked;
            Project.DateTimeWithTimeZone = chDateTimeWithTimeZone.Checked;
            Project.EmitOrder = chEmitOrder.Checked;
            Project.GenerateDesignerCategoryAttribute = chGenerateDesignerCategoryAttribute.Checked;
            Project.EntityFramework = chEntityFramework.Checked;
            Project.GenerateInterfaces = chGenerateInterfaces.Checked;
            Project.AssemblyVisible = chAssemblyVisible.Checked;
            Project.EnableUpaCheck = chEnableUpaCheck.Checked;
            Project.GenerateComplexTypesForCollections = chGenerateComplexTypesForCollections.Checked;
            Project.CompactTypeNames = chCompactTypeNames.Checked;
            Project.SeparateSubstitutes = chSeparateSubstitutes.Checked;
            Project.UniqueTypeNamesAcrossNamespaces = chUniqueTypeNamesAcrossNamespaces.Checked;
            Project.CreateGeneratedCodeAttributeVersion = chCreateGeneratedCodeAttributeVersion.Checked;
            Project.NetCoreSpecificCode = chNetCoreSpecificCode.Checked;
            Project.GenerateCommandLineArgumentsComment = chGenerateCommandLineArgumentsComment.Checked;
            Project.UseArrayItemAttribute = chUseArrayItemAttribute.Checked;
            Project.MapUnionToWidestCommonType = chMapUnionToWidestCommonType.Checked;
            Project.SeparateNamespaceHierarchy = chSeparateNamespaceHierarchy.Checked;

            // tabFiles
            tblFiles.AcceptChanges();
            Project.Files.Clear();
            foreach (DataRow R in tblFiles.Rows)
                Project.Files.Add(R.AsString("FilePath"));

            // tabNamespaces
            tblNamespaces.AcceptChanges();
            Project.Namespaces.Clear();
            foreach (DataRow R2 in tblNamespaces.Rows)
                Project.Namespaces.Add(new NsPair(R2.AsString("Xsd"), R2.AsString("CSharp"))); 
        }
 
        void OpenProject()
        {
            using (var F = new OpenFileDialog())
            {
                F.Filter = "Json Files (JSON)|*.json";
                F.InitialDirectory = GetLastProjectFolder();

                if (F.ShowDialog() == DialogResult.OK)
                {
                    string FilePath = F.FileName;
                    LoadProject(FilePath);

                    App.Settings.LastProjectPath = FilePath;
                    App.Settings.Save();
                }
            }
        }
        void NewProject()
        {
            using (var F = new SaveFileDialog())
            {
                F.Filter = "Json Files (JSON)|*.json";
                F.InitialDirectory = GetLastProjectFolder();

                if (F.ShowDialog() == DialogResult.OK)
                {
                    string FilePath = F.FileName;
                    Project = new ProjectSettings();
                    Project.Save(FilePath);

                    App.Settings.LastProjectPath = FilePath;
                    App.Settings.Save();

                    LoadProject(FilePath);
                }
            }
        }
        void SaveProject()
        {
            ControlsToItem();

            string FilePath = App.Settings.LastProjectPath;
            Project.Save(FilePath);
            ProjectChanged();

            Log($"Project saved.");
        }
        void SaveProjectAs()
        {
            if (Project != null)
            {
                using (var F = new SaveFileDialog())
                {
                    F.Filter = "Json Files (JSON)|*.json";
                    F.InitialDirectory = GetLastProjectFolder();

                    if (F.ShowDialog() == DialogResult.OK)
                    {
                        ControlsToItem();

                        string FilePath = F.FileName;
                        Project.Save(FilePath);

                        App.Settings.LastProjectPath = FilePath;
                        App.Settings.Save();

                        ProjectChanged();

                    }
                }
            }
        }
        void ExecuteProject()
        {
            LogClear();
            SaveProject();

            if (Project.Files.Count == 0)
                Sys.Throw("Cannot execute project. No XSD files.");

            if (string.IsNullOrWhiteSpace(Project.OutputFolder))
                Sys.Throw("Cannot execute project. No output folder.");

            if (Directory.Exists(Project.OutputFolder))
                Directory.Delete(Project.OutputFolder, true);

            Log("Generating...");
            Generator Gen = new Generator();
            Gen.Log = this.Log;

            // tabGeneral
            Gen.OutputFolder = edtOutputFolder.Text.Trim();
            Gen.NamespacePrefix = edtNamespacePrefix.Text.Trim();
            Gen.PrivateMemberPrefix = edtPrivateMemberPrefix.Text.Trim();
            Gen.TextValuePropertyName = edtTextValuePropertyName.Text.Trim();
 
            Gen.CollectionType = Type.GetType(cboCollectionType.Text);
            Gen.IntegerDataType = Type.GetType(cboIntegerDataType.Text);
            Gen.CollectionSettersMode = ToEnum<CollectionSettersMode>(cboCollectionSettersMode.Text);
            Gen.NamingScheme = ToEnum<NamingScheme>(cboNamingScheme.Text);
            Gen.DataAnnotationMode = ToEnum<DataAnnotationMode>(cboDataAnnotationMode.Text);
 
            // tabFlags
            Gen.SeparateClasses = chSeparateClasses.Checked;
            Gen.GenerateDescriptionAttribute = chGenerateDescriptionAttribute.Checked;
            Gen.DisableComments = chDisableComments.Checked;
            Gen.GenerateDebuggerStepThroughAttribute = chGenerateDebuggerStepThroughAttribute.Checked;
            Gen.EnableNullableReferenceAttributes = chEnableNullableReferenceAttributes.Checked;
            Gen.GenerateNullables = chGenerateNullables.Checked;
            Gen.DoNotForceIsNullable = chDoNotForceIsNullable.Checked;
            Gen.UseXElementForAny = chUseXElementForAny.Checked;
            Gen.EnableDataBinding = chEnableDataBinding.Checked;
            Gen.GenerateSerializableAttribute = chGenerateSerializableAttribute.Checked;
            Gen.UseShouldSerializePattern = chUseShouldSerializePattern.Checked;
            Gen.EnumAsString = chEnumAsString.Checked;
            Gen.UseIntegerDataTypeAsFallback = chUseIntegerDataTypeAsFallback.Checked;
            Gen.DateTimeWithTimeZone = chDateTimeWithTimeZone.Checked;
            Gen.EmitOrder = chEmitOrder.Checked;
            Gen.GenerateDesignerCategoryAttribute = chGenerateDesignerCategoryAttribute.Checked;
            Gen.EntityFramework = chEntityFramework.Checked;
            Gen.GenerateInterfaces = chGenerateInterfaces.Checked;
            Gen.AssemblyVisible = chAssemblyVisible.Checked;
            Gen.EnableUpaCheck = chEnableUpaCheck.Checked;
            Gen.GenerateComplexTypesForCollections = chGenerateComplexTypesForCollections.Checked;
            Gen.CompactTypeNames = chCompactTypeNames.Checked;
            Gen.SeparateSubstitutes = chSeparateSubstitutes.Checked;
            Gen.UniqueTypeNamesAcrossNamespaces = chUniqueTypeNamesAcrossNamespaces.Checked;
            Gen.CreateGeneratedCodeAttributeVersion = chCreateGeneratedCodeAttributeVersion.Checked;
            Gen.NetCoreSpecificCode = chNetCoreSpecificCode.Checked;
            Gen.GenerateCommandLineArgumentsComment = chGenerateCommandLineArgumentsComment.Checked;
            Gen.UseArrayItemAttribute = chUseArrayItemAttribute.Checked;
            Gen.MapUnionToWidestCommonType = chMapUnionToWidestCommonType.Checked;
            Gen.SeparateNamespaceHierarchy = chSeparateNamespaceHierarchy.Checked;

            Dictionary<NamespaceKey, string> NSDic = new Dictionary<NamespaceKey, string>();

            if (!string.IsNullOrWhiteSpace(Project.GlobalNamespace))
            {
                NSDic[new NamespaceKey("")] = Project.GlobalNamespace;
            }
            else if (Project.Namespaces.Count > 0)
            {                
                foreach (NsPair Entry in Project.Namespaces)
                    NSDic[new NamespaceKey(Entry.Xsd)] = Entry.CSharp;                
            }
            else
            {
                Sys.Throw("Cannot execute project. No Global Namespace or XSD to C# namespace mapping defined.");
            }

            Gen.NamespaceProvider = NSDic.ToNamespaceProvider();

            Gen.Generate(Project.Files);

            Log("DONE.");
        }

        void AddFile()
        {
            using (var F = new OpenFileDialog())
            {
                F.Filter = "XSD Files|*.xsd|XML Files|*.xml|All Files|*.*";
                F.InitialDirectory = GetLastProjectFolder();
                F.Multiselect = true;

                if (F.ShowDialog() == DialogResult.OK)
                {
                    foreach (string FileName in F.FileNames)
                        tblFiles.Rows.Add(FileName);
                    tblFiles.AcceptChanges();
                }
            }
        }
        void DeleteFile()
        {
            DataRow Row = GetCurrentRow(gridFiles);
            if (Row != null )
            {
                DataTable Table = Row.Table;
                Row.Delete();
                Table.AcceptChanges();
            }
        }

        void AddNamespace()
        {
            NsPair NsPair = new NsPair();
            if (NamespaceDialog.ShowModal(NsPair))
            {
                tblNamespaces.Rows.Add(NsPair.Xsd, NsPair.CSharp);
                tblNamespaces.AcceptChanges();
            } 
        }
        void EditNamespace()
        {
            DataRow Row = GetCurrentRow(gridNamespaces);
            if (Row != null)
            {
                NsPair NsPair = new NsPair(Row.AsString("Xsd"), Row.AsString("CSharp"));
                if (NamespaceDialog.ShowModal(NsPair))
                {
                    Row["Xsd"] = NsPair.Xsd;
                    Row["CSharp"] = NsPair.CSharp;
                    Row.Table.AcceptChanges();
                }
            }
        }
        void DeleteNamespace()
        {
            DataRow Row = GetCurrentRow(gridNamespaces);
            if (Row != null)
            {
                DataTable Table = Row.Table;
                Row.Delete();
                Table.AcceptChanges();
            }
        } 
 
        string GetLastProjectFolder()
        {
            string FilePath = App.Settings.LastProjectPath;
            return !string.IsNullOrWhiteSpace(FilePath) && File.Exists(FilePath) ? Path.GetDirectoryName(FilePath): Directory.GetCurrentDirectory();
        }
        void ShowAboutDialog()
        {
            using (AboutDialog F = new AboutDialog())
            {
                F.ShowDialog();
            }
        }

        void ScrollToEnd()
        {
            edtLog.SelectionStart = edtLog.Text.Length;
            edtLog.ScrollToCaret();
        }
        public void Log(string LogText)
        {
            void Internal()
            {
                LogText = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}: {LogText}";
                edtLog.AppendText(LogText + Environment.NewLine);
                ScrollToEnd();
            }
            if (!InvokeRequired)
            {
                Internal();
            }
            else
            {
                Invoke(new Action(() =>
                {
                    Internal();
                }));
            }
        }
        public void ProcessLog(LogInfo Info)
        {            
            void Internal()
            {
                string LogText = Bf.In(Info.Level, LogLevel.Fatal | LogLevel.Error) ? Info.ToString() : Info.Text;
                Log(LogText);
            }
            if (!InvokeRequired)
            {
                Internal();
            }
            else
            {
                Invoke(new Action(() =>
                {
                    Internal();
                }));
            }
        }

        public void LogStart(string LogText)
        {
            void Internal()
            {
                LogText = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}: {LogText}";
                edtLog.AppendText(LogText);
            }
            if (!InvokeRequired)
            {
                Internal();
            }
            else
            {
                Invoke(new Action(() =>
                {
                    Internal();
                }));
            }

        }
        public void LogAppend(string LogText)
        {
            void Internal()
            {
                edtLog.AppendText(LogText);
            }
            if (!InvokeRequired)
            {
                Internal();
            }
            else
            {
                Invoke(new Action(() =>
                {
                    Internal();
                }));
            }
            
        }
        public void LogEnd(string LogText)
        {
            void Internal()
            {
                edtLog.AppendText(LogText + Environment.NewLine);
                ScrollToEnd();
            }
            if (!InvokeRequired)
            {
                Internal();
            }
            else
            {
                Invoke(new Action(() =>
                {
                    Internal();
                }));
            }

        }
        public void LogClear()
        {
            void Internal()
            {
                edtLog.Text = string.Empty;
            }
            if (!InvokeRequired)
            {
                Internal();
            }
            else
            {
                Invoke(new Action(() =>
                {
                    Internal();
                }));
            }
            
        }
       
        /* overrides */
        protected override void OnShown(EventArgs e)
        {
            if (!DesignMode)
                FormInitialize();
            base.OnShown(e);
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Control) == Keys.Control && e.KeyCode == Keys.S)
                SaveProject();
                
            base.OnKeyDown(e);
        } 
        
        /* static */
        static public void InitializeGrid(BindingSource bs, DataGridView Grid)
        {
            Grid.AutoGenerateColumns = true;
            Grid.DataSource = bs;
            Grid.ReadOnly = true;
            Grid.AllowUserToAddRows = false;
            Grid.AllowUserToDeleteRows = false;
            Grid.MultiSelect = false;
            Grid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; //.Fill;
            Grid.BorderStyle = BorderStyle.None;
            Grid.GridColor = SystemColors.ScrollBar;
        }
        static public void SetComboBoxValue(string Value, ComboBox Box)
        {
            int Index = Box.Items.IndexOf(Value);
            Index = Index >= 0? Index: 0;
            Box.SelectedIndex = Index;
        }
        static public T ToEnum<T>(string value)
        {
            try
            {
                return (T)Enum.Parse(typeof(T), value, true);
            }
            catch  
            { 
            }

            return default(T);
        }
        static public DataRow GetCurrentRow(DataGridView Grid)
        {
            BindingSource bs = Grid.DataSource as BindingSource;
            DataRow Row = bs.Current is DataRowView ? (bs.Current as DataRowView).Row : null;
            return Row;
        }
        
        /* construction */
        public MainForm()
        {
            InitializeComponent();
        }
    }
}
