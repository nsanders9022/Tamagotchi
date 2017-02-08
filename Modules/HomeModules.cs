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
      return View["tamagotchislist.cshtml", allTamagotchis];
    };

    Get["/tamagotchi_list/new"] = _ => {
        return View["Tamagotchi_form.cshtml"];
      };
      Get["/tamagotchi_list/{id}"] = parameters => {
        Tamagotchi tamagotchi = Tamagotchi.Find(parameters.id);
        return View["tamagotchi_item.cshtml", tamagotchi];
      };
      Post["/tamagotchi_list"] = _ => {
        Tamagotchi newTamagotchi = new Tamagotchi(Request.Form["new-name"], Request.Form["new-food"], Request.Form["new-attention"], Request.Form["new-rest"]);
        List<Tamagotchi> allTamagotchis = Tamagotchi.GetAll();
        return View["tamagotchi_list.cshtml", allTamagotchis];
      };
    }
  }
}
