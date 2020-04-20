namespace CSGSITools
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Worker_GSI = new System.ComponentModel.BackgroundWorker();
            this.lbl_playerstate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_bombCurrentTime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_bombCurrentState = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chk_autofocusFrezzeTime = new MetroFramework.Controls.MetroCheckBox();
            this.chk_autofocus = new MetroFramework.Controls.MetroCheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.combo_states = new MetroFramework.Controls.MetroComboBox();
            this.chk_stayState = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbl_roundState = new System.Windows.Forms.Label();
            this.lbl_currentRoundState = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_currentMap = new System.Windows.Forms.Label();
            this.Worker_CheckCSGO = new System.ComponentModel.BackgroundWorker();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.metroTab_csgsiTools = new MetroFramework.Controls.MetroTabControl();
            this.CSGOStateTabPage = new MetroFramework.Controls.MetroTabPage();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.metroLink1 = new MetroFramework.Controls.MetroLink();
            this.metroLink_valveGSI = new MetroFramework.Controls.MetroLink();
            this.metroLink_Metro = new MetroFramework.Controls.MetroLink();
            this.metroLink_Rakijah = new MetroFramework.Controls.MetroLink();
            this.metroLink_Steam4net = new MetroFramework.Controls.MetroLink();
            this.metroLink_Json = new MetroFramework.Controls.MetroLink();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLink_spkMusic = new MetroFramework.Controls.MetroLink();
            this.metroLink_spk = new MetroFramework.Controls.MetroLink();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.lbl_mercuryAge = new MetroFramework.Controls.MetroLabel();
            this.pictureBox_Github = new System.Windows.Forms.PictureBox();
            this.txtBox_steamID = new MetroFramework.Controls.MetroTextBox();
            this.lbl_setSteamID64 = new System.Windows.Forms.Label();
            this.metroPanel10 = new MetroFramework.Controls.MetroPanel();
            this.ps_status = new MetroFramework.Controls.MetroProgressSpinner();
            this.lbl_infoversion = new MetroFramework.Controls.MetroLabel();
            this.Trolha = new System.Windows.Forms.Timer(this.components);
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.metroTab_csgsiTools.SuspendLayout();
            this.CSGOStateTabPage.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Github)).BeginInit();
            this.metroPanel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // Worker_GSI
            // 
            this.Worker_GSI.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Worker_GSI_DoWork);
            // 
            // lbl_playerstate
            // 
            this.lbl_playerstate.AutoSize = true;
            this.lbl_playerstate.Location = new System.Drawing.Point(100, 52);
            this.lbl_playerstate.Name = "lbl_playerstate";
            this.lbl_playerstate.Size = new System.Drawing.Size(79, 15);
            this.lbl_playerstate.TabIndex = 1;
            this.lbl_playerstate.Text = "(currentState)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Player State:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Bomb Time:";
            // 
            // lbl_bombCurrentTime
            // 
            this.lbl_bombCurrentTime.AutoSize = true;
            this.lbl_bombCurrentTime.Location = new System.Drawing.Point(100, 156);
            this.lbl_bombCurrentTime.Name = "lbl_bombCurrentTime";
            this.lbl_bombCurrentTime.Size = new System.Drawing.Size(79, 15);
            this.lbl_bombCurrentTime.TabIndex = 3;
            this.lbl_bombCurrentTime.Text = "(currentState)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Bomb State:";
            // 
            // lbl_bombCurrentState
            // 
            this.lbl_bombCurrentState.AutoSize = true;
            this.lbl_bombCurrentState.Location = new System.Drawing.Point(100, 128);
            this.lbl_bombCurrentState.Name = "lbl_bombCurrentState";
            this.lbl_bombCurrentState.Size = new System.Drawing.Size(79, 15);
            this.lbl_bombCurrentState.TabIndex = 1;
            this.lbl_bombCurrentState.Text = "(currentState)";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chk_autofocusFrezzeTime);
            this.groupBox4.Controls.Add(this.chk_autofocus);
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(245, 103);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(331, 114);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Extras";
            // 
            // chk_autofocusFrezzeTime
            // 
            this.chk_autofocusFrezzeTime.AutoSize = true;
            this.chk_autofocusFrezzeTime.Location = new System.Drawing.Point(19, 67);
            this.chk_autofocusFrezzeTime.Name = "chk_autofocusFrezzeTime";
            this.chk_autofocusFrezzeTime.Size = new System.Drawing.Size(241, 15);
            this.chk_autofocusFrezzeTime.Style = MetroFramework.MetroColorStyle.Blue;
            this.chk_autofocusFrezzeTime.TabIndex = 11;
            this.chk_autofocusFrezzeTime.Text = "Open CSGO when round is in freeze time!";
            this.chk_autofocusFrezzeTime.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.toolTip.SetToolTip(this.chk_autofocusFrezzeTime, "When the round starts, csgo window will open for you.");
            this.chk_autofocusFrezzeTime.UseSelectable = true;
            this.chk_autofocusFrezzeTime.UseStyleColors = true;
            // 
            // chk_autofocus
            // 
            this.chk_autofocus.AutoSize = true;
            this.chk_autofocus.Location = new System.Drawing.Point(19, 36);
            this.chk_autofocus.Name = "chk_autofocus";
            this.chk_autofocus.Size = new System.Drawing.Size(177, 15);
            this.chk_autofocus.Style = MetroFramework.MetroColorStyle.Blue;
            this.chk_autofocus.TabIndex = 10;
            this.chk_autofocus.Text = "Open CSGO when round live!";
            this.chk_autofocus.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.toolTip.SetToolTip(this.chk_autofocus, "When the round starts, csgo window will open for you.");
            this.chk_autofocus.UseSelectable = true;
            this.chk_autofocus.UseStyleColors = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.combo_states);
            this.groupBox1.Controls.Add(this.chk_stayState);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(245, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(331, 85);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Steam State Chooser";
            // 
            // combo_states
            // 
            this.combo_states.FormattingEnabled = true;
            this.combo_states.ItemHeight = 23;
            this.combo_states.Items.AddRange(new object[] {
            "Offline",
            "Online",
            "Busy",
            "Away",
            "Snooze 💤",
            "LookingToTrade",
            "LookingToPlay"});
            this.combo_states.Location = new System.Drawing.Point(19, 22);
            this.combo_states.Name = "combo_states";
            this.combo_states.Size = new System.Drawing.Size(306, 29);
            this.combo_states.TabIndex = 17;
            this.combo_states.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.combo_states.UseSelectable = true;
            this.combo_states.UseStyleColors = true;
            this.combo_states.SelectedIndexChanged += new System.EventHandler(this.combo_states_SelectedIndexChanged);
            // 
            // chk_stayState
            // 
            this.chk_stayState.AutoSize = true;
            this.chk_stayState.Location = new System.Drawing.Point(19, 57);
            this.chk_stayState.Name = "chk_stayState";
            this.chk_stayState.Size = new System.Drawing.Size(240, 19);
            this.chk_stayState.TabIndex = 8;
            this.chk_stayState.Text = "While in match, stay in the state defined.";
            this.toolTip.SetToolTip(this.chk_stayState, "(soon) When the round starts, csgo window will open for you.");
            this.chk_stayState.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.lbl_bombCurrentTime);
            this.groupBox3.Controls.Add(this.lbl_roundState);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.lbl_bombCurrentState);
            this.groupBox3.Controls.Add(this.lbl_currentRoundState);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.lbl_playerstate);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.lbl_currentMap);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(0, 14);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(223, 203);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Game State";
            // 
            // lbl_roundState
            // 
            this.lbl_roundState.AutoSize = true;
            this.lbl_roundState.Location = new System.Drawing.Point(24, 101);
            this.lbl_roundState.Name = "lbl_roundState";
            this.lbl_roundState.Size = new System.Drawing.Size(74, 15);
            this.lbl_roundState.TabIndex = 6;
            this.lbl_roundState.Text = "Round State:";
            // 
            // lbl_currentRoundState
            // 
            this.lbl_currentRoundState.AutoSize = true;
            this.lbl_currentRoundState.Location = new System.Drawing.Point(100, 101);
            this.lbl_currentRoundState.Name = "lbl_currentRoundState";
            this.lbl_currentRoundState.Size = new System.Drawing.Size(79, 15);
            this.lbl_currentRoundState.TabIndex = 5;
            this.lbl_currentRoundState.Text = "(currentState)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Map:";
            // 
            // lbl_currentMap
            // 
            this.lbl_currentMap.AutoSize = true;
            this.lbl_currentMap.Location = new System.Drawing.Point(100, 30);
            this.lbl_currentMap.Name = "lbl_currentMap";
            this.lbl_currentMap.Size = new System.Drawing.Size(79, 15);
            this.lbl_currentMap.TabIndex = 3;
            this.lbl_currentMap.Text = "(currentState)";
            // 
            // Worker_CheckCSGO
            // 
            this.Worker_CheckCSGO.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Worker_CheckCSGO_DoWork);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "notifyIcon1";
            this.notifyIcon.Visible = true;
            // 
            // metroTab_csgsiTools
            // 
            this.metroTab_csgsiTools.Controls.Add(this.CSGOStateTabPage);
            this.metroTab_csgsiTools.Controls.Add(this.metroTabPage1);
            this.metroTab_csgsiTools.Cursor = System.Windows.Forms.Cursors.Default;
            this.metroTab_csgsiTools.Location = new System.Drawing.Point(13, 46);
            this.metroTab_csgsiTools.Name = "metroTab_csgsiTools";
            this.metroTab_csgsiTools.SelectedIndex = 0;
            this.metroTab_csgsiTools.Size = new System.Drawing.Size(584, 264);
            this.metroTab_csgsiTools.TabIndex = 7;
            this.metroTab_csgsiTools.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTab_csgsiTools.UseSelectable = true;
            // 
            // CSGOStateTabPage
            // 
            this.CSGOStateTabPage.BackColor = System.Drawing.Color.Transparent;
            this.CSGOStateTabPage.Controls.Add(this.groupBox3);
            this.CSGOStateTabPage.Controls.Add(this.groupBox1);
            this.CSGOStateTabPage.Controls.Add(this.groupBox4);
            this.CSGOStateTabPage.Cursor = System.Windows.Forms.Cursors.Default;
            this.CSGOStateTabPage.HorizontalScrollbarBarColor = true;
            this.CSGOStateTabPage.HorizontalScrollbarHighlightOnWheel = false;
            this.CSGOStateTabPage.HorizontalScrollbarSize = 10;
            this.CSGOStateTabPage.Location = new System.Drawing.Point(4, 38);
            this.CSGOStateTabPage.Name = "CSGOStateTabPage";
            this.CSGOStateTabPage.Size = new System.Drawing.Size(576, 222);
            this.CSGOStateTabPage.TabIndex = 1;
            this.CSGOStateTabPage.Text = "State";
            this.CSGOStateTabPage.UseCustomBackColor = true;
            this.CSGOStateTabPage.UseCustomForeColor = true;
            this.CSGOStateTabPage.UseStyleColors = true;
            this.CSGOStateTabPage.VerticalScrollbarBarColor = true;
            this.CSGOStateTabPage.VerticalScrollbarHighlightOnWheel = false;
            this.CSGOStateTabPage.VerticalScrollbarSize = 10;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.BackColor = System.Drawing.Color.Transparent;
            this.metroTabPage1.Controls.Add(this.metroLink1);
            this.metroTabPage1.Controls.Add(this.metroLink_valveGSI);
            this.metroTabPage1.Controls.Add(this.metroLink_Metro);
            this.metroTabPage1.Controls.Add(this.metroLink_Rakijah);
            this.metroTabPage1.Controls.Add(this.metroLink_Steam4net);
            this.metroTabPage1.Controls.Add(this.metroLink_Json);
            this.metroTabPage1.Controls.Add(this.metroLabel3);
            this.metroTabPage1.Controls.Add(this.metroLabel7);
            this.metroTabPage1.Controls.Add(this.metroLabel6);
            this.metroTabPage1.Controls.Add(this.metroLabel5);
            this.metroTabPage1.Controls.Add(this.metroLabel4);
            this.metroTabPage1.Controls.Add(this.metroLink_spkMusic);
            this.metroTabPage1.Controls.Add(this.metroLink_spk);
            this.metroTabPage1.Controls.Add(this.metroLabel9);
            this.metroTabPage1.Controls.Add(this.lbl_mercuryAge);
            this.metroTabPage1.Controls.Add(this.pictureBox_Github);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(576, 222);
            this.metroTabPage1.TabIndex = 2;
            this.metroTabPage1.Text = "INFORMATION";
            this.metroTabPage1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTabPage1.UseCustomBackColor = true;
            this.metroTabPage1.UseCustomForeColor = true;
            this.metroTabPage1.UseStyleColors = true;
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // metroLink1
            // 
            this.metroLink1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroLink1.Location = new System.Drawing.Point(509, 107);
            this.metroLink1.Name = "metroLink1";
            this.metroLink1.Size = new System.Drawing.Size(17, 20);
            this.metroLink1.TabIndex = 81;
            this.metroLink1.Text = "|";
            this.metroLink1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLink1.UseCustomBackColor = true;
            this.metroLink1.UseSelectable = true;
            // 
            // metroLink_valveGSI
            // 
            this.metroLink_valveGSI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroLink_valveGSI.Location = new System.Drawing.Point(524, 108);
            this.metroLink_valveGSI.Name = "metroLink_valveGSI";
            this.metroLink_valveGSI.Size = new System.Drawing.Size(40, 20);
            this.metroLink_valveGSI.TabIndex = 80;
            this.metroLink_valveGSI.Text = "Valve";
            this.metroLink_valveGSI.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLink_valveGSI.UseCustomBackColor = true;
            this.metroLink_valveGSI.UseSelectable = true;
            this.metroLink_valveGSI.Click += new System.EventHandler(this.metroLink_valveGSI_Click);
            // 
            // metroLink_Metro
            // 
            this.metroLink_Metro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroLink_Metro.Location = new System.Drawing.Point(467, 127);
            this.metroLink_Metro.Name = "metroLink_Metro";
            this.metroLink_Metro.Size = new System.Drawing.Size(91, 20);
            this.metroLink_Metro.TabIndex = 79;
            this.metroLink_Metro.Text = "DenRic Denise";
            this.metroLink_Metro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroLink_Metro.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLink_Metro.UseCustomBackColor = true;
            this.metroLink_Metro.UseSelectable = true;
            // 
            // metroLink_Rakijah
            // 
            this.metroLink_Rakijah.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroLink_Rakijah.Location = new System.Drawing.Point(467, 107);
            this.metroLink_Rakijah.Name = "metroLink_Rakijah";
            this.metroLink_Rakijah.Size = new System.Drawing.Size(44, 20);
            this.metroLink_Rakijah.TabIndex = 78;
            this.metroLink_Rakijah.Text = "rakijah";
            this.metroLink_Rakijah.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLink_Rakijah.UseCustomBackColor = true;
            this.metroLink_Rakijah.UseSelectable = true;
            this.metroLink_Rakijah.Click += new System.EventHandler(this.metroLink_Rakijah_Click);
            // 
            // metroLink_Steam4net
            // 
            this.metroLink_Steam4net.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroLink_Steam4net.Location = new System.Drawing.Point(467, 89);
            this.metroLink_Steam4net.Name = "metroLink_Steam4net";
            this.metroLink_Steam4net.Size = new System.Drawing.Size(91, 19);
            this.metroLink_Steam4net.TabIndex = 77;
            this.metroLink_Steam4net.Text = "SteamRE Team";
            this.metroLink_Steam4net.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLink_Steam4net.UseCustomBackColor = true;
            this.metroLink_Steam4net.UseSelectable = true;
            // 
            // metroLink_Json
            // 
            this.metroLink_Json.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroLink_Json.Location = new System.Drawing.Point(467, 70);
            this.metroLink_Json.Name = "metroLink_Json";
            this.metroLink_Json.Size = new System.Drawing.Size(75, 19);
            this.metroLink_Json.TabIndex = 76;
            this.metroLink_Json.Text = "Newtonsoft";
            this.metroLink_Json.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLink_Json.UseCustomBackColor = true;
            this.metroLink_Json.UseSelectable = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.Location = new System.Drawing.Point(362, 33);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(75, 25);
            this.metroLabel3.TabIndex = 71;
            this.metroLabel3.Text = "Libraries";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel3.UseCustomBackColor = true;
            this.metroLabel3.UseStyleColors = true;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(388, 70);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(77, 19);
            this.metroLabel7.TabIndex = 75;
            this.metroLabel7.Text = "Json.NET ©";
            this.metroLabel7.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel7.UseCustomBackColor = true;
            this.metroLabel7.UseStyleColors = true;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(338, 127);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(127, 19);
            this.metroLabel6.TabIndex = 74;
            this.metroLabel6.Text = "MetroFramework ©";
            this.metroLabel6.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel6.UseCustomBackColor = true;
            this.metroLabel6.UseStyleColors = true;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(405, 107);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(60, 19);
            this.metroLabel5.TabIndex = 73;
            this.metroLabel5.Text = "CSGSI ©";
            this.metroLabel5.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel5.UseCustomBackColor = true;
            this.metroLabel5.UseStyleColors = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(372, 89);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(93, 19);
            this.metroLabel4.TabIndex = 72;
            this.metroLabel4.Text = "Steam4NET ©";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel4.UseCustomBackColor = true;
            this.metroLabel4.UseStyleColors = true;
            // 
            // metroLink_spkMusic
            // 
            this.metroLink_spkMusic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroLink_spkMusic.Location = new System.Drawing.Point(248, 64);
            this.metroLink_spkMusic.Name = "metroLink_spkMusic";
            this.metroLink_spkMusic.Size = new System.Drawing.Size(20, 16);
            this.metroLink_spkMusic.TabIndex = 67;
            this.metroLink_spkMusic.Text = "🎶";
            this.metroLink_spkMusic.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLink_spkMusic.UseCustomBackColor = true;
            this.metroLink_spkMusic.UseSelectable = true;
            this.metroLink_spkMusic.Click += new System.EventHandler(this.metroLink_spkMusic_Click);
            // 
            // metroLink_spk
            // 
            this.metroLink_spk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroLink_spk.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.metroLink_spk.Location = new System.Drawing.Point(179, 68);
            this.metroLink_spk.Name = "metroLink_spk";
            this.metroLink_spk.Size = new System.Drawing.Size(71, 24);
            this.metroLink_spk.TabIndex = 66;
            this.metroLink_spk.Text = "SP0OK3R";
            this.metroLink_spk.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLink_spk.UseCustomBackColor = true;
            this.metroLink_spk.UseSelectable = true;
            this.metroLink_spk.Click += new System.EventHandler(this.metroLink_spk_Click);
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel9.Location = new System.Drawing.Point(84, 70);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(93, 19);
            this.metroLabel9.TabIndex = 65;
            this.metroLabel9.Text = "Developed by";
            this.metroLabel9.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel9.UseCustomBackColor = true;
            this.metroLabel9.UseStyleColors = true;
            // 
            // lbl_mercuryAge
            // 
            this.lbl_mercuryAge.AutoSize = true;
            this.lbl_mercuryAge.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lbl_mercuryAge.Location = new System.Drawing.Point(16, 29);
            this.lbl_mercuryAge.Name = "lbl_mercuryAge";
            this.lbl_mercuryAge.Size = new System.Drawing.Size(122, 19);
            this.lbl_mercuryAge.TabIndex = 64;
            this.lbl_mercuryAge.Text = "MERCURY BOT ©";
            this.lbl_mercuryAge.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.lbl_mercuryAge.UseCustomBackColor = true;
            this.lbl_mercuryAge.UseStyleColors = true;
            // 
            // pictureBox_Github
            // 
            this.pictureBox_Github.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_Github.Image = global::CSGSITools.Properties.Resources.github_logo;
            this.pictureBox_Github.Location = new System.Drawing.Point(154, 98);
            this.pictureBox_Github.Name = "pictureBox_Github";
            this.pictureBox_Github.Size = new System.Drawing.Size(33, 34);
            this.pictureBox_Github.TabIndex = 70;
            this.pictureBox_Github.TabStop = false;
            this.pictureBox_Github.Click += new System.EventHandler(this.pictureBox_Github_Click);
            // 
            // txtBox_steamID
            // 
            // 
            // 
            // 
            this.txtBox_steamID.CustomButton.Image = null;
            this.txtBox_steamID.CustomButton.Location = new System.Drawing.Point(118, 2);
            this.txtBox_steamID.CustomButton.Name = "";
            this.txtBox_steamID.CustomButton.Size = new System.Drawing.Size(17, 17);
            this.txtBox_steamID.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBox_steamID.CustomButton.TabIndex = 1;
            this.txtBox_steamID.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBox_steamID.CustomButton.UseSelectable = true;
            this.txtBox_steamID.CustomButton.Visible = false;
            this.txtBox_steamID.Lines = new string[0];
            this.txtBox_steamID.Location = new System.Drawing.Point(455, 56);
            this.txtBox_steamID.MaxLength = 32767;
            this.txtBox_steamID.Multiline = true;
            this.txtBox_steamID.Name = "txtBox_steamID";
            this.txtBox_steamID.PasswordChar = '\0';
            this.txtBox_steamID.ReadOnly = true;
            this.txtBox_steamID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBox_steamID.SelectedText = "";
            this.txtBox_steamID.SelectionLength = 0;
            this.txtBox_steamID.SelectionStart = 0;
            this.txtBox_steamID.ShortcutsEnabled = true;
            this.txtBox_steamID.Size = new System.Drawing.Size(138, 22);
            this.txtBox_steamID.TabIndex = 24;
            this.txtBox_steamID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBox_steamID.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.txtBox_steamID.UseSelectable = true;
            this.txtBox_steamID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtBox_steamID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lbl_setSteamID64
            // 
            this.lbl_setSteamID64.AutoSize = true;
            this.lbl_setSteamID64.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_setSteamID64.ForeColor = System.Drawing.Color.White;
            this.lbl_setSteamID64.Location = new System.Drawing.Point(364, 63);
            this.lbl_setSteamID64.Name = "lbl_setSteamID64";
            this.lbl_setSteamID64.Size = new System.Drawing.Size(85, 13);
            this.lbl_setSteamID64.TabIndex = 46;
            this.lbl_setSteamID64.Text = "Player SteamID:";
            // 
            // metroPanel10
            // 
            this.metroPanel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.metroPanel10.Controls.Add(this.ps_status);
            this.metroPanel10.Controls.Add(this.lbl_infoversion);
            this.metroPanel10.HorizontalScrollbarBarColor = true;
            this.metroPanel10.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel10.HorizontalScrollbarSize = 10;
            this.metroPanel10.Location = new System.Drawing.Point(-6, 307);
            this.metroPanel10.Name = "metroPanel10";
            this.metroPanel10.Size = new System.Drawing.Size(615, 22);
            this.metroPanel10.TabIndex = 23;
            this.metroPanel10.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroPanel10.UseCustomBackColor = true;
            this.metroPanel10.UseCustomForeColor = true;
            this.metroPanel10.VerticalScrollbarBarColor = true;
            this.metroPanel10.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel10.VerticalScrollbarSize = 10;
            // 
            // ps_status
            // 
            this.ps_status.Location = new System.Drawing.Point(587, 3);
            this.ps_status.Maximum = 100;
            this.ps_status.Name = "ps_status";
            this.ps_status.Size = new System.Drawing.Size(16, 16);
            this.ps_status.TabIndex = 17;
            this.ps_status.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ps_status.UseCustomBackColor = true;
            this.ps_status.UseCustomForeColor = true;
            this.ps_status.UseSelectable = true;
            // 
            // lbl_infoversion
            // 
            this.lbl_infoversion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_infoversion.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lbl_infoversion.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lbl_infoversion.Location = new System.Drawing.Point(670, 1);
            this.lbl_infoversion.Name = "lbl_infoversion";
            this.lbl_infoversion.Size = new System.Drawing.Size(138, 15);
            this.lbl_infoversion.TabIndex = 45;
            this.lbl_infoversion.Text = "v";
            this.lbl_infoversion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_infoversion.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.lbl_infoversion.UseCustomBackColor = true;
            this.lbl_infoversion.UseStyleColors = true;
            // 
            // Trolha
            // 
            this.Trolha.Enabled = true;
            this.Trolha.Interval = 3000;
            this.Trolha.Tick += new System.EventHandler(this.Trolha_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 328);
            this.Controls.Add(this.txtBox_steamID);
            this.Controls.Add(this.lbl_setSteamID64);
            this.Controls.Add(this.metroPanel10);
            this.Controls.Add(this.metroTab_csgsiTools);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Resizable = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Style = MetroFramework.MetroColorStyle.Default;
            this.Text = "CSGSI Tools";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.metroTab_csgsiTools.ResumeLayout(false);
            this.CSGOStateTabPage.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Github)).EndInit();
            this.metroPanel10.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker Worker_GSI;
        private System.Windows.Forms.Label lbl_playerstate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_bombCurrentState;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lbl_roundState;
        private System.Windows.Forms.Label lbl_currentRoundState;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_currentMap;
        private System.ComponentModel.BackgroundWorker Worker_CheckCSGO;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_bombCurrentTime;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chk_stayState;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private MetroFramework.Controls.MetroTabControl metroTab_csgsiTools;
        private MetroFramework.Controls.MetroTabPage CSGOStateTabPage;
        private MetroFramework.Controls.MetroTextBox txtBox_steamID;
        private System.Windows.Forms.Label lbl_setSteamID64;
        private MetroFramework.Controls.MetroPanel metroPanel10;
        private MetroFramework.Controls.MetroLabel lbl_infoversion;
        private MetroFramework.Controls.MetroComboBox combo_states;
        private System.Windows.Forms.Timer Trolha;
        private MetroFramework.Controls.MetroProgressSpinner ps_status;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroLink metroLink_spkMusic;
        private MetroFramework.Controls.MetroLink metroLink_spk;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroLabel lbl_mercuryAge;
        private System.Windows.Forms.PictureBox pictureBox_Github;
        private MetroFramework.Controls.MetroLink metroLink_Metro;
        private MetroFramework.Controls.MetroLink metroLink_Rakijah;
        private MetroFramework.Controls.MetroLink metroLink_Steam4net;
        private MetroFramework.Controls.MetroLink metroLink_Json;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLink metroLink_valveGSI;
        private MetroFramework.Controls.MetroLink metroLink1;
        private MetroFramework.Controls.MetroCheckBox chk_autofocus;
        private MetroFramework.Controls.MetroCheckBox chk_autofocusFrezzeTime;
    }
}

