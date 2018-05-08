using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantReviews.Library;
using RestaurantReviews.Library.Models;
using RestaurantReviews.DataAccessLayer;
using RestaurantReviews.DataAccessLayer.Repositories;
using System.Net;
using NLog;

namespace RestaurantReviews.Web.Controllers
{
    public class ReviewController : Controller
    {
        IRepository<Restaurant> crud;
        IRepository<Review> revCrud;
        IDbContext restDB;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public ReviewController()
        {
            restDB = new RestaurantContext();
            crud = new RestaurantCrud<Restaurant>(restDB);
            revCrud = new RestaurantCrud<Review>(restDB);
            
        }

        public ReviewController(IDbContext fakeDb)
        {
            //fakeDb = new FakeTapasContext();
            //fakeRestDb = new FakeRestaurantContext();
        }

        /*
        protected override void Dispose(bool disposing)
        {
           
        }
        */

        // GET: Review
        public ActionResult Index(int? id)
        {



            var restaurant = crud.GetByID(id);
            if (restaurant != null)
            {
                
                return View(restaurant);
            }


            //return HttpNotFound();
            return View();

            //return View(crud.Table.ToList());
        }

        /* 
         *       public ActionResult Index([Bind(Prefix="Id")] int restaurantId)
        {
            var restaurant = crud.GetByID(restaurantId);
            if (restaurant != null)
            {
                return View(restaurant);
            }

            return HttpNotFound();

            //return View(crud.Table.ToList());
        }
        */



        // GET: Review/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Review/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Review/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create(Review review, int id)
        public ActionResult Create([Bind(Include = "ReviewerName,Rating,Description")] Review review, int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //int id
                    crud.GetByID(id).Reviews.Add(review);
                    crud.GetByID(id).hasReviews = true;
                    crud.Save();

                    //revCrud.Insert(review);
                    logger.Info("review added by " + review.ReviewerName + " to " + (crud.GetByID(id).RestaurantName));
                    //return RedirectToAction("Index", "Review", id);
                    return RedirectToAction("Index", "Restaurant");
                }
                return View();
            }
            catch
            {
                // log some problem
                logger.Info("review add failed");
                return View();
            }
        }

        /*
        // POST: Review/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        */

        // GET: Review/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Review review = revCrud.GetByID(id);

            if (review == null)
            {
                return HttpNotFound();
            }

            return View(review);
        }

        // POST: Review/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReviewerName,Rating,Description")] Review newReview, int id)
        {
            try
            {
               // if (ModelState.IsValid)
               // {
                    var oldReview = revCrud.Table.ToList().First(x => x.ReviewId == id);


                    newReview.ReviewId = oldReview.ReviewId;
                    
                    revCrud.Delete(oldReview);
                //revCrud.Insert(newReview);

                // revCrud.Table.ToList().ToList().Remove(oldReview);
                //revCrud.Table.ToList().ToList().Add(newReview);

                //crud.GetByID(newReview.RestaurantId).Reviews.Add(newReview);
                revCrud.Insert(newReview);
                    revCrud.Save();

                    return RedirectToAction("Index", "Restaurant");
                //}

              //  return View(newReview);
            }
            catch
            {
                return View(newReview);
            }
        }
        /*
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        */

        // GET: Reviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = revCrud.GetByID(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Review review = revCrud.GetByID(id);
            logger.Info("review for " + crud.GetByID(review.RestaurantId));
            revCrud.Delete(review);
            return RedirectToAction("Index", "Restaurant");
        }

        /*
        // POST: Review/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                revCrud.Delete(revCrud.GetByID(id));

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        */
    }
}
