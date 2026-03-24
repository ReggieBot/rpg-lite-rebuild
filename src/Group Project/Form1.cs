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
    }
