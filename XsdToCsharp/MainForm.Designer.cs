namespace XsdToCsharp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            ToolBar = new ToolStrip();
            btnExecuteProject = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnOpenProject = new ToolStripButton();
            btnNewProject = new ToolStripButton();
            btnSaveProject = new ToolStripButton();
            btnSaveProjectAs = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            btnAbout = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            btnExit = new ToolStripButton();
            statusStrip1 = new StatusStrip();
            lblProjectName = new ToolStripStatusLabel();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            lblProjectPath = new ToolStripStatusLabel();
            Pager = new TabControl();
            tabGeneral = new TabPage();
            edtGlobalNamespace = new TextBox();
            label11 = new Label();
            textBox1 = new TextBox();
            cboDataAnnotationMode = new ComboBox();
            cboNamingScheme = new ComboBox();
            cboCollectionSettersMode = new ComboBox();
            cboIntegerDataType = new ComboBox();
            cboCollectionType = new ComboBox();
            edtTextValuePropertyName = new TextBox();
            edtPrivateMemberPrefix = new TextBox();
            edtNamespacePrefix = new TextBox();
            edtOutputFolder = new TextBox();
            edtName = new TextBox();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            tabFlags = new TabPage();
            chSeparateNamespaceHierarchy = new CheckBox();
            chMapUnionToWidestCommonType = new CheckBox();
            chUseArrayItemAttribute = new CheckBox();
            chGenerateCommandLineArgumentsComment = new CheckBox();
            chNetCoreSpecificCode = new CheckBox();
            chCreateGeneratedCodeAttributeVersion = new CheckBox();
            chUniqueTypeNamesAcrossNamespaces = new CheckBox();
            chCompactTypeNames = new CheckBox();
            chSeparateSubstitutes = new CheckBox();
            chSeparateClasses = new CheckBox();
            chGenerateComplexTypesForCollections = new CheckBox();
            chEnableUpaCheck = new CheckBox();
            chDoNotForceIsNullable = new CheckBox();
            chDisableComments = new CheckBox();
            chAssemblyVisible = new CheckBox();
            chGenerateDescriptionAttribute = new CheckBox();
            chGenerateInterfaces = new CheckBox();
            chEntityFramework = new CheckBox();
            chDateTimeWithTimeZone = new CheckBox();
            chUseIntegerDataTypeAsFallback = new CheckBox();
            chGenerateDesignerCategoryAttribute = new CheckBox();
            chGenerateDebuggerStepThroughAttribute = new CheckBox();
            chGenerateSerializableAttribute = new CheckBox();
            chUseShouldSerializePattern = new CheckBox();
            chGenerateNullables = new CheckBox();
            chEmitOrder = new CheckBox();
            chEnableNullableReferenceAttributes = new CheckBox();
            chUseXElementForAny = new CheckBox();
            chEnableDataBinding = new CheckBox();
            chEnumAsString = new CheckBox();
            tabFiles = new TabPage();
            gridFiles = new DataGridView();
            panel2 = new Panel();
            btnDeleteFile = new Button();
            btnAddFile = new Button();
            tabNamespaces = new TabPage();
            gridNamespaces = new DataGridView();
            panel1 = new Panel();
            btnAddNs = new Button();
            btnDeleteNs = new Button();
            btnEditNs = new Button();
            Splitter = new SplitContainer();
            edtLog = new RichTextBox();
            tabPlusFlags = new TabPage();
            chNormalNullables = new CheckBox();
            chUseBackingField = new CheckBox();
            chUseSpecified = new CheckBox();
            ToolBar.SuspendLayout();
            statusStrip1.SuspendLayout();
            Pager.SuspendLayout();
            tabGeneral.SuspendLayout();
            tabFlags.SuspendLayout();
            tabFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridFiles).BeginInit();
            panel2.SuspendLayout();
            tabNamespaces.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridNamespaces).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Splitter).BeginInit();
            Splitter.Panel1.SuspendLayout();
            Splitter.Panel2.SuspendLayout();
            Splitter.SuspendLayout();
            tabPlusFlags.SuspendLayout();
            SuspendLayout();
            // 
            // ToolBar
            // 
            ToolBar.ImageScalingSize = new Size(32, 32);
            ToolBar.Items.AddRange(new ToolStripItem[] { btnExecuteProject, toolStripSeparator1, btnOpenProject, btnNewProject, btnSaveProject, btnSaveProjectAs, toolStripSeparator3, btnAbout, toolStripSeparator2, btnExit });
            ToolBar.Location = new Point(0, 0);
            ToolBar.Name = "ToolBar";
            ToolBar.Size = new Size(1008, 39);
            ToolBar.TabIndex = 0;
            ToolBar.Text = "toolStrip1";
            // 
            // btnExecuteProject
            // 
            btnExecuteProject.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnExecuteProject.Image = Properties.Resources.table_lightning;
            btnExecuteProject.ImageTransparentColor = Color.Magenta;
            btnExecuteProject.Name = "btnExecuteProject";
            btnExecuteProject.Size = new Size(36, 36);
            btnExecuteProject.Text = "Execute Project";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 39);
            // 
            // btnOpenProject
            // 
            btnOpenProject.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnOpenProject.Image = Properties.Resources.table_import;
            btnOpenProject.ImageTransparentColor = Color.Magenta;
            btnOpenProject.Name = "btnOpenProject";
            btnOpenProject.Size = new Size(36, 36);
            btnOpenProject.Text = "Open Project";
            // 
            // btnNewProject
            // 
            btnNewProject.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnNewProject.Image = Properties.Resources.table_add;
            btnNewProject.ImageTransparentColor = Color.Magenta;
            btnNewProject.Name = "btnNewProject";
            btnNewProject.Size = new Size(36, 36);
            btnNewProject.Text = "New Project";
            // 
            // btnSaveProject
            // 
            btnSaveProject.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnSaveProject.Image = Properties.Resources.table_save;
            btnSaveProject.ImageTransparentColor = Color.Magenta;
            btnSaveProject.Name = "btnSaveProject";
            btnSaveProject.Size = new Size(36, 36);
            btnSaveProject.Text = "Save Project";
            // 
            // btnSaveProjectAs
            // 
            btnSaveProjectAs.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnSaveProjectAs.Image = Properties.Resources.save_as;
            btnSaveProjectAs.ImageTransparentColor = Color.Magenta;
            btnSaveProjectAs.Name = "btnSaveProjectAs";
            btnSaveProjectAs.Size = new Size(36, 36);
            btnSaveProjectAs.Text = "Save Project As";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 39);
            // 
            // btnAbout
            // 
            btnAbout.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnAbout.Image = Properties.Resources.information;
            btnAbout.ImageTransparentColor = Color.Magenta;
            btnAbout.Name = "btnAbout";
            btnAbout.Size = new Size(36, 36);
            btnAbout.Text = "About";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 39);
            // 
            // btnExit
            // 
            btnExit.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnExit.Image = Properties.Resources.door_out;
            btnExit.ImageTransparentColor = Color.Magenta;
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(36, 36);
            btnExit.Text = "Exit";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblProjectName, toolStripStatusLabel1, lblProjectPath });
            statusStrip1.Location = new Point(0, 719);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1008, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblProjectName
            // 
            lblProjectName.Name = "lblProjectName";
            lblProjectName.Size = new Size(79, 17);
            lblProjectName.Text = "Project Name";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.AutoSize = false;
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(16, 17);
            // 
            // lblProjectPath
            // 
            lblProjectPath.Name = "lblProjectPath";
            lblProjectPath.Size = new Size(93, 17);
            lblProjectPath.Text = "Project Full Path";
            // 
            // Pager
            // 
            Pager.Controls.Add(tabGeneral);
            Pager.Controls.Add(tabFlags);
            Pager.Controls.Add(tabPlusFlags);
            Pager.Controls.Add(tabFiles);
            Pager.Controls.Add(tabNamespaces);
            Pager.Dock = DockStyle.Fill;
            Pager.Location = new Point(0, 0);
            Pager.Name = "Pager";
            Pager.SelectedIndex = 0;
            Pager.Size = new Size(1008, 616);
            Pager.TabIndex = 2;
            // 
            // tabGeneral
            // 
            tabGeneral.Controls.Add(edtGlobalNamespace);
            tabGeneral.Controls.Add(label11);
            tabGeneral.Controls.Add(textBox1);
            tabGeneral.Controls.Add(cboDataAnnotationMode);
            tabGeneral.Controls.Add(cboNamingScheme);
            tabGeneral.Controls.Add(cboCollectionSettersMode);
            tabGeneral.Controls.Add(cboIntegerDataType);
            tabGeneral.Controls.Add(cboCollectionType);
            tabGeneral.Controls.Add(edtTextValuePropertyName);
            tabGeneral.Controls.Add(edtPrivateMemberPrefix);
            tabGeneral.Controls.Add(edtNamespacePrefix);
            tabGeneral.Controls.Add(edtOutputFolder);
            tabGeneral.Controls.Add(edtName);
            tabGeneral.Controls.Add(label10);
            tabGeneral.Controls.Add(label9);
            tabGeneral.Controls.Add(label8);
            tabGeneral.Controls.Add(label7);
            tabGeneral.Controls.Add(label6);
            tabGeneral.Controls.Add(label5);
            tabGeneral.Controls.Add(label4);
            tabGeneral.Controls.Add(label3);
            tabGeneral.Controls.Add(label2);
            tabGeneral.Controls.Add(label1);
            tabGeneral.Location = new Point(4, 24);
            tabGeneral.Name = "tabGeneral";
            tabGeneral.Padding = new Padding(3);
            tabGeneral.Size = new Size(1000, 588);
            tabGeneral.TabIndex = 0;
            tabGeneral.Text = "General";
            tabGeneral.UseVisualStyleBackColor = true;
            // 
            // edtGlobalNamespace
            // 
            edtGlobalNamespace.Location = new Point(166, 59);
            edtGlobalNamespace.Name = "edtGlobalNamespace";
            edtGlobalNamespace.Size = new Size(460, 23);
            edtGlobalNamespace.TabIndex = 22;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(51, 63);
            label11.Name = "label11";
            label11.Size = new Size(106, 15);
            label11.TabIndex = 21;
            label11.Text = "Global Namespace";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(25, 394);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(950, 176);
            textBox1.TabIndex = 20;
            textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // cboDataAnnotationMode
            // 
            cboDataAnnotationMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDataAnnotationMode.FormattingEnabled = true;
            cboDataAnnotationMode.Location = new Point(166, 357);
            cboDataAnnotationMode.Name = "cboDataAnnotationMode";
            cboDataAnnotationMode.Size = new Size(225, 23);
            cboDataAnnotationMode.TabIndex = 19;
            // 
            // cboNamingScheme
            // 
            cboNamingScheme.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNamingScheme.FormattingEnabled = true;
            cboNamingScheme.Location = new Point(166, 329);
            cboNamingScheme.Name = "cboNamingScheme";
            cboNamingScheme.Size = new Size(225, 23);
            cboNamingScheme.TabIndex = 18;
            // 
            // cboCollectionSettersMode
            // 
            cboCollectionSettersMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCollectionSettersMode.FormattingEnabled = true;
            cboCollectionSettersMode.Location = new Point(166, 281);
            cboCollectionSettersMode.Name = "cboCollectionSettersMode";
            cboCollectionSettersMode.Size = new Size(225, 23);
            cboCollectionSettersMode.TabIndex = 17;
            // 
            // cboIntegerDataType
            // 
            cboIntegerDataType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboIntegerDataType.FormattingEnabled = true;
            cboIntegerDataType.Location = new Point(166, 250);
            cboIntegerDataType.Name = "cboIntegerDataType";
            cboIntegerDataType.Size = new Size(225, 23);
            cboIntegerDataType.TabIndex = 16;
            // 
            // cboCollectionType
            // 
            cboCollectionType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCollectionType.FormattingEnabled = true;
            cboCollectionType.Location = new Point(166, 221);
            cboCollectionType.Name = "cboCollectionType";
            cboCollectionType.Size = new Size(225, 23);
            cboCollectionType.TabIndex = 15;
            // 
            // edtTextValuePropertyName
            // 
            edtTextValuePropertyName.Location = new Point(166, 178);
            edtTextValuePropertyName.Name = "edtTextValuePropertyName";
            edtTextValuePropertyName.Size = new Size(460, 23);
            edtTextValuePropertyName.TabIndex = 14;
            // 
            // edtPrivateMemberPrefix
            // 
            edtPrivateMemberPrefix.Location = new Point(166, 147);
            edtPrivateMemberPrefix.Name = "edtPrivateMemberPrefix";
            edtPrivateMemberPrefix.Size = new Size(460, 23);
            edtPrivateMemberPrefix.TabIndex = 13;
            // 
            // edtNamespacePrefix
            // 
            edtNamespacePrefix.Location = new Point(166, 119);
            edtNamespacePrefix.Name = "edtNamespacePrefix";
            edtNamespacePrefix.Size = new Size(460, 23);
            edtNamespacePrefix.TabIndex = 12;
            // 
            // edtOutputFolder
            // 
            edtOutputFolder.Location = new Point(166, 89);
            edtOutputFolder.Name = "edtOutputFolder";
            edtOutputFolder.Size = new Size(460, 23);
            edtOutputFolder.TabIndex = 11;
            // 
            // edtName
            // 
            edtName.Location = new Point(166, 20);
            edtName.Name = "edtName";
            edtName.Size = new Size(460, 23);
            edtName.TabIndex = 10;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(25, 284);
            label10.Name = "label10";
            label10.Size = new Size(132, 15);
            label10.TabIndex = 9;
            label10.Text = "Collection setters mode";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(61, 252);
            label9.Name = "label9";
            label9.Size = new Size(96, 15);
            label9.TabIndex = 8;
            label9.Text = "Integer data type";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(70, 224);
            label8.Name = "label8";
            label8.Size = new Size(87, 15);
            label8.TabIndex = 7;
            label8.Text = "Collection type";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(31, 360);
            label7.Name = "label7";
            label7.Size = new Size(126, 15);
            label7.TabIndex = 6;
            label7.Text = "Data annotation mode";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(63, 332);
            label6.Name = "label6";
            label6.Size = new Size(94, 15);
            label6.TabIndex = 5;
            label6.Text = "Naming scheme";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(17, 182);
            label5.Name = "label5";
            label5.Size = new Size(140, 15);
            label5.TabIndex = 4;
            label5.Text = "Text value property name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(28, 151);
            label4.Name = "label4";
            label4.Size = new Size(129, 15);
            label4.TabIndex = 3;
            label4.Text = "Private members prefix";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(55, 123);
            label3.Name = "label3";
            label3.Size = new Size(102, 15);
            label3.TabIndex = 2;
            label3.Text = "Namespace prefix";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(78, 92);
            label2.Name = "label2";
            label2.Size = new Size(79, 15);
            label2.TabIndex = 1;
            label2.Text = "Output folder";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(78, 21);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 0;
            label1.Text = "Project Name";
            // 
            // tabFlags
            // 
            tabFlags.AutoScroll = true;
            tabFlags.Controls.Add(chSeparateNamespaceHierarchy);
            tabFlags.Controls.Add(chMapUnionToWidestCommonType);
            tabFlags.Controls.Add(chUseArrayItemAttribute);
            tabFlags.Controls.Add(chGenerateCommandLineArgumentsComment);
            tabFlags.Controls.Add(chNetCoreSpecificCode);
            tabFlags.Controls.Add(chCreateGeneratedCodeAttributeVersion);
            tabFlags.Controls.Add(chUniqueTypeNamesAcrossNamespaces);
            tabFlags.Controls.Add(chCompactTypeNames);
            tabFlags.Controls.Add(chSeparateSubstitutes);
            tabFlags.Controls.Add(chSeparateClasses);
            tabFlags.Controls.Add(chGenerateComplexTypesForCollections);
            tabFlags.Controls.Add(chEnableUpaCheck);
            tabFlags.Controls.Add(chDoNotForceIsNullable);
            tabFlags.Controls.Add(chDisableComments);
            tabFlags.Controls.Add(chAssemblyVisible);
            tabFlags.Controls.Add(chGenerateDescriptionAttribute);
            tabFlags.Controls.Add(chGenerateInterfaces);
            tabFlags.Controls.Add(chEntityFramework);
            tabFlags.Controls.Add(chDateTimeWithTimeZone);
            tabFlags.Controls.Add(chUseIntegerDataTypeAsFallback);
            tabFlags.Controls.Add(chGenerateDesignerCategoryAttribute);
            tabFlags.Controls.Add(chGenerateDebuggerStepThroughAttribute);
            tabFlags.Controls.Add(chGenerateSerializableAttribute);
            tabFlags.Controls.Add(chUseShouldSerializePattern);
            tabFlags.Controls.Add(chGenerateNullables);
            tabFlags.Controls.Add(chEmitOrder);
            tabFlags.Controls.Add(chEnableNullableReferenceAttributes);
            tabFlags.Controls.Add(chUseXElementForAny);
            tabFlags.Controls.Add(chEnableDataBinding);
            tabFlags.Controls.Add(chEnumAsString);
            tabFlags.Location = new Point(4, 24);
            tabFlags.Name = "tabFlags";
            tabFlags.Padding = new Padding(3);
            tabFlags.Size = new Size(1000, 588);
            tabFlags.TabIndex = 1;
            tabFlags.Text = "Flags";
            tabFlags.UseVisualStyleBackColor = true;
            // 
            // chSeparateNamespaceHierarchy
            // 
            chSeparateNamespaceHierarchy.AutoSize = true;
            chSeparateNamespaceHierarchy.Location = new Point(8, 637);
            chSeparateNamespaceHierarchy.Name = "chSeparateNamespaceHierarchy";
            chSeparateNamespaceHierarchy.Size = new Size(496, 19);
            chSeparateNamespaceHierarchy.TabIndex = 29;
            chSeparateNamespaceHierarchy.Text = "Separate Namespace Hierarchy. Separates namespace hierarchy by folder. Default is false.";
            chSeparateNamespaceHierarchy.UseVisualStyleBackColor = true;
            // 
            // chMapUnionToWidestCommonType
            // 
            chMapUnionToWidestCommonType.AutoSize = true;
            chMapUnionToWidestCommonType.Location = new Point(8, 616);
            chMapUnionToWidestCommonType.Name = "chMapUnionToWidestCommonType";
            chMapUnionToWidestCommonType.Size = new Size(1395, 19);
            chMapUnionToWidestCommonType.TabIndex = 28;
            chMapUnionToWidestCommonType.Text = resources.GetString("chMapUnionToWidestCommonType.Text");
            chMapUnionToWidestCommonType.UseVisualStyleBackColor = true;
            // 
            // chUseArrayItemAttribute
            // 
            chUseArrayItemAttribute.AutoSize = true;
            chUseArrayItemAttribute.Location = new Point(8, 592);
            chUseArrayItemAttribute.Name = "chUseArrayItemAttribute";
            chUseArrayItemAttribute.Size = new Size(623, 19);
            chUseArrayItemAttribute.TabIndex = 27;
            chUseArrayItemAttribute.Text = "Use ArrayItem Attribute. Enables use of XmlArrayItemAttribute for sequences with single elements. Default is true.";
            chUseArrayItemAttribute.UseVisualStyleBackColor = true;
            // 
            // chGenerateCommandLineArgumentsComment
            // 
            chGenerateCommandLineArgumentsComment.AutoSize = true;
            chGenerateCommandLineArgumentsComment.Location = new Point(8, 570);
            chGenerateCommandLineArgumentsComment.Name = "chGenerateCommandLineArgumentsComment";
            chGenerateCommandLineArgumentsComment.Size = new Size(1137, 19);
            chGenerateCommandLineArgumentsComment.TabIndex = 26;
            chGenerateCommandLineArgumentsComment.Text = "Generate CommandLine Arguments Comment.Adds a comment with the exact command line arguments that were used to generate the source code using the CommandLineArgumentsProvider. Default is false.";
            chGenerateCommandLineArgumentsComment.UseVisualStyleBackColor = true;
            // 
            // chNetCoreSpecificCode
            // 
            chNetCoreSpecificCode.AutoSize = true;
            chNetCoreSpecificCode.Location = new Point(8, 548);
            chNetCoreSpecificCode.Name = "chNetCoreSpecificCode";
            chNetCoreSpecificCode.Size = new Size(714, 19);
            chNetCoreSpecificCode.TabIndex = 25;
            chNetCoreSpecificCode.Text = "Net Core Specific Code. Generate code that works with .NET Core but might be incompatible with .NET Framework. Default is false.";
            chNetCoreSpecificCode.UseVisualStyleBackColor = true;
            // 
            // chCreateGeneratedCodeAttributeVersion
            // 
            chCreateGeneratedCodeAttributeVersion.AutoSize = true;
            chCreateGeneratedCodeAttributeVersion.Location = new Point(8, 525);
            chCreateGeneratedCodeAttributeVersion.Name = "chCreateGeneratedCodeAttributeVersion";
            chCreateGeneratedCodeAttributeVersion.Size = new Size(601, 19);
            chCreateGeneratedCodeAttributeVersion.TabIndex = 24;
            chCreateGeneratedCodeAttributeVersion.Text = "Create GeneratedCodeAttribute Version. Adds version information to GeneratedCodeAttribute. Default is true.";
            chCreateGeneratedCodeAttributeVersion.UseVisualStyleBackColor = true;
            // 
            // chUniqueTypeNamesAcrossNamespaces
            // 
            chUniqueTypeNamesAcrossNamespaces.AutoSize = true;
            chUniqueTypeNamesAcrossNamespaces.Location = new Point(8, 503);
            chUniqueTypeNamesAcrossNamespaces.Name = "chUniqueTypeNamesAcrossNamespaces";
            chUniqueTypeNamesAcrossNamespaces.Size = new Size(878, 19);
            chUniqueTypeNamesAcrossNamespaces.TabIndex = 23;
            chUniqueTypeNamesAcrossNamespaces.Text = "Unique Type Name Across Namespaces. Create unique type names across all namespaces. See https://github.com/mganss/XmlSchemaClassGenerator/issues/240";
            chUniqueTypeNamesAcrossNamespaces.UseVisualStyleBackColor = true;
            // 
            // chCompactTypeNames
            // 
            chCompactTypeNames.AutoSize = true;
            chCompactTypeNames.Location = new Point(8, 460);
            chCompactTypeNames.Name = "chCompactTypeNames";
            chCompactTypeNames.Size = new Size(571, 19);
            chCompactTypeNames.TabIndex = 22;
            chCompactTypeNames.Text = "Compact Type Names. Generates type names without namespace qualifiers for namespaces in using list";
            chCompactTypeNames.UseVisualStyleBackColor = true;
            // 
            // chSeparateSubstitutes
            // 
            chSeparateSubstitutes.AutoSize = true;
            chSeparateSubstitutes.Location = new Point(8, 481);
            chSeparateSubstitutes.Name = "chSeparateSubstitutes";
            chSeparateSubstitutes.Size = new Size(510, 19);
            chSeparateSubstitutes.TabIndex = 21;
            chSeparateSubstitutes.Text = "Separate Substitutes. Generates a separate property for each element of a substitution group";
            chSeparateSubstitutes.UseVisualStyleBackColor = true;
            // 
            // chSeparateClasses
            // 
            chSeparateClasses.AutoSize = true;
            chSeparateClasses.Location = new Point(8, 6);
            chSeparateClasses.Name = "chSeparateClasses";
            chSeparateClasses.Size = new Size(338, 19);
            chSeparateClasses.TabIndex = 20;
            chSeparateClasses.Text = "Separate Classes. Separates each class into an individual file";
            chSeparateClasses.UseVisualStyleBackColor = true;
            // 
            // chGenerateComplexTypesForCollections
            // 
            chGenerateComplexTypesForCollections.AutoSize = true;
            chGenerateComplexTypesForCollections.Location = new Point(8, 439);
            chGenerateComplexTypesForCollections.Name = "chGenerateComplexTypesForCollections";
            chGenerateComplexTypesForCollections.Size = new Size(1034, 19);
            chGenerateComplexTypesForCollections.TabIndex = 19;
            chGenerateComplexTypesForCollections.Text = "Generate Complex Types For Collections. When a ComplexType has a member that is used as a collection around another ComplexType the serializer will output the intermediate ComplexType.";
            chGenerateComplexTypesForCollections.UseVisualStyleBackColor = true;
            // 
            // chEnableUpaCheck
            // 
            chEnableUpaCheck.AutoSize = true;
            chEnableUpaCheck.Location = new Point(8, 416);
            chEnableUpaCheck.Name = "chEnableUpaCheck";
            chEnableUpaCheck.Size = new Size(409, 19);
            chEnableUpaCheck.TabIndex = 18;
            chEnableUpaCheck.Text = "Enable Upa Check. Check for Unique Particle Attribution (UPA) violations";
            chEnableUpaCheck.UseVisualStyleBackColor = true;
            // 
            // chDoNotForceIsNullable
            // 
            chDoNotForceIsNullable.AutoSize = true;
            chDoNotForceIsNullable.Location = new Point(8, 129);
            chDoNotForceIsNullable.Name = "chDoNotForceIsNullable";
            chDoNotForceIsNullable.Size = new Size(1085, 19);
            chDoNotForceIsNullable.TabIndex = 17;
            chDoNotForceIsNullable.Text = resources.GetString("chDoNotForceIsNullable.Text");
            chDoNotForceIsNullable.UseVisualStyleBackColor = true;
            // 
            // chDisableComments
            // 
            chDisableComments.AutoSize = true;
            chDisableComments.Location = new Point(8, 46);
            chDisableComments.Name = "chDisableComments";
            chDisableComments.Size = new Size(320, 19);
            chDisableComments.TabIndex = 16;
            chDisableComments.Text = "Disable Comments. Do not include comments from xsd";
            chDisableComments.UseVisualStyleBackColor = true;
            // 
            // chAssemblyVisible
            // 
            chAssemblyVisible.AutoSize = true;
            chAssemblyVisible.Location = new Point(8, 394);
            chAssemblyVisible.Name = "chAssemblyVisible";
            chAssemblyVisible.Size = new Size(385, 19);
            chAssemblyVisible.TabIndex = 15;
            chAssemblyVisible.Text = "Assembly Visible. Generate types as internal if true. public otherwise.";
            chAssemblyVisible.UseVisualStyleBackColor = true;
            // 
            // chGenerateDescriptionAttribute
            // 
            chGenerateDescriptionAttribute.AutoSize = true;
            chGenerateDescriptionAttribute.Location = new Point(8, 26);
            chGenerateDescriptionAttribute.Name = "chGenerateDescriptionAttribute";
            chGenerateDescriptionAttribute.Size = new Size(471, 19);
            chGenerateDescriptionAttribute.TabIndex = 14;
            chGenerateDescriptionAttribute.Text = "Generate Description Attribute.  Generate DescriptionAttribute from XML comments.";
            chGenerateDescriptionAttribute.UseVisualStyleBackColor = true;
            // 
            // chGenerateInterfaces
            // 
            chGenerateInterfaces.AutoSize = true;
            chGenerateInterfaces.Location = new Point(8, 372);
            chGenerateInterfaces.Name = "chGenerateInterfaces";
            chGenerateInterfaces.Size = new Size(403, 19);
            chGenerateInterfaces.TabIndex = 13;
            chGenerateInterfaces.Text = "Generate Interfaces. Generate interfaces for groups and attribute groups";
            chGenerateInterfaces.UseVisualStyleBackColor = true;
            // 
            // chEntityFramework
            // 
            chEntityFramework.AutoSize = true;
            chEntityFramework.Location = new Point(8, 350);
            chEntityFramework.Name = "chEntityFramework";
            chEntityFramework.Size = new Size(424, 19);
            chEntityFramework.TabIndex = 12;
            chEntityFramework.Text = "Entity Framework. Generate Entity Framework Code First compatible classes";
            chEntityFramework.UseVisualStyleBackColor = true;
            // 
            // chDateTimeWithTimeZone
            // 
            chDateTimeWithTimeZone.AutoSize = true;
            chDateTimeWithTimeZone.Location = new Point(8, 283);
            chDateTimeWithTimeZone.Name = "chDateTimeWithTimeZone";
            chDateTimeWithTimeZone.Size = new Size(489, 19);
            chDateTimeWithTimeZone.TabIndex = 11;
            chDateTimeWithTimeZone.Text = "DateTime With TimeZone. Generate DateTimeOffset properties for xs:dateTime elements";
            chDateTimeWithTimeZone.UseVisualStyleBackColor = true;
            // 
            // chUseIntegerDataTypeAsFallback
            // 
            chUseIntegerDataTypeAsFallback.AutoSize = true;
            chUseIntegerDataTypeAsFallback.Location = new Point(8, 260);
            chUseIntegerDataTypeAsFallback.Name = "chUseIntegerDataTypeAsFallback";
            chUseIntegerDataTypeAsFallback.Size = new Size(510, 19);
            chUseIntegerDataTypeAsFallback.TabIndex = 10;
            chUseIntegerDataTypeAsFallback.Text = "Use Integer DataType As Fallback. Use integer data type only if no better type can be inferred";
            chUseIntegerDataTypeAsFallback.UseVisualStyleBackColor = true;
            // 
            // chGenerateDesignerCategoryAttribute
            // 
            chGenerateDesignerCategoryAttribute.AutoSize = true;
            chGenerateDesignerCategoryAttribute.Location = new Point(8, 328);
            chGenerateDesignerCategoryAttribute.Name = "chGenerateDesignerCategoryAttribute";
            chGenerateDesignerCategoryAttribute.Size = new Size(442, 19);
            chGenerateDesignerCategoryAttribute.TabIndex = 9;
            chGenerateDesignerCategoryAttribute.Text = "Generate DesignerCategory Attribute. Generate the DesignerCategoryAttribute?";
            chGenerateDesignerCategoryAttribute.UseVisualStyleBackColor = true;
            // 
            // chGenerateDebuggerStepThroughAttribute
            // 
            chGenerateDebuggerStepThroughAttribute.AutoSize = true;
            chGenerateDebuggerStepThroughAttribute.Location = new Point(8, 66);
            chGenerateDebuggerStepThroughAttribute.Name = "chGenerateDebuggerStepThroughAttribute";
            chGenerateDebuggerStepThroughAttribute.Size = new Size(494, 19);
            chGenerateDebuggerStepThroughAttribute.TabIndex = 8;
            chGenerateDebuggerStepThroughAttribute.Text = "Generate DebuggerStepThrough Attribute. Generate the DebuggerStepThroughAttribute?";
            chGenerateDebuggerStepThroughAttribute.UseVisualStyleBackColor = true;
            // 
            // chGenerateSerializableAttribute
            // 
            chGenerateSerializableAttribute.AutoSize = true;
            chGenerateSerializableAttribute.Location = new Point(8, 193);
            chGenerateSerializableAttribute.Name = "chGenerateSerializableAttribute";
            chGenerateSerializableAttribute.Size = new Size(371, 19);
            chGenerateSerializableAttribute.TabIndex = 7;
            chGenerateSerializableAttribute.Text = "Generate Serializable Attribute. Generate the Serializable attribute?";
            chGenerateSerializableAttribute.UseVisualStyleBackColor = true;
            // 
            // chUseShouldSerializePattern
            // 
            chUseShouldSerializePattern.AutoSize = true;
            chUseShouldSerializePattern.Location = new Point(8, 216);
            chUseShouldSerializePattern.Name = "chUseShouldSerializePattern";
            chUseShouldSerializePattern.Size = new Size(523, 19);
            chUseShouldSerializePattern.TabIndex = 6;
            chUseShouldSerializePattern.Text = "Use ShouldSerialize Pattern. Use ShouldSerialize pattern in where possible to support nullables?";
            chUseShouldSerializePattern.UseVisualStyleBackColor = true;
            // 
            // chGenerateNullables
            // 
            chGenerateNullables.AutoSize = true;
            chGenerateNullables.Location = new Point(8, 108);
            chGenerateNullables.Name = "chGenerateNullables";
            chGenerateNullables.Size = new Size(399, 19);
            chGenerateNullables.TabIndex = 5;
            chGenerateNullables.Text = "Generate Nullables. Generate Nullable members for optional elements?";
            chGenerateNullables.UseVisualStyleBackColor = true;
            // 
            // chEmitOrder
            // 
            chEmitOrder.AutoSize = true;
            chEmitOrder.Location = new Point(8, 306);
            chEmitOrder.Name = "chEmitOrder";
            chEmitOrder.Size = new Size(699, 19);
            chEmitOrder.TabIndex = 4;
            chEmitOrder.Text = "Emit Order. Emit the \"Order\" attribute value for XmlElementAttribute to ensure the correct order  of the serialized XML elements.";
            chEmitOrder.UseVisualStyleBackColor = true;
            // 
            // chEnableNullableReferenceAttributes
            // 
            chEnableNullableReferenceAttributes.AutoSize = true;
            chEnableNullableReferenceAttributes.Location = new Point(8, 87);
            chEnableNullableReferenceAttributes.Name = "chEnableNullableReferenceAttributes";
            chEnableNullableReferenceAttributes.Size = new Size(849, 19);
            chEnableNullableReferenceAttributes.TabIndex = 3;
            chEnableNullableReferenceAttributes.Text = "Enable Nullable Reference Attributes. Generate attributes for nullable references to avoid compiler-warnings in .NET Core and Standard with nullable-checks.";
            chEnableNullableReferenceAttributes.UseVisualStyleBackColor = true;
            // 
            // chUseXElementForAny
            // 
            chUseXElementForAny.AutoSize = true;
            chUseXElementForAny.Location = new Point(8, 150);
            chUseXElementForAny.Name = "chUseXElementForAny";
            chUseXElementForAny.Size = new Size(424, 19);
            chUseXElementForAny.TabIndex = 2;
            chUseXElementForAny.Text = "Use XElement For Any. Use XElement instead of XmlElement for Any nodes?";
            chUseXElementForAny.UseVisualStyleBackColor = true;
            // 
            // chEnableDataBinding
            // 
            chEnableDataBinding.AutoSize = true;
            chEnableDataBinding.Location = new Point(8, 171);
            chEnableDataBinding.Name = "chEnableDataBinding";
            chEnableDataBinding.Size = new Size(401, 19);
            chEnableDataBinding.TabIndex = 1;
            chEnableDataBinding.Text = "Enable Data Binding. Enable data binding with INotifyPropertyChanged";
            chEnableDataBinding.UseVisualStyleBackColor = true;
            // 
            // chEnumAsString
            // 
            chEnumAsString.AutoSize = true;
            chEnumAsString.Location = new Point(8, 238);
            chEnumAsString.Name = "chEnumAsString";
            chEnumAsString.Size = new Size(346, 19);
            chEnumAsString.TabIndex = 0;
            chEnumAsString.Text = "Enum As String. Use string instead of enum for enumeration.";
            chEnumAsString.UseVisualStyleBackColor = true;
            // 
            // tabFiles
            // 
            tabFiles.Controls.Add(gridFiles);
            tabFiles.Controls.Add(panel2);
            tabFiles.Location = new Point(4, 24);
            tabFiles.Name = "tabFiles";
            tabFiles.Padding = new Padding(3);
            tabFiles.Size = new Size(1000, 588);
            tabFiles.TabIndex = 2;
            tabFiles.Text = "Xsd Files";
            tabFiles.UseVisualStyleBackColor = true;
            // 
            // gridFiles
            // 
            gridFiles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridFiles.Dock = DockStyle.Fill;
            gridFiles.Location = new Point(3, 42);
            gridFiles.Name = "gridFiles";
            gridFiles.Size = new Size(994, 543);
            gridFiles.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnDeleteFile);
            panel2.Controls.Add(btnAddFile);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(994, 39);
            panel2.TabIndex = 0;
            // 
            // btnDeleteFile
            // 
            btnDeleteFile.Location = new Point(111, 3);
            btnDeleteFile.Name = "btnDeleteFile";
            btnDeleteFile.Size = new Size(100, 32);
            btnDeleteFile.TabIndex = 1;
            btnDeleteFile.Text = "Delete";
            btnDeleteFile.UseVisualStyleBackColor = true;
            // 
            // btnAddFile
            // 
            btnAddFile.Location = new Point(5, 3);
            btnAddFile.Name = "btnAddFile";
            btnAddFile.Size = new Size(100, 32);
            btnAddFile.TabIndex = 0;
            btnAddFile.Text = "Add";
            btnAddFile.UseVisualStyleBackColor = true;
            // 
            // tabNamespaces
            // 
            tabNamespaces.Controls.Add(gridNamespaces);
            tabNamespaces.Controls.Add(panel1);
            tabNamespaces.Location = new Point(4, 24);
            tabNamespaces.Name = "tabNamespaces";
            tabNamespaces.Padding = new Padding(3);
            tabNamespaces.Size = new Size(1000, 588);
            tabNamespaces.TabIndex = 3;
            tabNamespaces.Text = "Xsd To C# Namespaces";
            tabNamespaces.UseVisualStyleBackColor = true;
            // 
            // gridNamespaces
            // 
            gridNamespaces.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridNamespaces.Dock = DockStyle.Fill;
            gridNamespaces.Location = new Point(3, 41);
            gridNamespaces.Name = "gridNamespaces";
            gridNamespaces.Size = new Size(994, 544);
            gridNamespaces.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnAddNs);
            panel1.Controls.Add(btnDeleteNs);
            panel1.Controls.Add(btnEditNs);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(994, 38);
            panel1.TabIndex = 0;
            // 
            // btnAddNs
            // 
            btnAddNs.Location = new Point(5, 3);
            btnAddNs.Name = "btnAddNs";
            btnAddNs.Size = new Size(100, 32);
            btnAddNs.TabIndex = 3;
            btnAddNs.Text = "Add";
            btnAddNs.UseVisualStyleBackColor = true;
            // 
            // btnDeleteNs
            // 
            btnDeleteNs.Location = new Point(217, 3);
            btnDeleteNs.Name = "btnDeleteNs";
            btnDeleteNs.Size = new Size(100, 32);
            btnDeleteNs.TabIndex = 2;
            btnDeleteNs.Text = "Delete";
            btnDeleteNs.UseVisualStyleBackColor = true;
            // 
            // btnEditNs
            // 
            btnEditNs.Location = new Point(111, 3);
            btnEditNs.Name = "btnEditNs";
            btnEditNs.Size = new Size(100, 32);
            btnEditNs.TabIndex = 1;
            btnEditNs.Text = "Edit";
            btnEditNs.UseVisualStyleBackColor = true;
            // 
            // Splitter
            // 
            Splitter.Dock = DockStyle.Fill;
            Splitter.Location = new Point(0, 39);
            Splitter.Name = "Splitter";
            Splitter.Orientation = Orientation.Horizontal;
            // 
            // Splitter.Panel1
            // 
            Splitter.Panel1.Controls.Add(Pager);
            // 
            // Splitter.Panel2
            // 
            Splitter.Panel2.Controls.Add(edtLog);
            Splitter.Size = new Size(1008, 680);
            Splitter.SplitterDistance = 616;
            Splitter.SplitterWidth = 6;
            Splitter.TabIndex = 3;
            // 
            // edtLog
            // 
            edtLog.BackColor = Color.Gainsboro;
            edtLog.Dock = DockStyle.Fill;
            edtLog.Location = new Point(0, 0);
            edtLog.Name = "edtLog";
            edtLog.Size = new Size(1008, 58);
            edtLog.TabIndex = 0;
            edtLog.Text = "";
            // 
            // tabPlusFlags
            // 
            tabPlusFlags.Controls.Add(chUseSpecified);
            tabPlusFlags.Controls.Add(chUseBackingField);
            tabPlusFlags.Controls.Add(chNormalNullables);
            tabPlusFlags.Location = new Point(4, 24);
            tabPlusFlags.Name = "tabPlusFlags";
            tabPlusFlags.Padding = new Padding(3);
            tabPlusFlags.Size = new Size(1000, 588);
            tabPlusFlags.TabIndex = 4;
            tabPlusFlags.Text = "Plus Flags";
            tabPlusFlags.UseVisualStyleBackColor = true;
            // 
            // chNormalNullables
            // 
            chNormalNullables.AutoSize = true;
            chNormalNullables.Location = new Point(8, 6);
            chNormalNullables.Name = "chNormalNullables";
            chNormalNullables.Size = new Size(559, 19);
            chNormalNullables.TabIndex = 21;
            chNormalNullables.Text = "Normal Nullables. When true, the default, emit nullable properties as  type? PropertyName { get; set; }";
            chNormalNullables.UseVisualStyleBackColor = true;
            // 
            // chUseBackingField
            // 
            chUseBackingField.AutoSize = true;
            chUseBackingField.Location = new Point(8, 31);
            chUseBackingField.Name = "chUseBackingField";
            chUseBackingField.Size = new Size(607, 19);
            chUseBackingField.TabIndex = 22;
            chUseBackingField.Text = "Use Backing Field. When false, the default, emit generic List properties as List<Type> PropertyName { get; set; }";
            chUseBackingField.UseVisualStyleBackColor = true;
            // 
            // chUseSpecified
            // 
            chUseSpecified.AutoSize = true;
            chUseSpecified.Location = new Point(8, 56);
            chUseSpecified.Name = "chUseSpecified";
            chUseSpecified.Size = new Size(501, 19);
            chUseSpecified.TabIndex = 23;
            chUseSpecified.Text = "Use Specified Property. When false, the default, no PropertyIsSpecified property is emitted.";
            chUseSpecified.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 741);
            Controls.Add(Splitter);
            Controls.Add(statusStrip1);
            Controls.Add(ToolBar);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "XsdToCsharp";
            ToolBar.ResumeLayout(false);
            ToolBar.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            Pager.ResumeLayout(false);
            tabGeneral.ResumeLayout(false);
            tabGeneral.PerformLayout();
            tabFlags.ResumeLayout(false);
            tabFlags.PerformLayout();
            tabFiles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridFiles).EndInit();
            panel2.ResumeLayout(false);
            tabNamespaces.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridNamespaces).EndInit();
            panel1.ResumeLayout(false);
            Splitter.Panel1.ResumeLayout(false);
            Splitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Splitter).EndInit();
            Splitter.ResumeLayout(false);
            tabPlusFlags.ResumeLayout(false);
            tabPlusFlags.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip ToolBar;
        private StatusStrip statusStrip1;
        private ToolStripButton btnNewProject;
        private ToolStripButton btnOpenProject;
        private ToolStripButton btnSaveProject;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnExit;
        private ToolStripButton btnAbout;
        private ToolStripSeparator toolStripSeparator2;
        private TabControl Pager;
        private TabPage tabGeneral;
        private TabPage tabFlags;
        private ToolStripStatusLabel lblProjectName;
        private ToolStripButton btnExecuteProject;
        private SplitContainer Splitter;
        private RichTextBox edtLog;
        private Label label1;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private CheckBox chEnableNullableReferenceAttributes;
        private CheckBox chUseXElementForAny;
        private CheckBox chEnableDataBinding;
        private CheckBox chEnumAsString;
        private CheckBox chGenerateComplexTypesForCollections;
        private CheckBox chEnableUpaCheck;
        private CheckBox chDoNotForceIsNullable;
        private CheckBox chDisableComments;
        private CheckBox chAssemblyVisible;
        private CheckBox chGenerateDescriptionAttribute;
        private CheckBox chGenerateInterfaces;
        private CheckBox chEntityFramework;
        private CheckBox chDateTimeWithTimeZone;
        private CheckBox chUseIntegerDataTypeAsFallback;
        private CheckBox chGenerateDesignerCategoryAttribute;
        private CheckBox chGenerateDebuggerStepThroughAttribute;
        private CheckBox chGenerateSerializableAttribute;
        private CheckBox chUseShouldSerializePattern;
        private CheckBox chGenerateNullables;
        private CheckBox chEmitOrder;
        private CheckBox chSeparateNamespaceHierarchy;
        private CheckBox chMapUnionToWidestCommonType;
        private CheckBox chUseArrayItemAttribute;
        private CheckBox chGenerateCommandLineArgumentsComment;
        private CheckBox chNetCoreSpecificCode;
        private CheckBox chCreateGeneratedCodeAttributeVersion;
        private CheckBox chUniqueTypeNamesAcrossNamespaces;
        private CheckBox chCompactTypeNames;
        private CheckBox chSeparateSubstitutes;
        private CheckBox chSeparateClasses;
        private ComboBox cboCollectionType;
        private TextBox edtTextValuePropertyName;
        private TextBox edtPrivateMemberPrefix;
        private TextBox edtNamespacePrefix;
        private TextBox edtOutputFolder;
        private TextBox edtName;
        private ComboBox cboDataAnnotationMode;
        private ComboBox cboNamingScheme;
        private ComboBox cboCollectionSettersMode;
        private ComboBox cboIntegerDataType;
        private TextBox textBox1;
        private TabPage tabFiles;
        private TabPage tabNamespaces;
        private Panel panel2;
        private Panel panel1;
        private DataGridView gridFiles;
        private DataGridView gridNamespaces;
        private Button btnAddFile;
        private Button btnDeleteFile;
        private Button btnAddNs;
        private Button btnDeleteNs;
        private Button btnEditNs;
        private ToolStripButton btnSaveProjectAs;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel lblProjectPath;
        private TextBox edtGlobalNamespace;
        private Label label11;
        private TabPage tabPlusFlags;
        private CheckBox chUseSpecified;
        private CheckBox chUseBackingField;
        private CheckBox chNormalNullables;
    }
}
