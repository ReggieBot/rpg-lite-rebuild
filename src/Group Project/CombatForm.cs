using System;
using System.Drawing;
using System.Windows.Forms;

namespace Group_Project
{
    // small combat overlay
    // doesn't know anything about maps, tiles, sections, xp, etc.
    // displays one fight and lets user play rounds through CombatSession
    public class CombatForm : Form
    {
        // This object owns the actual combat logic.
        private CombatSession _combatSession;

        // top left label for player name and hp
        private Label _labelPlayerStats;

        // top right label for enemy name and hp
        private Label _labelEnemyStats;

        // middle text area for combat messages
        private TextBox _textBoxCombatLog;

        // button to process one attack round
        private Button _buttonAttack;

        // button to close the form after combat is finished
        private Button _buttonContinue;

        // MainForm will read these later (these are the result flags)
        public bool PlayerWon { get; private set; }
        public bool PlayerDied { get; private set; }

        // create new combat form for one player vs. one enemy
        public CombatForm(Player player, Enemy enemy)
        {
            InitializeFormWindow();

            // build controls and add to form
            BuildControls();

            // create combatsession
            _combatSession = new CombatSession(player, enemy);

            PlayerWon = false;
            PlayerDied = false;

            RefreshCombatDisplay();
        }

        // main window properties
        private void InitializeFormWindow()
        {
            Text = "Combat";

            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            ClientSize = new Size(460, 280);

            MaximizeBox = false;

            MinimizeBox = false;

            BackColor = Color.LightGray;
        }

        // creates and places ui controls
        private void BuildControls()
        {
            _labelPlayerStats = new Label();

            _labelPlayerStats.Location = new Point(20, 20);
            _labelPlayerStats.Size = new Size(180, 50);
            // I hate this font so much but its like the only one that looks decent at a small size lol
            _labelPlayerStats.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            _labelEnemyStats = new Label();

            _labelEnemyStats.Location = new Point(250, 20);
            _labelEnemyStats.Size = new Size(180, 50);
            _labelEnemyStats.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            _textBoxCombatLog = new TextBox();
            _textBoxCombatLog.Location = new Point(20, 90);
            _textBoxCombatLog.Size = new Size(410, 100);
            _textBoxCombatLog.Multiline = true;
            _textBoxCombatLog.ReadOnly = true;
            _textBoxCombatLog.TabStop = false;
            _textBoxCombatLog.Text = "Click Attack to begin combat";

            _buttonAttack = new Button();
            _buttonAttack.Location = new Point(20, 215);
            _buttonAttack.Size = new Size(120, 35);
            _buttonAttack.Text = "Attack";
            _buttonAttack.Click += ButtonAttack_Click;

            _buttonContinue = new Button();
            _buttonContinue.Location = new Point(310, 215);
            _buttonContinue.Size = new Size(120, 35);
            _buttonContinue.Text = "Continue";
            _buttonContinue.Enabled = false;
            _buttonContinue.Click += ButtonContinue_Click;

            Controls.Add(_labelPlayerStats);
            Controls.Add(_labelEnemyStats);
            Controls.Add(_textBoxCombatLog);
            Controls.Add(_buttonAttack);
            Controls.Add(_buttonContinue);
        }

        // refreshes labels and button states to match current combat session state
        private void RefreshCombatDisplay()
        {
            Player player = _combatSession.Player;
            Enemy enemy = _combatSession.Enemy;

            int playerHealth = (int)player.CurrentHealth;
            int enemyHealth = (int)enemy.CurrentHealth;


            _labelPlayerStats.Text =
                player.Name + Environment.NewLine +
                "HP: " + playerHealth + " / " + (int)player.MaxHealth;


            _labelEnemyStats.Text =
                enemy.Name + Environment.NewLine +
                "HP: " + enemyHealth + " / " + (int)enemy.MaxHealth;

            // make sure user cant press attack again if combat ends
            _buttonAttack.Enabled = !_combatSession.CombatFinished;

            // continue button available after combat finishes
            _buttonContinue.Enabled = _combatSession.CombatFinished;
        }

        // processes combat round and updates display
        private void ButtonAttack_Click(object sender, EventArgs e)
        {
            // ask CombatSession to run one full round
            string combatRoundText = _combatSession.ProcessRound();

            // show the summary returned by CombatSession
            _textBoxCombatLog.Text = combatRoundText;

            // If combat ended this round then copy the result flags to the form
            // MainForm will read these later
            if (_combatSession.CombatFinished)
            {
                PlayerWon = _combatSession.PlayerWon;
                PlayerDied = _combatSession.PlayerDied;
            }

            RefreshCombatDisplay();
        }

        // closes overlay after combat is over
        private void ButtonContinue_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
