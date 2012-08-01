using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Data.Items;
using Sitecore.Data;
using SC = global::Sitecore;
using Sitecore.Events;
using WebsiteKernel.Sitecore.Extensions;
using Sitecore.Diagnostics;

namespace WebsiteKernel.Events
{
    public abstract class Event 
    {
        protected Item EventItem {get;set;}

        protected abstract void InternalOnItemSave(object sender, EventArgs args);
        protected abstract void InternalOnItemAdded(object sender, EventArgs args);

        protected static Dictionary<ID, DateTime> EventItems = new Dictionary<ID, DateTime>();

        private Database OrgingaDB { get; set; }

        /// <summary>
        /// Called when [item save].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        public void OnItemSave(object sender, EventArgs args)
        {
            try
            {
                if (!RunEvent(sender, args))
                {
                    return;
                }

                InternalOnItemSave(sender, args);
            }
            catch (Exception ex)
            {
                var type = this.GetType();
                Log.Error(String.Format("Error Running Event {0} with error {1}", ex.Message, type), type);
            }
            finally
            {
                CleanUp();
            }
        }

        /// <summary>
        /// Called when [item added].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        public void OnItemAdded(object sender, EventArgs args)
        {
            try
            {
                if (!RunEvent(sender, args))
                {
                    return;
                }

                InternalOnItemAdded(sender, args);
            }
            catch (Exception ex)
            {
                var type = this.GetType();
                Log.Error(String.Format("Error Running Event {0} with error {1}", ex.Message, type), type);
            }
            finally
            {
                CleanUp();
            }
        }

        /// <summary>
        /// Cleans up.
        /// </summary>
        private void CleanUp()
        {
            if (EventItems.Any(x => x.Key == EventItem.ID))
            {
                EventItems.Remove(EventItem.ID);
            }

            //we want to remove any old items that could be still around from an event that failed
            if (EventItems.Any())
            {
                //get all the items that have been in the list for 10 mins 
                var oldItems = EventItems.Where(x => DateTime.Now.Subtract(x.Value) > new TimeSpan(0, 10, 0));
                foreach (var item in oldItems)
                {
                     EventItems.Remove(item.Key);
                }
            }
            SC.Context.Database = OrgingaDB;
        }

        /// <summary>
        /// Checked if the event should run and also does some house keeping
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        /// <returns></returns>
        private bool RunEvent(object sender, EventArgs args)
        {
             if (args == null)
                return false;

            // We don't have context which means that we are not in the authoring environment
            if (SC.Context.Database == null)
                return false;

            SitecoreEventArgs sitecoreEventArgs = args as SitecoreEventArgs;
            EventItem = sitecoreEventArgs.Parameters[0] as Item;

            if (EventItem == null || EventItem.Template == null)
                return false;

            // Skip standard values item
            if (EventItem.IsStandardValues())
                return false;

            //item saved is called when an item is published (because the item is being saved in the web database)
            //when this happens, we don't want our code to move the item anywhere
            if ((SC.Context.Job != null && SC.Context.Job.Category.Equals("publish", StringComparison.OrdinalIgnoreCase))
                || String.Compare(EventItem.Database.Name, "master", true) != 0)
            {
                return false;
            }


            //check to see if there is an event working on this item already
            if(EventItems.Any(x=>x.Key == EventItem.ID))
            {
                //if there is then don't do anything
                return false;
            }


            //house keeping time :)

            //add the id of the item we are working with the EventItems dictionary along with the time
            EventItems.Add(EventItem.ID, DateTime.Now);
            
            //remember the context database before changing it
            OrgingaDB = SC.Context.Database;

            //change the context database to the same as the item we are working with
            SC.Context.Database = EventItem.Database;

            //do injection
            WebsiteKernalNinjectKernelContainer.Inject(this);

            //all is well
            return true;
        }
    }
}

