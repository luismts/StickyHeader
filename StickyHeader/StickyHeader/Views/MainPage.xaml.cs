using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StickyHeader.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            // Here you can know the height of your control
        }

        private void btn1_Clicked(object sender, EventArgs e)
        {
            collectionView.IsVisible = true;
            labelView.IsVisible = false;
        }

        private void btn2_Clicked(object sender, EventArgs e)
        {
            collectionView.IsVisible = false;
            labelView.IsVisible = true;
        }
    }
}
