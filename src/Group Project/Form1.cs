using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows.Forms;

namespace Group_Project
{
    public partial class MainForm : Form
    {
        // === CORE GAME OBJECTS ===
        private Player _player;
        private List<GameMap> _maps;
        private int _currentMapIndex;
        private GameStateManager _saveManager;
        private GameState _currentState;
        private Random _rng = new Random();

        // === UI GRID ===
        private PictureBox[,] _tileBoxes = new PictureBox[7, 7];
        private TableLayoutPanel _gridPanel;


        public MainForm()
        {
            InitializeComponent();
            InitializeGame();
        }

        /// <summary>
        /// sets up the game: loads save or creates new player,
        /// initializes maps, builds grid, loads first section.
        /// </summary>
        private void InitializeGame()
        {
            _saveManager = new GameStateManager();
            _maps = InitializeAllMaps();

            SaveData saveData = _saveManager.LoadGame();
            if (saveData != null)
            {
              //  _player = RestorePlayerFromSave(saveData);
                _currentMapIndex = _maps.FindIndex(
                    m => m.MapName == saveData.MapProgress.MapName);
                if (_currentMapIndex < 0) _currentMapIndex = 0;
            }
            else
            {
                _player = new Player("Hero", 100, 15);
                _currentMapIndex = 0;
            }

            _currentState = GameState.Exploring;
            //InitializeGrid();
            //InitializeDialogs();
            //LoadCurrentSection();

        }

        /*
         This method is being called during startup in InitializeGame()
         instead of just building everything in one gargantuan method, we'll delegate to one
         priv builder per map. Keeps everything self-contained
         this delegates building to the MapFactory classes,
         which in turn delegate to the MapEntityFactory for creating entities
        */
        private List<GameMap> InitializeAllMaps()
        {
            // delegate to individual builders for each map, then add them to the list and return
            return new List<GameMap>
            {
                Map1Factory.BuildMap1()
            };
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void labelAllyTwo_Click(object sender, EventArgs e)
        {

        }

        private void labelAllyOne_Click(object sender, EventArgs e)
        {

        }
    }
}
