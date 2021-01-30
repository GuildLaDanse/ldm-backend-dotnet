using System;
using LaDanse.Domain.Entities.Comments;
using LaDanse.Domain.Entities.Identity;
using LaDanse.Domain.Entities.Shared;

namespace LaDanse.Domain.Entities.Events
{
    public partial class Event : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime InviteTime { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime LastModifiedTime { get; set; }
        public EventState State { get; set; }

        public Guid CommentGroupId { set; get; }
        public CommentGroup CommentGroup { set; get; }

        public Guid OrganiserId { get; set; }
        public virtual User Organiser { get; set; }
    }
}
