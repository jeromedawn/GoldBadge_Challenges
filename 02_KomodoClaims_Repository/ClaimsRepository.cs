using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomodoClaims_Repository
{
    public class ClaimsRepository
    {
        private Queue<Claims> _listOfClaims = new Queue<Claims>();
        //read a claim 
        public Queue<Claims> SeeAllClaims()
        {
            return _listOfClaims;
        }
        //enter a new claim
        public bool EnterNewClaim(Claims claim)
        {
            _listOfClaims.Enqueue(claim);
            return true;
        }       
        public Claims ViewNextClaim()
        {
            Claims claim;
            if (_listOfClaims.Count > 0)
            {
                claim = _listOfClaims.Peek();
                return claim;
            }
            return null;
        }
        //helper method 
       public Queue<Claims> GetClaims()
        {
            return _listOfClaims;
        }
        public bool ProcessClaim()
        {
            if (_listOfClaims.Count > 0 )
            {
                _listOfClaims.Dequeue();
                return true;
            }
            return false;
        }
    }
}
