
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StickyHeader.Controls
{
    public class CustomCollectionView : CollectionView
    {
        private View _customHeader, _secondContent;

        public CustomCollectionView()
        {
            Scrolled += GoodCollectionView_Scrolled;
        }

        [TypeConverter(typeof(ReferenceTypeConverter))]
        public View CustomHeader
        {
            set
            {
                _customHeader = value;
                _customHeader.SizeChanged += (o, e) => this.Header = new BoxView() { HeightRequest = _customHeader.Height };                
            }
        }

        [TypeConverter(typeof(ReferenceTypeConverter))]
        public View SecondContent
        {
            set => _secondContent = value;
        }

        private async void GoodCollectionView_Scrolled(object sender, ItemsViewScrolledEventArgs e)
        {
            double scrollY = e.VerticalOffset < 0 ? 0 : e.VerticalOffset;
            scrollY = scrollY > _customHeader.Height ? _customHeader.Height : scrollY;

            ////Show or hide the header and scroll the second view
            await Task.WhenAll(_customHeader?.TranslateTo(0, -scrollY, 50), 
                _secondContent?.TranslateTo(0, -scrollY + _customHeader.Height, 50));
        }
    }
}
