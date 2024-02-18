using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Context;

        internal class Book:BaseEntity
        {
            public string name { get; set; }
            [ForeignKey("UserId")] public User User { get; set; }
            public Guid UserId { get; set; }
        }




