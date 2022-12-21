using AutoBaloo.Data.Enums;
using AutoBaloo.Data.Static;
using AutoBaloo.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoBaloo.Data
{
    public class AppDbInitializer
    {

        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();


                
                                //Vehicule
                                if (!context.Vehicules.Any())
                                {
                    context.Vehicules.AddRange(new List<Vehicule>()
                                    {
                                                new Vehicule()
                                                {

                                                    MarqueVehicule        = "Audi",

                                                    TypeCarbu             = "Diesel",
                                                    PrixVehicule          = 1000000,
                                                    DescriptionVehicule   = " Audi A3 SEDAN 1.6 TDi S tronic Business NAVI/FULL LED/JA16/PDC",
                                                    DateConstruct         = "2017",
                                                    KM                    =  "68.082km ",
                                                    OptionVehicule        = 0,
                                                    CouleurVehicule       = "noir",
                                                    Prix_par_jour         = 123,
                                                    Datearrivée            =DateTime.Now.ToString(),
                                                    ImageURL              = "/12.jpg",
                                                    typeAchat             =TypeAchat.louer,
                                                },



                                                 new Vehicule()
                                                {

                                                    MarqueVehicule        = "BMW",

                                                    TypeCarbu             = "Diesel",
                                                    PrixVehicule          = 20566,
                                                    DescriptionVehicule   = "BMW X1 2.0 d sDrive18 NAVI / CUIR / PDC AV+AR / JA 17         ",
                                                    DateConstruct         = "2017",
                                                    KM                    =  " 89.196km ",
                                                    OptionVehicule        = 0,
                                                    CouleurVehicule       = "Blanc",
                                                    Prix_par_jour         = 123,
                                                    Datearrivée            =DateTime.Now.ToString(),
                                                    ImageURL              = "/2.jpg",
                                                    typeAchat             =TypeAchat.louer
                                                },
                                                 new Vehicule()
                                                {

                                                    MarqueVehicule        = "Audi",

                                                    TypeCarbu             = "Diesel",
                                                    PrixVehicule          = 255000,
                                                    DescriptionVehicule   = " Audi A3 SEDAN 1.6 TDi S tronic Business NAVI/FULL LED/JA16/PDC",
                                                    DateConstruct         = "2017",
                                                    KM                    =  " 65.851km ",
                                                    OptionVehicule        = 0,
                                                    CouleurVehicule       = "Rouge",
                                                     Prix_par_jour         = 123,
                                                    Datearrivée            =DateTime.Now.ToString(),
                                                    ImageURL              = "/1.jpg",
                                                      typeAchat             =TypeAchat.Vendre,

                                                },


                                                   new Vehicule()
                                                {

                                                    MarqueVehicule        = "RENAULT CLIO E-TECH",

                                                    TypeCarbu             = "Essence",
                                                    PrixVehicule          = 24950,
                                                    DescriptionVehicule   = " 1.8 TURBO TROPHY RS *RECARO ALCANTARA*MAXTON KIT*L",
                                                    DateConstruct         = "2017",
                                                    KM                    =  "8 651 km ",
                                                    OptionVehicule        = 0,
                                                    CouleurVehicule       = "Gris",
                                                    Prix_par_jour         =0 ,
                                                   Datearrivée            =DateTime.Now.ToString(),
                                                    ImageURL              = "/4.png",
                                                    typeAchat             =TypeAchat.Vendre,
                                                },


                                                   new Vehicule()
                                                {

                                                    MarqueVehicule        = "Renault Talisman",

                                                    TypeCarbu             = "Deisel",
                                                    PrixVehicule          = 13900,
                                                    DescriptionVehicule   = " zen",
                                                    DateConstruct         = "06/2016",
                                                    KM                    =  "73 492  km ",
                                                    OptionVehicule        =0,
                                                    CouleurVehicule       = "jaune",
                                                    Prix_par_jour         =0 ,
                                                   Datearrivée            =DateTime.Now.ToString(),
                                                    ImageURL              = "/5.png",
                                                    typeAchat             =TypeAchat.Vendre,
                                                },

                                                       new Vehicule()
                                                {

                                                    MarqueVehicule        = "Porsche 718",

                                                    TypeCarbu             = "Essence",
                                                    PrixVehicule          = 119718,
                                                    DescriptionVehicule   = " Spyder 4.0 Turbo PDK / CARBON / PDLS+ /HEATED SEAT",
                                                    DateConstruct         = "05/2021",
                                                    KM                    =  "10 850   km ",
                                                    OptionVehicule        = 0,
                                                    CouleurVehicule       = "jaune",
                                                    Prix_par_jour         =0 ,
                                                    Datearrivée            ="12-12-22",
                                                    ImageURL              = "/6.jpg",
                                                    typeAchat             =TypeAchat.Vendre,
                                                },
                                    }) ;

                                    context.SaveChanges();


                                }

                            //Stock
                               if (!context.Stocks.Any())
                                {
                                    context.Stocks.AddRange(new List<Stock>()
                                    {
                                        new Stock()
                                        {
                                              DateStock           = "01/01/2022",
                                              QteStock            = 100,
                                              IdVehicule          =  1
                                        },

                                        new Stock()
                                        {
                                              DateStock           = "01/01/2022",
                                              QteStock            = 100,
                                               IdVehicule          = 2

                                        },

                                       /* new Stock()
                                        {
                                              DateStock           = "01/01/2010",
                                              QteStock            = 100,
                                               IdVehicule          =  

                                        },

                                        new Stock()
                                        {
                                              DateStock           = "01/01/2010",
                                              QteStock            = 100,
                                               IdVehicule          =  

                                        },

                                        new Stock()
                                        {
                                              DateStock           = "01/01/2010",
                                              QteStock            = 100,
                                               IdVehicule          =  

                                        }*/
                                    });
                                    context.SaveChanges();
                                }

                            //Statut
                              if (!context.Statuts.Any())
                                {
                                    context.Statuts.AddRange(new List<Statut>()
                                    {
                                        new Statut()
                                        {
                                              StatutVehicule           = StatutVehicule.Disponible,
                                              
                                              IdVehicule          =  1
                                        },

                                        new Statut()
                                        {
                                              StatutVehicule           = StatutVehicule.Loué,

                                              IdVehicule          =  2

                                        },

                                       
                                    });
                                    context.SaveChanges();
                              }
                           



                          /*      //Reservation
                            if (!context.Reservations.Any())
                                {
                    context.Reservations.AddRange(new List<Reservation>()
                                    {
                                        new Reservation()
                                        {

                                           DateDebut="01/05/2022",
                                            DateFin = "01/06/2022",
                                           Duree =30  ,
                                           MontantReservation= " 5566",

                                           TypeReservation=TypeReservation.Louer,
                                           IdUtilisateur=1,
                                           IdVehicule= 44,
    }
                                    }) ;
                                    context.SaveChanges();

                                }

                                //Paiement
                           /*     if (!context.Paiements.Any())
                                {
                                    context.Paiements.AddRange(new List<Paiement>()
                                    {
                                        new Paiement()
                                        {

                                        }
                                    });
                                    context.SaveChanges();
                                }*/

                                //Utilisateur
                           /*   if (!context.Utilisateurs.Any())
                                {
                                    context.Utilisateurs.AddRange(new List<Utilisateur>()
                                    {
                                        new Utilisateur()
                                        {
                                             NomUtilisateur  = "Théo",
                                            EmailUtilisateur =  "theos@gmail.com",
                                            MotPasse         = "theo??",
                                            Adresse          = "vapart 40"

                                        },


                                    });
                                    context.SaveChanges();

                                }

                               */

            }
        }



        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@AutoBaloo.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@AutoBaloo.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}




