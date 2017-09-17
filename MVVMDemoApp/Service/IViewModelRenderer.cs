﻿using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemoApp.Service
{
    public interface IViewModelRenderer
    {
        void RenderViewModel<T>() where T : ViewModelBase;
    }
}
