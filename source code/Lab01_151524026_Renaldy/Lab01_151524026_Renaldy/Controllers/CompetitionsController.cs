using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lab01_151524026_Renaldy.Models;

namespace Lab01_151524026_Renaldy.Controllers
{
    public class CompetitionsController : Controller
    {
        private MemberModel db = new MemberModel();

        public Competition Competitions { get; private set; }

        // GET: Competitions
        public ActionResult Index()
        {
            return View(db.Competition.ToList());
        }

        // GET: Competitions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competition competition = db.Competition.Find(id);
            if (competition == null)
            {
                return HttpNotFound();
            }
            return View(competition);
        }

        // GET: Competitions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Competitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompetitionId,CompetitionName,Location,StartDate,EndDate,Description")] Competition competition)
        {
            if (ModelState.IsValid)
            {
                db.Competition.Add(competition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(competition);
        }

        // GET: Competitions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Competition Competition = db.Competition.Find(id);
            var memberCompetition = new MemberCompetition
            {
                Competition = db.Competition.Include(i => i.Members).First(i => i.CompetitionId == id)
            };


            if (memberCompetition.Competition == null)
            {
                return HttpNotFound();
            }
            var allmemberlist = db.Member.ToList();
            memberCompetition.AllMembers = allmemberlist.Select(m => new SelectListItem
            {
                Text = m.FirstName,
                Value = m.MemberId.ToString()
            });

            return View(memberCompetition);
        }

        // POST: Competitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "CompetitionId,CompetitionName,Location,StartDate,EndDate,Description")] Competition competition)
        //{
        //if (ModelState.IsValid)
        //{
        //    db.Entry(competition).State = EntityState.Modified;
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        //return View(competition);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MemberCompetition memberCompetition)
        {
            if (memberCompetition == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            if (ModelState.IsValid)
            {
                var competitionToUpdate = db.Competition
                    .Include(c => c.Members).First(c => c.CompetitionId == memberCompetition.Competition.CompetitionId);

                if (TryUpdateModel(competitionToUpdate, "Competition", new string[] { "Name", "Location", "StartDate", "EndDate", "Description", "CompetitionId" }))
                {
                    var newMembers = db.Member.Where(
                        m => memberCompetition.SelectedMembers.Contains(m.MemberId)).ToList();
                    var updatedMembers = new HashSet<int>(memberCompetition.SelectedMembers);

                    foreach (Member member in db.Member)
                    {
                        if (!updatedMembers.Contains(member.MemberId))
                        {
                            competitionToUpdate.Members.Remove(member);
                        }
                        else
                        {
                            competitionToUpdate.Members.Add((member));
                        }
                    }
                    db.Entry(competitionToUpdate).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            return View(memberCompetition);
        }

        // GET: Competitions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competition competition = db.Competition.Find(id);
            if (competition == null)
            {
                return HttpNotFound();
            }
            return View(competition);
        }

        // POST: Competitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Competition competition = db.Competition.Find(id);
            db.Competition.Remove(competition);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
