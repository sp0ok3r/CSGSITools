using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CSGSI;
using CSGSI.Nodes;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using Steam4NET;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace CSGSITools
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        #region test
        private ISteam006 steam006;
        private ISteamClient012 steamclient;
        private ISteamUser016 steamuser;
        private ISteamFriends013 steamfriends013;
        private ISteamFriends002 steamfriends002;
        private int user;
        private int pipe;
        private CSteamID steamid;
        private EPersonaState CurrentState;

        private int LoadSteam()
        {
            if (Steamworks.Load(true))
            {
                Console.WriteLine("Ok, Steam Works!");
            }
            else
            {
                MessageBox.Show("Failed, Steam Works!");
                Console.WriteLine("Failed, Steam Works!");

                return -1;
            }

            steam006 = Steamworks.CreateSteamInterface<ISteam006>();

            steamclient = Steamworks.CreateInterface<ISteamClient012>();
            pipe = steamclient.CreateSteamPipe();
            user = steamclient.ConnectToGlobalUser(pipe);
            steamuser = steamclient.GetISteamUser<ISteamUser016>(user, pipe);
            steamfriends013 = steamclient.GetISteamFriends<ISteamFriends013>(user, pipe);
            steamfriends002 = steamclient.GetISteamFriends<ISteamFriends002>(user, pipe);
            CSteamID steamID = steamuser.GetSteamID();

            CurrentState = steamfriends002.GetFriendPersonaState(steamID);

            string ConvertTo64 = steamID.ConvertToUint64().ToString();
            txtBox_steamID.Text = ConvertTo64;
            steamid = steamID;
            if (steam006 == null)
            {
                Console.WriteLine("steam006 is null !");
                return -1;
            }
            if (steamclient == null)
            {
                Console.WriteLine("steamclient is null !");
                return -1;
            }


            return 0;

        }
        #endregion

        GameStateListener gsl;
        Thread Th_CheckCSGOProcess;


        public static bool IsPlanted;
        public static PlayerActivity Activity = PlayerActivity.Undefined;
        public static int Health = -1;
        public static int Ammo = -1;
        public static int AmmoMax = -1;
        public static int Armor = -1;
        public static PlayerTeam Team = PlayerTeam.Undefined;
        public static WeaponType WpType = WeaponType.Undefined;
        public static RoundWinTeam WinTeam;
        public static RoundPhase Phase;

        private static MapMode mode = MapMode.Undefined;
        private static readonly int[] scores = new int[2] { 0, 0 }; //CT-T
        private static string map = "Undefined";
        private static readonly int[] stats = new int[3] { 0, 0, 0 }; //Kills, Assists, Deaths

        private static string csgoCFGPath;

        public Form1()
        {
            InitializeComponent();
            Worker_GSI.RunWorkerAsync();
            Trolha.Tick += Trolha_Tick;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadCSGOFolder();
            metroTab_csgsiTools.SelectedIndex = 0;
            ps_status.Visible = true;
            CheckCSGOProcess();

            Worker_CheckCSGO.DoWork += Worker_CheckCSGO_DoWork;
            Worker_CheckCSGO.RunWorkerAsync("CheckCSGOProcess");
            LoadSteam();

        }

        public static void LoadCSGOFolder()
        {
            string csgoPath = tryLocatingCSGOFolder();
            csgoCFGPath = csgoPath + @"\csgo\cfg\";

            DirectoryInfo d = new DirectoryInfo(csgoCFGPath);
            FileInfo[] Files = d.GetFiles("gamestate_integration_teste.cfg"); 

            if (Files.Length == 0)
            {
                Process.GetProcesses()
                         .Where(x => x.ProcessName.ToLower()
                                      .Contains("csgo"))
                         .ToList()
                         .ForEach(x => x.Kill());

                string fileToCopy = Program.ExecutablePath + "\\gamestate_integration_teste.cfg";
                File.Copy(fileToCopy, csgoCFGPath + Path.GetFileName(fileToCopy));
            }
        }


        private void Worker_GSI_DoWork(object sender, DoWorkEventArgs e)
        {
            gsl = new GameStateListener(3000);
            gsl.NewGameState += new NewGameStateHandler(CurrentBombState);
            gsl.NewGameState += new NewGameStateHandler(RoundState);
            gsl.NewGameState += new NewGameStateHandler(PlayerState);


            if (!gsl.Start())
            {
                Environment.Exit(0);
            }
        }

        private void CheckCSGOProcess()
        {
            Process[] ps = Process.GetProcessesByName("csgo");
            if (ps.Length == 0)
            {
                MessageBox.Show("Starting csgo for you... restarting "+ Program.AppName + " in 15sec.", Program.AppName,
                MessageBoxButtons.OK, MessageBoxIcon.Error);

                Process.Start("steam://run/730");
                
                Thread.Sleep(15000);
                Process.Start(Application.ExecutablePath);
                Application.Exit();
            }
        }


        private void PlayerState(GameState gs)
        {
            int Health = gs.Player.State.Health;
            int WeaponAmmoClip = gs.Player.Weapons.ActiveWeapon.AmmoClip;
            string CurrentWeapon = gs.Player.Weapons.ActiveWeapon.Name;
            float RoundEnds = gs.PhaseCountdowns.PhaseEndsIn;


            if (gs.Player.Activity == PlayerActivity.Undefined)
            {


            }
            else if (gs.Player.Activity == PlayerActivity.Menu)
            {//Is in a menu (also applies to opening the in game menu with ESC).


            }
            else if (gs.Player.Activity == PlayerActivity.Playing)
            {//Playing or spectating.

                if (gs.Map.Mode != mode) mode = gs.Map.Mode;
                if (gs.Map.Name != map) map = gs.Map.Name;
                if (gs.Player.MatchStats.Kills != stats[0]) stats[0] = gs.Player.MatchStats.Kills;
                if (gs.Player.MatchStats.Assists != stats[1]) stats[1] = gs.Player.MatchStats.Assists;
                if (gs.Player.MatchStats.Deaths != stats[2]) stats[2] = gs.Player.MatchStats.Deaths;
                if (gs.Map.TeamCT.Score != scores[0]) scores[0] = gs.Map.TeamCT.Score;
                if (gs.Map.TeamT.Score != scores[1]) scores[1] = gs.Map.TeamT.Score;


            }
            else if (gs.Player.Activity == PlayerActivity.TextInput)
            {//Console is open

            }


            bool Flash = false;
            bool Smoke = false;
            bool Molly = false;
            //gs.Player.MatchStats.Kills
            bool dead = false;

            if (gs.Player.SteamID.Equals(txtBox_steamID.Text.ToString()) && Health == 0)
            {
                lbl_playerstate.Text = "OOF!";
                lbl_playerstate.ForeColor = Color.Red;
                dead = true;

            }
            else if (gs.Player.SteamID.Equals(txtBox_steamID.Text.ToString()) && Health > 0)
            {

                lbl_playerstate.Text = "ALIVE!";
                lbl_playerstate.ForeColor = Color.DarkGreen;
                dead = false;

            }
            else
            {
                lbl_playerstate.Text = "No server.";
                lbl_playerstate.ForeColor = Color.Red;
            }




            //FLASHED
            if (gs.Player.State.Flashed == 0)
            {
                Flash = false;
            }
            else if (gs.Player.State.Flashed > 0)
            {
                lbl_playerstate.Text = "ALIVE! AND FLASHED";
                Flash = true;
            }

            //SMOKED
            if (gs.Player.State.Smoked == 0)
            {
                Smoke = false;

            }
            else if (gs.Player.State.Smoked > 0)
            {

                lbl_playerstate.Text = "ALIVE! AND SMOKED";
                Smoke = true;
            }
            //BURNING
            if (gs.Player.State.Burning == 0)
            {
                Molly = false;

            }
            else if (gs.Player.State.Burning > 0)
            {

                lbl_playerstate.Text = "ALIVE! AND BURNING";
                Molly = true;
            }

            if (Flash == false && Smoke == false && Molly == false && dead == false)
            {

            }
        }


        private void CurrentBombState(GameState gs)
        {
            if (!IsPlanted &&
               gs.Round.Phase == RoundPhase.Live &&
               gs.Round.Bomb == BombState.Planted &&
               gs.Previously.Round.Bomb == BombState.Undefined)
            {

                lbl_bombCurrentState.Text = "Bomb has been planted.";
                lbl_bombCurrentState.ForeColor = Color.Red;
                IsPlanted = true;

            }
            else if (gs.Round.Bomb != BombState.Exploded)
            {
             
                IsPlanted = false;
                lbl_bombCurrentState.ForeColor = Color.Red;
                lbl_bombCurrentState.Text = "Bomb not planted.";

            }
            else if (gs.Round.Bomb == BombState.Exploded)
            {

                lbl_bombCurrentState.Text = "Exploded.";
                lbl_bombCurrentState.ForeColor = Color.Red;

            }
            else if (gs.Round.Bomb == BombState.Defused)
            {

                lbl_bombCurrentState.Text = "Defused.";
                lbl_bombCurrentState.ForeColor = Color.DodgerBlue;

            }
            else if (IsPlanted && gs.Round.Phase == RoundPhase.FreezeTime)
            {
                IsPlanted = false;
                lbl_bombCurrentState.Text = "Bomb not planted.";
                lbl_bombCurrentState.ForeColor = Color.Black;

            }
            else
            {
                IsPlanted = false;
                lbl_bombCurrentState.ForeColor = Color.Red;
                lbl_bombCurrentState.Text = "No server.";

            }
        }

        private void RoundState(GameState gs)
        {
            lbl_currentMap.Text = gs.Map.Name;
            if (gs.Round.Phase == RoundPhase.Over)
            {

                lbl_currentRoundState.Text = "ROUND OVER: " + gs.Round.WinTeam + " - WINS";
                lbl_currentRoundState.ForeColor = Color.Red;

            }
            else if (gs.Round.Phase == RoundPhase.Live)
            {
                lbl_currentRoundState.ForeColor = Color.DarkGreen;
                lbl_currentRoundState.Text = "ROUND LIVE - GL HF!";

                lbl_currentMap.ForeColor = Color.DarkGreen;


                if (chk_autofocus.Checked && gs.Player.SteamID.Equals(txtBox_steamID.Text.ToString()) && gs.Player.State.Health == 100)
                {
                    FocusProcess("csgo");
                }
            }
            else if (gs.Round.Phase == RoundPhase.FreezeTime)
            {
                lbl_currentRoundState.Text = "* Freeze Time *";
                lbl_currentRoundState.ForeColor = Color.DarkOrange;

                if (chk_autofocusFrezzeTime.Checked && gs.Player.SteamID.Equals(txtBox_steamID.Text.ToString()) && gs.Player.State.Health == 100)
                {
                    FocusProcess("csgo");
                }

                //
            }

            else if (gs.Round.Phase == RoundPhase.FreezeTime || gs.Round.Phase == RoundPhase.Undefined && gs.Map.Round == 0)
            {
                //
            }
            else if (gs.Round.Phase == RoundPhase.Undefined)
            {
                lbl_currentRoundState.Text = "No server.";
                lbl_currentRoundState.ForeColor = Color.Red;

                lbl_currentMap.ForeColor = Color.Red;
                lbl_currentMap.Text = "No server.";

            }
            else if (gs.Round.Phase != RoundPhase.Undefined)
            {
                lbl_currentMap.Text = gs.Map.Name;

                if (chk_stayState.Checked)
                {
                }

            }
            else
            {


            }
        }

        #region FocusProcess - http://josephgozlan.blogspot.com/2013/02/c-bring-another-application-to.html
        [DllImport("user32.dll")]
        public static extern bool ShowWindowAsync(HandleRef hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr WindowHandle);
        public const int SW_RESTORE = 9;

        private void FocusProcess(string procName)
        {
            Process[] objProcesses = Process.GetProcessesByName(procName); if (objProcesses.Length > 0)
            {
                IntPtr hWnd = IntPtr.Zero;
                hWnd = objProcesses[0].MainWindowHandle;
                ShowWindowAsync(new HandleRef(null, hWnd), SW_RESTORE);
                SetForegroundWindow(objProcesses[0].MainWindowHandle);
            }
        }
        #endregion


        private void Worker_CheckCSGO_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Th_CheckCSGOProcess = Thread.CurrentThread;
                while (true)
                {


                    if (Process.GetProcessesByName("csgo").Length == 0)
                    {
                        MessageBox.Show("Please start csgo..., restarting in 25 secs.", Program.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        System.Windows.Forms.Application.Restart();
                        Thread.Sleep(25000);
                    }
                    else
                    {


                    }
                    Thread.Sleep(20000);
                }

            }
            catch (ThreadAbortException)
            {
                MessageBox.Show("?", "Sp0ok3r SteamTools", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        #region WindowMover

        private const int WM_NCLBUTTONDBLCLK = 0x00A3;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_NCLBUTTONDBLCLK)
            {
                m.Result = IntPtr.Zero;
                return;
            }

            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }
            base.WndProc(ref m);
        }
        #endregion

        private void link_spk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/sp0ok3r");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/rakijah/CSGSI");
        }


        public static void SetStatus(int Number)
        {
            Steamworks.Load(true);
            ISteamClient006 client = Steamworks.CreateInterface<ISteamClient006>();
            int hSteamPipe = client.CreateSteamPipe();
            int hSteamUser = client.ConnectToGlobalUser(hSteamPipe);
            ISteamUser004 iSteamUser = client.GetISteamUser<ISteamUser004>(hSteamUser, hSteamPipe);
            ISteamFriends003 iSteamFriends = client.GetISteamFriends<ISteamFriends003>(hSteamUser, hSteamPipe);
            ISteamFriends001 PersonaStateChange = client.GetISteamFriends<ISteamFriends001>(hSteamUser, hSteamPipe);
            EPersonaState ePersonaState = (EPersonaState)int.Parse(Number.ToString());
            PersonaStateChange.SetPersonaState(ePersonaState);
        }

        #region ComboBox_Select_States_steam
        private void combo_states_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chk_stayState.Checked)
            {

                if (this.combo_states.SelectedIndex == 0)
                {
                    SetStatus(0);
                }
                else if (this.combo_states.SelectedIndex == 1)
                {
                    SetStatus(1);
                }
                else if (this.combo_states.SelectedIndex == 2)
                {
                    SetStatus(2);
                }
                else if (this.combo_states.SelectedIndex == 3)
                {
                    SetStatus(3);
                }
                else if (this.combo_states.SelectedIndex == 4)
                {
                    SetStatus(4);
                }
                else if (this.combo_states.SelectedIndex == 5)
                {
                    SetStatus(5);
                }
            }
        }
        #endregion
        public string getActiveWindowName()
        {
            try
            {
                var activatedHandle = GetForegroundWindow();

                Process[] processes = Process.GetProcesses();
                foreach (Process clsProcess in processes)
                {

                    if (activatedHandle == clsProcess.MainWindowHandle)
                    {
                        string processName = clsProcess.ProcessName;

                        return processName;
                    }
                }
            }
            catch { }
            return null;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetForegroundWindow();
        void Trolha_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("o " + getActiveWindowName());

        }


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            gsl.Stop();
            Application.ExitThread();
            Environment.Exit(0);
        }


        #region LINKS
        private void pictureBox_Github_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/sp0ok3r/Mercury");
        }

        private void metroLink_spk_Click(object sender, EventArgs e)
        {
            Process.Start("http://steamcommunity.com/profiles/76561198041931474");
        }

        private void metroLink_spkMusic_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/watch?v=YSOUfUsM0zY");
        }

        private void metroLink_valveGSI_Click(object sender, EventArgs e)
        {
            Process.Start("https://developer.valvesoftware.com/wiki/Counter-Strike:_Global_Offensive_Game_State_Integration");
        }

        private void metroLink_Rakijah_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/rakijah/CSGSI");
        }
        #endregion


        // https://developer.valvesoftware.com/wiki/Counter-Strike:_Global_Offensive_Game_State_Integration#Locating_CS:GO_Install_Directory
        // Improved csgo installation detection by bernieplayshd #14
        private static string tryLocatingCSGOFolder()
        {
            // Locate the Steam installation directory
            string steamDir = (string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Valve\Steam", "SteamPath", ""),
                   libsFile = steamDir + @"\steamapps\libraryfolders.vdf";

            Regex regex = new Regex("\"\\d+\".*\"(.*?)\"", RegexOptions.Compiled);

            List<string> libraries = new List<string> { steamDir.Replace('/', '\\') };

            // Find all Steam game libraries
            if (File.Exists(libsFile))
            {
                foreach (string line in File.ReadAllLines(libsFile))
                {
                    foreach (Match match in regex.Matches(line))
                    {
                        if (match.Success && match.Groups.Count != 0)
                        {
                            libraries.Add(match.Groups[1].Value.Replace("\\\\", "\\"));
                            break;
                        }
                    }
                }
            }

            // Search them for the CS:GO installation
            foreach (string lib in libraries)
            {
                string csgoDir = lib + @"\steamapps\common\Counter-Strike Global Offensive";
                if (Directory.Exists(csgoDir))
                {
                    return csgoDir;
                }
            }

            return null;
        }
    }
}