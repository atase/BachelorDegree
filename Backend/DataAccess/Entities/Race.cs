
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kidney.DataAccess.Entities
{
    public enum RACE
    {
        ASIAN_AMERICAN,
        BLACK,
        WHITE,
        NATIVE_AMERICAN,
        OTHER,
        UNKNOWN
    }
    public class Race
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Type { get; set; }
    }
}
