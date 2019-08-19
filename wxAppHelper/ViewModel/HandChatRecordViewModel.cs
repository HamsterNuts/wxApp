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
        public HandChatRecordViewModel()
        {
            //FlowDirectionProperty = "RightToLeft";
        }
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
            set { SetProperty(ref _sourceIdProperty, value);
                SourceImageProperty = wxAppHelper.Helper.InitializeData.HandContactData.Where(x => x.IdProperty == value).FirstOrDefault().ImageProperty;
                FlowDirectionProperty = (SourceIdProperty == wxAppHelper.Helper.InitializeData.TheCurrentUserId) ? "RightToLeft" : "LeftToRight";
            }
        }

        private int _targetIdProperty;
        public int TargetIdProperty
        {
            get { return _targetIdProperty; }
            set {
                SetProperty(ref _targetIdProperty, value);
            }
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

        private string _sourceImageProperty;
        public string SourceImageProperty
        {
            get { return _sourceImageProperty; }
            set { SetProperty(ref _sourceImageProperty, value); }
        }
        private string _flowDirectionProperty;
        public string FlowDirectionProperty
        {
            get { return _flowDirectionProperty; }
            set { SetProperty(ref _flowDirectionProperty, value); }
        }
    }
}
