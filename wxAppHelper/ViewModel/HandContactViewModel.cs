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
        private int _idProperty;
        public int IdProperty
        {
            get { return _idProperty; }
            set { SetProperty(ref _idProperty, value); }
        }
        //name
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

        private int _sexProperty;
        public int SexProperty
        {
            get { return _sexProperty; }
            set { SetProperty(ref _sexProperty, value); }
        }
        private string _signatureProperty;
        public string SignatureProperty
        {
            get { return _signatureProperty; }
            set { SetProperty(ref _signatureProperty, value); }
        }
        private string _noteProperty;
        public string NoteProperty
        {
            get { return _noteProperty; }
            set { SetProperty(ref _noteProperty, value); }
        }
        private string _wxNumberProperty;
        public string WxNumberProperty
        {
            get { return _wxNumberProperty; }
            set { SetProperty(ref _wxNumberProperty, value); }
        }
        private string _sourceProperty;
        public string SourceProperty
        {
            get { return _sourceProperty; }
            set { SetProperty(ref _sourceProperty, value); }
        }
        private string _addressProperty;
        public string AddressProperty
        {
            get { return _addressProperty; }
            set { SetProperty(ref _addressProperty, value); }
        }
        
    }
}
