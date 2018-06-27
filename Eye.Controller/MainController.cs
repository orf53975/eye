using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Timers;
using System.Windows.Forms;
using Eye.CombatLog.Core;
using Eye.Controller.Modules;
using Eye.Controller.Modules.AegisTimerModule;
using Eye.Controller.Modules.BkbSecondsModule;
using Eye.Controller.Modules.BountyRuneGoldModule;
using Eye.Controller.Modules.BountyRuneGoldModule.Commands;
using Eye.Controller.Modules.BountyRuneGoldModule.Events;
using Eye.Controller.Modules.DataShowerModule;
using Eye.Controller.Modules.ImportantItemsModule;
using Eye.Controller.Modules.ImportantItemsModule.ImportantItemsCommands;
using Eye.Controller.Modules.PauseModule;
using Eye.Controller.Modules.RunesModule;
using Eye.Controller.Modules.RunesModule.Commands;
using Eye.Controller.Modules.SmokeModule;
using Eye.Controller.Modules.SmokeModule.Commands;
using Eye.Events.Core;
using Eye.Gsi.Core;
using Eye.Gsi.Objects;
using Eye.Objects;

namespace Eye.Controller
{
    public partial class MainController : Form
    {
        private readonly EyePlayerController _playerController;
        private readonly EyeController _controller;

        private readonly EventsCounter _eventsCounter;
        private readonly GameEndedEvent _gameEndedEvent;


        private readonly ModuleCollection _modules;

        public MainController()
        {
            _playerController = new EyePlayerController();

            _controller = new EyeController(_playerController);
            _controller.EventManager.NewToken += EventManagerNewToken;

            _modules = new ModuleCollection();
            _modules.ModuleAdded += (sender, module) =>
            {
                modulesCheckedListBox.Items.Add(module, module.Enabled);

                modulesComboBox.Items.Add(module);
                if (modulesComboBox.Items.Count == 1) modulesComboBox.SelectedIndex = 0;
            };

            _eventsCounter = new EventsCounter();
            _eventsCounter.CombatLogEventsCountChange += EventsCounterOnCombatLogEventsCountChange;
            _eventsCounter.GameStateEventsCountChange += EventsCounterOnGameStateEventsCountChange;
            _controller.EventManager.Subscribe(_eventsCounter);

            _gameEndedEvent = new GameEndedEvent();
            _gameEndedEvent.GameEnded += GameEnded;
            _controller.EventManager.Subscribe(_gameEndedEvent);

            InitializeComponent();

            LoadModules();
        }

        private void LoadModules()
        {
            _modules.Add(new AegisTimer(_controller));
            _modules.Add(new BkbSeconds(_controller));
            _modules.Add(new ImportantItems(_controller));
            _modules.Add(new Pause(_controller));

            _modules.Add(new Smoke(_controller));
            _modules.Add(new Rune(_controller));
            _modules.Add(new BountyRuneGold(_controller));
            _modules.Add(new DataShower(_controller));
        }

        private void ReloadModules()
        {
            foreach (var module in _modules)
                module.Reload();
        }

        private void GameEnded(object o, EventArgs eventArgs)
        {
            ReloadModules();
        }

        private void modulesCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var module = modulesCheckedListBox.Items[e.Index] as IControllerModule;
            if (module == null) return;

            var state = e.NewValue;
            if (state == CheckState.Checked)
                module.Enable();
            if (state == CheckState.Unchecked)
                module.Disable();
        }

        private void EventsCounterOnGameStateEventsCountChange(object sender, int count)
        {
            Invoke(new Action(() =>
            {
                gameStatsStatsLabel.Text =
                    string.Format(gameStatsStatsLabel.Tag.ToString(), count);
            }));
        }

        private void EventsCounterOnCombatLogEventsCountChange(object sender, int count)
        {
            Invoke(new Action(() =>
            {
                combatLogStatsLabel.Text =
                    string.Format(combatLogStatsLabel.Tag.ToString(), count);
            }));
        }

        private void EventManagerNewToken(object sender, string token)
        {
            Invoke(new Action(() =>
            {
                observersCheckedListBox.Items.Add(token);

                if (observersCheckedListBox.Items.Count == 1)
                    observersCheckedListBox.SetItemChecked(0, true);
            }));
        }

        private void tokensCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
                for (var i = 0; i < observersCheckedListBox.Items.Count; i++)
                    if (e.Index != i) observersCheckedListBox.SetItemChecked(i, false);

