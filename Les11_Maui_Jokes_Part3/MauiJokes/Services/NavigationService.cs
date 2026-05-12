using MauiJokesBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoGentMaui.Services
{
    public class NavigationService
    {
        public async Task GoToAsync(string routeName, ShellNavigationQueryParameters parameters = null)
        {
            if ( parameters == null )
                await Shell.Current.GoToAsync(routeName);
            else
                await Shell.Current.GoToAsync(routeName, parameters);
        }

        public async Task GoToJokeDetailAsync(string jokeId)
        {
            await GoToAsync(nameof(JokeDetailPage), new ShellNavigationQueryParameters
            {
                { "jokeId", jokeId }
            });
        }
    }
}
