﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BigSchool3.Models
{
    public class Following
    {
        [Key]
        [Column(Order = 1)]
        public String FollowerId { get; set; }
        [Key]
        [Column(Order = 2)]
        public String FolloweeId { get; set; }
        public ApplicationUser Followee { get; set; }
        public ApplicationUser Follower { get; set; }
    }
}