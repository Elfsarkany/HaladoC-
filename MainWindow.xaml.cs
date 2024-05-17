using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TurnBasedGame.Classes;
using TurnBasedGame.ModelsAndCommands;

namespace TurnBasedGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainMenuChangeModel _menuChangeModel;
        private ChangeToGameCommand _changeToGameCommand;
        private ChangeToMainMenuCommand _changeToMainMenuCommand;

        private CombatMenuChangeModel _combatModel;
        private ToCombatCommand _toCombatCommand;
        private ToInventoryCommand _toInventoryCommand;
        private ToTheMapCommand _toTheMapCommand;
        private ToSpecialCommand _toSpecialCommand;

        private Character _player;
        private Encounter _encounter;

        private Random _random;

        public MainWindow()
        {
            _random = new Random();

            _player = new Character("Knight",Specialization.Fighter);
            _encounter = new Encounter(_player);

            _menuChangeModel = new MainMenuChangeModel();
            _changeToGameCommand = new ChangeToGameCommand(_menuChangeModel);
            _changeToMainMenuCommand = new ChangeToMainMenuCommand(_menuChangeModel);

            _combatModel = new CombatMenuChangeModel();
            _toCombatCommand = new ToCombatCommand(_combatModel,_encounter);
            _toInventoryCommand = new ToInventoryCommand(_combatModel);
            _toTheMapCommand = new ToTheMapCommand(_combatModel);
            _toSpecialCommand = new ToSpecialCommand(_combatModel);

            InitializeComponent();
            ProgramGrid.DataContext = this;
            Reset();
        }

        public void Reset()
        {
            MenuModel.Index = 0;
            _player = new Character("Knight", Specialization.Fighter);
            _encounter = new Encounter(_player);
            PrepareCombatField();
        }

        public void PrepareCombatField()
        {
            if (_player.GetLvl() < 5)
            {
                _encounter.RefreshEncounter(0);
            }
            else if( _player.GetLvl() < 10)
            {
                _encounter.RefreshEncounter(_random.Next(0,2));
            }
            else
            {
                _encounter.RefreshEncounter(_random.Next(0, 3));
            }
            SetHpBars();
            RefreshHpBars();
        }

        public MainMenuChangeModel MenuModel
        {
            get
            {
                return _menuChangeModel;
            }
        }

        public ChangeToMainMenuCommand ToMainMenuCommand
        {
            get
            {
                return _changeToMainMenuCommand;
            }
        }

        public ChangeToGameCommand ToGameCommand
        {
            get
            {
                return _changeToGameCommand;
            }
        }

        public CombatMenuChangeModel GameModel
        {
            get
            {
                return _combatModel;
            }
        }

        public ToCombatCommand CombatCommand
        {
            get
            {
                return _toCombatCommand;
            }
        }

        public ToSpecialCommand SpecialCommand
        {
            get
            {
                return _toSpecialCommand;
            }
        }

        public ToTheMapCommand MapCommand
        {
            get
            {
                return _toTheMapCommand;
            }
        }

        public ToInventoryCommand InventoryCommand
        {
            get
            {
                return _toInventoryCommand;
            }
        }

        private void b_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public Encounter Battle
        {
            get { return _encounter; }
        }

        private void SetHpBars()
        {
            pb_EnemyHealth.Maximum = _encounter.EnemyHP;
            pb_PlayerHealth.Maximum = _encounter.PlayerHP;
        }
        private void RefreshHpBars()
        {
            pb_EnemyHealth.Value = _encounter.EnemyHP;
            pb_PlayerHealth.Value = _encounter.PlayerHP;
            l_EnemyHealth.Content = _encounter.EnemyHP.ToString();
            l_PlayerHealth.Content = _encounter.PlayerHP.ToString();
        }

        private void b_Attack_Click(object sender, RoutedEventArgs e)
        {
            Battle.DamageDealing(0);
            if (Battle.CombatEnded())
            {
                Battle.Heal(20);
                Battle.XpReward();
                MapCommand.Execute(this);
                PrepareCombatField();
            }
            else
            {
                Battle.DamageDealing(1);
                if (Battle.CombatEnded())
                {
                    MessageBox.Show("You sadly died. Better luck next time!");
                    Reset();
                }
            }
            RefreshHpBars();
        }
    }
}