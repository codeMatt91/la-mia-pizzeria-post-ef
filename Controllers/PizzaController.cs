using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static.Controllers
{


    public class PizzaController : Controller
    {

        public static PizzaContext db = new PizzaContext();

        public static listaPizze pizze = null;
        public IActionResult Index()
        {
            //if (pizze == null)
            //{
            //    Pizza Margherita = new Pizza( "Margherita", "Ingredienti: Mozzarella, Pomodoro e Basilico", 6.50, "img/margherita.jpg");
            //    Pizza Boscaiola = new Pizza( "Boscaiola", "Ingredienti: Mozzarella, Salsiccia e Funghi", 7.50, "img/boscaiola.jpg");
            //    Pizza Bufala = new Pizza( "Bufala", "Ingredienti: Mozzarella di bufala, Pomodoro e Basilico", 7.50, "img/bufala.jpg");
            //    Pizza Formaggi = new Pizza( "Formaggi", "Ingredienti: Mozzarella, Gorgonzola, Fontina e Taleggio", 9.00, "img/formaggi.webp");
            //    Pizza Salame = new Pizza( "Salame", "Ingredienti: Mozzarella, pomodoro e Salame piccante", 8.50, "img/salame.jpg");
            //    Pizza Funghi = new Pizza( "Funghi", "Ingredienti: Mozzarella, pomodoro e Funghi", 7.00, "img/funghi.jpg");

            pizze = new();
            //    //pizze.pizzas.Add(Margherita);
            //    //pizze.pizzas.Add(Boscaiola);
            //    //pizze.pizzas.Add(Bufala);
            //    //pizze.pizzas.Add(Formaggi);
            //    //pizze.pizzas.Add(Salame);
            //    //pizze.pizzas.Add(Funghi);

            //    db.Add(Margherita);
            //    db.Add(Boscaiola);
            //    db.Add(Bufala);
            //    db.Add(Formaggi);
            //    db.Add(Salame);
            //    db.Add(Funghi);
            //    db.SaveChanges();
            //}


            return View(db);
        }


        public IActionResult Show(Pizza pizza)
        {

            return View("Show", pizza);
        }

        public IActionResult CreaNuovaPizza()
        {
            Pizza NuovaPizza = new Pizza()
            {
                Name = "",
                Description = "",
                Price = 0.0,
                Photo = "",

            };

            return View(NuovaPizza);
        }


        public IActionResult ShowPizza(Pizza pizza)
        {

            if (!ModelState.IsValid)
            {
                return View("CreaNuovaPizza", pizza);
            }

            Pizza nuovaPizza = new Pizza()
            {
                Id = pizza.Id,
                Name = pizza.Name,
                Description = pizza.Description,
                Price = pizza.Price,
                Photo = pizza.Photo,

            };
            db.Add(nuovaPizza);
            db.SaveChanges();
            return View("ShowPizza", nuovaPizza);
        }






        public IActionResult AggiornaPizza(Pizza pizza)
        {

            return View("AggiornaPizza", pizza);
        }







        public IActionResult EditPizza(Pizza pizza)
        {
            Pizza updatePizza = new Pizza();
            

            if (pizza != null)
            {

                updatePizza = db.Pizzas.Find(pizza.Id);

                updatePizza.Name = pizza.Name;
                updatePizza.Description = pizza.Description;
                updatePizza.Price = pizza.Price;
                if (updatePizza.Photo != pizza.Photo)
                {
                    updatePizza.Photo = pizza.Photo;
                }
                db.Update(updatePizza);
                db.SaveChanges();
            }
            

            return View("Show", updatePizza);
        }








        public IActionResult RimuoviPizza(Pizza pizza)
        {
            return View("RimuoviPizza", pizza);
        }



        [HttpPost]
        public IActionResult Delete(Pizza pizza)
        {
            Pizza updatePizza = db.Pizzas.Find(pizza.Id);

            if (updatePizza.Id == pizza.Id)
            {
                db.Remove(updatePizza);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
