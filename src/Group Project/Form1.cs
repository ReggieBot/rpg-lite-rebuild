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
        private Random _rng = new Random();

        private GameSession _session;

        // === UI GRID ===
        private PictureBox[,] _tileBoxes = new PictureBox[7, 7];
        
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
                // TODO: fix the damn save restore
                _player = new Player("Reggie", 100, 15);

                // find what map the save points to
                _currentMapIndex = _maps.FindIndex(
                    m => m.MapName == saveData.MapProgress.MapName);
                if (_currentMapIndex < 0)
                {
                    _currentMapIndex = 0;
                }
            }
            else
            {
                _player = new Player("Reggie", 100, 15);
                _currentMapIndex = 0;
            }

            _session = new GameSession(_player, _maps, _currentMapIndex);
            InitializeGrid();
            //InitializeDialogs();
            LoadCurrentSection();

        }

        private void InitializeGrid()
        {
            // clear controls associated with the grid panel
            tableLayoutPanel_Grid.Controls.Clear();

            for (int row = 0; row < 7; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    PictureBox tileBox = new PictureBox();

                    tileBox.Dock = DockStyle.Fill;
                    // Padding usually takes a single int for all sides (you can check definition)
                    // but Winforms provides overloaded constructors (hence why I'm just using '1')
                    tileBox.Margin = new Padding(1);
                    // could definitely go with zoom size mode here as well
                    tileBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    tileBox.BackColor = Color.DarkGray;

                    // Point is a struct (readonly) that takes two ints, much easier than building my own
                    // storing point as (row, col) to match the rest of the grid codebase,
                    // even though Point is usually (x, y) and thus (col, row)
                    tileBox.Tag = new Point(row, col);
                    tileBox.Click += OnTileClicked;

                    _tileBoxes[row, col] = tileBox;
                    tableLayoutPanel_Grid.Controls.Add(tileBox, col, row);

                }
            }
        }
        
        // click handler for tiles
        private void OnTileClicked(object sender, EventArgs e)
        {
            // only continue if the click came from a picturebox
            // and its Tag contains the stored grid coordinates
            if (!(sender is PictureBox clickedBox) || !(clickedBox.Tag is Point position))
            {
                return;
            }

            // Point.X stores row and Point.Y stores column
            // backwards, I know...
            int row = position.X;
            int column = position.Y;

            // let GameSession handle arrow movement
            if (_session.TryMoveToTileDestination(row, column))
            {
                LoadCurrentSection();
                return;
            }

            // let GameSession handle item pickup
            if (_session.TryPickUpItem(row, column))
            {
                LoadCurrentSection();
                return;
            }
        }

        // load current sections to tiles 
        private void LoadCurrentSection()
        {
            Section currentSection = _session.CurrentSection;
            // keep the section label synced with the current section

            string sectionName = null;
            if (currentSection != null)
            {
                sectionName = currentSection.SectionName;
            }

            if (string.IsNullOrWhiteSpace(sectionName))
            {
                labelSectionValue.Text = "Unknown Section!";
            }
            else
            {
                labelSectionValue.Text = sectionName;
            }

            // assign images to tiles based on the section's tile data
            for (int row = 0; row < 7; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    PictureBox tileBox = _tileBoxes[row, col];
                    Tile tile = currentSection.GetTile(row, col);

                    if (tile == null)
                    {
                        tileBox.ImageLocation = null;
                        tileBox.Name = string.Empty;
                        // continue to next iteration, so we don't access the tile's null property
                        continue;
                    }

                    tileBox.ImageLocation = tile.ImagePath;

                    if (tile.Entity != null)
                    {
                        tileBox.Name = tile.Entity.Name;
                    }
                    else
                    {
                        tileBox.Name = tile.Type.ToString();
                    }
                }
            }
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
