using System;
using System.Collections.Generic;

namespace MyDatingapp.Api.Model
{
    public partial class Tuser
    {
        public Tuser()
        {
            TuserPhoto = new HashSet<TuserPhoto>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string KnownAs { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? LastActive { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public virtual ICollection<TuserPhoto> TuserPhoto { get; set; }
    }
}
