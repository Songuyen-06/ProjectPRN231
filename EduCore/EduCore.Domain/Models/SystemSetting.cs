using System;
using System.Collections.Generic;

namespace EduCore.Domain.Models
{
    public partial class SystemSetting
    {
        public int SettingId { get; set; }
        public int? UserId { get; set; }
        public string Theme { get; set; } = null!;
        public string Language { get; set; } = null!;
        public bool NotificationsEnabled { get; set; }

        public virtual User? User { get; set; }
    }
}
