using perpusku_api.Common;
using perpusku_api.Common.Classes;
using System;
using System.Reflection;

namespace perpusku_api.Model.Enum.MasterData
{
    public enum BookGenre
    {
        [StringValue("Fantasy")] Fantasy = 1,
        [StringValue("High Fantasy")] HighFantasy,
        [StringValue("Urban Fantasy")] UrbanFantasy,
        [StringValue("Dark Fantasy")] DarkFantasy,
        [StringValue("Science Fiction")] ScienceFiction,
        [StringValue("Hard Science Fiction")] HardScienceFiction,
        [StringValue("Space Opera")] SpaceOpera,
        [StringValue("Cyberpunk")] Cyberpunk,
        [StringValue("Mystery")] Mystery,
        [StringValue("Cozy Mystery")] CozyMystery,
        [StringValue("Thriller")] Thriller,
        [StringValue("Crime")] Crime,
        [StringValue("Romance")] Romance,
        [StringValue("Contemporary Romance")] ContemporaryRomance,
        [StringValue("Historical Romance")] HistoricalRomance,
        [StringValue("Paranormal Romance")] ParanormalRomance,
        [StringValue("Horror")] Horror,
        [StringValue("Gothic Horror")] GothicHorror,
        [StringValue("Cosmic Horror")] CosmicHorror,
        [StringValue("Slasher")] Slasher,
        [StringValue("Historical Fiction")] HistoricalFiction,
        [StringValue("Young Adult")] YoungAdult,
        [StringValue("Children's Literature")] ChildrensLiterature,
        [StringValue("Biography")] Biography,
        [StringValue("Autobiography")] Autobiography,
        [StringValue("History")] History,
        [StringValue("Self-Help")] SelfHelp,
        [StringValue("Philosophy")] Philosophy,
        [StringValue("Science")] Science,
        [StringValue("Travel")] Travel,
        [StringValue("Other")] Other
    }
}
