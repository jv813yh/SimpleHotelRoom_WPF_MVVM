using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomWPF.Models
{
    public class RoomID
    {
        public int FloorNumber { get; }
        public int RoomNumber { get; }

        public RoomID(int floorNumber, int roomNumber)
        {
            FloorNumber = floorNumber;
            RoomNumber = roomNumber;
        }
        public override bool Equals(object? obj)
        {
            return obj is RoomID room &&
                this.FloorNumber == room.FloorNumber &&
                this.RoomNumber == room.RoomNumber;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FloorNumber, RoomNumber);
        }

        /*
        public static bool operator ==(RoomID left, RoomID right)
        {
            if (left == null && right == null)
                return true;

            return left != null && left.Equals(right);
        }

        public static bool operator !=(RoomID left, RoomID right)
        {
            return !(left == right);
        }
        */

    }
}
