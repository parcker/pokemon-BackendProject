using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Pokemon.Model
{
   
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class Ability
    {
        [JsonPropertyName("is_hidden")]
        public bool IsHidden { get; set; }

        [JsonPropertyName("slot")]
        public int Slot { get; set; }

        [JsonPropertyName("ability")]
        public Ability Ability_ { get; set; }
    }

    public class Ability2
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class Animated
    {
        [JsonPropertyName("back_default")]
        public string BackDefault { get; set; }

        [JsonPropertyName("back_female")]
        public object BackFemale { get; set; }

        [JsonPropertyName("back_shiny")]
        public string BackShiny { get; set; }

        [JsonPropertyName("back_shiny_female")]
        public object BackShinyFemale { get; set; }

        [JsonPropertyName("front_default")]
        public string FrontDefault { get; set; }

        [JsonPropertyName("front_female")]
        public object FrontFemale { get; set; }

        [JsonPropertyName("front_shiny")]
        public string FrontShiny { get; set; }

        [JsonPropertyName("front_shiny_female")]
        public object FrontShinyFemale { get; set; }
    }

    public class BlackWhite
    {
        [JsonPropertyName("animated")]
        public Animated Animated { get; set; }

        [JsonPropertyName("back_default")]
        public string BackDefault { get; set; }

        [JsonPropertyName("back_female")]
        public object BackFemale { get; set; }

        [JsonPropertyName("back_shiny")]
        public string BackShiny { get; set; }

        [JsonPropertyName("back_shiny_female")]
        public object BackShinyFemale { get; set; }

        [JsonPropertyName("front_default")]
        public string FrontDefault { get; set; }

        [JsonPropertyName("front_female")]
        public object FrontFemale { get; set; }

        [JsonPropertyName("front_shiny")]
        public string FrontShiny { get; set; }

        [JsonPropertyName("front_shiny_female")]
        public object FrontShinyFemale { get; set; }
    }

    public class Crystal
    {
        [JsonPropertyName("back_default")]
        public string BackDefault { get; set; }

        [JsonPropertyName("back_shiny")]
        public string BackShiny { get; set; }

        [JsonPropertyName("front_default")]
        public string FrontDefault { get; set; }

        [JsonPropertyName("front_shiny")]
        public string FrontShiny { get; set; }
    }

    public class DiamondPearl
    {
        [JsonPropertyName("back_default")]
        public string BackDefault { get; set; }

        [JsonPropertyName("back_female")]
        public object BackFemale { get; set; }

        [JsonPropertyName("back_shiny")]
        public string BackShiny { get; set; }

        [JsonPropertyName("back_shiny_female")]
        public object BackShinyFemale { get; set; }

        [JsonPropertyName("front_default")]
        public string FrontDefault { get; set; }

        [JsonPropertyName("front_female")]
        public object FrontFemale { get; set; }

        [JsonPropertyName("front_shiny")]
        public string FrontShiny { get; set; }

        [JsonPropertyName("front_shiny_female")]
        public object FrontShinyFemale { get; set; }
    }

    public class DreamWorld
    {
        [JsonPropertyName("front_default")]
        public string FrontDefault { get; set; }

        [JsonPropertyName("front_female")]
        public object FrontFemale { get; set; }
    }

    public class Emerald
    {
        [JsonPropertyName("front_default")]
        public string FrontDefault { get; set; }

        [JsonPropertyName("front_shiny")]
        public string FrontShiny { get; set; }
    }

    public class FireredLeafgreen
    {
        [JsonPropertyName("back_default")]
        public string BackDefault { get; set; }

        [JsonPropertyName("back_shiny")]
        public string BackShiny { get; set; }

        [JsonPropertyName("front_default")]
        public string FrontDefault { get; set; }

        [JsonPropertyName("front_shiny")]
        public string FrontShiny { get; set; }
    }

    public class Form
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class GameIndex
    {
        [JsonPropertyName("game_index")]
        public int GameIndex_ { get; set; }

        [JsonPropertyName("version")]
        public Version Version { get; set; }
    }

    public class Generation
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class GenerationI
    {
        [JsonPropertyName("red-blue")]
        public RedBlue RedBlue { get; set; }

        [JsonPropertyName("yellow")]
        public Yellow Yellow { get; set; }
    }

    public class GenerationIi
    {
        [JsonPropertyName("crystal")]
        public Crystal Crystal { get; set; }

        [JsonPropertyName("gold")]
        public Gold Gold { get; set; }

        [JsonPropertyName("silver")]
        public Silver Silver { get; set; }
    }

    public class GenerationIii
    {
        [JsonPropertyName("emerald")]
        public Emerald Emerald { get; set; }

        [JsonPropertyName("firered-leafgreen")]
        public FireredLeafgreen FireredLeafgreen { get; set; }

        [JsonPropertyName("ruby-sapphire")]
        public RubySapphire RubySapphire { get; set; }
    }

    public class GenerationIv
    {
        [JsonPropertyName("diamond-pearl")]
        public DiamondPearl DiamondPearl { get; set; }

        [JsonPropertyName("heartgold-soulsilver")]
        public HeartgoldSoulsilver HeartgoldSoulsilver { get; set; }

        [JsonPropertyName("platinum")]
        public Platinum Platinum { get; set; }
    }

    public class GenerationV
    {
        [JsonPropertyName("black-white")]
        public BlackWhite BlackWhite { get; set; }
    }

    public class GenerationVi
    {
        [JsonPropertyName("omegaruby-alphasapphire")]
        public OmegarubyAlphasapphire OmegarubyAlphasapphire { get; set; }

        [JsonPropertyName("x-y")]
        public XY XY { get; set; }
    }

    public class GenerationVii
    {
        [JsonPropertyName("icons")]
        public Icons Icons { get; set; }

        [JsonPropertyName("ultra-sun-ultra-moon")]
        public UltraSunUltraMoon UltraSunUltraMoon { get; set; }
    }

    public class GenerationViii
    {
        [JsonPropertyName("icons")]
        public Icons Icons { get; set; }
    }

    public class Gold
    {
        [JsonPropertyName("back_default")]
        public string BackDefault { get; set; }

        [JsonPropertyName("back_shiny")]
        public string BackShiny { get; set; }

        [JsonPropertyName("front_default")]
        public string FrontDefault { get; set; }

        [JsonPropertyName("front_shiny")]
        public string FrontShiny { get; set; }
    }

    public class HeartgoldSoulsilver
    {
        [JsonPropertyName("back_default")]
        public string BackDefault { get; set; }

        [JsonPropertyName("back_female")]
        public object BackFemale { get; set; }

        [JsonPropertyName("back_shiny")]
        public string BackShiny { get; set; }

        [JsonPropertyName("back_shiny_female")]
        public object BackShinyFemale { get; set; }

        [JsonPropertyName("front_default")]
        public string FrontDefault { get; set; }

        [JsonPropertyName("front_female")]
        public object FrontFemale { get; set; }

        [JsonPropertyName("front_shiny")]
        public string FrontShiny { get; set; }

        [JsonPropertyName("front_shiny_female")]
        public object FrontShinyFemale { get; set; }
    }

    public class HeldItem
    {
        [JsonPropertyName("item")]
        public Item Item { get; set; }

        [JsonPropertyName("version_details")]
        public IEnumerable<VersionDetail> VersionDetails { get; set; }
    }

    public class Home
    {
        [JsonPropertyName("front_default")]
        public string FrontDefault { get; set; }

        [JsonPropertyName("front_female")]
        public object FrontFemale { get; set; }

        [JsonPropertyName("front_shiny")]
        public string FrontShiny { get; set; }

        [JsonPropertyName("front_shiny_female")]
        public object FrontShinyFemale { get; set; }
    }

    public class Icons
    {
        [JsonPropertyName("front_default")]
        public string FrontDefault { get; set; }

        [JsonPropertyName("front_female")]
        public object FrontFemale { get; set; }
    }

    public class Item
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class Move
    {
        [JsonPropertyName("move")]
        public Move Move_ { get; set; }

        [JsonPropertyName("version_group_details")]
        public IEnumerable<VersionGroupDetail> VersionGroupDetails { get; set; }
    }

    public class Move2
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class MoveLearnMethod
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class OfficialArtwork
    {
        [JsonPropertyName("front_default")]
        public string FrontDefault { get; set; }
    }

    public class OmegarubyAlphasapphire
    {
        [JsonPropertyName("front_default")]
        public string FrontDefault { get; set; }

        [JsonPropertyName("front_female")]
        public object FrontFemale { get; set; }

        [JsonPropertyName("front_shiny")]
        public string FrontShiny { get; set; }

        [JsonPropertyName("front_shiny_female")]
        public object FrontShinyFemale { get; set; }
    }

    public class Other
    {
        [JsonPropertyName("dream_world")]
        public DreamWorld DreamWorld { get; set; }

        [JsonPropertyName("home")]
        public Home Home { get; set; }

        [JsonPropertyName("official-artwork")]
        public OfficialArtwork OfficialArtwork { get; set; }
    }

    public class PastType
    {
        [JsonPropertyName("generation")]
        public Generation Generation { get; set; }

        [JsonPropertyName("types")]
        public IEnumerable<Type> Types { get; set; }
    }

    public class Platinum
    {
        [JsonPropertyName("back_default")]
        public string BackDefault { get; set; }

        [JsonPropertyName("back_female")]
        public object BackFemale { get; set; }

        [JsonPropertyName("back_shiny")]
        public string BackShiny { get; set; }

        [JsonPropertyName("back_shiny_female")]
        public object BackShinyFemale { get; set; }

        [JsonPropertyName("front_default")]
        public string FrontDefault { get; set; }

        [JsonPropertyName("front_female")]
        public object FrontFemale { get; set; }

        [JsonPropertyName("front_shiny")]
        public string FrontShiny { get; set; }

        [JsonPropertyName("front_shiny_female")]
        public object FrontShinyFemale { get; set; }
    }

    public class RedBlue
    {
        [JsonPropertyName("back_default")]
        public string BackDefault { get; set; }

        [JsonPropertyName("back_gray")]
        public string BackGray { get; set; }

        [JsonPropertyName("front_default")]
        public string FrontDefault { get; set; }

        [JsonPropertyName("front_gray")]
        public string FrontGray { get; set; }
    }

    public class PokeApiBaseResponseObject
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("base_experience")]
        public int BaseExperience { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("is_default")]
        public bool IsDefault { get; set; }

        [JsonPropertyName("order")]
        public int Order { get; set; }

        [JsonPropertyName("weight")]
        public int Weight { get; set; }

        [JsonPropertyName("abilities")]
        public IEnumerable<Ability> Abilities { get; set; }

        [JsonPropertyName("forms")]
        public IEnumerable<Form> Forms { get; set; }

        [JsonPropertyName("game_indices")]
        public IEnumerable<GameIndex> GameIndices { get; set; }

        [JsonPropertyName("held_items")]
        public IEnumerable<HeldItem> HeldItems { get; set; }

        [JsonPropertyName("location_area_encounters")]
        public string LocationAreaEncounters { get; set; }

        [JsonPropertyName("moves")]
        public IEnumerable<Move> Moves { get; set; }

        [JsonPropertyName("species")]
        public Species Species { get; set; }

        [JsonPropertyName("sprites")]
        public Sprites Sprites { get; set; }

        [JsonPropertyName("stats")]
        public IEnumerable<Stat> Stats { get; set; }

        [JsonPropertyName("types")]
        public IEnumerable<Type> Types { get; set; }

        [JsonPropertyName("past_types")]
        public IEnumerable<PastType> PastTypes { get; set; }
    }

    public class RubySapphire
    {
        [JsonPropertyName("back_default")]
        public string BackDefault { get; set; }

        [JsonPropertyName("back_shiny")]
        public string BackShiny { get; set; }

        [JsonPropertyName("front_default")]
        public string FrontDefault { get; set; }

        [JsonPropertyName("front_shiny")]
        public string FrontShiny { get; set; }
    }

    public class Silver
    {
        [JsonPropertyName("back_default")]
        public string BackDefault { get; set; }

        [JsonPropertyName("back_shiny")]
        public string BackShiny { get; set; }

        [JsonPropertyName("front_default")]
        public string FrontDefault { get; set; }

        [JsonPropertyName("front_shiny")]
        public string FrontShiny { get; set; }
    }

    public class Species
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class Sprites
    {
        [JsonPropertyName("back_default")]
        public string BackDefault { get; set; }

        [JsonPropertyName("back_female")]
        public object BackFemale { get; set; }

        [JsonPropertyName("back_shiny")]
        public string BackShiny { get; set; }

        [JsonPropertyName("back_shiny_female")]
        public object BackShinyFemale { get; set; }

        [JsonPropertyName("front_default")]
        public string FrontDefault { get; set; }

        [JsonPropertyName("front_female")]
        public object FrontFemale { get; set; }

        [JsonPropertyName("front_shiny")]
        public string FrontShiny { get; set; }

        [JsonPropertyName("front_shiny_female")]
        public object FrontShinyFemale { get; set; }

        [JsonPropertyName("other")]
        public Other Other { get; set; }

        [JsonPropertyName("versions")]
        public Versions Versions { get; set; }
    }

    public class Stat
    {
        [JsonPropertyName("base_stat")]
        public int BaseStat { get; set; }

        [JsonPropertyName("effort")]
        public int Effort { get; set; }

        [JsonPropertyName("stat")]
        public Stat Stat_ { get; set; }
    }

    public class Stat2
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class Type
    {
        [JsonPropertyName("slot")]
        public int Slot { get; set; }

        [JsonPropertyName("type")]
        public Type Type_ { get; set; }
    }

    public class Type2
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class UltraSunUltraMoon
    {
        [JsonPropertyName("front_default")]
        public string FrontDefault { get; set; }

        [JsonPropertyName("front_female")]
        public object FrontFemale { get; set; }

        [JsonPropertyName("front_shiny")]
        public string FrontShiny { get; set; }

        [JsonPropertyName("front_shiny_female")]
        public object FrontShinyFemale { get; set; }
    }

    public class Version
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class VersionDetail
    {
        [JsonPropertyName("rarity")]
        public int Rarity { get; set; }

        [JsonPropertyName("version")]
        public Version Version { get; set; }
    }

    public class VersionGroup
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class VersionGroupDetail
    {
        [JsonPropertyName("level_learned_at")]
        public int LevelLearnedAt { get; set; }

        [JsonPropertyName("version_group")]
        public VersionGroup VersionGroup { get; set; }

        [JsonPropertyName("move_learn_method")]
        public MoveLearnMethod MoveLearnMethod { get; set; }
    }

    public class Versions
    {
        [JsonPropertyName("generation-i")]
        public GenerationI GenerationI { get; set; }

        [JsonPropertyName("generation-ii")]
        public GenerationIi GenerationIi { get; set; }

        [JsonPropertyName("generation-iii")]
        public GenerationIii GenerationIii { get; set; }

        [JsonPropertyName("generation-iv")]
        public GenerationIv GenerationIv { get; set; }

        [JsonPropertyName("generation-v")]
        public GenerationV GenerationV { get; set; }

        [JsonPropertyName("generation-vi")]
        public GenerationVi GenerationVi { get; set; }

        [JsonPropertyName("generation-vii")]
        public GenerationVii GenerationVii { get; set; }

        [JsonPropertyName("generation-viii")]
        public GenerationViii GenerationViii { get; set; }
    }

    public class XY
    {
        [JsonPropertyName("front_default")]
        public string FrontDefault { get; set; }

        [JsonPropertyName("front_female")]
        public object FrontFemale { get; set; }

        [JsonPropertyName("front_shiny")]
        public string FrontShiny { get; set; }

        [JsonPropertyName("front_shiny_female")]
        public object FrontShinyFemale { get; set; }
    }

    public class Yellow
    {
        [JsonPropertyName("back_default")]
        public string BackDefault { get; set; }

        [JsonPropertyName("back_gray")]
        public string BackGray { get; set; }

        [JsonPropertyName("front_default")]
        public string FrontDefault { get; set; }

        [JsonPropertyName("front_gray")]
        public string FrontGray { get; set; }
    }


}
