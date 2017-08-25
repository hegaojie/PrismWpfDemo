using System.Collections.Specialized;
using System.Windows;
using Prism.Regions;
using System.Windows.Controls;

namespace PrismWpfDemo.Infrastructures.Mvvm
{
    public class StackpanelRegionAdapter : RegionAdapterBase<StackPanel>
    {
        public StackpanelRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory) : base(regionBehaviorFactory)
        {
        }

        protected override void Adapt(IRegion region, StackPanel regionTarget)
        {
            region.Views.CollectionChanged += (s, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (FrameworkElement eNewItem in e.NewItems)
                    {
                        regionTarget.Children.Add(eNewItem);
                    }
                }
            };
        }

        protected override IRegion CreateRegion()
        {
            return new AllActiveRegion();
        }
    }
}
