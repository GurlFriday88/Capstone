using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Data
{
    public static class CapstoneDBContextExtensions
    {

        public static void EnsureDatabaseSeeded(this CapstoneDBContext context)
        {

            if (!context.BcbsPrefixes.Any())
            {
                

                context.AddRange(new Provider[]
                {

                    new Provider()
                    {
                        Name = "Argus",
                        SubscriberNumber = "P0000000",
                        PhoneNumber = "813-222-2222",
                        PagesToSave = 2,
                        SavedPagesDescription = "Benefits page and elgibility page",
                        BenefitRenewal = "Every 12 months from last date of service",
                        AuthNote = "Lorem Ipsum blah blah blah and some more blah blah ",
                        MiscNotes = "when you wish upon a star. Makes no difference who you are",
                        
                        
                    }





                });
                context.SaveChanges();

                if (!context.BcbsPrefixes.Any())
                {
                    var provider1 = context.Providers.SingleOrDefault(p => p.Name.Equals("Argus"));

                    context.AddRange(new BcbsPrefix[]
                    {
                        new BcbsPrefix()
                        {
                            Prefix = "XJGH",
                            ProviderID = provider1.ID
                            


                        },
                        new BcbsPrefix()
                        {
                            Prefix = "VMYH",
                            ProviderID = provider1.ID
                        }


                    });
                    context.SaveChanges();




                }





            }


        }
    }
}
