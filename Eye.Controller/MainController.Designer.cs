namespace Eye.Controller
{
    partial class MainController
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
            this.startButton = new System.Windows.Forms.Button();
            this.gameStateListenerStatusLabel = new System.Windows.Forms.Label();
            this.combatLogListenerStatusLabel = new System.Windows.Forms.Label();
            this.localAddressLabel = new System.Windows.Forms.Label();
            this.localAddressTextBox = new System.Windows.Forms.TextBox();
            this.webSocketServerStatusLabel = new System.Windows.Forms.Label();
            this.observersCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.observersTokenLabel = new System.Windows.Forms.Label();
            this.modulesReloadButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.receivedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.combatLogStatsLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.gameStatsStatsLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.actionLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.lastActionLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.modulesCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.modulesLabel = new System.Windows.Forms.Label();
            this.modulesTabControl = new System.Windows.Forms.TabControl();
            this.smokeTabPage = new System.Windows.Forms.TabPage();
            this.smokeRemoveBtn = new System.Windows.Forms.Button();
            this.smokeAddBtn = new System.Windows.Forms.Button();
            this.smokeHeroesLabel = new System.Windows.Forms.Label();
            this.smokeHeroesСomboBox = new System.Windows.Forms.ComboBox();
            this.importantItemsTabPage = new System.Windows.Forms.TabPage();
            this.importantItemsRemoveRapierBtn = new System.Windows.Forms.Button();
            this.importantItemsRemoveAegisBtn = new System.Windows.Forms.Button();
            this.importantItemsRemoveGemBtn = new System.Windows.Forms.Button();
            this.importantItemsAddRapierBtn = new System.Windows.Forms.Button();
            this.importantItemsAddAegisBtn = new System.Windows.Forms.Button();
            this.importantItemsAddGemBtn = new System.Windows.Forms.Button();
            this.importantItemsHeroesLabel = new System.Windows.Forms.Label();
            this.importantItemsHeroesComboBox = new System.Windows.Forms.ComboBox();
            this.runesTabPage = new System.Windows.Forms.TabPage();
            this.runesRemoveArcaneBtn = new System.Windows.Forms.Button();
            this.runesRemoveInvisBtn = new System.Windows.Forms.Button();
            this.runesRemoveHasteBtn = new System.Windows.Forms.Button();
            this.runesRemoveRegBtn = new System.Windows.Forms.Button();
            this.runesRemoveDDBtn = new System.Windows.Forms.Button();
            this.runesAddArcaneBtn = new System.Windows.Forms.Button();
            this.runesAddInvisBtn = new System.Windows.Forms.Button();
            this.runesAddHasteBtn = new System.Windows.Forms.Button();
            this.runesAddRegBtn = new System.Windows.Forms.Button();
            this.runesAddDDBtn = new System.Windows.Forms.Button();
            this.runesHeroesLabel = new System.Windows.Forms.Label();
            this.runesHeroesComboBox = new System.Windows.Forms.ComboBox();
            this.bountyGoldTabPage = new System.Windows.Forms.TabPage();
            this.gountyGoldHideBtn = new System.Windows.Forms.Button();
            this.bountyGoldOpenBtn = new System.Windows.Forms.Button();
            this.modulesComboBox = new System.Windows.Forms.ComboBox();
            this.updateModuleBtn = new System.Windows.Forms.Button();
            this.dataShowerTabPage = new System.Windows.Forms.TabPage();
            this.datasComboBox = new System.Windows.Forms.ComboBox();
            this.dataShowBtn = new System.Windows.Forms.Button();
            this.dataHideBtn = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.modulesTabControl.SuspendLayout();
            this.smokeTabPage.SuspendLayout();
            this.importantItemsTabPage.SuspendLayout();
            this.runesTabPage.SuspendLayout();
            this.bountyGoldTabPage.SuspendLayout();
            this.dataShowerTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.startButton.Location = new System.Drawing.Point(344, 261);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(70, 22);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Запустить";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // gameStateListenerStatusLabel
            // 
            this.gameStateListenerStatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gameStateListenerStatusLabel.AutoSize = true;
            this.gameStateListenerStatusLabel.Location = new System.Drawing.Point(8, 265);
            this.gameStateListenerStatusLabel.Name = "gameStateListenerStatusLabel";
            this.gameStateListenerStatusLabel.Size = new System.Drawing.Size(183, 13);
            this.gameStateListenerStatusLabel.TabIndex = 2;
            this.gameStateListenerStatusLabel.Tag = "GameState Listener: {0}";
            this.gameStateListenerStatusLabel.Text = "GameState Listener: NOT STARTED";
            // 
            // combatLogListenerStatusLabel
            // 
            this.combatLogListenerStatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.combatLogListenerStatusLabel.AutoSize = true;
            this.combatLogListenerStatusLabel.Location = new System.Drawing.Point(8, 245);
            this.combatLogListenerStatusLabel.Name = "combatLogListenerStatusLabel";
            this.combatLogListenerStatusLabel.Size = new System.Drawing.Size(184, 13);
            this.combatLogListenerStatusLabel.TabIndex = 3;
            this.combatLogListenerStatusLabel.Tag = "CombatLog Listener: {0}";
            this.combatLogListenerStatusLabel.Text = "CombatLog Listener: NOT STARTED";
            // 
            // localAddressLabel
            // 
            this.localAddressLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.localAddressLabel.AutoSize = true;
            this.localAddressLabel.Location = new System.Drawing.Point(198, 245);
            this.localAddressLabel.Name = "localAddressLabel";
            this.localAddressLabel.Size = new System.Drawing.Size(81, 13);
            this.localAddressLabel.TabIndex = 4;
            this.localAddressLabel.Text = "Локальный IP:";
            // 
            // localAddressTextBox
            // 
            this.localAddressTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.localAddressTextBox.Location = new System.Drawing.Point(201, 262);
            this.localAddressTextBox.Name = "localAddressTextBox";
            this.localAddressTextBox.ReadOnly = true;
            this.localAddressTextBox.Size = new System.Drawing.Size(137, 20);
            this.localAddressTextBox.TabIndex = 5;
            // 
            // webSocketServerStatusLabel
            // 
            this.webSocketServerStatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.webSocketServerStatusLabel.AutoSize = true;
            this.webSocketServerStatusLabel.Location = new System.Drawing.Point(8, 225);
            this.webSocketServerStatusLabel.Name = "webSocketServerStatusLabel";
            this.webSocketServerStatusLabel.Size = new System.Drawing.Size(181, 13);
            this.webSocketServerStatusLabel.TabIndex = 6;
            this.webSocketServerStatusLabel.Tag = "WebSocket Server: {0}";
            this.webSocketServerStatusLabel.Text = "WebSocket Server: NOT STARTED";
            // 
            // observersCheckedListBox
            // 
            this.observersCheckedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.observersCheckedListBox.FormattingEnabled = true;
            this.observersCheckedListBox.Location = new System.Drawing.Point(11, 27);
            this.observersCheckedListBox.Name = "observersCheckedListBox";
            this.observersCheckedListBox.Size = new System.Drawing.Size(181, 184);
            this.observersCheckedListBox.TabIndex = 9;
            this.observersCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.tokensCheckedListBox_ItemCheck);
            // 
            // observersTokenLabel
            // 
            this.observersTokenLabel.AutoSize = true;
            this.observersTokenLabel.Location = new System.Drawing.Point(8, 9);
            this.observersTokenLabel.Name = "observersTokenLabel";
            this.observersTokenLabel.Size = new System.Drawing.Size(112, 13);
            this.observersTokenLabel.TabIndex = 10;
            this.observersTokenLabel.Text = "Токены обсерверов:";
            // 
            // modulesReloadButton
            // 
            this.modulesReloadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.modulesReloadButton.Location = new System.Drawing.Point(201, 217);
            this.modulesReloadButton.Name = "modulesReloadButton";
            this.modulesReloadButton.Size = new System.Drawing.Size(213, 23);
            this.modulesReloadButton.TabIndex = 11;
            this.modulesReloadButton.Text = "Перезагрузить все модули";
            this.modulesReloadButton.UseVisualStyleBackColor = true;
            this.modulesReloadButton.Click += new System.EventHandler(this.modulesReloadButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.receivedLabel,
            this.combatLogStatsLabel,
            this.gameStatsStatsLabel,
            this.actionLabel,
            this.lastActionLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 289);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(861, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // receivedLabel
            // 
            this.receivedLabel.Name = "receivedLabel";
            this.receivedLabel.Size = new System.Drawing.Size(57, 17);
            this.receivedLabel.Tag = "Received:";
            this.receivedLabel.Text = "Received:";
            // 
            // combatLogStatsLabel
            // 
            this.combatLogStatsLabel.Name = "combatLogStatsLabel";
            this.combatLogStatsLabel.Size = new System.Drawing.Size(111, 17);
            this.combatLogStatsLabel.Tag = "{0} combatlog events";
            this.combatLogStatsLabel.Text = "0 combatlog events";
            // 
            // gameStatsStatsLabel
            // 
            this.gameStatsStatsLabel.Name = "gameStatsStatsLabel";
            this.gameStatsStatsLabel.Size = new System.Drawing.Size(108, 17);
            this.gameStatsStatsLabel.Tag = "{0} gamestate events";
            this.gameStatsStatsLabel.Text = "0 gamestate events";
            // 
            // actionLabel
            // 
            this.actionLabel.Name = "actionLabel";
            this.actionLabel.Size = new System.Drawing.Size(123, 17);
            this.actionLabel.Text = "Последние действие:";
            // 
            // lastActionLabel
            // 
            this.lastActionLabel.Name = "lastActionLabel";
            this.lastActionLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // modulesCheckedListBox
            // 
            this.modulesCheckedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.modulesCheckedListBox.DisplayMember = "Name";
            this.modulesCheckedListBox.FormattingEnabled = true;
            this.modulesCheckedListBox.Location = new System.Drawing.Point(201, 27);
            this.modulesCheckedListBox.Name = "modulesCheckedListBox";
            this.modulesCheckedListBox.Size = new System.Drawing.Size(218, 154);
            this.modulesCheckedListBox.TabIndex = 13;
            this.modulesCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.modulesCheckedListBox_ItemCheck);
            // 
            // modulesLabel
            // 
            this.modulesLabel.AutoSize = true;
            this.modulesLabel.Location = new System.Drawing.Point(198, 9);
            this.modulesLabel.Name = "modulesLabel";
            this.modulesLabel.Size = new System.Drawing.Size(48, 13);
            this.modulesLabel.TabIndex = 14;
            this.modulesLabel.Text = "Модули:";
            // 
            // modulesTabControl
            // 
            this.modulesTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.modulesTabControl.Controls.Add(this.dataShowerTabPage);
            this.modulesTabControl.Controls.Add(this.smokeTabPage);
            this.modulesTabControl.Controls.Add(this.importantItemsTabPage);
            this.modulesTabControl.Controls.Add(this.runesTabPage);
            this.modulesTabControl.Controls.Add(this.bountyGoldTabPage);
            this.modulesTabControl.Location = new System.Drawing.Point(425, 9);
            this.modulesTabControl.Name = "modulesTabControl";
            this.modulesTabControl.SelectedIndex = 0;
            this.modulesTabControl.Size = new System.Drawing.Size(428, 274);
            this.modulesTabControl.TabIndex = 15;
            // 
            // smokeTabPage
            // 
            this.smokeTabPage.Controls.Add(this.smokeRemoveBtn);
            this.smokeTabPage.Controls.Add(this.smokeAddBtn);
            this.smokeTabPage.Controls.Add(this.smokeHeroesLabel);
            this.smokeTabPage.Controls.Add(this.smokeHeroesСomboBox);
            this.smokeTabPage.Location = new System.Drawing.Point(4, 22);
            this.smokeTabPage.Name = "smokeTabPage";
            this.smokeTabPage.Size = new System.Drawing.Size(420, 248);
            this.smokeTabPage.TabIndex = 0;
            this.smokeTabPage.Text = "Смок";
            this.smokeTabPage.UseVisualStyleBackColor = true;
            // 
            // smokeRemoveBtn
            // 
            this.smokeRemoveBtn.Location = new System.Drawing.Point(84, 30);
            this.smokeRemoveBtn.Name = "smokeRemoveBtn";
            this.smokeRemoveBtn.Size = new System.Drawing.Size(75, 23);
            this.smokeRemoveBtn.TabIndex = 3;
            this.smokeRemoveBtn.Text = "Удалить";
            this.smokeRemoveBtn.UseVisualStyleBackColor = true;
            this.smokeRemoveBtn.Click += new System.EventHandler(this.smokeRemoveBtn_Click);
            // 
            // smokeAddBtn
            // 
            this.smokeAddBtn.Location = new System.Drawing.Point(3, 30);
            this.smokeAddBtn.Name = "smokeAddBtn";
            this.smokeAddBtn.Size = new System.Drawing.Size(75, 23);
            this.smokeAddBtn.TabIndex = 2;
            this.smokeAddBtn.Text = "Добавить";
            this.smokeAddBtn.UseVisualStyleBackColor = true;
            this.smokeAddBtn.Click += new System.EventHandler(this.smokeAddBtn_Click);
            // 
            // smokeHeroesLabel
            // 
            this.smokeHeroesLabel.AutoSize = true;
            this.smokeHeroesLabel.Location = new System.Drawing.Point(3, 6);
            this.smokeHeroesLabel.Name = "smokeHeroesLabel";
            this.smokeHeroesLabel.Size = new System.Drawing.Size(86, 13);
            this.smokeHeroesLabel.TabIndex = 1;
            this.smokeHeroesLabel.Text = "Выберите слот:";
            // 
            // smokeHeroesСomboBox
            // 
            this.smokeHeroesСomboBox.DisplayMember = "Name";
            this.smokeHeroesСomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.smokeHeroesСomboBox.FormattingEnabled = true;
            this.smokeHeroesСomboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.smokeHeroesСomboBox.Location = new System.Drawing.Point(95, 3);
            this.smokeHeroesСomboBox.Name = "smokeHeroesСomboBox";
            this.smokeHeroesСomboBox.Size = new System.Drawing.Size(64, 21);
            this.smokeHeroesСomboBox.TabIndex = 0;
            // 
            // importantItemsTabPage
            // 
            this.importantItemsTabPage.Controls.Add(this.importantItemsRemoveRapierBtn);
            this.importantItemsTabPage.Controls.Add(this.importantItemsRemoveAegisBtn);
            this.importantItemsTabPage.Controls.Add(this.importantItemsRemoveGemBtn);
            this.importantItemsTabPage.Controls.Add(this.importantItemsAddRapierBtn);
            this.importantItemsTabPage.Controls.Add(this.importantItemsAddAegisBtn);
            this.importantItemsTabPage.Controls.Add(this.importantItemsAddGemBtn);
            this.importantItemsTabPage.Controls.Add(this.importantItemsHeroesLabel);
            this.importantItemsTabPage.Controls.Add(this.importantItemsHeroesComboBox);
            this.importantItemsTabPage.Location = new System.Drawing.Point(4, 22);
            this.importantItemsTabPage.Name = "importantItemsTabPage";
            this.importantItemsTabPage.Size = new System.Drawing.Size(420, 248);
            this.importantItemsTabPage.TabIndex = 1;
            this.importantItemsTabPage.Text = "Важные пердметы";
            this.importantItemsTabPage.UseVisualStyleBackColor = true;
            // 
            // importantItemsRemoveRapierBtn
            // 
            this.importantItemsRemoveRapierBtn.Location = new System.Drawing.Point(114, 88);
            this.importantItemsRemoveRapierBtn.Name = "importantItemsRemoveRapierBtn";
            this.importantItemsRemoveRapierBtn.Size = new System.Drawing.Size(75, 23);
            this.importantItemsRemoveRapierBtn.TabIndex = 11;
            this.importantItemsRemoveRapierBtn.Text = "Удалить";
            this.importantItemsRemoveRapierBtn.UseVisualStyleBackColor = true;
            this.importantItemsRemoveRapierBtn.Click += new System.EventHandler(this.importantItemsRemoveRapierBtn_Click);
            // 
            // importantItemsRemoveAegisBtn
            // 
            this.importantItemsRemoveAegisBtn.Location = new System.Drawing.Point(114, 59);
            this.importantItemsRemoveAegisBtn.Name = "importantItemsRemoveAegisBtn";
            this.importantItemsRemoveAegisBtn.Size = new System.Drawing.Size(75, 23);
            this.importantItemsRemoveAegisBtn.TabIndex = 10;
            this.importantItemsRemoveAegisBtn.Text = "Удалить";
            this.importantItemsRemoveAegisBtn.UseVisualStyleBackColor = true;
            this.importantItemsRemoveAegisBtn.Click += new System.EventHandler(this.importantItemsRemoveAegisBtn_Click);
            // 
            // importantItemsRemoveGemBtn
            // 
            this.importantItemsRemoveGemBtn.Location = new System.Drawing.Point(114, 30);
            this.importantItemsRemoveGemBtn.Name = "importantItemsRemoveGemBtn";
            this.importantItemsRemoveGemBtn.Size = new System.Drawing.Size(75, 23);
            this.importantItemsRemoveGemBtn.TabIndex = 9;
            this.importantItemsRemoveGemBtn.Text = "Удалить";
            this.importantItemsRemoveGemBtn.UseVisualStyleBackColor = true;
            this.importantItemsRemoveGemBtn.Click += new System.EventHandler(this.importantItemsRemoveGemBtn_Click);
            // 
            // importantItemsAddRapierBtn
            // 
            this.importantItemsAddRapierBtn.Location = new System.Drawing.Point(4, 88);
            this.importantItemsAddRapierBtn.Name = "importantItemsAddRapierBtn";
            this.importantItemsAddRapierBtn.Size = new System.Drawing.Size(104, 23);
            this.importantItemsAddRapierBtn.TabIndex = 8;
            this.importantItemsAddRapierBtn.Text = "Добавить рапиру";
            this.importantItemsAddRapierBtn.UseVisualStyleBackColor = true;
            this.importantItemsAddRapierBtn.Click += new System.EventHandler(this.importantItemsAddRapierBtn_Click);
            // 
            // importantItemsAddAegisBtn
            // 
            this.importantItemsAddAegisBtn.Location = new System.Drawing.Point(4, 59);
            this.importantItemsAddAegisBtn.Name = "importantItemsAddAegisBtn";
            this.importantItemsAddAegisBtn.Size = new System.Drawing.Size(104, 23);
            this.importantItemsAddAegisBtn.TabIndex = 7;
            this.importantItemsAddAegisBtn.Text = "Добавить аегис";
            this.importantItemsAddAegisBtn.UseVisualStyleBackColor = true;
            this.importantItemsAddAegisBtn.Click += new System.EventHandler(this.importantItemsAddAegisBtn_Click);
            // 
            // importantItemsAddGemBtn
            // 
            this.importantItemsAddGemBtn.Location = new System.Drawing.Point(4, 30);
            this.importantItemsAddGemBtn.Name = "importantItemsAddGemBtn";
            this.importantItemsAddGemBtn.Size = new System.Drawing.Size(104, 23);
            this.importantItemsAddGemBtn.TabIndex = 6;
            this.importantItemsAddGemBtn.Text = "Добавить гем";
            this.importantItemsAddGemBtn.UseVisualStyleBackColor = true;
            this.importantItemsAddGemBtn.Click += new System.EventHandler(this.importantItemsAddGemBtn_Click);
            // 
            // importantItemsHeroesLabel
            // 
            this.importantItemsHeroesLabel.AutoSize = true;
            this.importantItemsHeroesLabel.Location = new System.Drawing.Point(3, 6);
            this.importantItemsHeroesLabel.Name = "importantItemsHeroesLabel";
            this.importantItemsHeroesLabel.Size = new System.Drawing.Size(86, 13);
            this.importantItemsHeroesLabel.TabIndex = 5;
            this.importantItemsHeroesLabel.Text = "Выберите слот:";
            // 
            // importantItemsHeroesComboBox
            // 
            this.importantItemsHeroesComboBox.DisplayMember = "Name";
            this.importantItemsHeroesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.importantItemsHeroesComboBox.FormattingEnabled = true;
            this.importantItemsHeroesComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.importantItemsHeroesComboBox.Location = new System.Drawing.Point(114, 3);
            this.importantItemsHeroesComboBox.Name = "importantItemsHeroesComboBox";
            this.importantItemsHeroesComboBox.Size = new System.Drawing.Size(75, 21);
            this.importantItemsHeroesComboBox.TabIndex = 4;
            // 
            // runesTabPage
            // 
            this.runesTabPage.Controls.Add(this.runesRemoveArcaneBtn);
            this.runesTabPage.Controls.Add(this.runesRemoveInvisBtn);
            this.runesTabPage.Controls.Add(this.runesRemoveHasteBtn);
            this.runesTabPage.Controls.Add(this.runesRemoveRegBtn);
            this.runesTabPage.Controls.Add(this.runesRemoveDDBtn);
            this.runesTabPage.Controls.Add(this.runesAddArcaneBtn);
            this.runesTabPage.Controls.Add(this.runesAddInvisBtn);
            this.runesTabPage.Controls.Add(this.runesAddHasteBtn);
            this.runesTabPage.Controls.Add(this.runesAddRegBtn);
            this.runesTabPage.Controls.Add(this.runesAddDDBtn);
            this.runesTabPage.Controls.Add(this.runesHeroesLabel);
            this.runesTabPage.Controls.Add(this.runesHeroesComboBox);
            this.runesTabPage.Location = new System.Drawing.Point(4, 22);
            this.runesTabPage.Name = "runesTabPage";
            this.runesTabPage.Size = new System.Drawing.Size(420, 248);
            this.runesTabPage.TabIndex = 2;
            this.runesTabPage.Text = "Руны";
            this.runesTabPage.UseVisualStyleBackColor = true;
            // 
            // runesRemoveArcaneBtn
            // 
            this.runesRemoveArcaneBtn.Location = new System.Drawing.Point(115, 146);
            this.runesRemoveArcaneBtn.Name = "runesRemoveArcaneBtn";
            this.runesRemoveArcaneBtn.Size = new System.Drawing.Size(75, 23);
            this.runesRemoveArcaneBtn.TabIndex = 19;
            this.runesRemoveArcaneBtn.Text = "Удалить";
            this.runesRemoveArcaneBtn.UseVisualStyleBackColor = true;
            this.runesRemoveArcaneBtn.Click += new System.EventHandler(this.runesRemoveArcaneBtn_Click);
            // 
            // runesRemoveInvisBtn
            // 
            this.runesRemoveInvisBtn.Location = new System.Drawing.Point(115, 117);
            this.runesRemoveInvisBtn.Name = "runesRemoveInvisBtn";
            this.runesRemoveInvisBtn.Size = new System.Drawing.Size(75, 23);
            this.runesRemoveInvisBtn.TabIndex = 18;
            this.runesRemoveInvisBtn.Text = "Удалить";
            this.runesRemoveInvisBtn.UseVisualStyleBackColor = true;
            this.runesRemoveInvisBtn.Click += new System.EventHandler(this.runesRemoveInvisBtn_Click);
            // 
            // runesRemoveHasteBtn
            // 
            this.runesRemoveHasteBtn.Location = new System.Drawing.Point(115, 88);
            this.runesRemoveHasteBtn.Name = "runesRemoveHasteBtn";
            this.runesRemoveHasteBtn.Size = new System.Drawing.Size(75, 23);
            this.runesRemoveHasteBtn.TabIndex = 19;
            this.runesRemoveHasteBtn.Text = "Удалить";
            this.runesRemoveHasteBtn.UseVisualStyleBackColor = true;
            this.runesRemoveHasteBtn.Click += new System.EventHandler(this.runesRemoveHasteBtn_Click);
            // 
            // runesRemoveRegBtn
            // 
            this.runesRemoveRegBtn.Location = new System.Drawing.Point(115, 59);
            this.runesRemoveRegBtn.Name = "runesRemoveRegBtn";
            this.runesRemoveRegBtn.Size = new System.Drawing.Size(75, 23);
            this.runesRemoveRegBtn.TabIndex = 18;
            this.runesRemoveRegBtn.Text = "Удалить";
            this.runesRemoveRegBtn.UseVisualStyleBackColor = true;
            this.runesRemoveRegBtn.Click += new System.EventHandler(this.runesRemoveRegBtn_Click);
            // 
            // runesRemoveDDBtn
            // 
            this.runesRemoveDDBtn.Location = new System.Drawing.Point(115, 30);
            this.runesRemoveDDBtn.Name = "runesRemoveDDBtn";
            this.runesRemoveDDBtn.Size = new System.Drawing.Size(75, 23);
            this.runesRemoveDDBtn.TabIndex = 17;
            this.runesRemoveDDBtn.Text = "Удалить";
            this.runesRemoveDDBtn.UseVisualStyleBackColor = true;
            this.runesRemoveDDBtn.Click += new System.EventHandler(this.runesRemoveDDBtn_Click);
            // 
            // runesAddArcaneBtn
            // 
            this.runesAddArcaneBtn.Location = new System.Drawing.Point(5, 146);
            this.runesAddArcaneBtn.Name = "runesAddArcaneBtn";
            this.runesAddArcaneBtn.Size = new System.Drawing.Size(104, 23);
            this.runesAddArcaneBtn.TabIndex = 16;
            this.runesAddArcaneBtn.Text = "Добавить волш.";
            this.runesAddArcaneBtn.UseVisualStyleBackColor = true;
            this.runesAddArcaneBtn.Click += new System.EventHandler(this.runesAddArcaneBtn_Click);
            // 
            // runesAddInvisBtn
            // 
            this.runesAddInvisBtn.Location = new System.Drawing.Point(5, 117);
            this.runesAddInvisBtn.Name = "runesAddInvisBtn";
            this.runesAddInvisBtn.Size = new System.Drawing.Size(104, 23);
            this.runesAddInvisBtn.TabIndex = 15;
            this.runesAddInvisBtn.Text = "Добавить инвиз";
            this.runesAddInvisBtn.UseVisualStyleBackColor = true;
            this.runesAddInvisBtn.Click += new System.EventHandler(this.runesAddInvisBtn_Click);
            // 
            // runesAddHasteBtn
            // 
            this.runesAddHasteBtn.Location = new System.Drawing.Point(5, 88);
            this.runesAddHasteBtn.Name = "runesAddHasteBtn";
            this.runesAddHasteBtn.Size = new System.Drawing.Size(104, 23);
            this.runesAddHasteBtn.TabIndex = 16;
            this.runesAddHasteBtn.Text = "Добавить хасту";
            this.runesAddHasteBtn.UseVisualStyleBackColor = true;
            this.runesAddHasteBtn.Click += new System.EventHandler(this.runesAddHasteBtn_Click);
            // 
            // runesAddRegBtn
            // 
            this.runesAddRegBtn.Location = new System.Drawing.Point(5, 59);
            this.runesAddRegBtn.Name = "runesAddRegBtn";
            this.runesAddRegBtn.Size = new System.Drawing.Size(104, 23);
            this.runesAddRegBtn.TabIndex = 15;
            this.runesAddRegBtn.Text = "Добавить реген";
            this.runesAddRegBtn.UseVisualStyleBackColor = true;
            this.runesAddRegBtn.Click += new System.EventHandler(this.runesAddRegBtn_Click);
            // 
            // runesAddDDBtn
            // 
            this.runesAddDDBtn.Location = new System.Drawing.Point(5, 30);
            this.runesAddDDBtn.Name = "runesAddDDBtn";
            this.runesAddDDBtn.Size = new System.Drawing.Size(104, 23);
            this.runesAddDDBtn.TabIndex = 14;
            this.runesAddDDBtn.Text = "Добавить ДД";
            this.runesAddDDBtn.UseVisualStyleBackColor = true;
            this.runesAddDDBtn.Click += new System.EventHandler(this.runesAddDDBtn_Click);
            // 
            // runesHeroesLabel
            // 
            this.runesHeroesLabel.AutoSize = true;
            this.runesHeroesLabel.Location = new System.Drawing.Point(4, 6);
            this.runesHeroesLabel.Name = "runesHeroesLabel";
            this.runesHeroesLabel.Size = new System.Drawing.Size(86, 13);
            this.runesHeroesLabel.TabIndex = 13;
            this.runesHeroesLabel.Text = "Выберите слот:";
            // 
            // runesHeroesComboBox
            // 
            this.runesHeroesComboBox.DisplayMember = "Name";
            this.runesHeroesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.runesHeroesComboBox.FormattingEnabled = true;
            this.runesHeroesComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.runesHeroesComboBox.Location = new System.Drawing.Point(115, 3);
            this.runesHeroesComboBox.Name = "runesHeroesComboBox";
            this.runesHeroesComboBox.Size = new System.Drawing.Size(75, 21);
            this.runesHeroesComboBox.TabIndex = 12;
            // 
            // bountyGoldTabPage
            // 
            this.bountyGoldTabPage.Controls.Add(this.gountyGoldHideBtn);
            this.bountyGoldTabPage.Controls.Add(this.bountyGoldOpenBtn);
            this.bountyGoldTabPage.Location = new System.Drawing.Point(4, 22);
            this.bountyGoldTabPage.Name = "bountyGoldTabPage";
            this.bountyGoldTabPage.Size = new System.Drawing.Size(420, 248);
            this.bountyGoldTabPage.TabIndex = 3;
            this.bountyGoldTabPage.Text = "Золото за баунти руны";
            this.bountyGoldTabPage.UseVisualStyleBackColor = true;
            // 
            // gountyGoldHideBtn
            // 
            this.gountyGoldHideBtn.Location = new System.Drawing.Point(3, 32);
            this.gountyGoldHideBtn.Name = "gountyGoldHideBtn";
            this.gountyGoldHideBtn.Size = new System.Drawing.Size(237, 23);
            this.gountyGoldHideBtn.TabIndex = 0;
            this.gountyGoldHideBtn.Text = "Скрыть";
            this.gountyGoldHideBtn.UseVisualStyleBackColor = true;
            this.gountyGoldHideBtn.Click += new System.EventHandler(this.gountyGoldHideBtn_Click);
            // 
            // bountyGoldOpenBtn
            // 
            this.bountyGoldOpenBtn.Location = new System.Drawing.Point(3, 3);
            this.bountyGoldOpenBtn.Name = "bountyGoldOpenBtn";
            this.bountyGoldOpenBtn.Size = new System.Drawing.Size(237, 23);
            this.bountyGoldOpenBtn.TabIndex = 0;
            this.bountyGoldOpenBtn.Text = "Показать";
            this.bountyGoldOpenBtn.UseVisualStyleBackColor = true;
            this.bountyGoldOpenBtn.Click += new System.EventHandler(this.gountyGoldOpenBtn_Click);
            // 
            // modulesComboBox
            // 
            this.modulesComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.modulesComboBox.DisplayMember = "Name";
            this.modulesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modulesComboBox.FormattingEnabled = true;
            this.modulesComboBox.Location = new System.Drawing.Point(202, 190);
            this.modulesComboBox.Name = "modulesComboBox";
            this.modulesComboBox.Size = new System.Drawing.Size(112, 21);
            this.modulesComboBox.TabIndex = 17;
            // 
            // updateModuleBtn
            // 
            this.updateModuleBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.updateModuleBtn.Location = new System.Drawing.Point(320, 189);
            this.updateModuleBtn.Name = "updateModuleBtn";
            this.updateModuleBtn.Size = new System.Drawing.Size(94, 23);
            this.updateModuleBtn.TabIndex = 0;
            this.updateModuleBtn.Text = "Перезагрузить";
            this.updateModuleBtn.UseVisualStyleBackColor = true;
            this.updateModuleBtn.Click += new System.EventHandler(this.updateModuleBtn_Click);
            // 
            // dataShowerTabPage
            // 
            this.dataShowerTabPage.Controls.Add(this.dataHideBtn);
            this.dataShowerTabPage.Controls.Add(this.dataShowBtn);
            this.dataShowerTabPage.Controls.Add(this.datasComboBox);
            this.dataShowerTabPage.Location = new System.Drawing.Point(4, 22);
            this.dataShowerTabPage.Name = "dataShowerTabPage";
            this.dataShowerTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.dataShowerTabPage.Size = new System.Drawing.Size(420, 248);
            this.dataShowerTabPage.TabIndex = 4;
            this.dataShowerTabPage.Text = "Данные";
            this.dataShowerTabPage.UseVisualStyleBackColor = true;
            // 
            // datasComboBox
            // 
            this.datasComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.datasComboBox.FormattingEnabled = true;
            this.datasComboBox.Location = new System.Drawing.Point(6, 6);
            this.datasComboBox.Name = "datasComboBox";
            this.datasComboBox.Size = new System.Drawing.Size(156, 21);
            this.datasComboBox.TabIndex = 0;
            // 
            // dataShowBtn
            // 
            this.dataShowBtn.Location = new System.Drawing.Point(6, 33);
            this.dataShowBtn.Name = "dataShowBtn";
            this.dataShowBtn.Size = new System.Drawing.Size(75, 23);
            this.dataShowBtn.TabIndex = 1;
            this.dataShowBtn.Text = "Показать";
            this.dataShowBtn.UseVisualStyleBackColor = true;
            this.dataShowBtn.Click += new System.EventHandler(this.dataShowBtn_Click);
            // 
            // dataHideBtn
            // 
            this.dataHideBtn.Location = new System.Drawing.Point(87, 33);
            this.dataHideBtn.Name = "dataHideBtn";
            this.dataHideBtn.Size = new System.Drawing.Size(75, 23);
            this.dataHideBtn.TabIndex = 1;
            this.dataHideBtn.Text = "Спрятать";
            this.dataHideBtn.UseVisualStyleBackColor = true;
            this.dataHideBtn.Click += new System.EventHandler(this.dataHideBtn_Click);
            // 
            // MainController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 311);
            this.Controls.Add(this.modulesComboBox);
            this.Controls.Add(this.modulesTabControl);
            this.Controls.Add(this.modulesLabel);
            this.Controls.Add(this.modulesCheckedListBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.modulesReloadButton);
            this.Controls.Add(this.observersTokenLabel);
            this.Controls.Add(this.observersCheckedListBox);
            this.Controls.Add(this.webSocketServerStatusLabel);
            this.Controls.Add(this.localAddressTextBox);
            this.Controls.Add(this.localAddressLabel);
            this.Controls.Add(this.combatLogListenerStatusLabel);
            this.Controls.Add(this.gameStateListenerStatusLabel);
            this.Controls.Add(this.updateModuleBtn);
            this.Controls.Add(this.startButton);
            this.MinimumSize = new System.Drawing.Size(700, 350);
            this.Name = "MainController";
            this.Text = "Eye Контроллер";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainController_FormClosed);
            this.Load += new System.EventHandler(this.MainController_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.modulesTabControl.ResumeLayout(false);
            this.smokeTabPage.ResumeLayout(false);
            this.smokeTabPage.PerformLayout();
            this.importantItemsTabPage.ResumeLayout(false);
            this.importantItemsTabPage.PerformLayout();
            this.runesTabPage.ResumeLayout(false);
            this.runesTabPage.PerformLayout();
            this.bountyGoldTabPage.ResumeLayout(false);
            this.dataShowerTabPage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label gameStateListenerStatusLabel;
        private System.Windows.Forms.Label combatLogListenerStatusLabel;
        private System.Windows.Forms.Label localAddressLabel;
        private System.Windows.Forms.TextBox localAddressTextBox;
        private System.Windows.Forms.Label webSocketServerStatusLabel;
        private System.Windows.Forms.CheckedListBox observersCheckedListBox;
        private System.Windows.Forms.Label observersTokenLabel;
        private System.Windows.Forms.Button modulesReloadButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.CheckedListBox modulesCheckedListBox;
        private System.Windows.Forms.Label modulesLabel;
        private System.Windows.Forms.TabControl modulesTabControl;
        private System.Windows.Forms.ToolStripStatusLabel receivedLabel;
        private System.Windows.Forms.ToolStripStatusLabel combatLogStatsLabel;
        private System.Windows.Forms.ToolStripStatusLabel gameStatsStatsLabel;
        private System.Windows.Forms.TabPage smokeTabPage;
        private System.Windows.Forms.Label smokeHeroesLabel;
        private System.Windows.Forms.ComboBox smokeHeroesСomboBox;
        private System.Windows.Forms.Button smokeRemoveBtn;
        private System.Windows.Forms.Button smokeAddBtn;
        private System.Windows.Forms.TabPage importantItemsTabPage;
        private System.Windows.Forms.Button importantItemsRemoveRapierBtn;
        private System.Windows.Forms.Button importantItemsRemoveAegisBtn;
        private System.Windows.Forms.Button importantItemsRemoveGemBtn;
        private System.Windows.Forms.Button importantItemsAddRapierBtn;
        private System.Windows.Forms.Button importantItemsAddAegisBtn;
        private System.Windows.Forms.Button importantItemsAddGemBtn;
        private System.Windows.Forms.Label importantItemsHeroesLabel;
        private System.Windows.Forms.ComboBox importantItemsHeroesComboBox;
        private System.Windows.Forms.TabPage runesTabPage;
        private System.Windows.Forms.Button runesRemoveArcaneBtn;
        private System.Windows.Forms.Button runesRemoveInvisBtn;
        private System.Windows.Forms.Button runesRemoveHasteBtn;
        private System.Windows.Forms.Button runesRemoveRegBtn;
        private System.Windows.Forms.Button runesRemoveDDBtn;
        private System.Windows.Forms.Button runesAddArcaneBtn;
        private System.Windows.Forms.Button runesAddInvisBtn;
        private System.Windows.Forms.Button runesAddHasteBtn;
        private System.Windows.Forms.Button runesAddRegBtn;
        private System.Windows.Forms.Button runesAddDDBtn;
        private System.Windows.Forms.Label runesHeroesLabel;
        private System.Windows.Forms.ComboBox runesHeroesComboBox;
        private System.Windows.Forms.ComboBox modulesComboBox;
        private System.Windows.Forms.Button updateModuleBtn;
        private System.Windows.Forms.ToolStripStatusLabel actionLabel;
        private System.Windows.Forms.ToolStripStatusLabel lastActionLabel;
        private System.Windows.Forms.TabPage bountyGoldTabPage;
        private System.Windows.Forms.Button bountyGoldOpenBtn;
        private System.Windows.Forms.Button gountyGoldHideBtn;
        private System.Windows.Forms.TabPage dataShowerTabPage;
        private System.Windows.Forms.ComboBox datasComboBox;
        private System.Windows.Forms.Button dataHideBtn;
        private System.Windows.Forms.Button dataShowBtn;
    }
}