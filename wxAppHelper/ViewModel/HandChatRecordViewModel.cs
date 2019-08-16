using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wxAppHelper.ViewModel
{
    public class HandChatRecordViewModel : BindableBase
    {
        private int _idProperty;
        public int IdProperty
        {
            get { return _idProperty; }
            set { SetProperty(ref _idProperty, value); }
        }

        private int _sourceIdProperty;
        public int SourceIdProperty
        {
            get { return _sourceIdProperty; }
            set { SetProperty(ref _sourceIdProperty, value); }
        }

        private int _targetIdProperty;
        public int TargetIdProperty
        {
            get { return _targetIdProperty; }
            set { SetProperty(ref _targetIdProperty, value); }
        }

        private string _contentProperty;
        public string ContentProperty
        {
            get { return _contentProperty; }
            set { SetProperty(ref _contentProperty, value); }
        }

        private DateTime _recordDateTime;
        public DateTime RecordDateTime
        {
            get { return _recordDateTime; }
            set { SetProperty(ref _recordDateTime, value); }
        }
    }
}
