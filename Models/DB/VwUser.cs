using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS.Models.DB
{
    [Keyless]
    public partial class VwUser
    {
        [StringLength(450)]
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string ImageUser { get; set; } = null!;
        public bool ActiveUser { get; set; }
        [StringLength(256)]
        public string? Role { get; set; }
        [StringLength(256)]
        public string? Email { get; set; }
    }
}
