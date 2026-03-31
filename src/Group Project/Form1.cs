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

            var saveData = _saveManager.LoadGame();
            if (saveData != null)
            {
                _player = RestorePlayerFromSave(saveData);
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
            InitializeGrid();
            InitializeDialogs();
            LoadCurrentSection();

        }

        // todo: this method is being called during startup in InitializeGame()
        // instead of just building everything in one gargantuan method, we'll delegate to one
        // priv builder per map. Keeps everything self-contained
        private List<GameMap> InitializeAllMaps()
        {}

        // todo: builds/returns a fully configed GameMap for Map1
        // creates all of the enemies, npcs, items, and section for this map
        // loads them into the GameMap object
        // that map object is what the rest of the game actually reads from,
        // nothing else creates enemies or items, they all look them up from here
        private GameMap BuildMap1()
        {}



    }
}
