using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wxAppHelper.ViewModel
{
    public class HandChatNewestRecordViewModel : BindableBase
    {
        private int _idProperty;
        public int IdProperty
        {
            get { return _idProperty; }
            set { SetProperty(ref _idProperty, value); }
        }

        private int _contactIdProperty;
        public int ContactIdProperty
        {
            get { return _contactIdProperty; }
            set
            {
                SetProperty(ref _contactIdProperty, value);
                var contact = Helper.InitializeData.HandContactData.Where(x => x.IdProperty == ContactIdProperty).FirstOrDefault();
                ContactNameProperty = contact.NameProperty;
                ContactImageProperty = contact.ImageProperty;
            }
        }

        private string _contactNameProperty;
        public string ContactNameProperty
        {
            get { return _contactNameProperty; }
            set { SetProperty(ref _contactNameProperty, value); }
        }

        private string _contactImageProperty;
        public string ContactImageProperty
        {
            get { return _contactImageProperty; }
            set { SetProperty(ref _contactImageProperty, value); }
        }

        private string _contentProperty;
        public string ContentProperty
        {
            get { return _contentProperty; }
            set { SetProperty(ref _contentProperty, value); }
        }

        private DateTime _recordDateTimeProperty;
        public DateTime RecordDateTimeProperty
        {
            get { return _recordDateTimeProperty; }
            set
            {
                SetProperty(ref _recordDateTimeProperty, value);
                StrRecordDateTimeProperty = _recordDateTimeProperty.ToString("hh:ss");
            }
        }

        private string _strRecordDateTimeProperty;
        public string StrRecordDateTimeProperty
        {
            get { return _strRecordDateTimeProperty; }
            set { SetProperty(ref _strRecordDateTimeProperty, value); }
        }
    }
}
