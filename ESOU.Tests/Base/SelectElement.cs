using System;
using System.Collections;
using OpenQA.Selenium;

namespace ESOU.Base
{
    internal class SelectElement
    {
        private IWebElement combobox;

        public SelectElement(IWebElement combobox)
        {
            this.combobox = combobox;
        }

        public IList Options { get; internal set; }
    }
}