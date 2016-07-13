using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UWPBook.P_Calculator_MVVM
{
    public abstract class BaseModel:NotifyPropertyChange
    {
        protected void SetProperty<TProperty>(ref TProperty orign,TProperty newObj,[CallerMemberName]string properName = null)
        {
            if (object.Equals(orign, newObj))
            {
                return;
            }
            orign = newObj;
            if (string.IsNullOrEmpty(properName))
            {
                return;
            }
            OnNotifyPropertyChanged(properName);
        }
    }
}
