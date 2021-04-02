using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomodoInsuranceBadges
{
    public class BadgesRepository
    {
        private Dictionary<int, Badges> _dictionaryOfBadges = new Dictionary<int, Badges>();
        int _count;
        //1. Create a Dictionary of badges 
        //2. The key for dictionary will be the badge ID 
        //3. the value of the dictionary will be the List of Door Names 

        //create
        public bool AddABadge(Badges badge)
        {
            _count++;
            badge.BadgeID = _count;
            _dictionaryOfBadges.Add(badge.BadgeID, badge);
            return true;
        }
        //update
        public bool UpdateABadgeByID(int originalbadgeId, Badges newBadge)
        {
            //get the badge 
            Badges oldBadge = GetDictionaryBadgesById(originalbadgeId);
            //update the budge 
            if (oldBadge != null)
            {
                oldBadge.BadgeID = newBadge.BadgeID;
                oldBadge.DoorNames = newBadge.DoorNames;
                return true;
            }
            return false;
        }
        public bool RemoveDoor(string doorName, int badgeID)
        {
            Badges badges = GetDictionaryBadgesById(badgeID);
            if (badges.DoorNames.Contains(doorName))
            {
                return badges.DoorNames.Remove(doorName);
            }
            return false;
        }
        public bool AddDoor(string doorname, int badgeID)
        {
            Badges badges = GetDictionaryBadgesById(badgeID);
            int initialCount = badges.DoorNames.Count;
            badges.DoorNames.Add(doorname);
            if (initialCount < badges.DoorNames.Count)
            {
                return true;
            }
            return false;
        }
        //read
        public Dictionary<int, Badges> GetDictionaryAllBadges()
        {
            return _dictionaryOfBadges;
        }

        //helper

        public Badges GetDictionaryBadgesById(int badgeId)
        {
            foreach (var item in _dictionaryOfBadges)
            {
                if (item.Key == badgeId)
                {
                    return item.Value;
                }
            }
            return null;
        }
    }
}