            switch (e.NewValue)
            {
                case CheckState.Unchecked:
                    _controller.EventManager.CurrentToken = "";
                    break;
                case CheckState.Checked:
                    _controller.EventManager.CurrentToken = observersCheckedListBox.Items[e.Index].ToString();
                    break;
                case CheckState.Indeterminate:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void MainController_Load(object sender, EventArgs e)
        {
            modulesCheckedListBox.DisplayMember = "Name";

            var ipAddress = Program.LocalAddress;
            if (ipAddress != null)
                localAddressTextBox.Text = ipAddress.ToString();

            var dataShower = _modules.Get<DataShower>();

            datasComboBox.DisplayMember = "Name";
            datasComboBox.DataSource = dataShower.Datas;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            _controller.Start();

            startButton.Enabled = false;

            gameStateListenerStatusLabel.Text = string.Format(gameStateListenerStatusLabel.Tag.ToString(), "OK");
            combatLogListenerStatusLabel.Text = string.Format(combatLogListenerStatusLabel.Tag.ToString(), "OK");
            webSocketServerStatusLabel.Text = string.Format(webSocketServerStatusLabel.Tag.ToString(), "OK");
        }

        private void modulesReloadButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите перезагрузить все модули?", "Модули", MessageBoxButtons.YesNo) == DialogResult.Yes)
                ReloadModules();
        }

        private void smokeAddBtn_Click(object sender, EventArgs e)
        {
            var index = smokeHeroesСomboBox.SelectedIndex;
            if(index == -1) return;

            var command = new SmokeModifierAdded {Hero = index};
            _playerController.Execute(command);
        }

        private void smokeRemoveBtn_Click(object sender, EventArgs e)
        {
            var index = smokeHeroesСomboBox.SelectedIndex;
            if (index == -1) return;

            var command = new SmokeModifierRemoved { Hero = index };
            _playerController.Execute(command);
        }


        private void importantItemsAddGemBtn_Click(object sender, EventArgs e)
        {
            var index = importantItemsHeroesComboBox.SelectedIndex;
            if (index == -1) return;

            var command = new ImportantItemAdded {Item = "gem", Member = index};
            _playerController.Execute(command);
        }

        private void importantItemsRemoveGemBtn_Click(object sender, EventArgs e)
        {
            var index = importantItemsHeroesComboBox.SelectedIndex;
            if (index == -1) return;

            var command = new ImportantItemRemoved { Item = "gem", Member = index };
            _playerController.Execute(command);
        }

        private void importantItemsAddAegisBtn_Click(object sender, EventArgs e)
        {
            var index = importantItemsHeroesComboBox.SelectedIndex;
            if (index == -1) return;

            var command = new ImportantItemAdded { Item = "aegis", Member = index };
            _playerController.Execute(command);
        }

        private void importantItemsRemoveAegisBtn_Click(object sender, EventArgs e)
        {
            var index = importantItemsHeroesComboBox.SelectedIndex;
            if (index == -1) return;

            var command = new ImportantItemRemoved { Item = "aegis", Member = index };
            _playerController.Execute(command);
        }

        private void importantItemsAddRapierBtn_Click(object sender, EventArgs e)
        {
            var index = importantItemsHeroesComboBox.SelectedIndex;
            if (index == -1) return;

            var command = new ImportantItemAdded { Item = "rapier", Member = index };
            _playerController.Execute(command);
        }

        private void importantItemsRemoveRapierBtn_Click(object sender, EventArgs e)
        {
            var index = importantItemsHeroesComboBox.SelectedIndex;
            if (index == -1) return;

            var command = new ImportantItemRemoved { Item = "rapier", Member = index };
            _playerController.Execute(command);
        }


        private void runesAddDDBtn_Click(object sender, EventArgs e)
        {
            var index = runesHeroesComboBox.SelectedIndex;
            if (index == -1) return;

            var command = new RuneModifierAdded { Hero = index, Rune = "doubledamage" };
            _playerController.Execute(command);
        }

        private void runesRemoveDDBtn_Click(object sender, EventArgs e)
        {
            var index = runesHeroesComboBox.SelectedIndex;
            if (index == -1) return;

            var command = new RuneModifierRemoved { Hero = index, Rune = "doubledamage" };
            _playerController.Execute(command);
        }

        private void runesAddRegBtn_Click(object sender, EventArgs e)
        {
            var index = runesHeroesComboBox.SelectedIndex;
            if (index == -1) return;

            var command = new RuneModifierAdded { Hero = index, Rune = "regen" };
            _playerController.Execute(command);
        }

        private void runesRemoveRegBtn_Click(object sender, EventArgs e)
        {
            var index = runesHeroesComboBox.SelectedIndex;
            if (index == -1) return;

            var command = new RuneModifierRemoved { Hero = index, Rune = "regen" };
            _playerController.Execute(command);
        }

        private void runesAddHasteBtn_Click(object sender, EventArgs e)
        {
            var index = runesHeroesComboBox.SelectedIndex;
            if (index == -1) return;

            var command = new RuneModifierAdded { Hero = index, Rune = "haste" };
            _playerController.Execute(command);
        }

        private void runesRemoveHasteBtn_Click(object sender, EventArgs e)
        {
            var index = runesHeroesComboBox.SelectedIndex;
            if (index == -1) return;

            var command = new RuneModifierRemoved { Hero = index, Rune = "haste" };
            _playerController.Execute(command);
        }

        private void runesAddInvisBtn_Click(object sender, EventArgs e)
        {
            var index = runesHeroesComboBox.SelectedIndex;
            if (index == -1) return;

            var command = new RuneModifierAdded { Hero = index, Rune = "invis" };
            _playerController.Execute(command);
        }

