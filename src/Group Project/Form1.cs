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
        private GameSession _session;
        private Image _grassTileImage;
        private const string PlayerSpritePath = @"assets\img\Player\player_direction_up.png";
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
            // ask factory for a ready to use session
            // Gosh this feels so much cleaner than doing all the setup in the form directly
            _session = GameSessionFactory.CreateNewSession();
            _grassTileImage = Image.FromFile(@"assets\img\Tiles\grass_tile.png");
            InitializeGrid();
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

                    tileBox.BackgroundImage = _grassTileImage;
                    tileBox.BackgroundImageLayout = ImageLayout.Stretch;
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

            // let GameSession decide what click does
            if (_session.TryHandleTileClick(row, column))
            {
                LoadCurrentSection();
            }
            // temporary label so I can see if this actually works
            else
            {
                labelStatus.Text = "Can't interact with this tile";
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

                    // clear old visual state first
                    // otherwise old colours, borders, etc. can persist on wrong tile
                    tileBox.Name = string.Empty;
                    tileBox.BorderStyle = BorderStyle.None;
                    tileBox.BackColor = Color.DarkGray;

                    if (tile == null)
                    {
                        continue;
                    }

                    bool shouldShowImage = ShouldShowTileImage(tile);
                    bool isPlayerHere = _session.IsPlayerOnTile(row, col);
                    string imagePathToShow = null;

                    if (shouldShowImage)
                    {
                        // default to tiles normal image
                        imagePathToShow = tile.ImagePath;
                    }

                    // player sprite overrides normal tile image
                    if (isPlayerHere)
                    {
                        imagePathToShow = PlayerSpritePath;
                    }

                    // only assign image path if it's different from one on the PictureBox
                    // StringComparison.OrdinalIgnoreCase compahttps://learn.microsoft.com/en-us/dotnet/api/system.stringcomparer.ordinalignorecase?view=net-10.0
                    if (!string.Equals(tileBox.ImageLocation,
                        tile.ImagePath, StringComparison.OrdinalIgnoreCase))
                    {
                        // only update if image actually changed
                        tileBox.ImageLocation = imagePathToShow;
                    }

                    // make arrow tiles blue for now so I can see them
                    // still need to fix all of these assets
                    if (tile.Type == TileType.ArrowLeft ||
                        tile.Type == TileType.ArrowRight ||
                        tile.Type == TileType.ArrowUp ||
                        tile.Type == TileType.ArrowDown)
                    {
                        tileBox.BackColor = Color.LightBlue;
                    }

                    if (tile.Entity != null)
                    {
                        tileBox.Name = tile.Entity.Name;
                    }
                    else
                    {
                        tileBox.Name = tile.Type.ToString();
                    }

                    // keep border
                    if (isPlayerHere)
                    {
                        tileBox.BorderStyle = BorderStyle.FixedSingle;
                    }
                }
            }

            // update sidebar after board redraw finishes
            UpdateSideBar();
        }

        private void UpdateSideBar()
        {
            Player player = _session.Player;

            // keep stat label in sync with actual player object
            labelPlayerStats.Text =
                "HP: " + ((int)player.CurrentHealth) + "/" + ((int)player.MaxHealth) +
                Environment.NewLine +
                "DMG: " + ((int)player.CurrentDamage) + " | LVL: " + player.Level;

            // default status text after successful action
            labelStatus.Text =
                "Exploring" +
                Environment.NewLine +
                "Pos: (" + _session.PlayerRow + ", " + _session.PlayerColumn + ")";
        }

        private bool ShouldShowTileImage(Tile tile)
        {
            if (tile == null)
            {
                return false;
            }

            if (tile.InteractionFinished)
            {
                if (tile.Type == TileType.Item ||
                    tile.Type == TileType.Enemy ||
                    tile.Type == TileType.Boss)
                {
                    return false;
                }
            }

            if (string.IsNullOrWhiteSpace(tile.ImagePath))
            {
                return false;
            }

            if (tile.ImagePath == "PLACEHOLDER" ||
                tile.ImagePath == "PLACEHOLDER PATHING")
            {
                return false;
            }

            return true;
        }
    }
}
