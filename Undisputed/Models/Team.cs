﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Undisputed.Data.Enum;

namespace Undisputed.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }

        public string? Title { get; set; }
        public string? Description { get; set; }

        public string? Image { get; set; }

        [ForeignKey("Address")]
        public int? AddressId { get; set; }

        public Address? Address { get; set; }

        public TeamCategory TeamCategory{ get; set; }

        [ForeignKey("AppUser")]
        public string? AppUserId { get; set; }

        public AppUser? AppUser { get; set; }

        public ICollection<AppUser> Users { get; set; }

        public DateTime? DateStarted { get; set; } = DateTime.Now;
    }
}
