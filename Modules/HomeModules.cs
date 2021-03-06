using Nancy;
using Gotchi.Objects;
using System.Collections.Generic;

namespace TamagotchiGame
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };

      Get["/tamagotchi_list"] = _ =>
      {
        List<Tamagotchi> allTamagotchis = Tamagotchi.GetAll();
        return View["tamagotchi_list.cshtml", allTamagotchis];
      };

      Get["/tamagotchi_list/new"] = _ => {
        return View["tamagotchi_form.cshtml"];
      };
      Get["/tamagotchi_list/{id}"] = parameters => {
        Tamagotchi tamagotchi = Tamagotchi.Find(parameters.id);
        return View["tamagotchi_item.cshtml", tamagotchi];
      };
      Post["/tamagotchi_list"] = _ => {
        Tamagotchi newTamagotchi = new Tamagotchi(Request.Form["new-name"]);
        List<Tamagotchi> allTamagotchis = Tamagotchi.GetAll();
        return View["tamagotchi_list.cshtml", allTamagotchis];
      };
      Post["/tamagotchi_item/rest/{id}"] = parameters => {
        Tamagotchi tamagotchi = Tamagotchi.Find(parameters.id);
        tamagotchi.AddRest();
        return View["tamagotchi_item.cshtml", tamagotchi];
      };
      Post["/tamagotchi_item/food/{id}"] = parameters => {
        Tamagotchi tamagotchi = Tamagotchi.Find(parameters.id);
        tamagotchi.AddFood();
        return View["tamagotchi_item.cshtml", tamagotchi];
      };
      Post["/tamagotchi_item/attention/{id}"] = parameters => {
        Tamagotchi tamagotchi = Tamagotchi.Find(parameters.id);
        tamagotchi.AddAttention();
        return View["tamagotchi_item.cshtml", tamagotchi];
      };
      Post["/tamagotchi_list/time"] = _ => {
        Tamagotchi.AddTime();
        // List<Tamagotchi> allTamagotchis = Tamagotchi.GetAll();
        return View["tamagotchi_list.cshtml", Tamagotchi.GetAll()];
      };
    }
  }
}
