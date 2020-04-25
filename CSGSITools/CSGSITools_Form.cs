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
    public partial class CSGSITools_Form : MetroFramework.Forms.MetroForm
    {
        #region test
        private static ISteam006 steam006;
        private static ISteamClient012 steamclient;
        private static ISteamUser016 steamuser;
        private static ISteamFriends013 steamfriends013;
        private static ISteamFriends002 steamfriends002;
        private static int user;
        private static int pipe;
        private static CSteamID steamid;
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

        public CSGSITools_Form()
        {
            InitializeComponent();
            TrolhaTimer.Tick += TrolhaTimer_Tick;
            lbl_version.Text = Program.Version;
            chk_stayState.Enabled = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            LoadCSGOFolder();
            metroTab_csgsiTools.SelectedIndex = 0;
            ps_status.Visible = true;
            CheckCSGOProcess();

            LoadSteam();
            gslStart();
        }

        public static void LoadCSGOFolder()
        {
            string csgoPath = tryLocatingCSGOFolder();
            csgoCFGPath = csgoPath + @"\csgo\cfg\";

            DirectoryInfo d = new DirectoryInfo(csgoCFGPath);
            FileInfo[] Files = d.GetFiles("gamestate_integration_sp0ok3rTool.cfg");

            if (Files.Length == 0)
            {
                Process.GetProcesses()
                         .Where(x => x.ProcessName.ToLower()
                                      .Contains("csgo"))
                         .ToList()
                         .ForEach(x => x.Kill());

                string fileToCopy = Program.ExecutablePath + "\\gamestate_integration_sp0ok3rTool.cfg";
                File.Copy(fileToCopy, csgoCFGPath + Path.GetFileName(fileToCopy));
            }
        }

        private void gslStart()
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
                MessageBox.Show("Starting csgo for you... restarting " + Program.AppName + " in 15sec.", Program.AppName,
                MessageBoxButtons.OK, MessageBoxIcon.Error);

                Process.Start("steam://run/730");

                Thread.Sleep(15000);
                Process.Start(Application.ExecutablePath);
                Application.Exit();
            }
        }


        #region PlayerState
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

                lbl_playerstate.Text = "Dead";

                dead = true;

            }
            else if (gs.Player.SteamID.Equals(txtBox_steamID.Text.ToString()) && Health > 0)
            {
                lbl_playerstate.ForeColor = Color.DarkGreen;
                lbl_playerstate.Text = "Alive";

                dead = false;

            }
            else
            {
                lbl_playerstate.ForeColor = Color.Red;
                lbl_playerstate.Text = "No server";

            }


            //FLASHED
            if (gs.Player.State.Flashed == 0)
            {
                Flash = false;
            }
            else if (gs.Player.State.Flashed > 0)
            {
                lbl_playerstate.Text = "ALIVE AND FLASHED";
                Flash = true;
            }

            //SMOKED
            if (gs.Player.State.Smoked == 0)
            {
                Smoke = false;

            }
            else if (gs.Player.State.Smoked > 0)
            {

                lbl_playerstate.Text = "ALIVE AND SMOKED";
                Smoke = true;
            }
            //BURNING
            if (gs.Player.State.Burning == 0)
            {
                Molly = false;

            }
            else if (gs.Player.State.Burning > 0)
            {

                lbl_playerstate.Text = "ALIVE AND BURNING";
                Molly = true;
            }

            if (Flash == false && Smoke == false && Molly == false && dead == false)
            {

            }
        }
        #endregion

        #region BombState
        private void CurrentBombState(GameState gs)
        {
            if (gs.Round.Phase == RoundPhase.Live &&
               gs.Bomb.State == BombState.Planted &&
               gs.Previously.Bomb.State == BombState.Planting)
            {
                lbl_bombCurrentState.ForeColor = Color.Red;
                lbl_bombCurrentState.Text = "Bomb has been planted";

                IsPlanted = true;

            }
            else if (gs.Round.Bomb == BombState.Exploded)
            {
                lbl_bombCurrentState.ForeColor = Color.Red;
                lbl_bombCurrentState.Text = "Exploded";


            }
            else if (gs.Round.Bomb == BombState.Defused)
            {
                lbl_bombCurrentState.ForeColor = Color.DodgerBlue;
                lbl_bombCurrentState.Text = "Defused";


            }
            else if (gs.Round.Phase == RoundPhase.FreezeTime)
            {
                IsPlanted = false;
                lbl_bombCurrentState.ForeColor = Color.Blue;
                lbl_bombCurrentState.Text = "Bomb not planted";


            }
            else if (gs.Round.Phase == RoundPhase.Live)
            {
                IsPlanted = false;
                lbl_bombCurrentState.ForeColor = Color.DarkRed;
                lbl_bombCurrentState.Text = "Bomb not planted yet";
            }
            else
            {
                IsPlanted = false;
                lbl_bombCurrentState.ForeColor = Color.Red;
                lbl_bombCurrentState.Text = "No server";

            }
        }
        #endregion

        #region RoundState
        private void RoundState(GameState gs)
        {
            lbl_currentMap.Text = gs.Map.Name;
            if (gs.Round.Phase == RoundPhase.Over)
            {

                lbl_currentRoundState.Text = gs.Round.WinTeam + " - WINS";
                lbl_currentRoundState.ForeColor = Color.Red;

            }
            else if (gs.Round.Phase == RoundPhase.Live)
            {
                lbl_currentRoundState.ForeColor = Color.DarkGreen;
                lbl_currentRoundState.Text = "LIVE";

                lbl_currentMap.ForeColor = Color.DarkGreen;


                if (chk_autofocus.Checked && gs.Player.SteamID.Equals(txtBox_steamID.Text.ToString()) && gs.Player.State.Health == 100)
                {
                    FocusProcess("csgo");
                }

                chk_stayState.Enabled = true;
            }
            else if (gs.Round.Phase == RoundPhase.FreezeTime)
            {
                lbl_currentRoundState.ForeColor = Color.DarkOrange;
                lbl_currentRoundState.Text = "* Freeze Time *";


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
                lbl_currentRoundState.ForeColor = Color.Red;
                lbl_currentRoundState.Text = "No server";

                lbl_currentMap.ForeColor = Color.Red;
                lbl_currentMap.Text = "No server";

            }
            else if (gs.Round.Phase != RoundPhase.Undefined)
            {
                lbl_currentMap.Text = gs.Map.Name;
                


            }
            else
            {


            }
        }
        #endregion

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

        public static void SetStatus(int Number)
        {
            steamfriends002.SetPersonaState((EPersonaState)int.Parse(Number.ToString()));
        }

        private void TrolhaTimer_Tick(object sender, EventArgs e)
        {
            var abc = steamfriends002.GetFriendPersonaState(steamid.ConvertToUint64());
            lbl_currentSteamState.Text = abc.ToString().Replace("k_EPersonaState", "");
        }


        #region ComboBox_Select_States_steam
        private void combo_states_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chk_stayState.Checked)
            {
                SetStatus(this.combo_states.SelectedIndex);
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

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (gsl != null)
            {
                gsl.Stop();
            }
            Application.ExitThread();
            Environment.Exit(0);
        }

        #region LINKS
        private void pictureBox_Github_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/sp0ok3r/CSGSITools");
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

        private void metroLink_Json_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.newtonsoft.com/json");
        }

        private void metroLink_Steam4net_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/SteamRE/Steam4NET");
        }

        private void metroLink_Metro_Click(object sender, EventArgs e)
        {
            Process.Start("http://denricdenise.info/metroframework-faq/");
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