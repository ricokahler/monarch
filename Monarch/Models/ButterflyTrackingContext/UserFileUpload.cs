﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Monarch.Models.ButterflyTrackingContext
{
    public class UserFileUpload
    {
        public int UserFileUploadId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public DateTime DateTime { get; set; }

        public override bool Equals(object obj)
        {
            // If parameter is null return false.
            if (obj == null)
                return false;

            // If parameter cannot be cast to Point return false.
            var file = obj as UserFileUpload;
            if (file == null)
                return false;

            // Return true if the fields match:
            return UserFileUploadId == file.UserFileUploadId;
        }

        // override get hash code for because the equals override
        public override int GetHashCode()
        {
            return UserFileUploadId;
        }
    }
}