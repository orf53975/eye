using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eye.Controller.Modules.BountyRuneGoldModule.Commands;
using Eye.Controller.Modules.BountyRuneGoldModule.Events;
using Eye.Objects;

namespace Eye.Controller.Modules.BountyRuneGoldModule
{
    public class BountyRuneGoldMinutes
    {
        public int SumRadiant => _radiantGolds.Sum(p => p.Value);
        public int SumDire => _direGolds.Sum(p => p.Value);

        public int CountRadiant => (int)Math.Ceiling(_radiantGolds.Count / 5m);
        public int CountDire => (int)Math.Ceiling(_direGolds.Count / 5m);

        private readonly Dictionary<Members.Member, int> _radiantGolds;
        private readonly Dictionary<Members.Member, int> _direGolds;

        public BountyRuneGoldMinutes()
        {
            _radiantGolds = new Dictionary<Members.Member, int>();
            _direGolds = new Dictionary<Members.Member, int>();
        }

        public void Add(Members.Member member, int gold)
        {
            if (member.Index < 5) _radiantGolds.Add(member, gold);
            else _direGolds.Add(member, gold);
        }
    }

    public class BountyRuneGold : IControllerModule
    {
        public string Name => "Золото за баунти руны";
        public bool Enabled { get; private set; }

        public Dictionary<int, BountyRuneGoldMinutes> Minutes { get; private set; }
        public double GameStartedTimeStamp { get; private set; }

        public event EventHandler GoldChanged; 

        private readonly BountyRunePickedupEvent _pickedup;
        private readonly GameStartedEvent _gameStarted;

        private readonly EyeController _controller;

        private bool _showed;

        public BountyRuneGold(EyeController controller)
        {
            Minutes = new Dictionary<int, BountyRuneGoldMinutes>();

            _pickedup = new BountyRunePickedupEvent(this);
            _pickedup.PickedUp += OnPickedUp;

            _gameStarted = new GameStartedEvent();
            _gameStarted.GameStarted += (sender, e) => GameStartedTimeStamp = e;

            _controller = controller;
            _controller.EventManager.Subscribe(_gameStarted);

            Enable();
        }

        public void Show()
        {
            if(_showed) return;

            var data = new Data { Minutes = new List<Minutes>() };

            var minutes = Minutes.Skip(Math.Max(0, Minutes.Count - 7));

            foreach (var pair in minutes)
            {
                data.Minutes.Add(new Minutes
                {
                    Radiant = new Team { Gold = pair.Value.SumRadiant, Bounties = pair.Value.CountRadiant },
                    Dire = new Team { Gold = pair.Value.SumDire, Bounties = pair.Value.CountDire },
                    Minute = pair.Key * 5
                });
            }

            data.DireGold = Minutes.Sum(m => m.Value.SumDire);
            data.RadiantGold = Minutes.Sum(m => m.Value.SumRadiant);
            data.Seconds = _controller.Entry.Map.ClockTime;
            data.Team1Name = "Radiant";
            data.Team2Name = "Dire";

            _controller.PlayerController.Execute(new BountyGoldOpen { Data = data });

            _showed = true;
        }

        public void Hide()
        {
            if (!_showed) return;

            _controller.PlayerController.Execute(new BountyGoldClose());

            _showed = false;
        }

        private void OnPickedUp(object sender, BountyRunePickedupEventAegs e)
        {
            var index = (int)Math.Floor(_controller.Entry.Map.ClockTime / 60d / 5d);
            if (!Minutes.ContainsKey(index))
            {
                var minutes = new BountyRuneGoldMinutes();
                minutes.Add(e.Member, e.Gold);
                Minutes.Add(index, minutes);
            }
            else Minutes[index].Add(e.Member, e.Gold);

            OnGoldChanged();
        }

        public void Enable()
        {
            if(Enabled) return;

            _controller.EventManager.Subscribe(_pickedup);

            Enabled = true;
        }

        public void Disable()
        {
            if (!Enabled) return;

            _controller.PlayerController.Execute(new BountyGoldClose());

            _controller.EventManager.Unsubscribe(_pickedup);

            Enabled = false;
        }

        public void Reload()
        {
            _controller.PlayerController.Execute(new BountyGoldClose());

            Minutes = new Dictionary<int, BountyRuneGoldMinutes>();
        }

        protected virtual void OnGoldChanged()
        {
            GoldChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
