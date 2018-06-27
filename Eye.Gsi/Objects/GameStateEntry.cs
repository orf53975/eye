// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using Eye.Objects;
//
//    var gsi = GameStateEntry.FromJson(jsonString);

using System.Collections.Generic;
using System.Linq;
using Eye.Shared;
using Newtonsoft.Json;

namespace Eye.Gsi.Objects
{
    public partial class GameStateEntry : IDataEntry
    {
        [JsonProperty("buildings")]
        public Buildings Buildings { get; set; }

        [JsonProperty("provider")]
        public Provider Provider { get; set; }

        [JsonProperty("map")]
        public Map Map { get; set; }

        [JsonProperty("player")]
        public Players Players { get; set; }

        [JsonProperty("hero")]
        public Heroes Heroes { get; set; }

        [JsonProperty("abilities")]
        public Abilities Abilities { get; set; }

        [JsonProperty("items")]
        public Items Items { get; set; }

        [JsonProperty("auth")]
        public Auth Auth { get; set; }

        [JsonProperty("draft")]
        public Draft Draft { get; set; }
        
        [JsonProperty("previously")]
        public GameStateEntry Previously { get; set; } // TODO: Придумать способ использовать данные о изменении
        
        [JsonProperty("added")]
        public dynamic Added { get; set; } // TODO: Придумать способ использовать данные о изменении
    }

    public class Buildings
    {
        public class Building
        {
            [JsonProperty("health")]
            public int Health { get; set; }

            [JsonProperty("max_health")]
            public int MaxHealth { get; set; }
        }

        public class RadiantBuildings
        {
            #region Radiant Top

            [JsonProperty("dota_goodguys_tower1_top")]
            public Building Tower1Top { get; set; }

            [JsonProperty("dota_goodguys_tower2_top")]
            public Building Tower2Top { get; set; }

            [JsonProperty("dota_goodguys_tower3_top")]
            public Building Tower3Top { get; set; }

            [JsonProperty("good_rax_melee_top")]
            public Building RaxMeleeTop { get; set; }

            [JsonProperty("good_rax_range_top")]
            public Building RaxRangeTop { get; set; }

            #endregion

            #region Radiant Mid

            [JsonProperty("dota_goodguys_tower1_mid")]
            public Building Tower1Mid { get; set; }

            [JsonProperty("dota_goodguys_tower2_mid")]
            public Building Tower2Mid { get; set; }

            [JsonProperty("dota_goodguys_tower3_mid")]
            public Building Tower3Mid { get; set; }

            [JsonProperty("good_rax_melee_mid")]
            public Building RaxMeleeMid { get; set; }

            [JsonProperty("good_rax_range_mid")]
            public Building RaxRangeMid { get; set; }

            #endregion

            #region Radiant Bot

            [JsonProperty("dota_goodguys_tower1_bot")]
            public Building Tower1Bot { get; set; }

            [JsonProperty("dota_goodguys_tower2_bot")]
            public Building Tower2Bot { get; set; }

            [JsonProperty("dota_goodguys_tower3_bot")]
            public Building Tower3Bot { get; set; }

            [JsonProperty("good_rax_melee_bot")]
            public Building RaxMeleeBot { get; set; }

            [JsonProperty("good_rax_range_bot")]
            public Building RaxRangeBot { get; set; }

            #endregion

            #region Radiant Fort

            [JsonProperty("dota_goodguys_tower4_top")]
            public Building Tower4Top { get; set; }

            [JsonProperty("dota_goodguys_tower4_bot")]
            public Building Tower4Bot { get; set; }

            [JsonProperty("dota_goodguys_fort")]
            public Building Ancient { get; set; }

            #endregion
        }

        public class DireBuildings
        {
            #region Dire Top

            [JsonProperty("dota_badguys_tower1_top")]
            public Building Tower1Top { get; set; }

            [JsonProperty("dota_badguys_tower2_top")]
            public Building Tower2Top { get; set; }

