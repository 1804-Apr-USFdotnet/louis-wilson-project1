using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantReviews.Library;
using RestaurantReviews.Library.Models;
using RestaurantReviews.DataAccessLayer;
using RestaurantReviews.DataAccessLayer.Repositories;
using NLog;

namespace RestaurantReviews.Web.Controllers
{
    public class RestaurantController : Controller
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        IRepository<Restaurant> crud;
        IRepository<Review> revCrud;
        IDbContext restDB;
        

        public RestaurantController()
        {
            restDB = new RestaurantContext();
            crud = new RestaurantCrud<Restaurant>(restDB);
            revCrud = new RestaurantCrud<Review>(restDB);
        }

        public RestaurantController(IDbContext fakeDb)
        {
            //fakeDb = new FakeTapasContext();
            //fakeRestDb = new FakeRestaurantContext();
        }

        // GET: Restaurant
        [HttpGet]// default type of Action
        public ActionResult Index(string searchTerm = null)
        {


            var foundRestaurants = crud.Table.ToList()
                //.OrderByDescending(restaurant => restaurant.Reviews.Average(review => review.Rating))
                .Where(restaurant => searchTerm == null || restaurant.RestaurantName.ToLower().Contains(searchTerm.ToLower()))
                //.Take(10)
                .Select(restaurant => new Restaurant
                {
                    Id = restaurant.Id,
                    RestaurantName = restaurant.RestaurantName,
                    FoodType = restaurant.FoodType,
                    Street1 = restaurant.Street1,
                    Street2 = restaurant.Street2,
                    City = restaurant.City,
                    State = restaurant.State,
                    Country = restaurant.Country,
                    Zipcode = restaurant.Zipcode,
                    Phone = restaurant.Phone
                    
                }
                

                /*
                   .OrderByDescending(r => r.Reviews.Average(review => review.Rating))
                   .Where(r => searchTerm == null || r.Name.StartsWith(searchTerm))
                   .Take(10)
                   .Select(r => new RestaurantListViewModel
                   {
                       Id = r.Id,
                       Name = r.Name,
                       City = r.City,
                       Country = r.Country,
                       CountOfReviews = r.Reviews.Count()
                   }
                   */
                            );


            /*
            var restaurants = crud.Table.ToList();
            return View(restaurants); 
            */

            /* var restaurants = from r in crud.Table.ToList()
                              orderby r.RestaurantName ascending
                              select r;
                              */
            /*
            var restaurants = from r in crud.Table.ToList()
                              orderby r.AvgRating descending
                              select r;
                              */
            /*
            var restaurants = from r in crud.Table.ToList()
                              orderby r.Reviews.Average(review => review.Rating) descending
                              select r;
                              */
            return View(foundRestaurants);
        }

        // GET: Restaurant/Details/5
        public ActionResult Details(int id)
        {

            return View(crud.GetByID(id));
        }

        // GET: Restaurant/Create
        public ActionResult Create()
        {
            return View();
        }



        // POST: Restaurant/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "RestaurantName,FoodType,Street1,City,State,Country,Zipcode,Phone")] Restaurant restaurant)
        public ActionResult Create (Restaurant restaurant)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                    crud.Insert(restaurant);
                    // log that it worked
                logger.Info(restaurant.RestaurantName + "added to database");
                    

                    return RedirectToAction("Index");
                //}
                //return View();
            }
            catch
            {
                // log some problem
                logger.Info("restaurant failed validation added to database");
                return View();
            }
        }

        /*
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

        // GET: Restaurant/Edit/5

        public ActionResult Edit(int id)
        {
            return View(crud.GetByID(id));
        }

        
      


        // POST: Restaurant/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
 
        public ActionResult Edit(int id, Restaurant newRestaurant)
        {
            try
            {
                var oldRestaurant = crud.Table.ToList().First(x => x.Id == id);


                newRestaurant.Id = oldRestaurant.Id;

                //newRestaurant.Reviews = oldRestaurant.Reviews;
               
                foreach (Review rev in oldRestaurant.Reviews)
                {
                    newRestaurant.Reviews.Add(rev);
                }
                

                crud.Delete(oldRestaurant);
                crud.Insert(newRestaurant);

                logger.Info(oldRestaurant.RestaurantName + "properties edited, replaced with entry" + newRestaurant.RestaurantName);

                return RedirectToAction("Index");
            }
            catch
            {
                logger.Info("restaurant edit failed");
                return View(newRestaurant);
            }
        }

        //public ActionResult Edit([Bind(Include = "Id,RestaurantName,FoodType,Street1,Street2,City,State,Country,Zipcode,Phone,Created,Modified")] Restaurant newRestaurant)
        //{
        //    try
        //    {
        //        /*
        //        var oldRestaurant = _restaurants.First(x => x.Id == id);

        //        _restaurants.Remove(oldRestaurant);
        //        newRestaurant.Id = oldRestaurant.Id;
        //        _restaurants.Add(newRestaurant);
        //        */

        //        //var restaurantToEdit = (crud.Table.ToList()).First(restaurant => restaurant.Id == id);
        //        //newRestaurant.Id = restaurantToEdit.Id;

        //        /*
        //        newRestaurant = crud.GetByID(id);
        //        ViewData.Model = newRestaurant;
        //        crud.Update(newRestaurant);
        //        */
        //        newRestaurant.AvgRating = 0;
        //        //newRestaurant = crud.GetByID(id);
        //        crud.Update(newRestaurant);
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View(newRestaurant);
        //    }
        //}

        // GET: Restaurant/Delete/5
        public ActionResult Delete(int id)
        {
            return View(crud.GetByID(id));
        }

        // POST: Restaurant/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                logger.Info(crud.GetByID(id).RestaurantName + " deleted");
                crud.Delete(crud.GetByID(id));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
