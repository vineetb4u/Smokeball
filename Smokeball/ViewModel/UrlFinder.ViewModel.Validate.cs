using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Smokeball
{
    public partial class UrlFinderViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private Dictionary<string, List<string>> propErrors = new Dictionary<string, List<string>>();

        public void Validate()
        {
            //Task.Run(() => DataValidation());
            DataValidation();
        }

        private void DataValidation()
        {
            this.propErrors.Clear();

            if (string.IsNullOrEmpty(SearchKeywords) || string.IsNullOrWhiteSpace(SearchKeywords))
            {
                AddError(nameof(SearchKeywords), "Required", false);
            }

            if (string.IsNullOrEmpty(Url) || string.IsNullOrWhiteSpace(Url))
            {
                AddError(nameof(Url), "Required", false);
            }
            else if (!isValidUrl())
            {
                AddError(nameof(Url), "Invalid Url", false);
            }
        }

        private bool isValidUrl()
        {
            return Uri.TryCreate(Url, UriKind.Absolute, out Uri uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }

        private void AddError(string propertyName, string error, bool isWarning)
        {
            if (!this.propErrors.ContainsKey(propertyName))
            {
                this.propErrors[propertyName] = new List<string>();
            }

            if (!this.propErrors[propertyName].Contains(error))
            {
                this.propErrors[propertyName].Insert(0, error);
                OnPropertyErrorsChanged(propertyName);
            }
        }

        #region INotifyDataErrorInfo

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        private void OnPropertyErrorsChanged(string p)
        {
            if (ErrorsChanged != null)
                ErrorsChanged.Invoke(this, new DataErrorsChangedEventArgs(p));
        }

        public IEnumerable GetErrors(string propertyName)
        {
            List<string> errors = new List<string>();
            if (propertyName != null)
            {
                propErrors.TryGetValue(propertyName, out errors);
                return errors;
            }

            else
                return null;
        }

        public bool HasErrors
        {
            get
            {
                try
                {
                    var propErrorsCount = propErrors.Values.FirstOrDefault(r => r.Count > 0);
                    if (propErrorsCount != null)
                        return true;
                    else
                        return false;
                }
                catch { }
                return true;
            }
        }

        # endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
                Validate();
                
            }
        }

        #endregion
    }

}
