using System.Threading;
using System.Threading.Tasks;
using LaDanse.Domain.Entities.CharacterClaims;
using LaDanse.Domain.Entities.Comments;
using LaDanse.Domain.Entities.Events;
using LaDanse.Domain.Entities.Forums;
using LaDanse.Domain.Entities.GameData.Characters;
using LaDanse.Domain.Entities.GameData.Core;
using LaDanse.Domain.Entities.GameData.Sync;
using LaDanse.Domain.Entities.GameData.Sync.Guild;
using LaDanse.Domain.Entities.GameData.Sync.Profile;
using LaDanse.Domain.Entities.Identity;
using LaDanse.Domain.Entities.Queues;
using LaDanse.Domain.Entities.Settings;
using LaDanse.Domain.Entities.Telemetry;
using Microsoft.EntityFrameworkCore;

namespace LaDanse.Application.Common.Interfaces
{
    public interface ILaDanseDbContext
    {
        #region CharacterClaims

        DbSet<GameCharacterClaim> GameCharacterClaims { get; set; }
        DbSet<GameCharacterClaimVersion> GameCharacterClaimVersions { get; set; }
        DbSet<PlaysGameRole> PlaysGameRoles { get; set; }

        #endregion

        #region Comments

        DbSet<Comment> Comments { get; set; }
        DbSet<CommentGroup> CommentGroups { get; set; }

        #endregion

        #region Events

        DbSet<Event> Events { get; set; }
        DbSet<SignUp> SignUps { get; set; }
        DbSet<SignedForGameRole> SignedForGameRoles { get; set; }

        #endregion

        #region Forums

        DbSet<Forum> Forums { get; set; }
        DbSet<Topic> Topics { get; set; }
        DbSet<Post> Posts { get; set; }
        DbSet<UnreadPost> UnreadPosts { get; set; }
        DbSet<ForumLastVisit> ForumLastVisits { get; set; }

        #endregion

        #region GameData

        DbSet<GameClass> GameClasses { get; set; }
        DbSet<GameFaction> GameFactions { get; set; }
        DbSet<GameRace> GameRaces { get; set; }
        DbSet<GameRealm> GameRealms { get; set; }

        DbSet<GameGuild> GameGuilds { get; set; }
        DbSet<GameCharacter> GameCharacters { get; set; }
        DbSet<GameCharacterVersion> GameCharacterVersions { get; set; }
        DbSet<InGameGuild> InGameGuilds { get; set; }

        DbSet<GameCharacterSource> GameCharacterSources { get; set; }
        DbSet<GameCharacterSyncSession> GameCharacterSyncSessions { get; set; }

        DbSet<TrackedBy> TrackedBys { get; set; }

        DbSet<GameGuildSync> GameGuildSyncs { get; set; }
        DbSet<ProfileSync> ProfileSyncs { get; set; }

        #endregion

        #region Identity

        DbSet<User> Users { get; set; }

        #endregion


        #region Queues

        DbSet<ActivityQueueItem> ActivityQueueItems { get; set; }
        DbSet<NotificationQueueItem> NotificationQueueItems { get; set; }

        #endregion


        #region Settings

        DbSet<Setting> Settings { get; set; }
        DbSet<CalendarExport> CalendarExports { get; set; }
        DbSet<FeatureToggle> FeatureToggles { get; set; }

        #endregion


        #region Telemetry

        DbSet<Feedback> Feedbacks { get; set; }
        DbSet<FeatureUse> FeatureUses { get; set; }
        DbSet<MailSend> MailSends { get; set; }

        #endregion

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}