            [JsonProperty("dota_badguys_tower3_top")]
            public Building Tower3Top { get; set; }

            [JsonProperty("good_rax_melee_top")]
            public Building RaxMeleeTop { get; set; }

            [JsonProperty("good_rax_range_top")]
            public Building RaxRangeTop { get; set; }

            #endregion

            #region Dire Mid

            [JsonProperty("dota_badguys_tower1_mid")]
            public Building Tower1Mid { get; set; }

            [JsonProperty("dota_badguys_tower2_mid")]
            public Building Tower2Mid { get; set; }

            [JsonProperty("dota_badguys_tower3_mid")]
            public Building Tower3Mid { get; set; }

            [JsonProperty("good_rax_melee_mid")]
            public Building RaxMeleeMid { get; set; }

            [JsonProperty("good_rax_range_mid")]
            public Building RaxRangeMid { get; set; }

            #endregion

            #region Dire Bot

            [JsonProperty("dota_badguys_tower1_bot")]
            public Building Tower1Bot { get; set; }

            [JsonProperty("dota_badguys_tower2_bot")]
            public Building Tower2Bot { get; set; }

            [JsonProperty("dota_badguys_tower3_bot")]
            public Building Tower3Bot { get; set; }

            [JsonProperty("good_rax_melee_bot")]
            public Building RaxMeleeBot { get; set; }

            [JsonProperty("good_rax_range_bot")]
            public Building RaxRangeBot { get; set; }

            #endregion

            #region Dire Fort

            [JsonProperty("dota_badguys_tower4_top")]
            public Building Tower4Top { get; set; }

            [JsonProperty("dota_badguys_tower4_bot")]
            public Building Tower4Bot { get; set; }

            [JsonProperty("dota_badguys_fort")]
            public Building Ancient { get; set; }

            #endregion
        }

        [JsonProperty("radiant")]
        public RadiantBuildings Radiant { get; set; }

        [JsonProperty("dire")]
        public DireBuildings Dire { get; set; }
    }

