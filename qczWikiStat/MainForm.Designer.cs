namespace qczWikiStat
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.smhDumpTextBox = new System.Windows.Forms.TextBox();
            this.browseSmhDumpButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ugDumpTextBox = new System.Windows.Forms.TextBox();
            this.browseUgDumpButton = new System.Windows.Forms.Button();
            this.loadDumpsButton = new System.Windows.Forms.Button();
            this.orderListBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chooseFile = new System.Windows.Forms.Button();
            this.outputFileTextBox = new System.Windows.Forms.TextBox();
            this.userCountBox = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.activePeriodDaysCheckBox = new System.Windows.Forms.CheckBox();
            this.periodMeanEditsCheckBox = new System.Windows.Forms.CheckBox();
            this.meanEditsCheckBox = new System.Windows.Forms.CheckBox();
            this.activeDaysCheckBox = new System.Windows.Forms.CheckBox();
            this.daysCheckBox = new System.Windows.Forms.CheckBox();
            this.lastEditCheckBox = new System.Windows.Forms.CheckBox();
            this.firstEditCheckBox = new System.Windows.Forms.CheckBox();
            this.periodEditsCheckBox = new System.Windows.Forms.CheckBox();
            this.allEditsNamespaceLabel = new System.Windows.Forms.Label();
            this.allEditsCheckBox = new System.Windows.Forms.CheckBox();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.startDateCheckBox = new System.Windows.Forms.CheckBox();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.doStatisticsButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.progressText = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.settingsTabControl = new System.Windows.Forms.TabControl();
            this.baseSettingsTab = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.mergeAliasEdits = new System.Windows.Forms.CheckBox();
            this.showUnregisteredUsersCheckbox = new System.Windows.Forms.CheckBox();
            this.showRegisteredUsersCheckbox = new System.Windows.Forms.CheckBox();
            this.showBotsCheckBox = new System.Windows.Forms.CheckBox();
            this.showPrivilegesCheckBox = new System.Windows.Forms.CheckBox();
            this.privilegesInNewColumnCheckBix = new System.Windows.Forms.RadioButton();
            this.privilegesUnderCheckBox = new System.Windows.Forms.RadioButton();
            this.useBotListCheckBox = new System.Windows.Forms.CheckBox();
            this.useAnonListCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.templateDataOutputRadioButton = new System.Windows.Forms.RadioButton();
            this.createCache = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.rankListOutputRadioButton = new System.Windows.Forms.RadioButton();
            this.statisticsOutputRadioButton = new System.Windows.Forms.RadioButton();
            this.showPercentZerosCheckBox = new System.Windows.Forms.CheckBox();
            this.reverseOrderCheckbox = new System.Windows.Forms.CheckBox();
            this.percentCountBox = new System.Windows.Forms.NumericUpDown();
            this.showDoubleZerosCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.processedPagesCount = new System.Windows.Forms.NumericUpDown();
            this.doubleCountBox = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.userDataTab = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.showRankBeforePeriodCheckBox = new System.Windows.Forms.CheckBox();
            this.showRankInPeriodCheckBox = new System.Windows.Forms.CheckBox();
            this.showRankChangeInPeriodCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.revertedEditsPercentageCheckBox = new System.Windows.Forms.CheckBox();
            this.revertedEditsCheckBox = new System.Windows.Forms.CheckBox();
            this.selectAllPcNsButton = new System.Windows.Forms.Button();
            this.selectAllNsButton = new System.Windows.Forms.Button();
            this.allNsInfoLabel = new System.Windows.Forms.Label();
            this.allNsPcInfoLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.periodDataGroupBox = new System.Windows.Forms.GroupBox();
            this.periodRevertedEditsPercentageCheckBox = new System.Windows.Forms.CheckBox();
            this.periodRevertedEditsCheckBox = new System.Windows.Forms.CheckBox();
            this.periodEditsNamespaceLabel = new System.Windows.Forms.Label();
            this.selectPeriodNsButton = new System.Windows.Forms.Button();
            this.periodNsInfoLabel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.periodNsPcInfoLabel = new System.Windows.Forms.Label();
            this.selectPeriodPcNsButton = new System.Windows.Forms.Button();
            this.filterTab = new System.Windows.Forms.TabPage();
            this.rankListComboBox = new System.Windows.Forms.ComboBox();
            this.showUsersWithAGivenRankCheckbox = new System.Windows.Forms.CheckBox();
            this.showOnlyRankChanges = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.allEditsInPeriodAtMostBox = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.allEditsAtMostBox = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.activePeriodDaysAtMostBox = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.activeDaysAtMostBox = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.allEditsInPeriodAtLeastBox = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.allEditsAtLeastBox = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.activePeriodDaysAtLeastBox = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.activeDaysAtLeastBox = new System.Windows.Forms.NumericUpDown();
            this.exitButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.reqsStatusLabel = new System.Windows.Forms.Label();
            this.aliasStatusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.userCountBox)).BeginInit();
            this.settingsTabControl.SuspendLayout();
            this.baseSettingsTab.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.percentCountBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.processedPagesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleCountBox)).BeginInit();
            this.userDataTab.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.periodDataGroupBox.SuspendLayout();
            this.filterTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.allEditsInPeriodAtMostBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.allEditsAtMostBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.activePeriodDaysAtMostBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.activeDaysAtMostBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.allEditsInPeriodAtLeastBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.allEditsAtLeastBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.activePeriodDaysAtLeastBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.activeDaysAtLeastBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "stub_meta_history dump:";
            // 
            // smhDumpTextBox
            // 
            this.smhDumpTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.smhDumpTextBox.Location = new System.Drawing.Point(170, 18);
            this.smhDumpTextBox.Name = "smhDumpTextBox";
            this.smhDumpTextBox.ReadOnly = true;
            this.smhDumpTextBox.Size = new System.Drawing.Size(585, 20);
            this.smhDumpTextBox.TabIndex = 1;
            // 
            // browseSmhDumpButton
            // 
            this.browseSmhDumpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseSmhDumpButton.Location = new System.Drawing.Point(761, 16);
            this.browseSmhDumpButton.Name = "browseSmhDumpButton";
            this.browseSmhDumpButton.Size = new System.Drawing.Size(88, 23);
            this.browseSmhDumpButton.TabIndex = 2;
            this.browseSmhDumpButton.Text = "Kiválasztás";
            this.browseSmhDumpButton.UseVisualStyleBackColor = true;
            this.browseSmhDumpButton.Click += new System.EventHandler(this.BrowseSmhDumpButtonClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "user_groups dump:";
            // 
            // ugDumpTextBox
            // 
            this.ugDumpTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ugDumpTextBox.Location = new System.Drawing.Point(170, 46);
            this.ugDumpTextBox.Name = "ugDumpTextBox";
            this.ugDumpTextBox.ReadOnly = true;
            this.ugDumpTextBox.Size = new System.Drawing.Size(585, 20);
            this.ugDumpTextBox.TabIndex = 4;
            // 
            // browseUgDumpButton
            // 
            this.browseUgDumpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseUgDumpButton.Location = new System.Drawing.Point(761, 44);
            this.browseUgDumpButton.Name = "browseUgDumpButton";
            this.browseUgDumpButton.Size = new System.Drawing.Size(88, 23);
            this.browseUgDumpButton.TabIndex = 5;
            this.browseUgDumpButton.Text = "Kiválasztás";
            this.browseUgDumpButton.UseVisualStyleBackColor = true;
            this.browseUgDumpButton.Click += new System.EventHandler(this.BrowseUgDumpButtonClick);
            // 
            // loadDumpsButton
            // 
            this.loadDumpsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loadDumpsButton.Enabled = false;
            this.loadDumpsButton.Location = new System.Drawing.Point(761, 73);
            this.loadDumpsButton.Name = "loadDumpsButton";
            this.loadDumpsButton.Size = new System.Drawing.Size(86, 23);
            this.loadDumpsButton.TabIndex = 6;
            this.loadDumpsButton.Text = "Betöltés";
            this.loadDumpsButton.UseVisualStyleBackColor = true;
            this.loadDumpsButton.Click += new System.EventHandler(this.LoadDumpsButtonClick);
            // 
            // orderListBox
            // 
            this.orderListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.orderListBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.orderListBox.DropDownWidth = 400;
            this.orderListBox.FormattingEnabled = true;
            this.orderListBox.Location = new System.Drawing.Point(70, 48);
            this.orderListBox.Name = "orderListBox";
            this.orderListBox.Size = new System.Drawing.Size(442, 21);
            this.orderListBox.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Rendezés:";
            // 
            // chooseFile
            // 
            this.chooseFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseFile.Location = new System.Drawing.Point(427, 257);
            this.chooseFile.Name = "chooseFile";
            this.chooseFile.Size = new System.Drawing.Size(85, 23);
            this.chooseFile.TabIndex = 24;
            this.chooseFile.Text = "Kiválasztás";
            this.chooseFile.UseVisualStyleBackColor = true;
            this.chooseFile.Click += new System.EventHandler(this.ChooseFileClick);
            // 
            // outputFileTextBox
            // 
            this.outputFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputFileTextBox.Location = new System.Drawing.Point(50, 259);
            this.outputFileTextBox.Name = "outputFileTextBox";
            this.outputFileTextBox.ReadOnly = true;
            this.outputFileTextBox.Size = new System.Drawing.Size(371, 20);
            this.outputFileTextBox.TabIndex = 23;
            // 
            // userCountBox
            // 
            this.userCountBox.Location = new System.Drawing.Point(200, 19);
            this.userCountBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.userCountBox.Name = "userCountBox";
            this.userCountBox.Size = new System.Drawing.Size(77, 20);
            this.userCountBox.TabIndex = 21;
            this.userCountBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.userCountBox.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 26);
            this.label5.TabIndex = 19;
            this.label5.Text = "Felhasználók maximális száma: (0, ha az összes jelenjen meg)";
            // 
            // activePeriodDaysCheckBox
            // 
            this.activePeriodDaysCheckBox.AutoSize = true;
            this.activePeriodDaysCheckBox.Checked = true;
            this.activePeriodDaysCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.activePeriodDaysCheckBox.Location = new System.Drawing.Point(9, 156);
            this.activePeriodDaysCheckBox.Name = "activePeriodDaysCheckBox";
            this.activePeriodDaysCheckBox.Size = new System.Drawing.Size(331, 17);
            this.activePeriodDaysCheckBox.TabIndex = 18;
            this.activePeriodDaysCheckBox.Tag = "";
            this.activePeriodDaysCheckBox.Text = "Aktív napok az adott időszakban (a szerkesztéssel töltött napok)";
            this.activePeriodDaysCheckBox.UseVisualStyleBackColor = true;
            // 
            // periodMeanEditsCheckBox
            // 
            this.periodMeanEditsCheckBox.AutoSize = true;
            this.periodMeanEditsCheckBox.Checked = true;
            this.periodMeanEditsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.periodMeanEditsCheckBox.Location = new System.Drawing.Point(9, 179);
            this.periodMeanEditsCheckBox.Name = "periodMeanEditsCheckBox";
            this.periodMeanEditsCheckBox.Size = new System.Drawing.Size(398, 17);
            this.periodMeanEditsCheckBox.TabIndex = 17;
            this.periodMeanEditsCheckBox.Tag = "";
            this.periodMeanEditsCheckBox.Text = "Napi átlagos szerk. (Szerk. az adott időszakban / napok száma az időszakban)";
            this.periodMeanEditsCheckBox.UseVisualStyleBackColor = true;
            // 
            // meanEditsCheckBox
            // 
            this.meanEditsCheckBox.AutoSize = true;
            this.meanEditsCheckBox.Checked = true;
            this.meanEditsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.meanEditsCheckBox.Location = new System.Drawing.Point(9, 245);
            this.meanEditsCheckBox.Name = "meanEditsCheckBox";
            this.meanEditsCheckBox.Size = new System.Drawing.Size(373, 17);
            this.meanEditsCheckBox.TabIndex = 16;
            this.meanEditsCheckBox.Text = "Napi átlagos szerk. (Összes szerk / első és utolsó nap között eltelt napok)";
            this.meanEditsCheckBox.UseVisualStyleBackColor = true;
            // 
            // activeDaysCheckBox
            // 
            this.activeDaysCheckBox.AutoSize = true;
            this.activeDaysCheckBox.Checked = true;
            this.activeDaysCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.activeDaysCheckBox.Location = new System.Drawing.Point(9, 222);
            this.activeDaysCheckBox.Name = "activeDaysCheckBox";
            this.activeDaysCheckBox.Size = new System.Drawing.Size(233, 17);
            this.activeDaysCheckBox.TabIndex = 15;
            this.activeDaysCheckBox.Text = "Aktív napok (a szerkesztéssel töltött napok)";
            this.activeDaysCheckBox.UseVisualStyleBackColor = true;
            // 
            // daysCheckBox
            // 
            this.daysCheckBox.AutoSize = true;
            this.daysCheckBox.Checked = true;
            this.daysCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.daysCheckBox.Location = new System.Drawing.Point(9, 199);
            this.daysCheckBox.Name = "daysCheckBox";
            this.daysCheckBox.Size = new System.Drawing.Size(239, 17);
            this.daysCheckBox.TabIndex = 14;
            this.daysCheckBox.Text = "Első és utolsó szerkesztés között eltelt napok";
            this.daysCheckBox.UseVisualStyleBackColor = true;
            // 
            // lastEditCheckBox
            // 
            this.lastEditCheckBox.AutoSize = true;
            this.lastEditCheckBox.Location = new System.Drawing.Point(9, 176);
            this.lastEditCheckBox.Name = "lastEditCheckBox";
            this.lastEditCheckBox.Size = new System.Drawing.Size(114, 17);
            this.lastEditCheckBox.TabIndex = 13;
            this.lastEditCheckBox.Text = "Utolsó szerkesztés";
            this.lastEditCheckBox.UseVisualStyleBackColor = true;
            // 
            // firstEditCheckBox
            // 
            this.firstEditCheckBox.AutoSize = true;
            this.firstEditCheckBox.Location = new System.Drawing.Point(9, 153);
            this.firstEditCheckBox.Name = "firstEditCheckBox";
            this.firstEditCheckBox.Size = new System.Drawing.Size(104, 17);
            this.firstEditCheckBox.TabIndex = 12;
            this.firstEditCheckBox.Text = "Első szerkesztés";
            this.firstEditCheckBox.UseVisualStyleBackColor = true;
            // 
            // periodEditsCheckBox
            // 
            this.periodEditsCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.periodEditsCheckBox.AutoSize = true;
            this.periodEditsCheckBox.Checked = true;
            this.periodEditsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.periodEditsCheckBox.Location = new System.Drawing.Point(6, 19);
            this.periodEditsCheckBox.Name = "periodEditsCheckBox";
            this.periodEditsCheckBox.Size = new System.Drawing.Size(184, 17);
            this.periodEditsCheckBox.TabIndex = 9;
            this.periodEditsCheckBox.Tag = "";
            this.periodEditsCheckBox.Text = "Szerkesztés az adott időszakban:";
            this.periodEditsCheckBox.UseVisualStyleBackColor = true;
            // 
            // allEditsNamespaceLabel
            // 
            this.allEditsNamespaceLabel.AutoSize = true;
            this.allEditsNamespaceLabel.Location = new System.Drawing.Point(6, 63);
            this.allEditsNamespaceLabel.Name = "allEditsNamespaceLabel";
            this.allEditsNamespaceLabel.Size = new System.Drawing.Size(227, 13);
            this.allEditsNamespaceLabel.TabIndex = 7;
            this.allEditsNamespaceLabel.Tag = "";
            this.allEditsNamespaceLabel.Text = "Összes szerkesztés a következő névterekben:";
            // 
            // allEditsCheckBox
            // 
            this.allEditsCheckBox.AutoSize = true;
            this.allEditsCheckBox.Checked = true;
            this.allEditsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.allEditsCheckBox.Location = new System.Drawing.Point(9, 19);
            this.allEditsCheckBox.Name = "allEditsCheckBox";
            this.allEditsCheckBox.Size = new System.Drawing.Size(118, 17);
            this.allEditsCheckBox.TabIndex = 6;
            this.allEditsCheckBox.Text = "Összes szerkesztés";
            this.allEditsCheckBox.UseVisualStyleBackColor = true;
            // 
            // endDatePicker
            // 
            this.endDatePicker.Location = new System.Drawing.Point(106, 45);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(143, 20);
            this.endDatePicker.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Végdátum:";
            // 
            // startDateCheckBox
            // 
            this.startDateCheckBox.AutoSize = true;
            this.startDateCheckBox.Checked = true;
            this.startDateCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.startDateCheckBox.Location = new System.Drawing.Point(9, 22);
            this.startDateCheckBox.Name = "startDateCheckBox";
            this.startDateCheckBox.Size = new System.Drawing.Size(88, 17);
            this.startDateCheckBox.TabIndex = 3;
            this.startDateCheckBox.Text = "Kezdődátum:";
            this.startDateCheckBox.UseVisualStyleBackColor = true;
            this.startDateCheckBox.CheckStateChanged += new System.EventHandler(this.StartDateCheckBoxCheckStateChanged);
            // 
            // startDatePicker
            // 
            this.startDatePicker.Location = new System.Drawing.Point(106, 19);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(143, 20);
            this.startDatePicker.TabIndex = 2;
            this.startDatePicker.Tag = "startDateDef";
            // 
            // doStatisticsButton
            // 
            this.doStatisticsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.doStatisticsButton.Enabled = false;
            this.doStatisticsButton.Location = new System.Drawing.Point(694, 606);
            this.doStatisticsButton.Name = "doStatisticsButton";
            this.doStatisticsButton.Size = new System.Drawing.Size(153, 23);
            this.doStatisticsButton.TabIndex = 8;
            this.doStatisticsButton.Text = "Statisztika elkészítése";
            this.doStatisticsButton.UseVisualStyleBackColor = true;
            this.doStatisticsButton.Click += new System.EventHandler(this.DoStatisticsButtonClick);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Wikimedia dump fájlok (*.gz)|*.gz";
            this.openFileDialog.Title = "Dump fájl megnyitása";
            // 
            // progressText
            // 
            this.progressText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressText.AutoSize = true;
            this.progressText.Location = new System.Drawing.Point(180, 611);
            this.progressText.Name = "progressText";
            this.progressText.Size = new System.Drawing.Size(0, 13);
            this.progressText.TabIndex = 10;
            this.progressText.Visible = false;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Szövegfájlok (*.txt)|*.txt";
            // 
            // settingsTabControl
            // 
            this.settingsTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsTabControl.Controls.Add(this.baseSettingsTab);
            this.settingsTabControl.Controls.Add(this.userDataTab);
            this.settingsTabControl.Controls.Add(this.filterTab);
            this.settingsTabControl.Enabled = false;
            this.settingsTabControl.Location = new System.Drawing.Point(12, 146);
            this.settingsTabControl.Name = "settingsTabControl";
            this.settingsTabControl.SelectedIndex = 0;
            this.settingsTabControl.Size = new System.Drawing.Size(838, 454);
            this.settingsTabControl.TabIndex = 11;
            // 
            // baseSettingsTab
            // 
            this.baseSettingsTab.Controls.Add(this.groupBox3);
            this.baseSettingsTab.Controls.Add(this.groupBox2);
            this.baseSettingsTab.Controls.Add(this.groupBox1);
            this.baseSettingsTab.Location = new System.Drawing.Point(4, 22);
            this.baseSettingsTab.Name = "baseSettingsTab";
            this.baseSettingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.baseSettingsTab.Size = new System.Drawing.Size(830, 428);
            this.baseSettingsTab.TabIndex = 0;
            this.baseSettingsTab.Text = "Alapbeállítások";
            this.baseSettingsTab.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.endDatePicker);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.startDatePicker);
            this.groupBox3.Controls.Add(this.startDateCheckBox);
            this.groupBox3.Location = new System.Drawing.Point(10, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(286, 74);
            this.groupBox3.TabIndex = 45;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Vizsgált időszak";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.mergeAliasEdits);
            this.groupBox2.Controls.Add(this.showUnregisteredUsersCheckbox);
            this.groupBox2.Controls.Add(this.showRegisteredUsersCheckbox);
            this.groupBox2.Controls.Add(this.showBotsCheckBox);
            this.groupBox2.Controls.Add(this.showPrivilegesCheckBox);
            this.groupBox2.Controls.Add(this.privilegesInNewColumnCheckBix);
            this.groupBox2.Controls.Add(this.privilegesUnderCheckBox);
            this.groupBox2.Controls.Add(this.useBotListCheckBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.userCountBox);
            this.groupBox2.Controls.Add(this.useAnonListCheckBox);
            this.groupBox2.Location = new System.Drawing.Point(10, 86);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(286, 332);
            this.groupBox2.TabIndex = 44;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Felhasználóadatok";
            // 
            // mergeAliasEdits
            // 
            this.mergeAliasEdits.AutoSize = true;
            this.mergeAliasEdits.Location = new System.Drawing.Point(6, 309);
            this.mergeAliasEdits.Name = "mergeAliasEdits";
            this.mergeAliasEdits.Size = new System.Drawing.Size(241, 17);
            this.mergeAliasEdits.TabIndex = 39;
            this.mergeAliasEdits.Text = "Aliasoktól érkező szerkesztések összevonása";
            this.mergeAliasEdits.UseVisualStyleBackColor = true;
            // 
            // showUnregisteredUsersCheckbox
            // 
            this.showUnregisteredUsersCheckbox.AutoSize = true;
            this.showUnregisteredUsersCheckbox.Location = new System.Drawing.Point(7, 110);
            this.showUnregisteredUsersCheckbox.Name = "showUnregisteredUsersCheckbox";
            this.showUnregisteredUsersCheckbox.Size = new System.Drawing.Size(200, 17);
            this.showUnregisteredUsersCheckbox.TabIndex = 32;
            this.showUnregisteredUsersCheckbox.Text = "Nem regisztrált felhasználók listázása";
            this.showUnregisteredUsersCheckbox.UseVisualStyleBackColor = true;
            // 
            // showRegisteredUsersCheckbox
            // 
            this.showRegisteredUsersCheckbox.AutoSize = true;
            this.showRegisteredUsersCheckbox.Checked = true;
            this.showRegisteredUsersCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showRegisteredUsersCheckbox.Location = new System.Drawing.Point(9, 64);
            this.showRegisteredUsersCheckbox.Name = "showRegisteredUsersCheckbox";
            this.showRegisteredUsersCheckbox.Size = new System.Drawing.Size(180, 17);
            this.showRegisteredUsersCheckbox.TabIndex = 31;
            this.showRegisteredUsersCheckbox.Text = "Regisztrált felhasználók listázása";
            this.showRegisteredUsersCheckbox.UseVisualStyleBackColor = true;
            // 
            // showBotsCheckBox
            // 
            this.showBotsCheckBox.AutoSize = true;
            this.showBotsCheckBox.Checked = true;
            this.showBotsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showBotsCheckBox.Location = new System.Drawing.Point(9, 87);
            this.showBotsCheckBox.Name = "showBotsCheckBox";
            this.showBotsCheckBox.Size = new System.Drawing.Size(229, 17);
            this.showBotsCheckBox.TabIndex = 30;
            this.showBotsCheckBox.Text = "Botok listázása (regisztrált + nem regisztrált)";
            this.showBotsCheckBox.UseVisualStyleBackColor = true;
            // 
            // showPrivilegesCheckBox
            // 
            this.showPrivilegesCheckBox.AutoSize = true;
            this.showPrivilegesCheckBox.Checked = true;
            this.showPrivilegesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showPrivilegesCheckBox.Location = new System.Drawing.Point(6, 145);
            this.showPrivilegesCheckBox.Name = "showPrivilegesCheckBox";
            this.showPrivilegesCheckBox.Size = new System.Drawing.Size(163, 17);
            this.showPrivilegesCheckBox.TabIndex = 27;
            this.showPrivilegesCheckBox.Text = "Jogosultságok megjelenítése";
            this.showPrivilegesCheckBox.UseVisualStyleBackColor = true;
            this.showPrivilegesCheckBox.CheckedChanged += new System.EventHandler(this.ShowPrivilegesCheckBoxCheckedChanged);
            // 
            // privilegesInNewColumnCheckBix
            // 
            this.privilegesInNewColumnCheckBix.AutoSize = true;
            this.privilegesInNewColumnCheckBix.Checked = true;
            this.privilegesInNewColumnCheckBix.Location = new System.Drawing.Point(29, 191);
            this.privilegesInNewColumnCheckBix.Name = "privilegesInNewColumnCheckBix";
            this.privilegesInNewColumnCheckBix.Size = new System.Drawing.Size(84, 17);
            this.privilegesInNewColumnCheckBix.TabIndex = 38;
            this.privilegesInNewColumnCheckBix.TabStop = true;
            this.privilegesInNewColumnCheckBix.Text = "új oszlopban";
            this.privilegesInNewColumnCheckBix.UseVisualStyleBackColor = true;
            // 
            // privilegesUnderCheckBox
            // 
            this.privilegesUnderCheckBox.AutoSize = true;
            this.privilegesUnderCheckBox.Location = new System.Drawing.Point(29, 168);
            this.privilegesUnderCheckBox.Name = "privilegesUnderCheckBox";
            this.privilegesUnderCheckBox.Size = new System.Drawing.Size(140, 17);
            this.privilegesUnderCheckBox.TabIndex = 37;
            this.privilegesUnderCheckBox.Text = "a szerkesztők neve alatt";
            this.privilegesUnderCheckBox.UseVisualStyleBackColor = true;
            // 
            // useBotListCheckBox
            // 
            this.useBotListCheckBox.Enabled = false;
            this.useBotListCheckBox.Location = new System.Drawing.Point(8, 214);
            this.useBotListCheckBox.Name = "useBotListCheckBox";
            this.useBotListCheckBox.Size = new System.Drawing.Size(269, 46);
            this.useBotListCheckBox.TabIndex = 28;
            this.useBotListCheckBox.Text = "A botlistában szereplő szerkesztők botflag nélküli botokként jelölése használata " +
    "a botflag nélküli botok felismeréséhez";
            this.useBotListCheckBox.UseVisualStyleBackColor = true;
            // 
            // useAnonListCheckBox
            // 
            this.useAnonListCheckBox.Enabled = false;
            this.useAnonListCheckBox.Location = new System.Drawing.Point(6, 257);
            this.useAnonListCheckBox.Name = "useAnonListCheckBox";
            this.useAnonListCheckBox.Size = new System.Drawing.Size(271, 46);
            this.useAnonListCheckBox.TabIndex = 29;
            this.useAnonListCheckBox.Text = "Az anonim listában szereplő szerkesztők ne jelenjenek meg a statisztikában";
            this.useAnonListCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.templateDataOutputRadioButton);
            this.groupBox1.Controls.Add(this.createCache);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.rankListOutputRadioButton);
            this.groupBox1.Controls.Add(this.statisticsOutputRadioButton);
            this.groupBox1.Controls.Add(this.outputFileTextBox);
            this.groupBox1.Controls.Add(this.showPercentZerosCheckBox);
            this.groupBox1.Controls.Add(this.reverseOrderCheckbox);
            this.groupBox1.Controls.Add(this.percentCountBox);
            this.groupBox1.Controls.Add(this.showDoubleZerosCheckBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.chooseFile);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.processedPagesCount);
            this.groupBox1.Controls.Add(this.orderListBox);
            this.groupBox1.Controls.Add(this.doubleCountBox);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Location = new System.Drawing.Point(302, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(522, 382);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kimenet";
            // 
            // templateDataOutputRadioButton
            // 
            this.templateDataOutputRadioButton.AutoSize = true;
            this.templateDataOutputRadioButton.Location = new System.Drawing.Point(222, 21);
            this.templateDataOutputRadioButton.Name = "templateDataOutputRadioButton";
            this.templateDataOutputRadioButton.Size = new System.Drawing.Size(56, 17);
            this.templateDataOutputRadioButton.TabIndex = 49;
            this.templateDataOutputRadioButton.Text = "sablon";
            this.templateDataOutputRadioButton.UseVisualStyleBackColor = true;
            // 
            // createCache
            // 
            this.createCache.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.createCache.Checked = true;
            this.createCache.CheckState = System.Windows.Forms.CheckState.Checked;
            this.createCache.Location = new System.Drawing.Point(22, 286);
            this.createCache.Name = "createCache";
            this.createCache.Size = new System.Drawing.Size(490, 61);
            this.createCache.TabIndex = 48;
            this.createCache.Text = resources.GetString("createCache.Text");
            this.createCache.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 262);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 13);
            this.label15.TabIndex = 47;
            this.label15.Text = "Célfájl:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 46;
            this.label6.Text = "Típusa:";
            // 
            // rankListOutputRadioButton
            // 
            this.rankListOutputRadioButton.AutoSize = true;
            this.rankListOutputRadioButton.Location = new System.Drawing.Point(133, 21);
            this.rankListOutputRadioButton.Name = "rankListOutputRadioButton";
            this.rankListOutputRadioButton.Size = new System.Drawing.Size(83, 17);
            this.rankListOutputRadioButton.TabIndex = 45;
            this.rankListOutputRadioButton.Text = "rangtáblázat";
            this.rankListOutputRadioButton.UseVisualStyleBackColor = true;
            this.rankListOutputRadioButton.CheckedChanged += new System.EventHandler(this.rankListOutputRadioButton_CheckedChanged);
            // 
            // statisticsOutputRadioButton
            // 
            this.statisticsOutputRadioButton.AutoSize = true;
            this.statisticsOutputRadioButton.Checked = true;
            this.statisticsOutputRadioButton.Location = new System.Drawing.Point(56, 21);
            this.statisticsOutputRadioButton.Name = "statisticsOutputRadioButton";
            this.statisticsOutputRadioButton.Size = new System.Drawing.Size(71, 17);
            this.statisticsOutputRadioButton.TabIndex = 44;
            this.statisticsOutputRadioButton.TabStop = true;
            this.statisticsOutputRadioButton.Text = "statisztika";
            this.statisticsOutputRadioButton.UseVisualStyleBackColor = true;
            // 
            // showPercentZerosCheckBox
            // 
            this.showPercentZerosCheckBox.AutoSize = true;
            this.showPercentZerosCheckBox.Checked = true;
            this.showPercentZerosCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showPercentZerosCheckBox.Location = new System.Drawing.Point(236, 176);
            this.showPercentZerosCheckBox.Name = "showPercentZerosCheckBox";
            this.showPercentZerosCheckBox.Size = new System.Drawing.Size(260, 17);
            this.showPercentZerosCheckBox.TabIndex = 36;
            this.showPercentZerosCheckBox.Text = "A tizedesrész végén álló nullák ne jelenjenek meg";
            this.showPercentZerosCheckBox.UseVisualStyleBackColor = true;
            // 
            // reverseOrderCheckbox
            // 
            this.reverseOrderCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.reverseOrderCheckbox.AutoSize = true;
            this.reverseOrderCheckbox.Location = new System.Drawing.Point(408, 75);
            this.reverseOrderCheckbox.Name = "reverseOrderCheckbox";
            this.reverseOrderCheckbox.Size = new System.Drawing.Size(104, 17);
            this.reverseOrderCheckbox.TabIndex = 39;
            this.reverseOrderCheckbox.Text = "Fordított sorrend";
            this.reverseOrderCheckbox.UseVisualStyleBackColor = true;
            // 
            // percentCountBox
            // 
            this.percentCountBox.Location = new System.Drawing.Point(237, 150);
            this.percentCountBox.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.percentCountBox.Name = "percentCountBox";
            this.percentCountBox.Size = new System.Drawing.Size(77, 20);
            this.percentCountBox.TabIndex = 34;
            this.percentCountBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.percentCountBox.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // showDoubleZerosCheckBox
            // 
            this.showDoubleZerosCheckBox.AutoSize = true;
            this.showDoubleZerosCheckBox.Location = new System.Drawing.Point(236, 127);
            this.showDoubleZerosCheckBox.Name = "showDoubleZerosCheckBox";
            this.showDoubleZerosCheckBox.Size = new System.Drawing.Size(260, 17);
            this.showDoubleZerosCheckBox.TabIndex = 35;
            this.showDoubleZerosCheckBox.Text = "A tizedesrész végén álló nullák ne jelenjenek meg";
            this.showDoubleZerosCheckBox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(217, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Százalékos értékek tizedesjegyeinek száma:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 355);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(299, 13);
            this.label16.TabIndex = 31;
            this.label16.Text = "Feldolgozott lapok (fejlesztői funkció, csak saját felelősségre!):";
            // 
            // processedPagesCount
            // 
            this.processedPagesCount.Location = new System.Drawing.Point(311, 353);
            this.processedPagesCount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.processedPagesCount.Name = "processedPagesCount";
            this.processedPagesCount.Size = new System.Drawing.Size(77, 20);
            this.processedPagesCount.TabIndex = 30;
            this.processedPagesCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // doubleCountBox
            // 
            this.doubleCountBox.Location = new System.Drawing.Point(236, 101);
            this.doubleCountBox.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.doubleCountBox.Name = "doubleCountBox";
            this.doubleCountBox.Size = new System.Drawing.Size(77, 20);
            this.doubleCountBox.TabIndex = 32;
            this.doubleCountBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.doubleCountBox.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 103);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(216, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "Nem egész számok tizedesjegyeinek száma:";
            // 
            // userDataTab
            // 
            this.userDataTab.Controls.Add(this.groupBox6);
            this.userDataTab.Controls.Add(this.groupBox5);
            this.userDataTab.Controls.Add(this.periodDataGroupBox);
            this.userDataTab.Location = new System.Drawing.Point(4, 22);
            this.userDataTab.Name = "userDataTab";
            this.userDataTab.Padding = new System.Windows.Forms.Padding(3);
            this.userDataTab.Size = new System.Drawing.Size(830, 428);
            this.userDataTab.TabIndex = 1;
            this.userDataTab.Text = "Megjelenített oszlopok";
            this.userDataTab.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.showRankBeforePeriodCheckBox);
            this.groupBox6.Controls.Add(this.showRankInPeriodCheckBox);
            this.groupBox6.Controls.Add(this.showRankChangeInPeriodCheckBox);
            this.groupBox6.Location = new System.Drawing.Point(414, 216);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(412, 94);
            this.groupBox6.TabIndex = 34;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Ranggal kapcsolatos adatok";
            // 
            // showRankBeforePeriodCheckBox
            // 
            this.showRankBeforePeriodCheckBox.AutoSize = true;
            this.showRankBeforePeriodCheckBox.Location = new System.Drawing.Point(9, 19);
            this.showRankBeforePeriodCheckBox.Name = "showRankBeforePeriodCheckBox";
            this.showRankBeforePeriodCheckBox.Size = new System.Drawing.Size(128, 17);
            this.showRankBeforePeriodCheckBox.TabIndex = 29;
            this.showRankBeforePeriodCheckBox.Text = "Rang az időszak előtt";
            this.showRankBeforePeriodCheckBox.UseVisualStyleBackColor = true;
            // 
            // showRankInPeriodCheckBox
            // 
            this.showRankInPeriodCheckBox.AutoSize = true;
            this.showRankInPeriodCheckBox.Location = new System.Drawing.Point(9, 42);
            this.showRankInPeriodCheckBox.Name = "showRankInPeriodCheckBox";
            this.showRankInPeriodCheckBox.Size = new System.Drawing.Size(138, 17);
            this.showRankInPeriodCheckBox.TabIndex = 30;
            this.showRankInPeriodCheckBox.Text = "Rang az időszak végén";
            this.showRankInPeriodCheckBox.UseVisualStyleBackColor = true;
            // 
            // showRankChangeInPeriodCheckBox
            // 
            this.showRankChangeInPeriodCheckBox.AutoSize = true;
            this.showRankChangeInPeriodCheckBox.Location = new System.Drawing.Point(9, 65);
            this.showRankChangeInPeriodCheckBox.Name = "showRankChangeInPeriodCheckBox";
            this.showRankChangeInPeriodCheckBox.Size = new System.Drawing.Size(199, 17);
            this.showRankChangeInPeriodCheckBox.TabIndex = 31;
            this.showRankChangeInPeriodCheckBox.Text = "Rang az időszak végén (változással)";
            this.showRankChangeInPeriodCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.revertedEditsPercentageCheckBox);
            this.groupBox5.Controls.Add(this.revertedEditsCheckBox);
            this.groupBox5.Controls.Add(this.selectAllPcNsButton);
            this.groupBox5.Controls.Add(this.allEditsNamespaceLabel);
            this.groupBox5.Controls.Add(this.allEditsCheckBox);
            this.groupBox5.Controls.Add(this.selectAllNsButton);
            this.groupBox5.Controls.Add(this.allNsInfoLabel);
            this.groupBox5.Controls.Add(this.allNsPcInfoLabel);
            this.groupBox5.Controls.Add(this.meanEditsCheckBox);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.lastEditCheckBox);
            this.groupBox5.Controls.Add(this.activeDaysCheckBox);
            this.groupBox5.Controls.Add(this.firstEditCheckBox);
            this.groupBox5.Controls.Add(this.daysCheckBox);
            this.groupBox5.Location = new System.Drawing.Point(8, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(400, 316);
            this.groupBox5.TabIndex = 33;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Teljes időtartamra vonatkozó adatok";
            // 
            // revertedEditsPercentageCheckBox
            // 
            this.revertedEditsPercentageCheckBox.AutoSize = true;
            this.revertedEditsPercentageCheckBox.Location = new System.Drawing.Point(151, 42);
            this.revertedEditsPercentageCheckBox.Name = "revertedEditsPercentageCheckBox";
            this.revertedEditsPercentageCheckBox.Size = new System.Drawing.Size(88, 17);
            this.revertedEditsPercentageCheckBox.TabIndex = 27;
            this.revertedEditsPercentageCheckBox.Text = "Visszavont %";
            this.revertedEditsPercentageCheckBox.UseVisualStyleBackColor = true;
            // 
            // revertedEditsCheckBox
            // 
            this.revertedEditsCheckBox.AutoSize = true;
            this.revertedEditsCheckBox.Location = new System.Drawing.Point(9, 42);
            this.revertedEditsCheckBox.Name = "revertedEditsCheckBox";
            this.revertedEditsCheckBox.Size = new System.Drawing.Size(135, 17);
            this.revertedEditsCheckBox.TabIndex = 26;
            this.revertedEditsCheckBox.Text = "Visszavont szerkesztés";
            this.revertedEditsCheckBox.UseVisualStyleBackColor = true;
            // 
            // selectAllPcNsButton
            // 
            this.selectAllPcNsButton.Location = new System.Drawing.Point(270, 127);
            this.selectAllPcNsButton.Name = "selectAllPcNsButton";
            this.selectAllPcNsButton.Size = new System.Drawing.Size(124, 23);
            this.selectAllPcNsButton.TabIndex = 24;
            this.selectAllPcNsButton.Text = "Névterek kiválasztása";
            this.selectAllPcNsButton.UseVisualStyleBackColor = true;
            this.selectAllPcNsButton.Click += new System.EventHandler(this.SelectAllPcNsButtonClick);
            // 
            // selectAllNsButton
            // 
            this.selectAllNsButton.Location = new System.Drawing.Point(270, 77);
            this.selectAllNsButton.Name = "selectAllNsButton";
            this.selectAllNsButton.Size = new System.Drawing.Size(124, 23);
            this.selectAllNsButton.TabIndex = 19;
            this.selectAllNsButton.Text = "Névterek kiválasztása";
            this.selectAllNsButton.UseVisualStyleBackColor = true;
            this.selectAllNsButton.Click += new System.EventHandler(this.SelectAllNsButtonClick);
            // 
            // allNsInfoLabel
            // 
            this.allNsInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.allNsInfoLabel.Location = new System.Drawing.Point(6, 82);
            this.allNsInfoLabel.Name = "allNsInfoLabel";
            this.allNsInfoLabel.Size = new System.Drawing.Size(258, 18);
            this.allNsInfoLabel.TabIndex = 20;
            // 
            // allNsPcInfoLabel
            // 
            this.allNsPcInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.allNsPcInfoLabel.Location = new System.Drawing.Point(6, 127);
            this.allNsPcInfoLabel.Name = "allNsPcInfoLabel";
            this.allNsPcInfoLabel.Size = new System.Drawing.Size(258, 18);
            this.allNsPcInfoLabel.TabIndex = 25;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(280, 13);
            this.label8.TabIndex = 23;
            this.label8.Tag = "";
            this.label8.Text = "Szerkesztések %-a az összes szerkesztésre vonatkozóan:";
            // 
            // periodDataGroupBox
            // 
            this.periodDataGroupBox.Controls.Add(this.periodRevertedEditsPercentageCheckBox);
            this.periodDataGroupBox.Controls.Add(this.periodRevertedEditsCheckBox);
            this.periodDataGroupBox.Controls.Add(this.periodEditsCheckBox);
            this.periodDataGroupBox.Controls.Add(this.periodEditsNamespaceLabel);
            this.periodDataGroupBox.Controls.Add(this.selectPeriodNsButton);
            this.periodDataGroupBox.Controls.Add(this.periodNsInfoLabel);
            this.periodDataGroupBox.Controls.Add(this.label10);
            this.periodDataGroupBox.Controls.Add(this.periodMeanEditsCheckBox);
            this.periodDataGroupBox.Controls.Add(this.activePeriodDaysCheckBox);
            this.periodDataGroupBox.Controls.Add(this.periodNsPcInfoLabel);
            this.periodDataGroupBox.Controls.Add(this.selectPeriodPcNsButton);
            this.periodDataGroupBox.Location = new System.Drawing.Point(414, 6);
            this.periodDataGroupBox.Name = "periodDataGroupBox";
            this.periodDataGroupBox.Size = new System.Drawing.Size(412, 204);
            this.periodDataGroupBox.TabIndex = 32;
            this.periodDataGroupBox.TabStop = false;
            this.periodDataGroupBox.Text = "Adott időszakra vonatkozó adatok";
            // 
            // periodRevertedEditsPercentageCheckBox
            // 
            this.periodRevertedEditsPercentageCheckBox.AutoSize = true;
            this.periodRevertedEditsPercentageCheckBox.Location = new System.Drawing.Point(245, 42);
            this.periodRevertedEditsPercentageCheckBox.Name = "periodRevertedEditsPercentageCheckBox";
            this.periodRevertedEditsPercentageCheckBox.Size = new System.Drawing.Size(88, 17);
            this.periodRevertedEditsPercentageCheckBox.TabIndex = 29;
            this.periodRevertedEditsPercentageCheckBox.Text = "Visszavont %";
            this.periodRevertedEditsPercentageCheckBox.UseVisualStyleBackColor = true;
            // 
            // periodRevertedEditsCheckBox
            // 
            this.periodRevertedEditsCheckBox.AutoSize = true;
            this.periodRevertedEditsCheckBox.Location = new System.Drawing.Point(6, 42);
            this.periodRevertedEditsCheckBox.Name = "periodRevertedEditsCheckBox";
            this.periodRevertedEditsCheckBox.Size = new System.Drawing.Size(233, 17);
            this.periodRevertedEditsCheckBox.TabIndex = 27;
            this.periodRevertedEditsCheckBox.Text = "Visszavont szerkesztés az adott időszakban";
            this.periodRevertedEditsCheckBox.UseVisualStyleBackColor = true;
            // 
            // periodEditsNamespaceLabel
            // 
            this.periodEditsNamespaceLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.periodEditsNamespaceLabel.AutoSize = true;
            this.periodEditsNamespaceLabel.Location = new System.Drawing.Point(6, 63);
            this.periodEditsNamespaceLabel.Name = "periodEditsNamespaceLabel";
            this.periodEditsNamespaceLabel.Size = new System.Drawing.Size(263, 13);
            this.periodEditsNamespaceLabel.TabIndex = 11;
            this.periodEditsNamespaceLabel.Tag = "";
            this.periodEditsNamespaceLabel.Text = "Szerkesztés az időszakban a következő névterekben:";
            // 
            // selectPeriodNsButton
            // 
            this.selectPeriodNsButton.Location = new System.Drawing.Point(282, 77);
            this.selectPeriodNsButton.Name = "selectPeriodNsButton";
            this.selectPeriodNsButton.Size = new System.Drawing.Size(124, 23);
            this.selectPeriodNsButton.TabIndex = 21;
            this.selectPeriodNsButton.Tag = "";
            this.selectPeriodNsButton.Text = "Névterek kiválasztása";
            this.selectPeriodNsButton.UseVisualStyleBackColor = true;
            this.selectPeriodNsButton.Click += new System.EventHandler(this.SelectPeriodNsButtonClick);
            // 
            // periodNsInfoLabel
            // 
            this.periodNsInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.periodNsInfoLabel.Location = new System.Drawing.Point(6, 82);
            this.periodNsInfoLabel.Name = "periodNsInfoLabel";
            this.periodNsInfoLabel.Size = new System.Drawing.Size(254, 18);
            this.periodNsInfoLabel.TabIndex = 22;
            this.periodNsInfoLabel.Tag = "";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(352, 13);
            this.label10.TabIndex = 26;
            this.label10.Tag = "";
            this.label10.Text = "Szerkesztések %-a az időszakban végzett szerkesztésekre vonatkozóan:";
            // 
            // periodNsPcInfoLabel
            // 
            this.periodNsPcInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.periodNsPcInfoLabel.Location = new System.Drawing.Point(6, 127);
            this.periodNsPcInfoLabel.Name = "periodNsPcInfoLabel";
            this.periodNsPcInfoLabel.Size = new System.Drawing.Size(254, 18);
            this.periodNsPcInfoLabel.TabIndex = 28;
            this.periodNsPcInfoLabel.Tag = "";
            // 
            // selectPeriodPcNsButton
            // 
            this.selectPeriodPcNsButton.Location = new System.Drawing.Point(282, 127);
            this.selectPeriodPcNsButton.Name = "selectPeriodPcNsButton";
            this.selectPeriodPcNsButton.Size = new System.Drawing.Size(124, 23);
            this.selectPeriodPcNsButton.TabIndex = 27;
            this.selectPeriodPcNsButton.Tag = "";
            this.selectPeriodPcNsButton.Text = "Névterek kiválasztása";
            this.selectPeriodPcNsButton.UseVisualStyleBackColor = true;
            this.selectPeriodPcNsButton.Click += new System.EventHandler(this.SelectPeriodPcNsButtonClick);
            // 
            // filterTab
            // 
            this.filterTab.Controls.Add(this.rankListComboBox);
            this.filterTab.Controls.Add(this.showUsersWithAGivenRankCheckbox);
            this.filterTab.Controls.Add(this.showOnlyRankChanges);
            this.filterTab.Controls.Add(this.label17);
            this.filterTab.Controls.Add(this.allEditsInPeriodAtMostBox);
            this.filterTab.Controls.Add(this.label18);
            this.filterTab.Controls.Add(this.allEditsAtMostBox);
            this.filterTab.Controls.Add(this.label19);
            this.filterTab.Controls.Add(this.activePeriodDaysAtMostBox);
            this.filterTab.Controls.Add(this.label20);
            this.filterTab.Controls.Add(this.activeDaysAtMostBox);
            this.filterTab.Controls.Add(this.label14);
            this.filterTab.Controls.Add(this.allEditsInPeriodAtLeastBox);
            this.filterTab.Controls.Add(this.label13);
            this.filterTab.Controls.Add(this.allEditsAtLeastBox);
            this.filterTab.Controls.Add(this.label12);
            this.filterTab.Controls.Add(this.activePeriodDaysAtLeastBox);
            this.filterTab.Controls.Add(this.label9);
            this.filterTab.Controls.Add(this.activeDaysAtLeastBox);
            this.filterTab.Location = new System.Drawing.Point(4, 22);
            this.filterTab.Name = "filterTab";
            this.filterTab.Padding = new System.Windows.Forms.Padding(3);
            this.filterTab.Size = new System.Drawing.Size(830, 428);
            this.filterTab.TabIndex = 2;
            this.filterTab.Text = "Szűrés";
            this.filterTab.UseVisualStyleBackColor = true;
            // 
            // rankListComboBox
            // 
            this.rankListComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rankListComboBox.DisplayMember = "RankName";
            this.rankListComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rankListComboBox.DropDownWidth = 400;
            this.rankListComboBox.Enabled = false;
            this.rankListComboBox.FormattingEnabled = true;
            this.rankListComboBox.Location = new System.Drawing.Point(217, 240);
            this.rankListComboBox.Name = "rankListComboBox";
            this.rankListComboBox.Size = new System.Drawing.Size(512, 21);
            this.rankListComboBox.TabIndex = 42;
            // 
            // showUsersWithAGivenRankCheckbox
            // 
            this.showUsersWithAGivenRankCheckbox.AutoSize = true;
            this.showUsersWithAGivenRankCheckbox.Location = new System.Drawing.Point(9, 242);
            this.showUsersWithAGivenRankCheckbox.Name = "showUsersWithAGivenRankCheckbox";
            this.showUsersWithAGivenRankCheckbox.Size = new System.Drawing.Size(183, 17);
            this.showUsersWithAGivenRankCheckbox.TabIndex = 41;
            this.showUsersWithAGivenRankCheckbox.Text = "Csak az ilyen rangú felhasználók:";
            this.showUsersWithAGivenRankCheckbox.UseVisualStyleBackColor = true;
            this.showUsersWithAGivenRankCheckbox.CheckedChanged += new System.EventHandler(this.showUsersWithAGivenRankCheckboxCheckedChanged);
            // 
            // showOnlyRankChanges
            // 
            this.showOnlyRankChanges.AutoSize = true;
            this.showOnlyRankChanges.Location = new System.Drawing.Point(9, 219);
            this.showOnlyRankChanges.Name = "showOnlyRankChanges";
            this.showOnlyRankChanges.Size = new System.Drawing.Size(148, 17);
            this.showOnlyRankChanges.TabIndex = 40;
            this.showOnlyRankChanges.Text = "Csak ha volt rangváltozás";
            this.showOnlyRankChanges.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 140);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(248, 13);
            this.label17.TabIndex = 39;
            this.label17.Text = "Összes szerkesztés az adott időszakban legfeljebb:";
            // 
            // allEditsInPeriodAtMostBox
            // 
            this.allEditsInPeriodAtMostBox.Location = new System.Drawing.Point(255, 138);
            this.allEditsInPeriodAtMostBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.allEditsInPeriodAtMostBox.Name = "allEditsInPeriodAtMostBox";
            this.allEditsInPeriodAtMostBox.Size = new System.Drawing.Size(77, 20);
            this.allEditsInPeriodAtMostBox.TabIndex = 38;
            this.allEditsInPeriodAtMostBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 114);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(148, 13);
            this.label18.TabIndex = 37;
            this.label18.Text = "Összes szerkesztés legfelebb:";
            // 
            // allEditsAtMostBox
            // 
            this.allEditsAtMostBox.Location = new System.Drawing.Point(157, 112);
            this.allEditsAtMostBox.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.allEditsAtMostBox.Name = "allEditsAtMostBox";
            this.allEditsAtMostBox.Size = new System.Drawing.Size(77, 20);
            this.allEditsAtMostBox.TabIndex = 36;
            this.allEditsAtMostBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 192);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(354, 13);
            this.label19.TabIndex = 35;
            this.label19.Text = "Aktív (szerkesztéssel töltött) napok száma az adott időszakban legfeljebb:";
            // 
            // activePeriodDaysAtMostBox
            // 
            this.activePeriodDaysAtMostBox.Location = new System.Drawing.Point(361, 190);
            this.activePeriodDaysAtMostBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.activePeriodDaysAtMostBox.Name = "activePeriodDaysAtMostBox";
            this.activePeriodDaysAtMostBox.Size = new System.Drawing.Size(77, 20);
            this.activePeriodDaysAtMostBox.TabIndex = 34;
            this.activePeriodDaysAtMostBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 166);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(256, 13);
            this.label20.TabIndex = 33;
            this.label20.Text = "Aktív (szerkesztéssel töltött) napok száma legfeljebb:";
            // 
            // activeDaysAtMostBox
            // 
            this.activeDaysAtMostBox.Location = new System.Drawing.Point(263, 164);
            this.activeDaysAtMostBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.activeDaysAtMostBox.Name = "activeDaysAtMostBox";
            this.activeDaysAtMostBox.Size = new System.Drawing.Size(77, 20);
            this.activeDaysAtMostBox.TabIndex = 32;
            this.activeDaysAtMostBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 34);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(243, 13);
            this.label14.TabIndex = 29;
            this.label14.Text = "Összes szerkesztés az adott időszakban legalább:";
            // 
            // allEditsInPeriodAtLeastBox
            // 
            this.allEditsInPeriodAtLeastBox.Location = new System.Drawing.Point(255, 32);
            this.allEditsInPeriodAtLeastBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.allEditsInPeriodAtLeastBox.Name = "allEditsInPeriodAtLeastBox";
            this.allEditsInPeriodAtLeastBox.Size = new System.Drawing.Size(77, 20);
            this.allEditsInPeriodAtLeastBox.TabIndex = 28;
            this.allEditsInPeriodAtLeastBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 8);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(145, 13);
            this.label13.TabIndex = 27;
            this.label13.Text = "Összes szerkesztés legalább:";
            // 
            // allEditsAtLeastBox
            // 
            this.allEditsAtLeastBox.Location = new System.Drawing.Point(157, 6);
            this.allEditsAtLeastBox.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.allEditsAtLeastBox.Name = "allEditsAtLeastBox";
            this.allEditsAtLeastBox.Size = new System.Drawing.Size(77, 20);
            this.allEditsAtLeastBox.TabIndex = 26;
            this.allEditsAtLeastBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 86);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(349, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "Aktív (szerkesztéssel töltött) napok száma az adott időszakban legalább:";
            // 
            // activePeriodDaysAtLeastBox
            // 
            this.activePeriodDaysAtLeastBox.Location = new System.Drawing.Point(361, 84);
            this.activePeriodDaysAtLeastBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.activePeriodDaysAtLeastBox.Name = "activePeriodDaysAtLeastBox";
            this.activePeriodDaysAtLeastBox.Size = new System.Drawing.Size(77, 20);
            this.activePeriodDaysAtLeastBox.TabIndex = 24;
            this.activePeriodDaysAtLeastBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(251, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Aktív (szerkesztéssel töltött) napok száma legalább:";
            // 
            // activeDaysAtLeastBox
            // 
            this.activeDaysAtLeastBox.Location = new System.Drawing.Point(263, 58);
            this.activeDaysAtLeastBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.activeDaysAtLeastBox.Name = "activeDaysAtLeastBox";
            this.activeDaysAtLeastBox.Size = new System.Drawing.Size(77, 20);
            this.activeDaysAtLeastBox.TabIndex = 22;
            this.activeDaysAtLeastBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.Location = new System.Drawing.Point(771, 606);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 12;
            this.exitButton.Text = "Kilépés";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Visible = false;
            this.exitButton.Click += new System.EventHandler(this.ExitButtonClick);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(690, 606);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 13;
            this.cancelButton.Text = "Mégse";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Visible = false;
            this.cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressBar.Location = new System.Drawing.Point(13, 606);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(138, 23);
            this.progressBar.TabIndex = 14;
            this.progressBar.Visible = false;
            // 
            // reqsStatusLabel
            // 
            this.reqsStatusLabel.AutoSize = true;
            this.reqsStatusLabel.Location = new System.Drawing.Point(13, 78);
            this.reqsStatusLabel.MaximumSize = new System.Drawing.Size(600, 0);
            this.reqsStatusLabel.Name = "reqsStatusLabel";
            this.reqsStatusLabel.Size = new System.Drawing.Size(13, 13);
            this.reqsStatusLabel.TabIndex = 15;
            this.reqsStatusLabel.Text = "_";
            // 
            // aliasStatusLabel
            // 
            this.aliasStatusLabel.AutoSize = true;
            this.aliasStatusLabel.Location = new System.Drawing.Point(13, 109);
            this.aliasStatusLabel.MaximumSize = new System.Drawing.Size(600, 0);
            this.aliasStatusLabel.Name = "aliasStatusLabel";
            this.aliasStatusLabel.Size = new System.Drawing.Size(13, 13);
            this.aliasStatusLabel.TabIndex = 16;
            this.aliasStatusLabel.Text = "_";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 641);
            this.Controls.Add(this.aliasStatusLabel);
            this.Controls.Add(this.reqsStatusLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.settingsTabControl);
            this.Controls.Add(this.progressText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.doStatisticsButton);
            this.Controls.Add(this.loadDumpsButton);
            this.Controls.Add(this.browseUgDumpButton);
            this.Controls.Add(this.ugDumpTextBox);
            this.Controls.Add(this.browseSmhDumpButton);
            this.Controls.Add(this.smhDumpTextBox);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "qczWikiStat";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormClosed);
            this.Load += new System.EventHandler(this.MainFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.userCountBox)).EndInit();
            this.settingsTabControl.ResumeLayout(false);
            this.baseSettingsTab.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.percentCountBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.processedPagesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleCountBox)).EndInit();
            this.userDataTab.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.periodDataGroupBox.ResumeLayout(false);
            this.periodDataGroupBox.PerformLayout();
            this.filterTab.ResumeLayout(false);
            this.filterTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.allEditsInPeriodAtMostBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.allEditsAtMostBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.activePeriodDaysAtMostBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.activeDaysAtMostBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.allEditsInPeriodAtLeastBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.allEditsAtLeastBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.activePeriodDaysAtLeastBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.activeDaysAtLeastBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox smhDumpTextBox;
        private System.Windows.Forms.Button browseSmhDumpButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ugDumpTextBox;
        private System.Windows.Forms.Button browseUgDumpButton;
        private System.Windows.Forms.Button loadDumpsButton;
        private System.Windows.Forms.DateTimePicker endDatePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox startDateCheckBox;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.Button doStatisticsButton;
        private System.Windows.Forms.CheckBox activePeriodDaysCheckBox;
        private System.Windows.Forms.CheckBox periodMeanEditsCheckBox;
        private System.Windows.Forms.CheckBox meanEditsCheckBox;
        private System.Windows.Forms.CheckBox activeDaysCheckBox;
        private System.Windows.Forms.CheckBox daysCheckBox;
        private System.Windows.Forms.CheckBox lastEditCheckBox;
        private System.Windows.Forms.CheckBox firstEditCheckBox;
        private System.Windows.Forms.CheckBox periodEditsCheckBox;
        private System.Windows.Forms.Label allEditsNamespaceLabel;
        private System.Windows.Forms.CheckBox allEditsCheckBox;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label progressText;
        private System.Windows.Forms.NumericUpDown userCountBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button chooseFile;
        private System.Windows.Forms.TextBox outputFileTextBox;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ComboBox orderListBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabControl settingsTabControl;
        private System.Windows.Forms.TabPage baseSettingsTab;
        private System.Windows.Forms.TabPage userDataTab;
        private System.Windows.Forms.CheckBox useAnonListCheckBox;
        private System.Windows.Forms.CheckBox useBotListCheckBox;
        private System.Windows.Forms.CheckBox showPrivilegesCheckBox;
        private System.Windows.Forms.CheckBox showBotsCheckBox;
        private System.Windows.Forms.Label allNsInfoLabel;
        private System.Windows.Forms.Button selectAllNsButton;
        private System.Windows.Forms.Label periodNsPcInfoLabel;
        private System.Windows.Forms.Button selectPeriodPcNsButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label allNsPcInfoLabel;
        private System.Windows.Forms.Button selectAllPcNsButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label periodNsInfoLabel;
        private System.Windows.Forms.Button selectPeriodNsButton;
        private System.Windows.Forms.Label periodEditsNamespaceLabel;
        private System.Windows.Forms.NumericUpDown doubleCountBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown percentCountBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox showPercentZerosCheckBox;
        private System.Windows.Forms.CheckBox showDoubleZerosCheckBox;
        private System.Windows.Forms.TabPage filterTab;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown activePeriodDaysAtLeastBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown activeDaysAtLeastBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown allEditsAtLeastBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown allEditsInPeriodAtLeastBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown processedPagesCount;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.RadioButton privilegesInNewColumnCheckBix;
        private System.Windows.Forms.RadioButton privilegesUnderCheckBox;
		private System.Windows.Forms.CheckBox reverseOrderCheckbox;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.NumericUpDown allEditsInPeriodAtMostBox;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.NumericUpDown allEditsAtMostBox;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.NumericUpDown activePeriodDaysAtMostBox;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.NumericUpDown activeDaysAtMostBox;
		private System.Windows.Forms.CheckBox showRankChangeInPeriodCheckBox;
		private System.Windows.Forms.CheckBox showRankBeforePeriodCheckBox;
		private System.Windows.Forms.CheckBox showRankInPeriodCheckBox;
		private System.Windows.Forms.Label reqsStatusLabel;
		private System.Windows.Forms.CheckBox showOnlyRankChanges;
		private System.Windows.Forms.ComboBox rankListComboBox;
		private System.Windows.Forms.CheckBox showUsersWithAGivenRankCheckbox;
		private System.Windows.Forms.RadioButton rankListOutputRadioButton;
		private System.Windows.Forms.RadioButton statisticsOutputRadioButton;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox showUnregisteredUsersCheckbox;
		private System.Windows.Forms.CheckBox showRegisteredUsersCheckbox;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.CheckBox createCache;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.GroupBox periodDataGroupBox;
		private System.Windows.Forms.CheckBox mergeAliasEdits;
		private System.Windows.Forms.CheckBox revertedEditsCheckBox;
		private System.Windows.Forms.CheckBox periodRevertedEditsCheckBox;
		private System.Windows.Forms.CheckBox revertedEditsPercentageCheckBox;
		private System.Windows.Forms.CheckBox periodRevertedEditsPercentageCheckBox;
		private System.Windows.Forms.Label aliasStatusLabel;
		private System.Windows.Forms.RadioButton templateDataOutputRadioButton;
	}
}

