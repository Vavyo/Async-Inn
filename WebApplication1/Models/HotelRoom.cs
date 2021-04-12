using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class HotelRoom
    {
        public int HotelId { get; set; }
        public int RoomNumber { get; set; }
        public int RoomId { get; set; }
        [Column(TypeName = "money")]
        public decimal Rate { get; set; }
        public bool PetFriendly { get; set; }

        public Hotel Hotel { get; set; }
        public Room Room { get; set; }
    }
}
