using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wxAppHelper.ViewModel
{
  public  class HandContactViewModel:BindableBase
    {
        private string _nameProperty;
        public string NameProperty
        {
            get { return _nameProperty; }
            set { SetProperty(ref _nameProperty, value); }
        }

        private string _imageProperty;
        public string ImageProperty
        {
            get { return _imageProperty; }
            set { SetProperty(ref _imageProperty, value); }
        }
    }
}
