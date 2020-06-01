using LaDanse.Application.Common.Interfaces;
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
using LaDanse.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;

namespace LaDanse.Persistence
{
    public class LaDanseDbContext : DbContext, ILaDanseDbContext
    {
        public LaDanseDbContext(DbContextOptions<LaDanseDbContext> options)
            : base(options)
        {
        }
        
        #region CharacterClaims
        
        public virtual DbSet<GameCharacterClaim> GameCharacterClaims { get; set; }
        public virtual DbSet<GameCharacterClaimVersion> GameCharacterClaimVersions { get; set; }
        public virtual DbSet<PlaysGameRole> PlaysGameRoles { get; set; }

        #endregion
        
        #region Comments
        
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<CommentGroup> CommentGroups { get; set; }

        #endregion
        
        #region Events
        
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<SignUp> SignUps { get; set; }
        public virtual DbSet<SignedForGameRole> SignedForGameRoles { get; set; }

        #endregion
        
        #region Forums
        
        public virtual DbSet<Forum> Forums { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<UnreadPost> UnreadPosts { get; set; }
        public virtual DbSet<ForumLastVisit> ForumLastVisits { get; set; }

        #endregion
        
        #region GameData
        
        public virtual DbSet<GameClass> GameClasses { get; set; }
        public virtual DbSet<GameFaction> GameFactions { get; set; }
        public virtual DbSet<GameRace> GameRaces { get; set; }
        public virtual DbSet<GameRealm> GameRealms { get; set; }
        
        public virtual DbSet<GameGuild> GameGuilds { get; set; }
        public virtual DbSet<GameCharacter> GameCharacters { get; set; }
        public virtual DbSet<GameCharacterVersion> GameCharacterVersions { get; set; }
        public virtual DbSet<InGameGuild> InGameGuilds { get; set; }
        
        public virtual DbSet<GameCharacterSource> GameCharacterSources { get; set; }
        public virtual DbSet<GameCharacterSyncSession> GameCharacterSyncSessions { get; set; }
        
        public virtual DbSet<TrackedBy> TrackedBys { get; set; }
        
        public virtual DbSet<GameGuildSync> GameGuildSyncs { get; set; }
        public virtual DbSet<ProfileSync> ProfileSyncs { get; set; }

        #endregion
        
        #region Identity
        
        public virtual DbSet<User> Users { get; set; }

        #endregion


        #region Queues
        
        public virtual DbSet<ActivityQueueItem> ActivityQueueItems { get; set; }
        public virtual DbSet<NotificationQueueItem> NotificationQueueItems { get; set; }

        #endregion


        #region Settings
        
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<CalendarExport> CalendarExports { get; set; }
        public virtual DbSet<FeatureToggle> FeatureToggles { get; set; }

        #endregion


        #region Telemetry
        
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<FeatureUse> FeatureUses { get; set; }
        public virtual DbSet<MailSend> MailSends { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyAllConfigurations();
        }
    }
}
