using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Persistence
{
    public class Seed
    {
        // activity 5 [Missing Screenshot?]
        // here is a tip on how to create the method.

        // because we want to use the connection to the sqlite's
        // db that we created in API.Program.Main
        public static void SeedData(DataContext context)
        {
            // since we have a connection to the database,
            // we can query the database tables with linq;
            // make sure you import System.Linq;
            if(context.Posts.Count() == 0)
            {
                // this will run once when a database's
                // post table is emtpy.
                // create a list of posts and instantiate. 
                // like the activity states, you only need
                // to seed with the Title and Body string properties.
                List<Post> seedPosts = new List<Post>
                {
                    new Post() { Title = "First Post!", Body = "and that is why you dont create law (fed reserve act of 1913) that outsources to a private bank with undisclosed shareholders the creation of your govts money. without consideration and with interest to boot. these banksters had a good run and now well have to pay for it when this monetary system implodes on itself. nationalize the bank, audit it, wipe the odious debts and return to sound currency before its too late. lol, sure. but one could dream."},
                    new Post() { Title = "This is my second post", Body = "yeah, never forget. they couldnt stop the biggest attack on us soil. they took away tons of rights through overreaching legislation to \"protect\" us going forward. we went straight to afghanistan and iraq when the 9/11 commision hid the fact that a majority of the terrorists where saudi funded nationalists. and since that first day while watching in english class that morning, we now are fighting \"terrorism\" in 7 different countries (8 if you count the 4000+ drone kills in pakistan, 9 if you want to include our cyberwar with iran) for almost two decades with some of them not even approved by congress. oh, and wtc7 was supposedly the only structure to ever fail because of fires but was proved to be a demo by the university of alaska. how could i possibly forget?"},
                    new Post() { Title = "Another day, another post", Body = "thank a veteran. even if you think weve become too imperialistic. all a vet ever wanted was to keep us safe so respect that. im thanking Paul. we posted up near him at the parade of honor downtown this morning. now only did he teach me something new about military propaganda classes during the cold war, i also found out he was from vernon. and we think i put his garage doors in back in the day. small world. thanks for everyone elses service today too..."},
                };

                // these next methods are accessed from
                // the base class DbContext in EntityFrameworkCore.
                
                // we could add new records into a table individually
                // context.Add(seedPosts[0]);
                // context.Add(seedPosts[1]);
                // context.Add(seedPosts[2]);
                // or we can just add a list using the add range method
                context.AddRange(seedPosts);

                // now we need to save, or the inserts statements under the hood
                // to add the objects in EntityFrameworkCore will not commit to the database. 
                context.SaveChanges();
            }
        }
    }
}