    public class Provider
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("appid")]
        public int AppId { get; set; }

        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
    }

    public class Map
    {
        public enum GameState
        {
            DOTA_GAMERULES_STATE_INIT = 0,
            DOTA_GAMERULES_STATE_WAIT_FOR_PLAYERS_TO_LOAD = 1,
            DOTA_GAMERULES_STATE_HERO_SELECTION = 2,
            DOTA_GAMERULES_STATE_STRATEGY_TIME = 3,
            DOTA_GAMERULES_STATE_PRE_GAME = 4,
            DOTA_GAMERULES_STATE_GAME_IN_PROGRESS = 5,
            DOTA_GAMERULES_STATE_POST_GAME = 6,
            DOTA_GAMERULES_STATE_DISCONNECT = 7,
            DOTA_GAMERULES_STATE_TEAM_SHOWCASE = 8,
            DOTA_GAMERULES_STATE_CUSTOM_GAME_SETUP = 9,
            DOTA_GAMERULES_STATE_WAIT_FOR_MAP_TO_LOAD = 10,
            DOTA_GAMERULES_STATE_LAST = 11
        }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("matchid")]
        public long Matchid { get; set; }

        [JsonProperty("game_time")]
        public int GameTime { get; set; }

        [JsonProperty("clock_time")]
        public int ClockTime { get; set; }

        [JsonProperty("daytime")]
        public bool Daytime { get; set; }

        [JsonProperty("nightstalker_night")]
        public bool NightstalkerNight { get; set; }

        [JsonProperty("game_state")]
        public GameState State { get; set; }

        [JsonProperty("paused")]
        public bool Paused { get; set; }

        [JsonProperty("win_team")]
        public string WinTeam { get; set; }

        [JsonProperty("customgamename")]
        public string Customgamename { get; set; }

        [JsonProperty("radiant_ward_purchase_cooldown")]
        public int RadiantWardPurchaseCooldown { get; set; }

        [JsonProperty("dire_ward_purchase_cooldown")]
        public int DireWardPurchaseCooldown { get; set; }

        [JsonProperty("roshan_state")]
        public string RoshanState { get; set; }

        [JsonProperty("roshan_state_end_seconds")]
        public int RoshanStateEndSeconds { get; set; }
    }

    public class Players
    {
        public class KillList
        {
            [JsonProperty("victimid_0")]
            public int KillsSlot0 { get; set; }

            [JsonProperty("victimid_1")]
            public int KillsSlot1 { get; set; }

            [JsonProperty("victimid_2")]
            public int KillsSlot2 { get; set; }

            [JsonProperty("victimid_3")]
            public int KillsSlot3 { get; set; }

            [JsonProperty("victimid_4")]
            public int KillsSlot4 { get; set; }

            [JsonProperty("victimid_5")]
            public int KillsSlot5 { get; set; }

            [JsonProperty("victimid_6")]
            public int KillsSlot6 { get; set; }

            [JsonProperty("victimid_7")]
            public int KillsSlot7 { get; set; }

            [JsonProperty("victimid_8")]
            public int KillsSlot8 { get; set; }

            [JsonProperty("victimid_9")]
            public int KillsSlot9 { get; set; }
        }

        public class Player
        {
            [JsonProperty("steamid")]
            public string SteamId { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("activity")]
            public string Activity { get; set; }

            [JsonProperty("kills")]
            public int Kills { get; set; }

            [JsonProperty("deaths")]
            public int Deaths { get; set; }

            [JsonProperty("assists")]
            public int Assists { get; set; }

            [JsonProperty("last_hits")]
            public int LastHits { get; set; }

            [JsonProperty("denies")]
            public int Denies { get; set; }

            [JsonProperty("kill_streak")]
            public int KillStreak { get; set; }

            [JsonProperty("kill_list")]
            public KillList KillList { get; set; }

            [JsonProperty("team_name")]
            public string TeamName { get; set; }

            [JsonProperty("gold")]
            public int Gold { get; set; }

            [JsonProperty("gold_reliable")]
            public int GoldReliable { get; set; }

            [JsonProperty("gold_unreliable")]
            public int GoldUnreliable { get; set; }

            [JsonProperty("gpm")]
            public int GPM { get; set; }

            [JsonProperty("xpm")]
            public int XPM { get; set; }

            [JsonProperty("net_worth")]
            public int NetWorth { get; set; }

            [JsonProperty("hero_damage")]
            public int HeroDamage { get; set; }

            [JsonProperty("support_gold_spent")]
            public int SupportGoldSpent { get; set; }

            [JsonProperty("wards_purchased")]
            public int WardsPurchased { get; set; }

            [JsonProperty("wards_placed")]
            public int WardsPlaced { get; set; }

            [JsonProperty("wards_destroyed")]
            public int WardsDestroyed { get; set; }

            [JsonProperty("runes_activated")]
            public int RunesActivated { get; set; }

            [JsonProperty("camps_stacked")]
            public int CampsStacked { get; set; }
        }

        public class RadiantPlayers
        {
            [JsonProperty("player0")]
            public Player Slot0 { get; set; }

            [JsonProperty("player1")]
            public Player Slot1 { get; set; }

            [JsonProperty("player2")]
            public Player Slot2 { get; set; }

            [JsonProperty("player3")]
            public Player Slot3 { get; set; }

            [JsonProperty("player4")]
            public Player Slot4 { get; set; }
        }

        public class DirePlayers
        {
            [JsonProperty("player5")]
            public Player Slot5 { get; set; }

            [JsonProperty("player6")]
            public Player Slot6 { get; set; }

            [JsonProperty("player7")]
            public Player Slot7 { get; set; }

            [JsonProperty("player8")]
            public Player Slot8 { get; set; }

            [JsonProperty("player9")]
            public Player Slot9 { get; set; }
        }

        [JsonProperty("team2")]
        public RadiantPlayers Radiant { get; set; }

        [JsonProperty("team3")]
        public DirePlayers Dire { get; set; }
    }

    public class Heroes
    {
        public class Hero
        {
            [JsonProperty("xpos")]
            public long X { get; set; }

            [JsonProperty("ypos")]
            public long Y { get; set; }

            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("level")]
            public int Level { get; set; }

            [JsonProperty("alive")]
            public bool Alive { get; set; }

            [JsonProperty("respawn_seconds")]
            public int RespawnSeconds { get; set; }

            [JsonProperty("buyback_cost")]
            public int BuybackCost { get; set; }

            [JsonProperty("buyback_cooldown")]
            public int BuybackCooldown { get; set; }

            [JsonProperty("health")]
            public int Health { get; set; }

            [JsonProperty("max_health")]
            public int MaxHealth { get; set; }

            [JsonProperty("health_percent")]
            public int HealthPercent { get; set; }

            [JsonProperty("mana")]
            public int Mana { get; set; }

            [JsonProperty("max_mana")]
            public int MaxMana { get; set; }

            [JsonProperty("mana_percent")]
            public int ManaPercent { get; set; }

            [JsonProperty("silenced")]
            public bool Silenced { get; set; }

            [JsonProperty("stunned")]
            public bool Stunned { get; set; }

            [JsonProperty("disarmed")]
            public bool Disarmed { get; set; }

            [JsonProperty("magicimmune")]
            public bool Magicimmune { get; set; }

            [JsonProperty("hexed")]
            public bool Hexed { get; set; }

            [JsonProperty("muted")]
            public bool Muted { get; set; }

            [JsonProperty("break")]
            public bool Break { get; set; }

            [JsonProperty("has_debuff")]
            public bool HasDebuff { get; set; }

            [JsonProperty("selected_unit")]
            public bool SelectedUnit { get; set; }

            [JsonProperty("talent_1")]
            public bool Talent1 { get; set; }

            [JsonProperty("talent_2")]
            public bool Talent2 { get; set; }

            [JsonProperty("talent_3")]
            public bool Talent3 { get; set; }

            [JsonProperty("talent_4")]
            public bool Talent4 { get; set; }

            [JsonProperty("talent_5")]
            public bool Talent5 { get; set; }

            [JsonProperty("talent_6")]
            public bool Talent6 { get; set; }

            [JsonProperty("talent_7")]
            public bool Talent7 { get; set; }

            [JsonProperty("talent_8")]
            public bool Talent8 { get; set; }
        }

        public class RadiantHeroes
        {
            [JsonProperty("player0")]
            public Hero Slot0 { get; set; }

            [JsonProperty("player1")]
            public Hero Slot1 { get; set; }

            [JsonProperty("player2")]
            public Hero Slot2 { get; set; }

            [JsonProperty("player3")]
            public Hero Slot3 { get; set; }

            [JsonProperty("player4")]
            public Hero Slot4 { get; set; }
        }

        public class DireHeroes
        {
            [JsonProperty("player5")]
            public Hero Slot5 { get; set; }

            [JsonProperty("player6")]
            public Hero Slot6 { get; set; }

            [JsonProperty("player7")]
            public Hero Slot7 { get; set; }

            [JsonProperty("player8")]
            public Hero Slot8 { get; set; }

            [JsonProperty("player9")]
            public Hero Slot9 { get; set; }
        }

        [JsonProperty("team2")]
        public RadiantHeroes Radiant { get; set; }

        [JsonProperty("team3")]
        public DireHeroes Dire { get; set; }
    }

    public class Abilities
    {
        public class Ability
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("level")]
            public long Level { get; set; }

            [JsonProperty("can_cast")]
            public bool CanCast { get; set; }

            [JsonProperty("passive")]
            public bool Passive { get; set; }

            [JsonProperty("ability_active")]
            public bool AbilityActive { get; set; }

            [JsonProperty("cooldown")]
            public long Cooldown { get; set; }

            [JsonProperty("ultimate")]
            public bool Ultimate { get; set; }
        }

        public class HeroAbilities
        {
            public IReadOnlyList<Ability> Abilities => new List<Ability> {
                Ability0, Ability1, Ability2, Ability3, Ability4, Ability5
            }.Where(a => a != null).ToList();

            public Ability Ability0 { get; set; }


            public Ability Ability1 { get; set; }


            public Ability Ability2 { get; set; }


            public Ability Ability3 { get; set; }


            public Ability Ability4 { get; set; }


            public Ability Ability5 { get; set; }
        }

        public class RadiantHeroesAbilities
        {
            [JsonProperty("player0")]
            public HeroAbilities Hero0 { get; set; }

            [JsonProperty("player1")]
            public HeroAbilities Hero1 { get; set; }

            [JsonProperty("player2")]
            public HeroAbilities Hero2 { get; set; }

            [JsonProperty("player3")]
            public HeroAbilities Hero3 { get; set; }

            [JsonProperty("player4")]
            public HeroAbilities Hero4 { get; set; }
        }

        public class DireHeroesAbilities
        {
            [JsonProperty("player5")]
            public HeroAbilities Hero5 { get; set; }

            [JsonProperty("player6")]
            public HeroAbilities Hero6 { get; set; }

            [JsonProperty("player7")]
            public HeroAbilities Hero7 { get; set; }

            [JsonProperty("player8")]
            public HeroAbilities Hero8 { get; set; }

            [JsonProperty("player9")]
            public HeroAbilities Hero9 { get; set; }
        }

        [JsonProperty("team2")]
        public RadiantHeroesAbilities Radiant { get; set; }

        [JsonProperty("team3")]
        public DireHeroesAbilities Dire { get; set; }
    }

    public partial class Items
    {
        public interface IActiveItem
        {
            [JsonProperty("can_cast")]
            bool CanCast { get; set; }
        }

        public interface ICooldownableItem
        {
            [JsonProperty("cooldown")]
            int Cooldown { get; set; }
        }

        public interface IChargeableItem
        {
            [JsonProperty("charges")]
            int Charges { get; set; }
        }

        public class Item: IActiveItem, ICooldownableItem, IChargeableItem
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("purchaser")]
            public int Purchaser { get; set; }

            [JsonProperty("passive")]
            public bool Passive { get; set; }

            public bool CanCast { get; set; }
            public int Cooldown { get; set; }
            public int Charges { get; set; }

            public int Slot { get; set; }
        }

        public class HeroItems
        {
            public IReadOnlyList<Item> Slots => new[] {
                Slot0, Slot1, Slot2, Slot3, Slot4, Slot5,
                Backpack0, Backpack1, Backpack2,
                Stash0, Stash1, Stash2, Stash3, Stash4, Stash5
            }.Where(i => i != null).ToArray();

            #region Slots

            [JsonProperty("slot0")]
            public Item Slot0 { get; set; }

            [JsonProperty("slot1")]
            public Item Slot1 { get; set; }

            [JsonProperty("slot2")]
            public Item Slot2 { get; set; }

            [JsonProperty("slot3")]
            public Item Slot3 { get; set; }

            [JsonProperty("slot4")]
            public Item Slot4 { get; set; }

            [JsonProperty("slot5")]
            public Item Slot5 { get; set; }

            #endregion

            #region Backpack

            [JsonProperty("slot6")]
            public Item Backpack0 { get; set; }

            [JsonProperty("slot7")]
            public Item Backpack1 { get; set; }

            [JsonProperty("slot8")]
            public Item Backpack2 { get; set; }

            #endregion

            #region Stash

            [JsonProperty("stash0")]
            public Item Stash0 { get; set; }

            [JsonProperty("stash1")]
            public Item Stash1 { get; set; }

            [JsonProperty("stash2")]
            public Item Stash2 { get; set; }

            [JsonProperty("stash3")]
            public Item Stash3 { get; set; }

            [JsonProperty("stash4")]
            public Item Stash4 { get; set; }

            [JsonProperty("stash5")]
            public Item Stash5 { get; set; }

            #endregion
        }

        public class RadiantHeroesItems
        {
            [JsonProperty("player0")]
            public HeroItems Hero0 { get; set; }

            [JsonProperty("player1")]
            public HeroItems Hero1 { get; set; }

            [JsonProperty("player2")]
            public HeroItems Hero2 { get; set; }

            [JsonProperty("player3")]
            public HeroItems Hero3 { get; set; }

            [JsonProperty("player4")]
            public HeroItems Hero4 { get; set; }
        }

        public class DireHeroesItems
        {
            [JsonProperty("player5")]
            public HeroItems Hero5 { get; set; }

            [JsonProperty("player6")]
            public HeroItems Hero6 { get; set; }

            [JsonProperty("player7")]
            public HeroItems Hero7 { get; set; }

            [JsonProperty("player8")]
            public HeroItems Hero8 { get; set; }

            [JsonProperty("player9")]
            public HeroItems Hero9 { get; set; }
        }

        [JsonProperty("team2")]
        public RadiantHeroesItems Radiant { get; set; }

        [JsonProperty("team3")]
        public DireHeroesItems Dire { get; set; }
    }

    public class Draft
    {
        public class Team
        {
            [JsonProperty("pick0_id")]
            public long Pick0Id { get; set; }

            [JsonProperty("pick0_class")]
            public string Pick0Class { get; set; }

            [JsonProperty("pick1_id")]
            public long Pick1Id { get; set; }

            [JsonProperty("pick1_class")]
            public string Pick1Class { get; set; }

            [JsonProperty("pick2_id")]
            public long Pick2Id { get; set; }

            [JsonProperty("pick2_class")]
            public string Pick2Class { get; set; }

            [JsonProperty("pick3_id")]
            public long Pick3Id { get; set; }

            [JsonProperty("pick3_class")]
            public string Pick3Class { get; set; }

            [JsonProperty("pick4_id")]
            public long Pick4Id { get; set; }

            [JsonProperty("pick4_class")]
            public string Pick4Class { get; set; }

            [JsonProperty("ban0_id")]
            public long Ban0Id { get; set; }

            [JsonProperty("ban0_class")]
            public string Ban0Class { get; set; }

            [JsonProperty("ban1_id")]
            public long Ban1Id { get; set; }

            [JsonProperty("ban1_class")]
            public string Ban1Class { get; set; }

            [JsonProperty("ban2_id")]
            public long Ban2Id { get; set; }

            [JsonProperty("ban2_class")]
            public string Ban2Class { get; set; }

            [JsonProperty("ban3_id")]
            public long Ban3Id { get; set; }

            [JsonProperty("ban3_class")]
            public string Ban3Class { get; set; }

            [JsonProperty("ban4_id")]
            public long Ban4Id { get; set; }

            [JsonProperty("ban4_class")]
            public string Ban4Class { get; set; }

            [JsonProperty("ban5_id")]
            public long Ban5Id { get; set; }

            [JsonProperty("ban5_class")]
            public string Ban5Class { get; set; }
        }

        [JsonProperty("activeteam")]
        public long ActiveTeam { get; set; }

        [JsonProperty("pick")]
        public bool Pick { get; set; }

        [JsonProperty("activeteam_time_remaining")]
        public long ActiveTeamTimeRemaining { get; set; }

        [JsonProperty("radiant_bonus_time")]
        public long RadiantBonusTime { get; set; }

        [JsonProperty("dire_bonus_time")]
        public long DireBonusTime { get; set; }

        [JsonProperty("team2")]
        public Team RadiantTeam { get; set; }

        [JsonProperty("team3")]
        public Team DireTeam { get; set; }
    }

    public class Auth
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}