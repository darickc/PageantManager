using System.Collections.Generic;

namespace PageantManager.Business.Entities
{
    public class User
    {
        public int UserId { get; set; }
		public string LdsAccountId { get; set; }
		public string Name { get; set; }

        public List<Applicant> Applicants { get; set; }
    }
}