        private void runesRemoveInvisBtn_Click(object sender, EventArgs e)
        {
            var index = runesHeroesComboBox.SelectedIndex;
            if (index == -1) return;

            var command = new RuneModifierRemoved { Hero = index, Rune = "invis" };
            _playerController.Execute(command);
        }

        private void runesAddArcaneBtn_Click(object sender, EventArgs e)
        {
            var index = runesHeroesComboBox.SelectedIndex;
            if (index == -1) return;

            var command = new RuneModifierAdded { Hero = index, Rune = "arcane" };
            _playerController.Execute(command);
        }

        private void runesRemoveArcaneBtn_Click(object sender, EventArgs e)
        {
            var index = runesHeroesComboBox.SelectedIndex;
            if (index == -1) return;

            var command = new RuneModifierRemoved { Hero = index, Rune = "arcane" };
            _playerController.Execute(command);
        }

        private void MainController_FormClosed(object sender, FormClosedEventArgs e)
        {
            _controller.Network.Stop();
        }

        private void updateModuleBtn_Click(object sender, EventArgs e)
        {
            var module = modulesComboBox.SelectedItem as IControllerModule;
            if (module == null) return;

            if(MessageBox.Show($"Вы уверены что хотите перезагрузить модуль: {module.Name}?", module.Name, MessageBoxButtons.YesNo) == DialogResult.Yes)
                module.Reload();
        }

        private void gountyGoldOpenBtn_Click(object sender, EventArgs e)
        {
            var bountyGold = _modules.GetEnabled<BountyRuneGold>();

            bountyGold?.Show();
        }

        private void gountyGoldHideBtn_Click(object sender, EventArgs e)
        {
            var bountyGold = _modules.GetEnabled<BountyRuneGold>();

            bountyGold?.Hide();
        }

        private void dataShowBtn_Click(object sender, EventArgs e)
        {
            var dataShower = _modules.GetEnabled<DataShower>();
            var data = datasComboBox.SelectedItem as IData;

            dataShower?.Show(data);
        }

        private void dataHideBtn_Click(object sender, EventArgs e)
        {
            var dataShower = _modules.GetEnabled<DataShower>();

            dataShower?.Hide();
        }
    }

    public class ModuleCollection : List<IControllerModule>
    {
        public event EventHandler<IControllerModule> ModuleAdded; 

        public new void Add(IControllerModule module)
        {
            OnModuleAdded(module);
            base.Add(module);
        }

        protected virtual void OnModuleAdded(IControllerModule e)
        {
            ModuleAdded?.Invoke(this, e);
        }

        public T Get<T>() where T : class, IControllerModule
        {
            return this.FirstOrDefault(m => m is T) as T;
        }

        public T GetEnabled<T>() where T : class, IControllerModule
        {
            var module = Get<T>();
            if (module.Enabled) return module;

            MessageBox.Show($"Модуль: {module.Name} отключен!");
            return null;
        }
    }

    public class GameEndedEvent : IEyeStateEntryEvent
    {
        public event EventHandler GameEnded; 

        public void Execute(EyeStateEntry entry, CombatLogEntry combatLogEntry)
        {
            OnGameEnded();
        }

        public bool EventPredicator(EyeStateEntry prev, EyeStateEntry entry)
        {
            return prev.Map.State == Map.GameState.DOTA_GAMERULES_STATE_GAME_IN_PROGRESS &&
                   entry.Map.State == Map.GameState.DOTA_GAMERULES_STATE_POST_GAME;
        }

        protected virtual void OnGameEnded()
        {
            GameEnded?.Invoke(this, EventArgs.Empty);
        }
    }

    public class EventsCounter : IEyeStateComatLogEvent, IEyeStateEntryEvent
    {
        public event EventHandler<int> CombatLogEventsCountChange;
        public event EventHandler<int> GameStateEventsCountChange;

        private int _combatLogCount, _gameStateCount;

        public void Execute(EyeStateEntry entry, CombatLogEntry combatLogEntry)
        {
            if(combatLogEntry == null)
                OnGameStateEventsCountChange(++_gameStateCount);
            else
                OnCombatLogEventsCountChange(++_combatLogCount);
        }

        public bool EventPredicator(EyeStateEntry prev, EyeStateEntry entry)
        {
            return true;
        }

        public bool EventPredicator(CombatLogEntry entry)
        {
            return true;
        }

        protected virtual void OnCombatLogEventsCountChange(int e)
        {
            CombatLogEventsCountChange?.Invoke(this, e);
        }

        protected virtual void OnGameStateEventsCountChange(int e)
        {
            GameStateEventsCountChange?.Invoke(this, e);
        }
    }

    public class EmptyTestModule : IControllerModule
    {
        public string Name => "Test";

        public bool Enabled { get; }

        public void Enable()
        {

        }

        public void Disable()
        {

        }

        public void Reload()
        {

        }
    }
}
