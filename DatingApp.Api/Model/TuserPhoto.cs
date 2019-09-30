using System;
using System.Collections.Generic;

namespace MyDatingapp.Api.Model
{
    public partial class TuserPhoto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime? DateAdded { get; set; }
        public bool? IsMain { get; set; }
        public int? UserId { get; set; }

        public virtual Tuser User { get; set; }
    }
}
