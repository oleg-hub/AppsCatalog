using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using AppsCatalog.Models;

namespace AppsCatalog.Data
{
    public static class ApplicationDBInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (!context.Applications.Any())
            {
                context.Applications.AddRange(
                    new Application
                    {
                        Title = "Instagram",
                        Description = "Instagram allows users to edit and upload photos and short videos through a mobile app." +
                        " Users can add a caption to each of their posts and use hashtags and location-based geotags to index" +
                        " these posts and make them searchable by other users within the app. Each post by a user appears on" +
                        " their followers' Instagram feeds and can also be viewed by the public when tagged using hashtags or" +
                        " geotags. Users also have the option of making their profile private so that only their followers can " +
                        "view their posts.",
                        Сategory = Models.enums.CategoryType.Social,
                        ApplicationUserName = "Jonh"
                    },
                    new Application
                    {
                        Title = " Аnews",
                        Description = "Fast and easy way of reading NEWS from websites, online newspapers, magazines, blogs and " +
                        "social networks on your mobile iOS devices. News aggregator Anews lets you add as many publishers as you" +
                        " like (literally any RSS feed: publications, magazines, media channels, blogs, pages, broadcasts) and view" +
                        " them all in a single app. ",
                        Сategory = Models.enums.CategoryType.News,
                        ApplicationUserName = "Tom"
                    },
                    new Application
                    {
                        Title = " Sky Sports",
                        Description = "Don’t miss a worldy, wicket, fastest lap or crunching tackle thanks to the knockout Sky Sports" +
                        " app. It’s got all the breaking stories from Sky Sports News, the best video, live scores, fixtures, results" +
                        " and all the brand new Sky Sports TV channels. You can also pick your favourite teams, stars, experts and " +
                        "sports to follow and configure your notifications so you only receive the updates that matter to you most.",
                        Сategory = Models.enums.CategoryType.Sport,
                        ApplicationUserName = "Martin"
                    },
                    new Application
                    {
                        Title = "Remote Control",
                        Description = "With the Remote Control for DirecTV, you can use your Android device as a remote" +
                        " control to command your DirecTV and TV. All in one place! Remote Control for SKY is a lightweight" +
                        " app with a theme designed specifically to save battery of your Android device.",
                        Сategory = Models.enums.CategoryType.No,
                        ApplicationUserName = "George"
                    },
                     new Application
                     {
                         Title = "Angry Birds",
                         Description = "Angry Birds organize celebrations on the occasion of various holidays and events from " +
                         "around the world! Join us! Enjoy bright festive atmosphere in your favorite addictive game Angry " +
                         "Birds!In the latest update: the lone hero accepts the call with a slingshot pig - Viking, and" +
                         " the battle begins!",
                         Сategory = Models.enums.CategoryType.Shooter,
                         ApplicationUserName = "Ann"
                     }
                );
                context.SaveChanges();
            }
        }
    }
}
