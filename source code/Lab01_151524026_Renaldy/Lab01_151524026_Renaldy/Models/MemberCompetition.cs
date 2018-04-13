using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab01_151524026_Renaldy.Models
{
    public class MemberCompetition
    {
        public Competition Competition { get; set; }
       
        [Display(Name = "Members")]
        public IEnumerable<SelectListItem> AllMembers { get; set; }

        private List<int> _selectedMembers;
        public List<int> SelectedMembers
        {
            get
            {
                if (_selectedMembers == null)
                {
                    _selectedMembers = Competition.Members.Select(m => m.MemberId).ToList();
                }
                return _selectedMembers;
            }
            set { _selectedMembers = value; }
        }
    }
}