using MyExam.iOS.Helpers;
using MyExam.iOS.Renderers;
using MyExam.Views;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(DoctorListPage), typeof(CustomPageRenderer))]
namespace MyExam.iOS.Renderers
{
    public class CustomPageRenderer : PageRenderer
    {
        #region Properties
        List<ToolbarItem> secondaryItems;
        UITableView table;
        private bool isRendered;
        #endregion

        #region Methods
        /// <summary>
        /// On Element changed method
        /// </summary>
        /// <param name="e"></param>
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            if (e.NewElement is ContentPage page)
            {
                secondaryItems = page.ToolbarItems.Where(i => i.Order == ToolbarItemOrder.Secondary).ToList();
                secondaryItems.ForEach(t => page.ToolbarItems.Remove(t));
            }
            base.OnElementChanged(e);
        }

        /// <summary>
        /// Show the icon menu on toolbar
        /// </summary>
        /// <param name="animated"></param>
        public override void ViewWillAppear(bool animated)
        {
            var element = (ContentPage)Element;
            if (secondaryItems != null && secondaryItems.Count > 0 && !isRendered)
            {
                element.ToolbarItems.Add(new ToolbarItem()
                {
                    Order = ToolbarItemOrder.Primary,
                    Icon = "icon_dots.png",
                    Priority = 1,
                    Command = new Command(() =>
                    {
                        ToolClicked();
                    })
                });
            }
            isRendered = true;
            base.ViewWillAppear(animated);
        }

        /// <summary>
        /// When clicked the menu option
        /// </summary>
        private void ToolClicked()
        {
            if (table == null)
            {
                var childRect = new RectangleF((float)View.Bounds.Width - 250, 0, 250, secondaryItems.Count() * 56);
                table = new UITableView(childRect)
                {
                    Source = new TableSource(secondaryItems) 
                };
                Add(table);
                return;
            }
            foreach (var subview in View.Subviews)
            {
                if (subview == table)
                {
                    table.RemoveFromSuperview();
                    return;
                }
            }
            Add(table);
        }
        #endregion
    }
}